using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ppt23.Api.Data;
using Ppt23.Shared;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);


string sqliteDbPath = builder.Configuration.GetValue<string>("sqliteDbPath");
if (string.IsNullOrEmpty(sqliteDbPath))
{
    throw new ArgumentNullException(nameof(sqliteDbPath));
}

builder.Services.AddDbContext<PptDbContext>(opt => opt.UseSqlite($"FileName={sqliteDbPath}"));
builder.Services.AddScoped<SeedingData>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(corsOptions => corsOptions.AddDefaultPolicy(policy =>
{
    policy.WithOrigins(builder.Configuration["AllowedOrigins"])
        .AllowAnyHeader()
        .WithMethods("DELETE", "GET", "PUT", "POST");
}));


var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hellou");

//get the list
app.MapGet("/hospital-equipment", (PptDbContext db) =>
{
    var equipmentList = db.Equipment.ToList();
    var equipmentVmList = new List<EquipmentVm>();
    foreach (var equipment in equipmentList)
    {
        var lastRevision = db.Revisions
            .Where(r => r.EquipmentId == equipment.Id)
            .OrderByDescending(r => r.DateTime)
            .FirstOrDefault();
        var equipmentVm = equipment.Adapt<EquipmentVm>();
        equipmentVm.LastRevisionDate = lastRevision?.DateTime;
        equipmentVmList.Add(equipmentVm);
    }
    return equipmentVmList;
});

app.MapGet("/equipment/{equipmentId}/actions", (Guid equipmentId, PptDbContext dbContext) =>
{
    var actions = dbContext.Actions
        .Include(a => a.Worker) // Include the Worker entity
        .Where(a => a.EquipmentID == equipmentId)
        .ToList();

    var actionViewModels = actions.Select(a => new ActionVm
    {
        Id = a.Id,
        Code = a.Code,
        Name = a.Name,
        DateTime = a.DateTime,
        Description = a.Description,
        WorkerName = a.Worker?.Name ?? string.Empty // Get the Worker's name or an empty string if the Worker is null
    }).ToList();

    return Results.Ok(actionViewModels);
});




//revision
app.MapGet("/revision/{SearchText}", (string SearchText, PptDbContext db) =>
{
    var list1 = db.Revisions.ToList();
    var revisions = list1.Where(r => r.Name.Contains(SearchText)).Adapt<List<RevisionVm>>();
    return Results.Ok(revisions);
});


//new item in list, with Id
app.MapPost("/hospital-equipment", (EquipmentVm equipmentVm, PptDbContext _db) =>
{
    var equipment = equipmentVm.Adapt<Equipment>();
    equipment.Id = Guid.Empty;
    var lastRevisionDate = equipmentVm.LastRevisionDate ?? DateTime.Now;

    // Create the first revision with the same name as the equipment
    var revision = new Revision
    {
        Name = $"{equipment.Name} Revision",
        DateTime = lastRevisionDate
    };
    equipment.Revisions.Add(revision);

    _db.Equipment.Add(equipment);
    _db.SaveChanges();

    return Results.Created($"/hospital-equipment/{equipment.Id}", equipment.Adapt<EquipmentVm>());
});

