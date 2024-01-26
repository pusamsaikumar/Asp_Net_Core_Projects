using BusinessLogicLayer;

using DataAccessLayer.Interfaces;
using StudentThreeTier;

var builder = WebApplication.CreateBuilder(args);

var startup = new StartUp(builder.Configuration);

// calling configure services
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// calling configure method:
startup.Configure(app, builder.Environment);







 /* Program.cs */

//// Add services to the container.

//builder.Services.AddControllers();
//// add xml
//builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IStudentRepository,StudentRepository>();
//builder.Services.AddScoped<IStudentyService, StudentService>();
//builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository >();
//builder.Services.AddScoped<IEmployeeService, EmployeeService >();   
//// configure

//builder.Services.AddOptions();
//builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
//builder.Services.Configure<ApiSettingsInfo>(builder.Configuration.GetSection("ApiSettingsInfo"));
//builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));

//var app = builder.Build();
//app.UseCors(c=>c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

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
 