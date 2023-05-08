using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ppt23.Api.Data;
using Ppt23.Shared;

var builder = WebApplication.CreateBuilder(args);


string sqliteDbPath = builder.Configuration.GetValue<string>("sqliteDbPath");
if (string.IsNullOrEmpty(sqliteDbPath))
{
    throw new ArgumentNullException(nameof(sqliteDbPath));
}

builder.Services.AddDbContext<PptDbContext>(opt => opt.UseSqlite("FileName=Hospital.db")); 

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
app.MapGet("/hospital-equipment", (PptDbContext _db) =>
{
    var equipmentList = _db.Equipment.ToList();
    var equipmentVmList = equipmentList.Adapt<List<EquipmentVm>>();
    return equipmentVmList;
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
    _db.Equipment.Add(equipment);
    _db.SaveChanges();
    return Results.Created($"/hospital-equipment/{equipment.Id}", equipment.Adapt<EquipmentVm>());
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
    var item = _db.Equipment.SingleOrDefault(x => x.Id == Id);
    if (item == null)
    {
        return Results.NotFound("This item cannot be found!");
    }
    else
    {
        updatedEquipment.Id = Id; //same Id
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
    return Results.Ok(equipmentVm);
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

app.Run();

