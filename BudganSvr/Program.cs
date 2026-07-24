using System;
using System.Threading;
using BudganInfra;
using BudganInfra.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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

Console.WriteLine($"Environment: {builder.Environment.IsDevelopment()}");

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    var connString = dbContext.Database.GetConnectionString();

    scope.ServiceProvider.GetRequiredService<DataContext>().Database.Migrate();
}

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
