using EmployeeStorePROC.Data;
using EmployeeStorePROC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register dbcontext
builder.Services.AddDbContext<EmployeeStoreProcDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

// register IEmployeeRepository
builder.Services.AddScoped<IEmployeeRepository , EmployeeRepository>();
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
