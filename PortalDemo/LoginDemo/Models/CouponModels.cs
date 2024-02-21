using Newtonsoft.Json;

namespace LoginDemo.Models
{
    public class CouponModels
    {
    }
    public class PROC_CUSTOM_GET_SHOPPERS

    {
        [JsonProperty("ClientStoreId")]
        public long ClientStoreId { get; set; }

        [JsonProperty("PREFERREDSTORE")]
        public string PREFERREDSTORE { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("MemberNumber")]
        public string MemberNumber { get; set; }

        [JsonProperty("UserDetailId")]
        public long UserDetailId { get; set; }

        [JsonProperty("ZIPCODE")]
        public string Zipcode { get; set; }
    }
}
