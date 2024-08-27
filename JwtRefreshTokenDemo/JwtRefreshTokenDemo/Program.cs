using JwtRefreshTokenDemo;

var builder = WebApplication.CreateBuilder(args);

var startUp = new StartUp(builder.Configuration, builder.Environment);

// calling configure services
startUp.ConfigureServices(builder.Services);

var app = builder.Build();

// calling Configure Method
startUp.Configure(app, builder.Environment);


//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

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

