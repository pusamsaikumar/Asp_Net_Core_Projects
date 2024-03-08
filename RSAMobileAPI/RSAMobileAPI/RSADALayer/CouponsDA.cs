using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RSAMobileAPI.RSARepositories.Services;

namespace RSAMobileAPI.RSADALayer
{
    public class CouponsDA 
    {
        private readonly RSA_QAEntities _rSADBContext;

        public CouponsDA(RSA_QAEntities rSADBContext)
        {
            _rSADBContext = rSADBContext;
        }

        public List<GetUserRedeemedCoupons_Result> GetUserRedeemedCoupons(int UserId)
        {
            var userIdParam = new SqlParameter("@UserID", UserId);
            var getUserRedeemedCouponsData = _rSADBContext.Set<GetUserRedeemedCoupons_Result>().FromSqlRaw("EXEC GetUserRedeemedCoupons @UserID", userIdParam).ToList();
            return getUserRedeemedCouponsData;

        }



        //public List<GetUserCouponsForRedeem_Result> GetUserCouponsForRedeem(int UserId, int CustomerId)
        //{
        //    return dbContext.GetUserCouponsForRedeem(UserId, CustomerId).ToList();
        //}
    }
}
