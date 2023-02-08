using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniValidation;
using ProyPV.DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProyectoProgra5Context>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
});


    var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
    .WithName("GetWeatherForecast");


app.MapPost("/ParametrosSensibilidad", async ([FromBody] ParametrosSensibilidad para, ProyectoProgra5Context context) =>
{
    try
    {
        if (!MiniValidator.TryValidate(para, out var errors))
        {
            return Results.BadRequest(new { codigo = -2, mensaje = "Datos Incorrectos", errores = errors });
        }
        await context.ParametrosSensibilidads.AddAsync(para);
        await context.SaveChangesAsync();
        context.Entry(para).Reference(para => para.IdServidorNavigation).Load();
        return Results.Created($"/ParametrosSensibilidad/{para.NombreParametro}{para.IdServidor}",
 new
 {
     codigo = 0,
     mensaje = "Creacion Exitosa",
     para = para,
     //nombreEstado = cliente.EstadoNavigation!.Nombre
 });
    }
    catch (Exception exc)
    {
        throw new Exception(exc.InnerException.ToString());
        return Results.Json(new
        {
            codigo = -1,
            mensaje = exc.Message
        },
    statusCode: StatusCodes.Status500InternalServerError);
    }
});


app.Run();
internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}