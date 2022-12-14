using _02___Application.Contracts;
using _02___Application.DI;
using _02___Application.Services;

using _03___Infrastructure.DBContexts;
using _03___Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeDBContext>(p => p.UseSqlServer(configuration.GetConnectionString("DataContext")));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IDBContext, EmployeeDBContext>();
builder.Services.AddApplicationCore();

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
