using BasketProject;
using BasketProject.Data;
using BasketProject.Repository;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);



var startup = new StartUp(builder.Configuration, builder.Environment);
startup.ConfigureServices(builder.Services);


var app = builder.Build();

startup.Configure(app, builder.Environment);


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// add connection string 
//builder.Services.AddDbContext<BasketDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BasketDBCon")));

//// add repository
//builder.Services.AddScoped<IBasketRepository, BasketRepository>();  

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
