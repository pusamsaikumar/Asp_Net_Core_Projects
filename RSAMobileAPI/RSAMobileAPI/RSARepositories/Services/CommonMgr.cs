using RSAMobileAPI.RSADALayer;
using RSAMobileAPI.RSARepositories.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RSAMobileAPI.RSARepositories.Services
{
    public class CommonMgr : ICommonMgr
    {
        private readonly CommonDA _commonDA;

        public CommonMgr(CommonDA commonDA)
        {
            _commonDA = commonDA;
        }

        public List<LM_GetBasketRewardForMobileApi_Result> GetBasketReward(int UserId)
        {
            return _commonDA.GetBasketRewared(UserId);
        }

        public List<GetCustomersList_Result> GetCustomersList(int CustomerId)
        {
            return _commonDA.GetCustomersList(CustomerId);  
        }
        public List<GetRecentBaskets_Result> GetRecentBaskets()
        {
            return _commonDA.GetRecentBaskets();
        }
        public List<GetRecentRedemptions_Result> GetRecentRedemptions()
        {
            return _commonDA.GetRecentRedemptions();
        }
        public List<GetRecentClips_Result> GetRecentClips()
        {
           return _commonDA.GetRecentClips(); 
        }
        public List<GetSlides_Result> GetSlides()
        {
            return _commonDA.GetSlides();
        }
        public List<GetMenuList_Result> GetMenuList()
        {
            return _commonDA.GetMenuList();
        }
        public List<GetRecipeCategories_Result> GetRecipeCategories()
        {
            return _commonDA.GetRecipeCategories(); 
        }
        public List<GetWeeklyAdsForBeforeLogin_Result> GetWeeklyAdsForBeforeLogin()
        {
            return _commonDA.GetWeeklyAdsForBeforeLogin();
        }
        public List<GetAllCouponsBeforeLogin_Result> GetAllCouponsBeforeLogin(string Token)
        {
            return _commonDA.GetAllCouponsBeforeLogin(Token);
        }
       public List<LM_GetRewardCountsByDepartment_Result> GetRewardCountsByDepartment()
        {
            return _commonDA.GetRewardCountsByDepartment();   
        }
        public List<LM_GetAllRewardsForDepartment_Result> GetAllRewardsForDepartment(int DepartmentId, int UserId)
        {
            return _commonDA.GetAllRewardsForDepartment(DepartmentId, UserId);
        }
        public List<GetDepartmentWiseCoupons_Result> GetDepartmentWiseCoupons(int ProductDepartmentId, int UserId, int NewsCategoryId)
        {
            return _commonDA.GetDepartmentWiseCoupons(ProductDepartmentId, UserId, NewsCategoryId);
        }
        public List<LM_GetQualifiedRewardTiersForMember_Result> GetQualifiedRewardTiersForMember(string MemberNumber, int RewardID)
        {
            return _commonDA.GetQualifiedRewardTiersForMember(MemberNumber, RewardID);
        }
        public List<LM_GetQualifiedPointsBasedRewardTiersForMember_Result> LM_GetQualifiedPointsBasedRewardTiersForMember(string MemberNumber, int RewardID)
        {
            return _commonDA.LM_GetQualifiedPointsBasedRewardTiersForMember(MemberNumber, RewardID);
        }
        public List<LM_GetPointsBasedRewardDetailsForMember_Result> LM_GetPointsBasedRewardDetailsForMember(string MemberNumber, int RewardID)
        {
            return _commonDA.LM_GetPointsBasedRewardDetailsForMember(MemberNumber,RewardID);
        }
        public List<GetAllEvents_Result> GetAllEvents(int userId)
        {
            return _commonDA.GetAllEvents(userId);  
        }
        public List<LM_GetUPCTierProducts_Result> GetUPCTierProducts(int RewardID, int TierID)
        {
            return _commonDA.GetUPCTierProducts(RewardID, TierID);  
        }
        public List<GetMemberMostRecentBasketItems_Result> GetMostRecentPurchaseItems(int userId)
        {
            return _commonDA.GetMostRecentPurchaseItems(userId);
        }
    }
}
