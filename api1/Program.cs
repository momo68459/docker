using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/Customers", () =>
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    
    return db.Customers.ToList();
});

app.MapGet("/Customers/{id}", (int id) =>
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    
    return db.Customers.Find(id);
});

app.MapPost("/Customers", (Customer obj) =>
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    db.Customers.Add(obj);
    db.SaveChanges();
    return obj;
});

app.MapPut("/Customers/{id}", (int id, Customer obj) =>
{
    obj.CustomerID = id;

    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();

    db.Customers.Update(obj);
    db.SaveChanges();
    return obj;
});

app.MapDelete("/Customers/{id}", (int id) =>
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();

    var obj = db.Customers.Find(id);
    db.Customers.Remove(obj!);
    db.SaveChanges();
    return obj;
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
