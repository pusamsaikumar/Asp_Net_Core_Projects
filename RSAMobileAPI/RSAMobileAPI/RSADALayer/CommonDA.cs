using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace RSAMobileAPI.RSADALayer
{
    public class CommonDA
    {
        private readonly RSA_QAEntities _rSADBContext;

        public CommonDA(RSA_QAEntities rSADBContext)
        {
            _rSADBContext = rSADBContext;
        }
        public List<GetCustomersList_Result> GetCustomersList(int CustomerId)
        {
            var customerIdParam = new SqlParameter("@CustomerId", CustomerId);
            var customerData = _rSADBContext.Set<GetCustomersList_Result>()
                .FromSqlRaw("EXEC GetCustomersList @CustomerId",customerIdParam).ToList();
            return customerData;
        }
        public List<LM_GetBasketRewardForMobileApi_Result> GetBasketRewared(int UserId)
        {
            var userIdParam = new SqlParameter("@UserId",UserId);
            var basketRewardData = _rSADBContext.Set<LM_GetBasketRewardForMobileApi_Result>().
                FromSqlRaw("EXEC LM_GetBasketRewardForMobileApi @UserId",userIdParam).ToList(); 
            return basketRewardData;
                
          }

        public List<GetRecentBaskets_Result> GetRecentBaskets()
        {
            var GetRecentBasketsData = _rSADBContext.Set<GetRecentBaskets_Result>().
                FromSqlRaw("EXEC GetRecentBaskets ").ToList();
            return GetRecentBasketsData;
        }
        public List<GetRecentRedemptions_Result> GetRecentRedemptions()
        {
            var getRecentRedemptionsData = _rSADBContext.Set<GetRecentRedemptions_Result>().
                FromSqlRaw("EXEC GetRecentRedemptions").ToList();
            return getRecentRedemptionsData;
        }

        public List<GetRecentClips_Result> GetRecentClips()
        {
            var getRecentClipsData = _rSADBContext.Set<GetRecentClips_Result>().
                FromSqlRaw("EXEC GetRecentClips").ToList();
            return getRecentClipsData;
        }

        public List<GetSlides_Result> GetSlides()
        {
            var getSlidesData = _rSADBContext.Set<GetSlides_Result>().FromSqlRaw("EXEC GetSlides").ToList();
            return getSlidesData;
        }
        public List<GetMenuList_Result> GetMenuList()
        {
            var getMenuListData = _rSADBContext.Set<GetMenuList_Result>().FromSqlRaw("EXEC GetMenuList").ToList() ;
            return getMenuListData;
        }

        public List<GetRecipeCategories_Result> GetRecipeCategories()
        {
            var getRecipeCategoriesData = _rSADBContext.Set<GetRecipeCategories_Result>().FromSqlRaw("EXEC GetRecipeCategories").ToList();
            return getRecipeCategoriesData;


        }

        public List<GetWeeklyAdsForBeforeLogin_Result> GetWeeklyAdsForBeforeLogin()
        {
            var getWeeklyAdsForBefoeLoginData = _rSADBContext.Set<GetWeeklyAdsForBeforeLogin_Result>().FromSqlRaw("EXEC GetWeeklyAdsForBeforeLogin").ToList();
            return getWeeklyAdsForBefoeLoginData;

        }
        public List<GetAllCouponsBeforeLogin_Result> GetAllCouponsBeforeLogin(string Token)
        {
            var tokenParam = new SqlParameter("@Token",Token);
            var getAllCouponsBeforeLoginData = _rSADBContext.Set<GetAllCouponsBeforeLogin_Result>().FromSqlRaw("EXEC GetAllCouponsBeforeLogin @Token",tokenParam).ToList(); 
            return getAllCouponsBeforeLoginData;
        }
        public List<LM_GetRewardCountsByDepartment_Result> GetRewardCountsByDepartment()
        {
            var getRewardCountsByDepartmentData = _rSADBContext.Set<LM_GetRewardCountsByDepartment_Result>().FromSqlRaw("EXEC LM_GetRewardCountsByDepartment").ToList(); 
            return getRewardCountsByDepartmentData;

        }
        public List<LM_GetAllRewardsForDepartment_Result> GetAllRewardsForDepartment(int DepartmentId, int UserId)
        {
            var departmentIdParam = new SqlParameter("@DepartmentId", DepartmentId);
            var userIdParam = new SqlParameter("@UserId",UserId);    
            var getAllRewardsForDepartmentData = _rSADBContext.Set<LM_GetAllRewardsForDepartment_Result>()
                .FromSqlRaw("EXEC LM_GetAllRewardsForDepartment @DepartmentId, @UserId",departmentIdParam,userIdParam).ToList();
            return getAllRewardsForDepartmentData;

             

        }
        public List<GetDepartmentWiseCoupons_Result> GetDepartmentWiseCoupons(int ProductDepartmentId, int UserId, int NewsCategoryId)
        {
            var productCategoryIdParam = new SqlParameter("@ProductCategoryId", ProductDepartmentId);
            var userIdParam = new SqlParameter("@UserId",UserId);
            var newsCategoryIdParam = new SqlParameter("@NewsCategoryId", NewsCategoryId);
            var getDepartmentWiseCouponsData = _rSADBContext.Set<GetDepartmentWiseCoupons_Result>().
                FromSqlRaw("EXEC GetDepartmentWiseCoupons @ProductCategoryId,@UserId,@NewsCategoryId", productCategoryIdParam, userIdParam,newsCategoryIdParam).ToList();
            return getDepartmentWiseCouponsData;
        }
        public List<LM_GetQualifiedRewardTiersForMember_Result> GetQualifiedRewardTiersForMember(string MemberNumber,int RewardID)
        {
            var memberNumberParam = new SqlParameter("@MemberNumber", MemberNumber);
            var rewardIDParam = new SqlParameter("@LMRewardID", RewardID);
            var getQualifiedRewardTiersForMemberData = _rSADBContext.Set<LM_GetQualifiedRewardTiersForMember_Result>().
                FromSqlRaw("EXEC LM_GetQualifiedRewardTiersForMember @MemberNumber,@LMRewardID",memberNumberParam, rewardIDParam).ToList();
            return getQualifiedRewardTiersForMemberData;

        }
        public List<LM_GetQualifiedPointsBasedRewardTiersForMember_Result> LM_GetQualifiedPointsBasedRewardTiersForMember(string MemberNumber,int RewardID) 
        {
            var memberNumberParameter = new SqlParameter("@MemberNumber", MemberNumber);
            var rewardIDParameter = new SqlParameter("@LMRewardID", RewardID);
            var LM_GetQualifiedPointsBasedRewardTiersForMemberData = _rSADBContext.Set<LM_GetQualifiedPointsBasedRewardTiersForMember_Result>().
                                                                    FromSqlRaw("EXEC LM_GetQualifiedPointsBasedRewardTiersForMember  @MemberNumber,@LMRewardID",memberNumberParameter, rewardIDParameter).ToList();
            return LM_GetQualifiedPointsBasedRewardTiersForMemberData;


        }
        public List<LM_GetPointsBasedRewardDetailsForMember_Result> LM_GetPointsBasedRewardDetailsForMember(string MemberNumber,int RewardID) 
        {
            var memberNumberParameter = new SqlParameter("@MemberNumber", MemberNumber);
            var rewardIDParameter = new SqlParameter("@LMRewardID", RewardID);
            var getPointsBasedRewardDetailsForMemberData = _rSADBContext.Set<LM_GetPointsBasedRewardDetailsForMember_Result>()
                .FromSqlRaw("EXEC LM_GetPointsBasedRewardDetailsForMember @MemberNumber='',@LMRewardID=1",memberNumberParameter,rewardIDParameter).ToList();
            return getPointsBasedRewardDetailsForMemberData;    
        }
        public List<GetAllEvents_Result> GetAllEvents(int userId)
        {
            var userIdParameter = new SqlParameter("@UserId", userId); 
            var getAllEventsData = _rSADBContext.Set<GetAllEvents_Result>().FromSqlRaw("EXEC GetAllEvents @UserId", userIdParameter).ToList();
            return getAllEventsData;

        }
        public List<LM_GetUPCTierProducts_Result> GetUPCTierProducts(int RewardID , int TierID)
        {
            var lmRewardIDParameter = new SqlParameter("@LMRewardID", RewardID);
            var lmRewardTierIDParameter = new SqlParameter("@LMRewardTierID", TierID);
            var getUPCTierProductsData = _rSADBContext.Set<LM_GetUPCTierProducts_Result>().FromSqlRaw("EXEC LM_GetUPCTierProducts @LMRewardID,@LMRewardTierID",lmRewardIDParameter,lmRewardTierIDParameter).ToList();
            return getUPCTierProductsData;
        }

        public List<GetMemberMostRecentBasketItems_Result> GetMostRecentPurchaseItems(int userId)
        {
            var userIdParameter = new SqlParameter("@UserId", userId);
            var getMostRecentPurchaseItems = _rSADBContext.Set<GetMemberMostRecentBasketItems_Result>().FromSqlRaw("EXEC GetMemberMostRecentBasketItems @UserId", userIdParameter).ToList();
            return getMostRecentPurchaseItems;

        }
    }
}
