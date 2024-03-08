namespace RSAMobileAPI.RSARepositories.Services
{
    public class EnumMgr
    {
        public enum SpecialsTypes
        {
            WeeklySpecials = 1,
            ProductCoupons = 2,
            BasketDeals = 3,
            ManufacturerCoupon = 4,
            GroupCoupon = 5,
            GroupBasketCoupon = 6,
            BogoCoupon = 7,
            DistributorCoupon = 9
        }
        public enum UploadLocations
        {
            CompanyLogo = 1,
            ClientLogo = 2,
            ProductsLogo = 3,
            SpecialsLogo = 4,
            BarcodeLogo = 5,
            WeeklySpecialsLogo = 6
        }
        public enum FileUploadMode
        {
            LocalFileSystem = 1,
            DataBase = 2,
            AmazonS3 = 3
        }
    }
}
