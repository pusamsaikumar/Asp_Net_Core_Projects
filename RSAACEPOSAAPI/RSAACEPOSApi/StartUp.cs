using Microsoft.OpenApi.Models;




using System.Net;
using System.Text;
using RSAACEPOSApi.BAL;
using RSAACEPOSApi.DAL;
using RSAACEPOSApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace RSAACEPOSApi
{
    public class StartUp
    {
        private readonly IWebHostEnvironment _env;

        public IConfiguration configRoot { get; }

        public StartUp(IConfiguration configuration, IWebHostEnvironment env)
        {
            configRoot = configuration;
            _env = env;
        }

    
        public void ConfigureServices(IServiceCollection services)
        {
            // ConfigJsonFiles  
            //var basepath = Path.Combine(Environment.CurrentDirectory, @"ConfigJsonFiles\");
            //IConfiguration config = new ConfigurationBuilder()
            //.SetBasePath(basepath)
            //.AddJsonFile("ConfigSettings.json")

            //.Build();

            // inside wwwroot folder

            //IConfiguration config = new ConfigurationBuilder()
            //.SetBasePath(_env.WebRootPath)
            //.AddJsonFile("ConfigSettings.json")

            //.Build();


            // inside a main project  RSAACEPOSApi
            IConfiguration config = new ConfigurationBuilder()
            //.SetBasePath(_env.ContentRootPath)
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("ConfigSettings.json")

            .Build();





            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddControllers().AddXmlSerializerFormatters();
            services.AddControllers().AddXmlDataContractSerializerFormatters();
            services.AddScoped<RSAACEPOSApiBAL>();
            services.AddScoped<RSAACEPOSApiDALcs>();


            // load jsonfile

            // configure AWS Lambda service
            services.AddAWSLambdaHosting(LambdaEventSource.RestApi);


            // configure file
            services.AddOptions();
            services.Configure<ConfigsValues>(config);
            services.Configure<Configs>(configRoot.GetSection("Configs"));
            services.Configure<List<ConfigSettings>>(configRoot.GetSection("ConfigSettings"));
           
           
        }

        
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {

          if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.Use(async (context, next) =>
            {
                try
                {
                    await next(context);
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    if (ex.InnerException != null)
                    {
                        await context.Response.WriteAsync(ex.Message);
                    }
                }


            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }


    }
}