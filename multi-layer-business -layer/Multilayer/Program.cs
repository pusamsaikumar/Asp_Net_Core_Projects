using Employee.Common.Utilities;
using Employee.Repositories;
using Employee.Repositories.Interfaces;
using Employee.Service;
using Employee.Service.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string[] assemblyNames =
{
    "Multilayer",
    "Employee.Common",
    "Employee.Repositories",
    "Employee.Service"
};



builder.Services.RegisterClassOnMactchingNames(assemblyNames);
    //builder.Services.AddScoped<IEmployeeService, EmployeeService >();
    //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


    var app = builder.Build();
app.UseCors(x => x .AllowAnyMethod() .AllowAnyHeader()  );

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
