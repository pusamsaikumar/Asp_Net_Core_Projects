using System.ComponentModel.DataAnnotations;

namespace LoginDemo.Models
{
  
    [Serializable]
    public class RetailersStoreModel
    {
        [Key]
        public int RSAClientId { get; set; }

        public int ClientStoreId { get; set; } = 75;

        public string StoreName { get; set; }

        public string StoreProfile { get; set; }

        public string StoreEmail { get; set; }

        public string StorePhone { get; set; }

        public string AddressLine1 { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string StoreTimings { get; set; }

        //public string Latitude { get; set; }

        //public string Longitude { get; set; }

        public bool IsEditView { get; set; } = true;
    }
}
