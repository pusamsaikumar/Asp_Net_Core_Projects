using Newtonsoft.Json;
using System.ComponentModel;
using System.Formats.Asn1;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JWTRoleAuthentication.CommonLayer.Models
{
  
   public class SampleDataTypes
    {
        public int? Id { get; set; } 
        public string? UserName { get; set; }
        public int? Age { get; set; }
       //public string? Age { get; set; }
        public bool? IsActive { get; set; }  
        public DateTime? DateOfBirth { get; set; }
        public double? Doublevalue { get; set; }

        //public string? ProfileName { get; set; } 
        public byte[]? Profile { get; set; }
        //public string Profile { get; set; }
        public Guid? UserID { get; set; }
        public TimeSpan? TimeSpanValue {  get; set; }    
        public float? Salary { get; set; } 
        public DateTime? JoinDate { get; set; }
        public decimal? Price { get; set; }  
        

    }
   public class ResponseDataTypes
    {
        public int StatusCode { get; set; } 
        public string StatusMessage { get; set; }
        public SampleDataTypes SampleDataTypes { get; set; }
    }
}




 