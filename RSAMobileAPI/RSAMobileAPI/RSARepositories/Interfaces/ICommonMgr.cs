using RSAMobileAPI.RSADALayer;

namespace RSAMobileAPI.RSARepositories.Interfaces
{
    public interface ICommonMgr
    {
        List<GetCustomersList_Result> GetCustomersList(int CustomerId);
        List<LM_GetBasketRewardForMobileApi_Result> GetBasketReward(int UserId);
         List<GetRecentBaskets_Result> GetRecentBaskets();
        List<GetRecentRedemptions_Result> GetRecentRedemptions();
        List<GetRecentClips_Result> GetRecentClips();
       List<GetSlides_Result> GetSlides();
        List<GetMenuList_Result> GetMenuList();
        List<GetRecipeCategories_Result> GetRecipeCategories();
        List<GetWeeklyAdsForBeforeLogin_Result> GetWeeklyAdsForBeforeLogin();
        List<GetAllCouponsBeforeLogin_Result> GetAllCouponsBeforeLogin(string Token);
        List<LM_GetRewardCountsByDepartment_Result> GetRewardCountsByDepartment();
        List<LM_GetAllRewardsForDepartment_Result> GetAllRewardsForDepartment(int DepartmentId, int UserId);
        List<GetDepartmentWiseCoupons_Result> GetDepartmentWiseCoupons(int ProductDepartmentId, int UserId, int NewsCategoryId);
         List<LM_GetQualifiedRewardTiersForMember_Result> GetQualifiedRewardTiersForMember(string MemberNumber, int RewardID);
         List<LM_GetQualifiedPointsBasedRewardTiersForMember_Result> LM_GetQualifiedPointsBasedRewardTiersForMember(string MemberNumber, int RewardID);
         List<LM_GetPointsBasedRewardDetailsForMember_Result> LM_GetPointsBasedRewardDetailsForMember(string MemberNumber, int RewardID);
        List<GetAllEvents_Result> GetAllEvents(int userId);
        List<LM_GetUPCTierProducts_Result> GetUPCTierProducts(int RewardID, int TierID);
        List<GetMemberMostRecentBasketItems_Result> GetMostRecentPurchaseItems(int userId);
    }
}
