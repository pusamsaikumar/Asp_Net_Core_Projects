namespace RSAMobileAPI.RSADALayer
{
    public class TF_GETUSERLOCATIONS_Result
    {
        public int UserAddressID { get; set; }
        public int? UserID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int? StateId {get;set;}
        public string StateName { get; set; }   
        public string CountryName { get; set; } 
        public string ZipCode { get; set; } 
        public int? AddressTypeId { get; set; }
        public string DrivingInstructions { get; set; } 
        public string UserName { get; set; }    
        public string FirstName { get; set; }   
        public string LastName { get; set; }    
    }
}








