using ApiExample1.Controllers;
using Business.Logic;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<EmployeeModuleLogic>();
builder.Services.AddTransient<EmployeeModuleRepo>();
builder.Services.AddTransient<EmployeeModel>();
builder.Services.AddTransient<DataContext>();
builder.Services.AddTransient<ProjectModel>();
builder.Services.AddTransient<ProjectModuleLogic>();
builder.Services.AddTransient<projectModuleRepo>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
