


using Application.Core;
using Microsoft.AspNetCore.Diagnostics;
using Persistence.EF;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Loading configuration for persistence
builder.Services.AddPersistenceService(builder.Configuration);
//Loading configuration for Application
builder.Services.AddTaskApplication();

var app = builder.Build();


// Configure the HTTP request pipeline.
 // we want swagger in production its only test purpose 
 app.UseSwagger();
 app.UseSwaggerUI();

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
        .Get<IExceptionHandlerPathFeature>()
        .Error;
    var response = new { error = exception.Message };
    await context.Response.WriteAsJsonAsync(response);
}));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
