using Microsoft.Extensions.Caching.Memory;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
//[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
public class Service : IService
{

    private static string storedData;

    private ObjectCache _cache = System.Runtime.Caching.MemoryCache.Default;


    //public string AddData(string data)
    //{
    //    try
    //    {
    //        if(data !=null)
    //        {
    //            string cacheName = "EmployeeData";
    //            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(2));
    //            return _memoryCache.Set(cacheName, data, cacheEntryOptions);


    //        }
    //        else
    //        {
    //            throw new ArgumentNullException("parameter", "Parameter cannot be null");
    //        }

    //    }

    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //}

    public void AddWCFData(string data)
    {
        try
        {
            if (!string.IsNullOrEmpty(data))
            {
               
                CacheItemPolicy policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(2)
                };

                _cache.Set("MyCatchData", data, policy);

            }

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public string AddData(string data)
    {
        return storedData = data;
    }
    
    public string GetData()
    {
        return storedData;
    }

    public string GetWCFData()
    {
        try
        {
            string data = (string)_cache.Get("MyCatchData");
//if (!string.IsNullOrEmpty(data.ToString()))
            if(data != null)
            {
                return data.ToString();
            }
            else
            {
                return "No data found";
            }

            
        }
        catch (Exception ex)
        {
            throw ex;
        }



    }

 





}
