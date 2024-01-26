using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Common.Utilities
{
    public static class ServiceLifeTimeExtension
    {
        public static IServiceCollection RegisterClassOnMactchingNames(  this IServiceCollection service , string[] assemblyNames )

        {
            var availableTypes = assemblyNames.SelectMany(assemblyName => Assembly.Load(assemblyName ).GetTypes() ).ToList();

            var interfaceTypes = availableTypes.Where(availableType => availableType.IsInterface).ToList();

            var classTypes = availableTypes.Where(availableType =>  !availableType.IsAbstract && availableType.IsClass).ToList();

            interfaceTypes.ForEach(interfaceType =>
            {
                var MatchingClassType = classTypes.FirstOrDefault(classType => classType.Name.Equals(interfaceType.Name.Substring(1)));
                if(MatchingClassType != null )
                {
                    if(assemblyNames.Contains(MatchingClassType.Namespace)){
                       service.AddScoped(interfaceType, MatchingClassType);
                    }
                    else
                    {
                        service.AddTransient(interfaceType, MatchingClassType);
                    }
                }
            });
            return service;
        }
    }
}
