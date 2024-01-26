using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentThreeTier.Lambda
{
    public class LambdaFunction : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            _ = builder
                .UseContentRoot(Directory.GetCurrentDirectory())
                //.UseStartup()
                .UseApiGateway();
        }
    }
}
