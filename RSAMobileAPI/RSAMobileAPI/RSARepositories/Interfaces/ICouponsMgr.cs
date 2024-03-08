using RSAMobileAPI.RSADALayer;

namespace RSAMobileAPI.RSARepositories.Interfaces
{
    public interface ICouponsMgr
    {
        List<GetUserRedeemedCoupons_Result> GetUserRedeemedCoupons(int UserId);
    }
}
