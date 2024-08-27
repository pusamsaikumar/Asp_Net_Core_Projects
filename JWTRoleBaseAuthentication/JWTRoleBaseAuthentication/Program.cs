using JWTRoleBaseAuthentication;

var builder = WebApplication.CreateBuilder(args);

var startup = new StartUp(builder.Configuration, builder.Environment);

// calling configure services
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// calling configure method:
startup.Configure(app, builder.Environment);

