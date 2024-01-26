using Amazon.S3;
using BusinessLogicLayer;
using CommonLayer.Models;

//using CommonLayer.Middlewares;
using DataAccessLayer.Entities;



using DataAccessLayer.Interfaces;
using DataAccessLayer.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Text;

namespace StudentThreeTier
{
    public class StartUp
    {
        //private readonly IConfiguration _configuration;
        public IConfiguration configRoot { get; set; }  

        // constructor
        public StartUp(IConfiguration configuration)
        {
           configRoot = configuration;
            
        }
     

      


        // load jsonfile
 
     
        // configure services
        public void ConfigureServices(IServiceCollection services)
        {
            
          
          //  services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen();

            // add xml data serialier AddXmlSerializerFormatters()
           // services.AddControllers().AddXmlDataContractSerializerFormatters();
            services.AddControllers().AddXmlSerializerFormatters();


            services.AddControllers().AddNewtonsoftJson(
                
                options => 
                options.SerializerSettings.ReferenceLoopHandling =Newtonsoft.Json.ReferenceLoopHandling.Ignore

                );

            // Pagination 
            services.AddScoped<IPaginationRepo, PaginationRepo>();  
            services.AddScoped<IPaginationService, PaginationService>();

            // dependeny injections
            services.AddScoped<IStudentRepository , StudentRepository>();
            services.AddScoped<IStudentyService,StudentService>();
            services.AddScoped<IEmployeeRepository , EmployeeRepository>(); 
            services.AddScoped<IEmployeeService , EmployeeService>();
            // transient service
            services.AddTransient<ITransientService , TaskService>();
            services.AddTransient<ITransientRepository, TaskRepository>();
            // scoped service
            services.AddScoped<IScopedService , TaskService>();
            services.AddTransient<IScopedRepository, TaskRepository>();

            // singleton service
            services.AddSingleton<ISingleTonService , TaskService>();
            services.AddTransient<ISingleTonRepository, TaskRepository>();
            
            // configure 
            services.AddOptions();
            services.Configure<AppSettings>(configRoot.GetSection("AppSettings"));
           
            services.Configure<ApiSettingsInfo>(configRoot.GetSection("ApiSettingsInfo"));
            
            services.Configure<ConnectionStrings>(configRoot.GetSection("ConnectionStrings"));

            services.Configure<Database>(configRoot.GetSection("Database"));

            // jwt
            services.Configure<JWT>(configRoot.GetSection("JWT"));

            // login auth 
            services.AddScoped<ILoginAuthRepo , LoginAuthRepo>();
            services.AddScoped<ILoginAuthService , LoginAuthService>();

            // add error handling exceptions here for method3
            services.AddTransient<GlobalExceptionHandlingMiddleware>();


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.AddAWSLambdaHosting(LambdaEventSource.RestApi);
            // services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

            // add data protection for encrypt and decrypt:
            services.AddDataProtection();

            // read the key from AppSettings:
            var appSettingsread = configRoot.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsread);

            // jwt authentication:
            var settings = appSettingsread.Get<AppSettings>();
            var secret = Encoding.UTF8.GetBytes(settings.Key);

            // jwt authentication:
             
            // default:
            var key = configRoot["AppSettings:Key"] ?? throw new InvalidProgramException("Secret key not configured");

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // configure authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddCookie(options =>
                options.Cookie.Name = "token"
                )
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters

                    {

                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        // ClockSkew = TimeSpan.Zero,
                        ClockSkew = new TimeSpan(0, 0, 5),
                        ValidAudience = configRoot["JWT:ValidAudience"],
                        ValidIssuer = configRoot["JWT:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(secret),

                        //ValidateIssuerSigningKey = true,
                        //IssuerSigningKey = new SymmetricSecurityKey(secret),
                        //ValidateIssuer = false,
                        //ValidateAudience = false
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["token"];
                            return Task.CompletedTask;
                        }
                    };

                });

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description="Please enter Bearer Jwt Token",
                    Name="Authorization",
                    Type = SecuritySchemeType.ApiKey

                });
                var scheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { scheme,Array.Empty<string>() } });
            });

            // add cors
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        // policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                        policy.WithOrigins("http://localhost:3000/").AllowAnyHeader().AllowAnyMethod();
                    });
            });



            // session storage:
            // services.AddMvc().AddSessionStateTempDataProvider();
            services.AddDistributedMemoryCache();



            services.AddSession(options =>
            {

                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // add service add memory cache
            services.AddMemoryCache();

            // aws connection s3 bucket
            services.AddDefaultAWSOptions(configRoot.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();

        }
        // configure http request pipeline

        
public void Configure(WebApplication app,IWebHostEnvironment env)
        {
           
           app.UseSession();

            app.UseRouting();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // raise exception handlers: Global 

            //app.UseExceptionHandler(options =>
            //{

            //    options.Run(async context =>
            //    {
            //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //        var ex = context.Features.Get<IExceptionHandlerFeature>();
            //        if (ex != null)
            //        {
            //            await context.Response.WriteAsync(ex.Error.Message);
            //        }
            //    });
            //});


            // method: HttpRequestErrorHandling middleware
            //app.Use(async (context, next) =>
            //{
            //    try
            //    {
            //        await next(context);
            //    }
            //    catch (Exception ex)
            //    {
            //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //        if(ex.InnerException != null)
            //        {
            //            await context.Response.WriteAsync(ex.Message);
            //        }
            //    }


            //});

            // use middleware for error handling
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            // add cors 
            app.UseCors(c=>c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.UseHttpsRedirection();

            // we have to must use for JWt authentication  app.UseAuthentication();
            app.UseAuthentication();
            app.UseAuthorization();

          

            app.MapControllers();
            app.Run();
        }
    }
    
}
