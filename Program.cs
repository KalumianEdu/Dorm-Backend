using DormAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DormAPI.Database.EF.Contexts;
using DormAPI.Database.Ado.Repositories;
using DormAPI.Database.Ado.Common;

var builder = WebApplication.CreateBuilder(args);



// 1. Read connection string and register DbContext with DI container 
builder.Services.AddDbContext<DormContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
);




// Test 


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAntiforgery();

// Add clsExternalLayer to DI container
builder.Services.AddScoped<clsExternalLayer>();
builder.Services.AddScoped<EmployeeRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAntiforgery();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
