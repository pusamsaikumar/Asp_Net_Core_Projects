using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace RSAMobileAPI.RSADALayer
{
    public class UsersDA
    {
        private readonly RSA_QAEntities _rSADBContext;
        public UsersDA(RSA_QAEntities rSADBContext)
        {

            _rSADBContext = rSADBContext;

        }
        public List<GetUserProfile_Result> GetUserProfile(int UserDetailId)
        {
            var userDetailIdParam = new SqlParameter("@UserDetailId", UserDetailId);
            var userProfileData = _rSADBContext.Set<GetUserProfile_Result>().
                FromSqlRaw("EXEC GetUserProfile @UserDetailId",userDetailIdParam).ToList();
            return userProfileData;
        }
        public List<GetUserCardInfo_Result> GetUserCardInfo(int UserId)
        {
            var userDetailIdParam = new SqlParameter("@UserId", UserId);
            var getUserCardInfoData = _rSADBContext.Set<GetUserCardInfo_Result>().FromSqlRaw("EXEC GetUserCardInfo @UserId",userDetailIdParam).ToList();
            return getUserCardInfoData;
        }

        public List<GetWeeklyAdGallery_Result> GetWeeklyAdGallery(int StoreId)
        {
            var storeIdParam = new SqlParameter("@StoreId", StoreId);
            var getWeeklyAdGalleryData = _rSADBContext.Set<GetWeeklyAdGallery_Result>().FromSqlRaw("EXEC GetweeklyAddGal @StoreId", storeIdParam).ToList(); // working

            // var getWeeklyAdGalleryData = _rSADBContext.Set<GetWeeklyAdGallery_Result>().FromSqlRaw("EXEC GetWeeklyAdGallery @StoreId", storeIdParam).ToList();  //not working
            return getWeeklyAdGalleryData;
        }

        public List<TF_GETORDERS_Result> GetOrders(int OrderId)
        {
            var orderIdParam = new SqlParameter("@OrderId", OrderId);
            var getOrdersData = _rSADBContext.Set<TF_GETORDERS_Result>().FromSqlRaw("EXEC TF_GETORDERS @OrderId",orderIdParam).ToList();
            return getOrdersData;

        }
        public List<TF_GETORDERDETAILS_Result> GetOrderDetails(int OrderId)
        {
            var orderDetailsIdParam = new SqlParameter("@OrderId", OrderId);
            var  getOrderDetailsData = _rSADBContext.Set<TF_GETORDERDETAILS_Result>().FromSqlRaw("EXEC TF_GETORDERDETAILS @OrderId",orderDetailsIdParam).ToList();

            return getOrderDetailsData;

        }
        public List<TF_GETORDERPAYMENTS_Result> GetOrderPayments(int OrderId) {
            var orderPaymentsIdParam = new SqlParameter("@OrderId", OrderId);
            var getGetOrderPaymentsData = _rSADBContext.Set<TF_GETORDERPAYMENTS_Result>().FromSqlRaw("EXEC TF_GETORDERPAYMENTS @OrderId", orderPaymentsIdParam).ToList();
            return getGetOrderPaymentsData;

          
        }

        public List<TF_GetAllMenu_Result> GetAllMenu(int ProductCategoryId, int UserId, int StoreId, string DeliveryDate, int DeliverAddressId)
        {
            var productCategoryIParam = new SqlParameter("@", ProductCategoryId);
            var userIdParam = new SqlParameter("@UserId",UserId);
            var storeIdParam = new SqlParameter("@StoreId", StoreId);
            var deliveryDateParam = new SqlParameter("@DeliveryDate", DeliveryDate);
            var deliveryAddressParam = new SqlParameter("@DeliverAddressId", DeliverAddressId);

            var getAllMenuData = _rSADBContext.Set<TF_GetAllMenu_Result>().FromSqlRaw("EXEC TF_GetAllMenu", productCategoryIParam, userIdParam, storeIdParam, deliveryDateParam, deliveryAddressParam).ToList();
            return getAllMenuData;
        }
        
        public List<GetUserGroups_Result> GetUserGroups(int UserId)
        {
            var userGroupIParam = new SqlParameter("@UserId", UserId);
            var getUserGroupsData = _rSADBContext.Set<GetUserGroups_Result>().FromSqlRaw("EXEC GetUserGroups @UserId", userGroupIParam).ToList();
            return getUserGroupsData;
        }
        public List<TF_GETUSERLOCATIONS_Result> GetUserLocations(int userId)
        {
            var userIdParam = new SqlParameter("@USERID", userId);
            var getUserLocations = _rSADBContext.Set<TF_GETUSERLOCATIONS_Result>().FromSqlRaw("EXEC TF_GETUSERLOCATIONS @USERID", userIdParam).ToList(); 
            return getUserLocations;
        }    
    }
}
