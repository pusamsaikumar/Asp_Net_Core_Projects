namespace LoginDemo.Models
{
    public class GetClientsInputModel
    {
        public class FindShopperInputModel
        {
            public string ClientDbName { get; set; }
            public string ClientId { get; set; }
            public string MemberNumber { get; set; }
            public string UserName { get; set; }
        }
    }
}
