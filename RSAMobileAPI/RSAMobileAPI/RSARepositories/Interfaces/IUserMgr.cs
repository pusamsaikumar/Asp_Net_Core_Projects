using RSAMobileAPI.RSADALayer;

namespace RSAMobileAPI.RSARepositories.Interfaces
{
    public interface IUserMgr
    {
        List<GetUserProfile_Result> GetUserProfile(int UserDetailId);
        List<GetUserCardInfo_Result> GetUserCardInfo(int UserId);
        List<GetWeeklyAdGallery_Result> GetWeeklyAdGallery(int StoreId);
        List<TF_GETORDERS_Result> GetOrders(int OrderId);
        List<TF_GETORDERDETAILS_Result> GetOrderDetails(int OrderId);
        List<TF_GETORDERPAYMENTS_Result> GetOrderPayments(int OrderId);
         List<TF_GetAllMenu_Result> GetAllMenu(int ProductCategoryId, int UserId, int StoreId, string DeliveryDate, int DeliverAddressId);
       List<GetUserGroups_Result> GetUserGroups(int UserId);
        List<TF_GETUSERLOCATIONS_Result> GetUserLocations(int userId);
    }
}
