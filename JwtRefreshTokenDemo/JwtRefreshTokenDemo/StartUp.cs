using CommonLayer.Models;
using Microsoft.Extensions.DependencyInjection;

namespace JwtRefreshTokenDemo
{
    public class StartUp
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration configRoot { get; set; }
        public StartUp(IConfiguration configuration,IWebHostEnvironment env)
        {
            _env = env;
           configRoot = configuration;
        }
        // configure services
        public void ConfigureServices(IServiceCollection services)
        {
           
            //  services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen();

            // configure 
            services.AddOptions();
            services.Configure<Database>(configRoot.GetSection("Database"));
            services.Configure<ConnectionStrings>(configRoot.GetSection("ConnectionStrings"));

        }
        public void Configure(WebApplication app,IWebHostEnvironment env)
        {
            // app.UseSession();
            app.UseRouting();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            // we have to must use for JWt authentication  app.UseAuthentication();
            app.UseAuthentication();
            app.UseAuthorization();



            app.MapControllers();
            app.Run();
        }
    }
}
