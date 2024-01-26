using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class AppSettings
    {
       // public string AzureConnectionKey { get; set; }
       // public string AzureContainerName { get; set;}
       // public long NumberOfTicks { get; set; } 

       // public long NumberofMilliSeconds { get; set; }
       //public int[] SelectedPvInstallationIds { get; set; }

       // public decimal MaxPvPower { get; set; }
       // public decimal MaxWindPower { get; set;}

        public string Key { get; set; }    
    }
     public class ConnectionStrings
    {
        public string SNCon { get; set; } 
    }
    public class ApiSettingsInfo
    {
        public string Key { get; set; }
        public string Version { get; set; }
        public string AppName { get; set; }
        public string DBName { get; set; }

        public string url { get; set; }


    }
}
