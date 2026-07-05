using System;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

if (Environment.GetEnvironmentVariable("WAIT_FOR_DEBUGGER") == "true")
{
    Console.WriteLine($"Waiting for debugger — PID {Environment.ProcessId}. Attach and then set WAIT_FOR_DEBUGGER=false or send SIGUSR1.");
    while (!System.Diagnostics.Debugger.IsAttached)
        Thread.Sleep(100);
    Console.WriteLine("Debugger attached.");
}

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "wwwroot",
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}