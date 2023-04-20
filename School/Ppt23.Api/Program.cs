using Ppt23.Shared;

var builder = WebApplication.CreateBuilder(args);

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


/* var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{

    var allowedOrigins = builder.Configuration["AllowedOrigins"];
    if (allowedOrigins != null)
    {
        options.AddPolicy(MyAllowSpecificOrigins,
                        policy =>
                        {
                            policy.WithOrigins(allowedOrigins)
                                .AllowAnyHeader()
                                .WithMethods("DELETE", "GET", "PUT", "POST");
                        });
    }
}); */


var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



List<EquipmentVm> list = EquipmentVm.RtnRndList(10);
List<RevisionVm> list1 = RevisionVm.GenerateRandomRevisions(10);


//get the list
app.MapGet("/hospital-equipment", () =>
{
    return list;
});


app.MapGet("/revision/{SearchText}", (string SearchText) =>
{
    return list1.Where(revision => revision.Name.Contains(SearchText)).ToList();
});

//new item in list, with Id
app.MapPost("/hospital-equipment", (EquipmentVm equipment) =>
{
    equipment.Id = Guid.NewGuid();
    list.Insert(0, equipment);
    return Results.Created($"/hospital-equipment/{equipment.Id}", equipment);
});

//delete item from list, need Id
app.MapDelete("/hospital-equipment/{Id}", (Guid Id) =>
{
    var item = list.SingleOrDefault(x => x.Id == Id);
    if (item == null)
        return Results.NotFound("This Item cannot be found!");
    list.Remove(item);
    return Results.Ok();
}
);

//edit item in list, need Id
app.MapPut("/hospital-equipment/{Id}", (Guid Id, EquipmentVm updatedEquipment) =>
{
    var item = list.SingleOrDefault(x => x.Id == Id);
    if (item == null)
    {
        return Results.NotFound("This item cannot be found!");
    }
    else
    {
        updatedEquipment.Id = Id; //same Id
        list.Remove(item);
        list.Insert(0, updatedEquipment);
        return Results.Ok();
    }
});

//get only specific item from list, need Id
app.MapGet("/hospital-equipment/{Id}", (Guid Id) =>
{
    var item = list.SingleOrDefault(x => x.Id == Id);
    if (item == null)
        return Results.NotFound($"Equipment with Id {Id} not found!");
    return Results.Ok(item);
});


app.Run();

