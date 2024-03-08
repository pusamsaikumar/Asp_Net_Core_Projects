using RSAMobileAPI.RSADALayer;
using RSAMobileAPI.RSARepositories.Interfaces;

namespace RSAMobileAPI.RSARepositories.Services
{
    public class CouponsMgr : ICouponsMgr
    {
        private readonly CouponsDA _couponsDA;

        public CouponsMgr(CouponsDA couponsDA)
        {
            _couponsDA = couponsDA;
        }
        public List<GetUserRedeemedCoupons_Result> GetUserRedeemedCoupons(int UserId)
        {
            return _couponsDA.GetUserRedeemedCoupons(UserId);
        }
    }
}
