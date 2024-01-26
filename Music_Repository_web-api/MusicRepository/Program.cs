using Microsoft.EntityFrameworkCore;
using MusicRepository.Data.MusicRepository;
using MusicRepository.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// register with dbcontext
builder.Services.AddDbContext<MusicDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MusicApiContext")));

// register with MusicRepository
builder.Services.AddScoped<IMusicService, MusicService>();

// register with automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
