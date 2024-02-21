using BasketProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

using BasketProject.Repository;



namespace BasketProject
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
            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddControllers().AddXmlSerializerFormatters();
            services.AddControllers().AddXmlDataContractSerializerFormatters();
            services.AddEndpointsApiExplorer();
            services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

            //// add connection string 
            services.AddDbContext<BasketDBContext>(options => options.UseSqlServer(configRoot.GetConnectionString("BasketDBCon")));

            //// add repository
          services.AddScoped<IBasketRepository, BasketRepository>();  

             // Add Logging builder
            services.AddLogging(builder =>
            {
                builder.AddConsole();
            });

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
