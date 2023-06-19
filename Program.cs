using AutoMapper;
using Dataflow.Data;
using Dataflow.Dtos;
using Dataflow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Dataflow.Services;
using Dataflow.Services.CategoryService;
using Dataflow.Services.ContactService;
using Dataflow.Services.ProductService;
using Dataflow.Services.TodoService;
using Dataflow.Services.TodosService;
using Dataflow.Services.UserService;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "Data Source=Dataflow.db";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var contextOptions = new DbContextOptionsBuilder<DataflowContext>()
    .UseSqlite(connectionString)
    .Options;

builder.Services.AddDbContext<DataflowContext>(options =>
{
    options.UseSqlite(connectionString);
});

using (var context = new DataflowContext(contextOptions))
{
    context.Database.EnsureCreated();
    context.SeedData();
}

// Register services
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();



var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataflowContext>();
    context.Database.Migrate();
    context.SeedData();
}

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