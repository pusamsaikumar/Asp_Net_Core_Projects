using RSAMobileAPI.RSADALayer;
using RSAMobileAPI.RSARepositories.Interfaces;

namespace RSAMobileAPI.RSARepositories.Services
{
    public class UserMgr : IUserMgr
    {
        private readonly UsersDA _usersDA;

        public UserMgr(UsersDA usersDA)
        {
            _usersDA = usersDA;
        }
        public List<GetUserProfile_Result> GetUserProfile(int UserDetailId)
        {
          return _usersDA.GetUserProfile(UserDetailId);
        }
       public List<GetUserCardInfo_Result> GetUserCardInfo(int UserId)
        {
            return _usersDA.GetUserCardInfo(UserId);
        }
        public List<GetWeeklyAdGallery_Result> GetWeeklyAdGallery(int StoreId)
        {
            return _usersDA.GetWeeklyAdGallery(StoreId);
        }
        public List<TF_GETORDERS_Result> GetOrders(int OrderId)
        {
            return _usersDA.GetOrders(OrderId);
        }
        public List<TF_GETORDERDETAILS_Result> GetOrderDetails(int OrderId)
        {
            return _usersDA.GetOrderDetails(OrderId);
        }
        public List<TF_GETORDERPAYMENTS_Result> GetOrderPayments(int OrderId)
        {
            return _usersDA.GetOrderPayments(OrderId);
        }
        public List<TF_GetAllMenu_Result> GetAllMenu(int ProductCategoryId, int UserId, int StoreId, string DeliveryDate, int DeliverAddressId)
        {
            return _usersDA.GetAllMenu(ProductCategoryId, UserId, StoreId, DeliveryDate, DeliverAddressId);
        }
        public List<GetUserGroups_Result> GetUserGroups(int UserId)
        {
            return _usersDA.GetUserGroups(UserId);
        }
        public List<TF_GETUSERLOCATIONS_Result> GetUserLocations(int userId)
        {
            return _usersDA.GetUserLocations(userId);   
        }
    }
}
