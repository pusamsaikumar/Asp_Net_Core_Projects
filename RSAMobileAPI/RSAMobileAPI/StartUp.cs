using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RSAMobileAPI.RSADALayer;

//using RSAMobileAPI.RSADALayer;
using RSAMobileAPI.RSAEntities;

using RSAMobileAPI.RSARepositories.Interfaces;
using RSAMobileAPI.RSARepositories.Services;
using RSAMobileAPI.RSAServices;
using System.Net;

namespace RSAMobileAPI
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
           
          // appsettings
            services.AddOptions();
            services.Configure<AppSettings>(configRoot.GetSection("AppSettings"));

            services.AddScoped<ICustomerMgr, CustomerMgr>();
            services.AddScoped<ICommonMgr, CommonMgr>();
            services.AddScoped<IServicesMgr, ServicesMgr>();
            services.AddScoped<ICouponsMgr,CouponsMgr>();
            services.AddScoped<ConstantMgr>();
            services.AddScoped<IUserMgr, UserMgr>();
            services.AddScoped<ImageMgr, ImageMgr>();
            services.AddScoped<UsersDA>();
            services.AddScoped<ServicesDA>();
            services.AddScoped<CustomerDA>();
            services.AddScoped<CommonDA>();
            services.AddScoped<CouponsDA>();
            services.AddScoped<ConfigurationHelper>();
            services.AddScoped<MultipleResultSets>();
            services.AddScoped<Helpers>();
           

           services.AddDbContext<RSA_QAEntities>(options => options.UseSqlServer(configRoot.GetConnectionString("RSADBCon")));
          
      
         

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

           // app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

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
