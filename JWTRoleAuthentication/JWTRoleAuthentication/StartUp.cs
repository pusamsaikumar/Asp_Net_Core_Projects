using JWTRoleAuthentication.CommonLayer.Models;
using JWTRoleAuthentication.Controllers;
using JWTRoleAuthentication.JWTBLL;
using JWTRoleAuthentication.JWTDAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Text;

namespace JWTRoleAuthentication
{
    //public class StartUp
    //{

    //    //private readonly IConfiguration _configuration;
    //    public IConfiguration configRoot { get; set; }

    //    // constructor
    //    public StartUp(IConfiguration configuration)
    //    {
    //        configRoot = configuration;

    //    }
    //    // configure services
    //    public  void ConfigureServices(IServiceCollection services)
    //    {
    //        // ConfigJsonFiles












    //        // dependeny injections
    //        services.AddScoped<IAuthRepo, AuthRepo>();
    //        services.AddScoped<IAuthService, AuthService>();
    //        services.AddScoped<ITokenService, TokenService>();
    //        services.AddScoped<Helpers>();








    //        // configure 
    //        services.AddOptions();
    //        services.Configure<AppSettings>(configRoot.GetSection("AppSettings"));



    //        services.Configure<ConnectionStrings>(configRoot.GetSection("ConnectionStrings"));

    //        services.Configure<JWT>(configRoot.GetSection("JWT"));



    //        // login auth 

    //        // wcf service
    //        //  services.AddScoped<IService,ServiceClient>();

    //        // add error handling exceptions here for method3



    //        services.AddCors(options =>
    //        {
    //            options.AddDefaultPolicy(
    //                policy =>
    //                {
    //                    policy.AllowAnyOrigin()
    //                        .AllowAnyHeader()
    //                        .AllowAnyMethod();
    //                });
    //        });


    //        // add data protection for encrypt and decrypt:
    //        services.AddDataProtection();


    //        // jwt authentication:

    //        // default:


    //        var appSettingsread = configRoot.GetSection("AppSettings");
    //        services.Configure<AppSettings>(appSettingsread);

    //        // jwt authentication:
    //        var settings = appSettingsread.Get<AppSettings>();
    //        var secret = Encoding.UTF8.GetBytes(settings.Key);

    //        // jwt authentication:

    //        // default:
    //        var key = configRoot["AppSettings:Key"] ?? throw new InvalidProgramException("Secret key not configured");

    //        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


    //        // JWT Configuration

    //        services.AddAuthentication(options =>
    //        {
    //            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //        })
    //        .AddJwtBearer(options =>
    //        {
    //            options.RequireHttpsMetadata = false; // Change this to true in production
    //            options.SaveToken = true;
    //            options.TokenValidationParameters = new TokenValidationParameters
    //            {
    //                ValidateIssuerSigningKey = true,
    //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configRoot["JWT:Secret"])),
    //                ValidateIssuer = true, // Ensure these values are set appropriately
    //                ValidateAudience = true,
    //                ValidIssuer = configRoot["JWT:ValidAudience"],
    //                ValidAudience = configRoot["JWT:ValidAudience"]


    //            };
    //        });

    //        // Add authorization policies
    //        services.AddAuthorization(options =>
    //        {
    //            options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    //            options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
    //            // Add more policies as needed
    //        });





    //        services.AddSwaggerGen(options =>
    //        {
    //            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //            {
    //                In = ParameterLocation.Header,
    //                Description = "Please enter Bearer Jwt Token",
    //                Name = "Authorization",
    //                Type = SecuritySchemeType.ApiKey

    //            });
    //            var scheme = new OpenApiSecurityScheme
    //            {
    //                Reference = new OpenApiReference
    //                {
    //                    Type = ReferenceType.SecurityScheme,
    //                    Id = "Bearer"
    //                }
    //            };
    //            options.AddSecurityRequirement(new OpenApiSecurityRequirement { { scheme, Array.Empty<string>() } });
    //        });

    //        services.AddMvc();
    //        services.AddControllers();
    //        services.AddSwaggerGen();

    //        services.AddHttpContextAccessor();

    //        // add cors
    //        //services.AddCors(options =>
    //        //{
    //        //    options.AddDefaultPolicy(
    //        //        policy =>
    //        //        {
    //        //            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    //        //           // policy.WithOrigins("http://localhost:3000/").AllowAnyHeader().AllowAnyMethod();
    //        //        });
    //        //});



