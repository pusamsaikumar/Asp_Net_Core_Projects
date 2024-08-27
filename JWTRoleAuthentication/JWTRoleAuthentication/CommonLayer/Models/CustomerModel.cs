namespace JWTRoleAuthentication.CommonLayer.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
    }
    public class DatasetResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Register> users { get; set; }
        public List<CustomerModel> Customer { get; set;}
    }
    public class CustomerResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        
        public CustomerModel Customer { get; set; }
    }
}
