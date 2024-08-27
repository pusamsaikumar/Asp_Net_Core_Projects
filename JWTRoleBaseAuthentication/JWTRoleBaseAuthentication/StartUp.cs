using JWTRoleBaseAuthentication.CommonLayer.Models;
using JWTRoleBaseAuthentication.DataAccessLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace JWTRoleBaseAuthentication
{
    public class StartUp
    {
        private readonly IWebHostEnvironment _env;

        //private readonly IConfiguration _configuration;
        public IConfiguration configRoot { get; set; }

        // constructor
        public StartUp(IConfiguration configuration, IWebHostEnvironment env)
        {
            configRoot = configuration;
            _env = env;
        }








        // configure services
        public async void ConfigureServices(IServiceCollection services)
        {
            // dependeny injections
            services.AddScoped<IAuthRepo,AuthRepo>();
         
            services.AddScoped<Helpers>();

            // configure 
            services.AddOptions();
            services.Configure<AppSettings>(configRoot.GetSection("AppSettings"));



            services.Configure<ConnectionStrings>(configRoot.GetSection("ConnectionStrings"));

            services.Configure<JWT>(configRoot.GetSection("JWT"));





            //  services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen();


           



            // configure 
            services.AddOptions();
            services.Configure<AppSettings>(configRoot.GetSection("AppSettings"));

          

            services.Configure<ConnectionStrings>(configRoot.GetSection("ConnectionStrings"));

            //services.Configure<Database>(configRoot.GetSection("Database"));

            //// jwt
            services.Configure<JWT>(configRoot.GetSection("JWT"));

            // login auth 
            //services.AddScoped<ILoginAuthRepo, LoginAuthRepo>();
            //services.AddScoped<ILoginAuthService, LoginAuthService>();
            //services.AddScoped<ITokenServices, TokenServices>();

            // wcf service
            //  services.AddScoped<IService,ServiceClient>();

            // add error handling exceptions here for method3
            


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
           

            // add data protection for encrypt and decrypt:
            services.AddDataProtection();

            // read the key from AppSettings:
            var appSettingsread = configRoot.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsread);


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //// configure authentication
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            //})
             
            //    .AddJwtBearer(options =>
            //    {
            //        options.SaveToken = true;
            //        options.RequireHttpsMetadata = false;
            //        options.TokenValidationParameters = new TokenValidationParameters

            //        {

            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ClockSkew = TimeSpan.Zero,
            //          //  ClockSkew = new TimeSpan(0, 0, 5),
            //            ValidAudience = configRoot["JWT:ValidAudience"],
            //            ValidIssuer = configRoot["JWT:ValidIssuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configRoot["JWT:Secret"])),

            //            //ValidateIssuerSigningKey = true,
            //            //IssuerSigningKey = new SymmetricSecurityKey(secret),
            //            //ValidateIssuer = false,
            //            //ValidateAudience = false
            //        };
                  

            //    });
          services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = configRoot["JWT:ValidAudience"],
        ValidIssuer = configRoot["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyThatIsAtLeast32CharactersLongsiodfupiweupr9woieruopweu")),

    };
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
            return Task.CompletedTask;
        }
    };
});
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
            }
            );

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter Bearer Jwt Token",
                    Name = "Authorization",
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
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { scheme, Array.Empty<string>() } });
            });


            //  add  AddHttpContextAccessor();
            services.AddHttpContextAccessor();

            // add cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });



            // session storage:
            // services.AddMvc().AddSessionStateTempDataProvider();
            services.AddDistributedMemoryCache();



            services.AddSession(options =>
            {

                options.IdleTimeout = TimeSpan.FromSeconds(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // add service add memory cache
            services.AddMemoryCache();


        }
        // configure http request pipeline


        public void Configure(WebApplication app, IWebHostEnvironment env)
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




            // add cors 
            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();
            app.UseRouting();

            // *** These are the important ones - note order matters ***
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStatusCodePages();
            //app.UseDefaultFiles(); // so index.html is not required
            //app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.Run();
        }
    }
}
