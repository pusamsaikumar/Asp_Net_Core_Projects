using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Caching;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.

//[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
public class Service : IService
{
    private readonly IMemoryCache _memoryCache;

    public Service()
    {
        
    }
    public Service(
        
        IMemoryCache memoryCache
        )
    {
        _memoryCache = memoryCache;
    }
    public void AddDataMemory(string value)
    {
        try
        {
            if (!string.IsNullOrEmpty(value))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _memoryCache.Set("MyCatchData", value, cacheEntryOptions);

            }
            else
            {
                throw new Exception("error");
            }

        }
        catch ( Exception ex )
        {
            throw ex;
        }

    }

    public string GetDataMemory()
    {
        try
        {
            var data = _memoryCache.Get("MyCatchData").ToString();
           return data; 
        }catch(Exception ex)
        {
            throw ex;
        }
    }
}
