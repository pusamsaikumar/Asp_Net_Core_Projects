using RSAECRSAPI.ECRSBLL;
using RSAECRSAPI.ECRSDAL;
using RSAECRSAPI.ECRSDAL.Models;

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

           

            //var path = Environment.CurrentDirectory;
            var path = Path.Combine(Environment.CurrentDirectory, @"");
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("AppConfigurations.json")
                .Build();
            var configSettings = config.Get<AppConfigurations>();
            services.Configure<AppConfigurations>(config);

            services.AddScoped<ITransactionService , TransactionService>();
            services.AddScoped<ITransactionRepo, TransactionRepo>();

            services.AddDataProtection();

            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddHttpContextAccessor();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();

            // add cors 
            //app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
          

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }


}
