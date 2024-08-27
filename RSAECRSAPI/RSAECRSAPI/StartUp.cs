using Amazon.S3;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RSAECRSAPI.ECRSBLL;
using RSAECRSAPI.ECRSDAL;
using RSAECRSAPI.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace RSAECRSAPI
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
        // configure services
        public void ConfigureServices(IServiceCollection services)
        {
          

            // This not  support for array of objects
            //var path = Environment.CurrentDirectory;
            //var path = Path.Combine(Environment.CurrentDirectory, @"");
            //IConfiguration config = new ConfigurationBuilder()
            //    .SetBasePath(path)
            //    .AddJsonFile("AppConfigurations.json")
            //    .Build();
            //var configSettings = config.Get<AppConfigurations>();
            //services.Configure<AppConfigurations>(config);

            var path = Path.Combine(Environment.CurrentDirectory, "AppConfigurations.json");
            var json = File.ReadAllText(path);
            var appConfigurations =  JsonConvert.DeserializeObject<List<AppConfigurations>>(json);
            services.AddSingleton(appConfigurations);

            services.AddScoped<ITransactionService , TransactionService>();
            services.AddScoped<ITransactionRepo, TransactionRepo>();
            services.AddScoped<Helpers>();
            services.AddScoped<IS3Repo,S3Repo>();
            services.AddScoped<IS3Service, S3Service>();
            services.AddScoped<S3BucketHelpers>();
           
            services.AddDataProtection();
            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddHttpContextAccessor();
            
            services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

            // connect aws s3 bucket
            services.AddDefaultAWSOptions(configRoot.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();
           
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }


}
