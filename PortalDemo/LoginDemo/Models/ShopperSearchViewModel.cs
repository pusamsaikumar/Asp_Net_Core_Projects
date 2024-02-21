using System.Collections.Generic;

namespace LoginDemo.Models
{
    public class ShopperErrorMessage
    {
        public int ErrorCode { get; set; }
        public string ErrorDetails { get; set; }
    }
    public class ShopperInfo
    {
        public Guid id { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string MemberNumber { get; set; }
        public string PREFERREDSTORE { get; set; }
        public int USERDETAILID { get; set; }
        public string USERNAME { get; set; }
        public string UserGUID { get; set; }
        public string UserToken { get; set; }
    }

    public class ShopperSearchViewModel
    {
        public ShopperErrorMessage ErrorMessage { get; set; }
        public List<ShopperInfo> ShopperInfo { get; set; }
    }
}