app.MapPost("/seed", (PptDbContext _db) =>
{
    // Step 1: Generate 10 random workers
    List<Worker> generatedWorkers = new List<Worker>();
    Random random = new Random();

    for (int i = 0; i < 10; i++)
    {
        Worker worker = new Worker
        {
            Name = Worker.GenerateRandomName(),
            JobTitle = Worker.GenerateRandomJobTitle()
        };

        generatedWorkers.Add(worker);
        _db.Workers.Add(worker);
    }

    _db.SaveChanges();

    // Step 2: Retrieve all equipment instances from the database
    List<Equipment> equipments = _db.Equipment.ToList();

    // Create a list to store the generated action view models
    List<ActionVm> generatedActions = new List<ActionVm>();

    foreach (Equipment equipment in equipments)
    {
        // Step 3: Create 5 to 20 random actions for each equipment
        int numActions = random.Next(5, 21);
        var actions = generatedWorkers.Select(worker => worker.Id).ToList();

        for (int i = 0; i < numActions; i++)
        {
            Ppt23.Api.Data.Action action = new Ppt23.Api.Data.Action
            {
                Name = Ppt23.Api.Data.Action.GenerateRandomName(),
                Code = Ppt23.Api.Data.Action.GenerateRandomCode(),
                Description = Ppt23.Api.Data.Action.GenerateRandomDescription(),
                DateTime = Ppt23.Api.Data.Action.GenerateRandomDateTime(),
                EquipmentID = equipment.Id
            };

            if (i < actions.Count)
            {
                action.WorkerID = actions[i];
            }

            _db.Actions.Add(action);

            // Convert the Action to ActionVm and add it to the generatedActions list
            ActionVm actionVm = new ActionVm
            {
                Id = action.Id,
                Code = action.Code,
                Name = action.Name,
                DateTime = action.DateTime,
                Description = action.Description,
                WorkerName = generatedWorkers.FirstOrDefault(w => w.Id == action.WorkerID)?.Name ?? string.Empty
            };

            generatedActions.Add(actionVm);
        }
    }

    _db.SaveChanges();

    return Results.Ok(generatedActions);
});


app.MapPatch("/action/{id:guid}/removeworker", (Guid id, PptDbContext _db) =>
{
    var action = _db.Actions.FirstOrDefault(a => a.Id == id);

    if (action == null)
    {
        return Results.NotFound();
    }

    // Remove the worker from the action
    action.WorkerID = Guid.Empty;

    _db.SaveChanges();

    return Results.Ok();
});



app.MapPost("/revision", (PptDbContext db, EquipmentVm item) =>
{
    Revision rev = new();
    rev.Id = Guid.Empty;
    rev.Name = $"{item.Name} Revision";
    rev.DateTime = DateTime.Now;
    rev.EquipmentId = item.Id;
    db.Revisions.Add(rev);
    db.SaveChanges();
    return Results.Ok();
});
//delete item from list, need Id
app.MapDelete("/hospital-equipment/{Id}", (Guid Id, PptDbContext _db) =>
{
    var item = _db.Equipment.SingleOrDefault(x => x.Id == Id);
    if (item == null)
        return Results.NotFound("This Item cannot be found!");
    _db.Equipment.Remove(item);
    _db.SaveChanges();
    return Results.Ok();
});


//edit item in list, need Id
app.MapPut("/hospital-equipment/{Id}", (Guid Id, EquipmentVm updatedEquipment, PptDbContext _db) =>
{
    var item = _db.Equipment.Include(e => e.Revisions).SingleOrDefault(x => x.Id == Id);
    if (item == null)
    {
        return Results.NotFound("This item cannot be found!");
    }
    else
    {
        // Update the last revision
        var lastRevision = item.Revisions.LastOrDefault();
        if (lastRevision != null)
        {
            lastRevision.DateTime = updatedEquipment.LastRevisionDate ?? lastRevision.DateTime;
        }

        // Update other properties of the equipment
        updatedEquipment.Id = Id;
        var en = updatedEquipment.Adapt<Equipment>();
        _db.Entry(item).CurrentValues.SetValues(en);
        _db.SaveChanges();

        return Results.Ok();
    }
});


//get only specific item from list, need Id
app.MapGet("/hospital-equipment/{Id}", (Guid Id, PptDbContext _db) =>
{
    var item = _db.Equipment.SingleOrDefault(x => x.Id == Id);
    if (item == null)
        return Results.NotFound($"Equipment with Id {Id} not found!");
    var equipmentVm = item.Adapt<EquipmentVm>();

    var revisions = _db.Revisions.Where(x => x.EquipmentId == Id).ToList();
    var revisionVms = revisions.Select(x => x.Adapt<RevisionVm>()).ToList();

    var equipmentWithRevisionsVm = equipmentVm.Adapt<EquipmentWithRevisionsVm>();
    equipmentWithRevisionsVm.Revisions = revisionVms;

    return Results.Ok(equipmentWithRevisionsVm);
});



using var appContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<PptDbContext>();
try
{
    appContext.Database.Migrate();
}
catch (Exception ex)
{
    Console.WriteLine($"Exception during db migration {ex.Message}");
}

await app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingData>().SeedData();

app.Run();

