using Amazon.SQS;
using SQSWebApi.Helpers;
using SQSWebApi.Models;
using SQSWebApi.Services;
using System.IO;
using System.Net;
using static SQSWebApi.Models.UserModel;


namespace SQSWebApi
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
            var path = Path.Combine(Environment.CurrentDirectory, @"JSONFiles\");
            // add jsonfile

            // Users.json
            IConfiguration usersCongfig = new ConfigurationBuilder()
           .SetBasePath(path)
           .AddJsonFile("Users.json").Build();

            var users = usersCongfig.GetSection("UsersData").Get<List<Users>>();

            services.AddSingleton(users);

            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddControllers().AddXmlSerializerFormatters();
            services.AddControllers().AddXmlDataContractSerializerFormatters();
         
           services.AddScoped<IAWSSQSHelper,AWSSQSHelper>();
            services.AddScoped<IAWSSQSService,AWSSQSService>();


            // add memory catch
            services.AddMemoryCache(

                options => options.ExpirationScanFrequency = TimeSpan.FromMinutes(2)
                ) ;

            // configure AWS Lambda service
            services.AddAWSLambdaHosting(LambdaEventSource.RestApi);


            // configure file
            services.AddOptions();

            services.Configure<ServiceConfiguaration>(configRoot.GetSection("ServiceConfiguaration"));
            services.AddAWSService<IAmazonSQS>();


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
