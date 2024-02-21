using Microsoft.Extensions.Caching.Memory;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.

[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
public class Service : IService
{
    private static string storedata; 
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
    public void AddDataMemory(string data)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
           .SetSlidingExpiration(TimeSpan.FromSeconds(3));
        // Store data in memory cache with a specific key
        _memoryCache.Set("MyDataKey", data, cacheEntryOptions);
    }

    public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

    public string GetDataMemory()
    {
        if(_memoryCache.TryGetValue("MyDataKey",out storedata)){
            return storedata;
        } 
        return string.Format("No data found");
    }
}