    //        // session storage:
    //        // services.AddMvc().AddSessionStateTempDataProvider();
    //        services.AddDistributedMemoryCache();



    //        services.AddSession(options =>
    //        {

    //            options.IdleTimeout = TimeSpan.FromSeconds(60);
    //            options.Cookie.HttpOnly = true;
    //            options.Cookie.IsEssential = true;
    //        });

    //        // add service add memory cache

    //        // configure http request pipeline




    //    }

    //    public void Configure(WebApplication app, IWebHostEnvironment env)
    //    {

    //        if (app.Environment.IsDevelopment())
    //        {
    //            app.UseSwagger();
    //            app.UseSwaggerUI();
    //        }


    //        // add cors 
    //        //app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

    //        app.UseHttpsRedirection();

    //        // we have to must use for JWt authentication  app.UseAuthentication();

    //        app.UseAuthentication();
    //        app.UseAuthorization();



    //        app.MapControllers();
    //        app.Run();
    //    }
    //}

    public class StartUp
    {
        private readonly IWebHostEnvironment _env;

        public IConfiguration Configuration { get; }
       

        public StartUp(IConfiguration configuration, IWebHostEnvironment env )
        {
            Configuration = configuration;
           _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // read jsonfile config:
            // ConfigJsonFiles



            var path = Path.Combine(Environment.CurrentDirectory, @"JSONFiles\");

            // // for RSAClient.json
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(path)
            .AddJsonFile("RSAClientData.json")
            .AddJsonFile("Applied.json")
            .Build();

           
            var rSAClients = config.GetSection("RSAClientData").Get<List<RSAClient>>();
            var coupons = config.GetSection("NewApplied").Get<List<Coupon>>();  


            // // Register the list of items as a singleton
            services.AddSingleton(rSAClients);
            services.AddSingleton(coupons);

            // // configure json data
            // //services.Configure<RSAClientData>(config);
            // //services.Configure<List<RSAClient>>(configRoot.GetSection("RSAClient"));





            // // Users.json
            // IConfiguration usersCongfig = new ConfigurationBuilder()
            //.SetBasePath(path)
            //.AddJsonFile("Users.json").Build();

            // var users = usersCongfig.GetSection("UsersData").Get<List<User>>();

            // services.AddSingleton(users);



            // dependeny injections
            services.AddScoped<IAuthRepo, AuthRepo>();
            services.AddScoped<IAuthService, AuthService>();
             services.AddScoped<ITokenService, TokenService>();
             services.AddScoped<Helpers>();
             services.AddScoped<CustomerDAL>();
             services.AddScoped<CustomerService>();
             services.AddScoped<ValidationHelper>();
             services.AddScoped<IFileRepo, FileRepo>();
            services.AddScoped<IFileService, FileService>();







                    // configure 
                    services.AddOptions();
                    services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));



                    services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

                    
            services.Configure<JWT>(Configuration.GetSection("JWT"));

            var key = Encoding.ASCII.GetBytes(Configuration["JWT:Secret"]);

            //       services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["Jwt:Issuer"],
            //        ValidAudience = Configuration["Jwt:Issuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            //    };
            //});
          services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false; // Set to true in production
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    ValidAudience = Configuration["JWT:ValidAudience"]
                };
            });


            services.AddMvc();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIApplication", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Please provide authorization token to access restricted features.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });

            services.AddControllers();
            services.AddHttpContextAccessor();
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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
                //app.UseSwagger();
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIApplication v1");
                //    c.RoutePrefix = string.Empty; // To serve the Swagger UI at the app's root URL
                //});
            }

            //  using middleware for refresh tokens:

            //app.UseMiddleware<RefreshTokenMiddleware>();

          //  app.UseMiddleware<GlobalExceptionHandlerMiddleware>();


            // Exception Handler:
            //app.Use(async (context, next) =>
            //{
            //    try
            //    {
            //        await next(context);
            //    }catch(Exception ex)
            //    {
            //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //        if(ex.InnerException != null)
            //        {
            //            await context.Response.WriteAsync(ex.Message.ToString());
            //        }
            //    }
            //}); 

            //app.UseExceptionHandler(options =>
            //{
            //    options.Run(async (context) =>
            //    {
                   
                        
                    
            //            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //            var re = context.Features.Get<IExceptionHandlerFeature>();
            //            if (re != null)
            //            {
            //               await context.Response.WriteAsync(re.Error.Message.ToString());
            //            }
                    


            //    });
            //});

            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}