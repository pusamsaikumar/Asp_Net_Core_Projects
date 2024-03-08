using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Options;
using RSAMobileAPI.RSADALayer;
using RSAMobileAPI.RSAEntities;

using RSAMobileAPI.RSARepositories.Interfaces;
using RSAMobileAPI.RSARepositories.Services;
using RSAMobileAPI.RSAServices;
using System.Security.AccessControl;
using System.Transactions;
using static RSAMobileAPI.RSAEntities.GetClientStoreForAppResponse;

namespace RSAMobileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSAMobileAPI : ControllerBase
    {
        private readonly ICustomerMgr _customerMgr;
        private readonly ICommonMgr _commonMgr;
        private readonly IOptions<AppSettings> _appsettings;
        private readonly IServicesMgr _servicesMgr;
        private readonly IUserMgr _userMgr;
        private readonly ImageMgr _imageMgr;
        private readonly ICouponsMgr _couponsMgr;
        private readonly MultipleResultSets _multipleResultSets;
        private readonly Helpers _helpers;
        private readonly ConfigurationHelper ConfigurationHelper;
       // public ConfigurationHelper ConfigurationHelper { get; }
     
        public RSAMobileAPI(
            ICustomerMgr customerMgr,
            ICommonMgr commonMgr,
            IOptions<AppSettings> appsettings,
            ConfigurationHelper configurationHelper,
            IServicesMgr servicesMgr,
            IUserMgr userMgr,
            ImageMgr imageMgr,
            ICouponsMgr couponsMgr,
            MultipleResultSets multipleResultSets,
            Helpers helpers




            )
        {
           _customerMgr = customerMgr;
            _commonMgr = commonMgr;
            _appsettings = appsettings;
            ConfigurationHelper = configurationHelper;
           _servicesMgr = servicesMgr;
            _userMgr = userMgr;
            _imageMgr = imageMgr;
            _couponsMgr = couponsMgr;
            _multipleResultSets = multipleResultSets;
            _helpers = helpers;
        }



        [HttpPost]
        [Route("Register")]
        public RegisterResponse Register(Register model)
        {
            RegisterResponse registerResponse = null;
            registerResponse = new RegisterResponse();
            registerResponse.ErrorMessage = new ErrorMessage();
            try
            {
                if(ConfigurationHelper.EnableSendEmailActivationLinkToNewUsers )
                {
                    model.UserRoleName = ConstantMgr.UserRole;
                    model.UserTypeId = 3;
                    return registerResponse = NewUserRegistrationWithActivationLink(model);

                }
                BarCodeResult barCodeResult = null;
                barCodeResult = new BarCodeResult();
               // membership 
            }catch (Exception ex)
            {

            }
            return registerResponse;    
        }

        [HttpPost]
        [Route("PortalNewUserRegistrationWithActivationLink")]
        public RegisterResponse PortalNewUserRegistrationWithActivationLink(Register model)
        {
            RegisterResponse registerResponse = null;
            registerResponse = new RegisterResponse();
            registerResponse.ErrorMessage = new ErrorMessage();
            registerResponse = NewUserRegistrationWithActivationLink(model);
            return registerResponse;
        }
       private RegisterResponse NewUserRegistrationWithActivationLink(Register model)
        {
            RegisterResponse registerResponse = null;
            return registerResponse;
        }
        [HttpPost]
        [Route("GetClientStores/{CustomerId}")]
        public GetClientStoreResponce GetClientStores(string CustomerId)
        {
            GetClientStoreResponce ClientStoreResponce = new GetClientStoreResponce();
            ClientStoreResponce.ErrorMessage = new ErrorMessage();
            try
            {
                var storesList = _customerMgr.GetClientStores(0).Where(m => m.CustomerId == Convert.ToInt32(CustomerId));
                ClientStoreResponce.GetClientStores = (from dr in storesList
                                                       select new ClientStores
                                                       {
                                                           ClientStoreId = dr.ClientStoreId,
                                                           ClientStoreName = dr.StoreName,
                                                           StorePhoneNumber = new String(dr.StorePhone.ToCharArray().Where(c => Char.IsDigit(c)).ToArray()),
                                                           AddressLine1 = dr.AddressLine1,
                                                           AddressLine2 = dr.StateName,
                                                           City = dr.City,
                                                           ZipCode = dr.ZipCode,
                                                           StoreTimings = dr.StoreTimings,
                                                           Latitude = Convert.ToDecimal(dr.Latitude),
                                                           Longitude = Convert.ToDecimal(dr.Longitude),
                                                           StateName = dr.StateName,
                                                           StoreEmail = dr.StoreEmail,
                                                           WeeklyAdStoreId = dr.WeeklyAdStoreId,
                                                           StoreNumber = (dr.StoreNumber != null ? Convert.ToInt32(dr.StoreNumber) : 0),
                                                           //StoreEcomStatus = (dr.StoreEcomStatus != null ? Convert.ToBoolean(dr.StoreEcomStatus) : false)
                                                       }).ToList();
                 ClientStoreResponce.EnableStoreManagement = Convert.ToBoolean(_commonMgr.GetCustomersList(Convert.ToInt32(CustomerId))[0].EnableStoreManagement);
                ClientStoreResponce.EnableStoreManagement = false;
                ClientStoreResponce.ErrorMessage.ErrorCode = 1;
                ClientStoreResponce.ErrorMessage.ErrorDetails = string.Empty;
            }
            catch (Exception ex)
            {
                ClientStoreResponce.ErrorMessage.ErrorCode = -1;
                ClientStoreResponce.ErrorMessage.ErrorDetails = "Something went wrong. Please try again.";
                //ClientStoreResponce.ErrorMessage.ErrorDetails = ex.Message + "." + ex.StackTrace;


            }
            return ClientStoreResponce;
        }

        [HttpGet]
        [Route("GetClientStoresForApp/{CustomerId}")]
        public GetClientStoreForAppResponse GetClientStoresForApp(string CustomerId)
        {
            GetClientStoreForAppResponse ClientStoreResponse = new GetClientStoreForAppResponse();
            ClientStoreResponse.ErrorMessage = new ErrorMessage();

            try
            {
                var customerId = Convert.ToInt32(CustomerId);

              
                var storesList = _customerMgr.GetClientStoresForApp(customerId);
                ClientStoreResponse.ClientStoresList = (from dr in storesList
                                                        select new ClientStoresForApp
                                                        {
                                                            ClientStoreId = dr.ClientStoreId,
                                                            ClientStoreName = dr.StoreName,
                                                            StorePhoneNumber = new String(dr.StorePhone.ToCharArray().Where(c => Char.IsDigit(c)).ToArray()),
                                                            AddressLine1 = dr.AddressLine1,
                                                            AddressLine2 = dr.StateName,
                                                            City = dr.City,
                                                            ZipCode = dr.ZipCode,
                                                            StoreTimings = dr.StoreTimings,
                                                            Latitude = Convert.ToDecimal(dr.Latitude),
                                                            Longitude = Convert.ToDecimal(dr.Longitude),
                                                            StateName = dr.StateName,
                                                            StoreEmail = dr.StoreEmail,
                                                            WeeklyAdStoreId = dr.WeeklyAdStoreId,
                                                            StoreNumber = (dr.StoreNumber != null ? Convert.ToInt32(dr.StoreNumber) : 0),
                                                            StoreEcomStatus = (dr.StoreEcomStatus != null ? Convert.ToBoolean(dr.StoreEcomStatus) : false),
                                                            // StoreImage = string.Concat(ConfigurationHelper.AmazonS3Url, ConfigurationHelper.AmazonBucketName, "/ClientImages/", dr.OtherPOS),
                                                            mealkitandroidstatus = Convert.ToBoolean(dr.Mealkitandroidstatus),
                                                            mealkitiosstatus = Convert.ToBoolean(dr.Mealkitiosstatus),
                                                            //ecomandroidstatus = Convert.ToBoolean(dr.Ecomandroidstatus),
                                                            //ecomiosstatus = Convert.ToBoolean(dr.Ecomiosstatus),
                                                            mealkitdeptnumber = Convert.ToInt32(dr.Mealkitdeptnumber),
                                                            mealkitlabel = dr.Mealkitlabel,
                                                            // ecomlabel = dr.Ecomlabel,
                                                        }).ToList();
                 ClientStoreResponse.EnableStoreManagement = Convert.ToBoolean(_commonMgr.GetCustomersList(Convert.ToInt32(CustomerId))[0].EnableStoreManagement);

                ClientStoreResponse.ErrorMessage.ErrorCode = 1;
                ClientStoreResponse.ErrorMessage.ErrorDetails = string.Empty;



            }
            catch (Exception ex)
            {
                ClientStoreResponse.ErrorMessage.ErrorCode = -1;
                ClientStoreResponse.ErrorMessage.ErrorDetails = "Something went wrong.Please try again";
                ClientStoreResponse.ErrorMessage.ErrorDetails = ex.Message + "." + ex.StackTrace;

            }
            return ClientStoreResponse;
        }

        [HttpGet]
        [Route("GetContactInfo")]
        public GetContactInfoResponce GetContactInfo()
        {
            GetContactInfoResponce objGetContactInfoResponce = new GetContactInfoResponce();
            objGetContactInfoResponce.ErrorMessage = new ErrorMessage();
            try
            {
                List<GetClientStores_Result> clientStoreList = new List<GetClientStores_Result>();
                clientStoreList = _customerMgr.GetClientStores(ConfigurationHelper.ClientStoreId).ToList();
                if (clientStoreList.Count > 0)
                {
                    objGetContactInfoResponce.ClientStoreId = Convert.ToInt32(clientStoreList[0].ClientStoreId);
                    objGetContactInfoResponce.ClientStoreName = clientStoreList[0].StateName;
                    objGetContactInfoResponce.AddressLine1 = clientStoreList[0].AddressLine1;
                    objGetContactInfoResponce.AddressLine2 = clientStoreList[0].AddressLine2;
                    objGetContactInfoResponce.City = clientStoreList[0].City;
                    objGetContactInfoResponce.StoreEmail = clientStoreList[0].StoreEmail;
                    objGetContactInfoResponce.StorePhoneNumber = clientStoreList[0].StorePhone;
                    objGetContactInfoResponce.ZipCode = clientStoreList[0].ZipCode;
                    objGetContactInfoResponce.State = clientStoreList[0].StateName;
                    objGetContactInfoResponce.StoreTimings = clientStoreList[0].StoreTimings;
                    objGetContactInfoResponce.PrivacyAndPolicy = ConfigurationHelper.PrivacyAndPolicy;
                    objGetContactInfoResponce.TermsAndConditions = ConfigurationHelper.TermsAndConditions;
                    objGetContactInfoResponce.SupportURL = ConfigurationHelper.SupportUrl;
                    objGetContactInfoResponce.WebSiteURL = ConfigurationHelper.ClientWebSiteUrl;
                    objGetContactInfoResponce.AllowLinkCardRegistration = ConfigurationHelper.AllowLinkCardRegistration;
                    objGetContactInfoResponce.AllowNewRegistration = ConfigurationHelper.AllowNewRegistration;

                    objGetContactInfoResponce.ClientProfile = _commonMgr.GetCustomersList(0).FirstOrDefault().CustomerProfile.ToString();
                    objGetContactInfoResponce.MemberCardMinLength = Convert.ToInt32(_appsettings?.Value.MemberCardMinLength.ToString());
                    objGetContactInfoResponce.MemberCardMaxLength = Convert.ToInt32(_appsettings?.Value.MemberCardMaxLength.ToString());

                }
                objGetContactInfoResponce.ErrorMessage.ErrorCode = 1;
                objGetContactInfoResponce.ErrorMessage.ErrorDetails = string.Empty;
            }catch (Exception ex)
            {
                objGetContactInfoResponce.ErrorMessage.ErrorCode = -1;
                objGetContactInfoResponce.ErrorMessage.ErrorDetails = "Error occured. Please try again. ";
               
            }
            return objGetContactInfoResponce;   
        }

        [HttpGet]
        [Route("GetUserProfile/{UserToken}")]
        public UserProfileResponse GetUserProfile(string UserToken)
        {
            UserProfileResponse objUserProfileResponse = null;
            objUserProfileResponse = new UserProfileResponse();
            objUserProfileResponse.ErrorMessage = new ErrorMessage();
            byte deviceId=0;
       
            try
            {
                int userId = _servicesMgr.IsTokenValid(UserToken,ref deviceId);
                if (userId > 0)
                {
                   GetUserProfile_Result userDetails = _userMgr.GetUserProfile(userId).FirstOrDefault(); 
                    if (userDetails != null)
                    {
                        UserInfo objUserInfo = null;
                        objUserInfo = new UserInfo();
                        objUserInfo.Email = userDetails.UserName;
                        objUserInfo.FirstName = (userDetails.FirstName != null ? userDetails.FirstName : "");
                        objUserInfo.LastName = (userDetails.LastName !=null ? userDetails.LastName : "");
                        objUserInfo.MemberNumber = userDetails.MemberNumber;
                        objUserInfo.FMPhoneNumber = (objUserInfo.FMPhoneNumber != null ? objUserInfo.FMPhoneNumber : "");
                        objUserInfo.IsEmployee = Convert.ToBoolean(userDetails.IsEmployee);
                        objUserInfo.PhoneNumber = userDetails.Mobile;
                      
                        objUserProfileResponse.UserDetails = objUserInfo;
                        objUserProfileResponse.ErrorMessage.ErrorCode = 1;
                        objUserProfileResponse.ErrorMessage.ErrorDetails=string.Empty;

                    }
                    else
                    {
                        objUserProfileResponse.ErrorMessage.ErrorCode = -1;
                        objUserProfileResponse.ErrorMessage.ErrorDetails = "Something went wrong. Please try again.";
                    }
                }
                else
                {
                    objUserProfileResponse.ErrorMessage.ErrorCode = -1001;
                    objUserProfileResponse.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";

                }

            }catch (Exception ex)
            {
                objUserProfileResponse.ErrorMessage.ErrorCode = -1;
                objUserProfileResponse.ErrorMessage.ErrorDetails = "Something went wrong. Please try again.";
                 
            }
            return (objUserProfileResponse);
        }

        [HttpGet]
        [Route("GetBasketReward/{UserToken}")]
        public BasketRewardResponse GetBasketReward(string UserToken)
        {
            BasketRewardResponse objBasketRewardResponse = null;
            objBasketRewardResponse = new BasketRewardResponse();
            objBasketRewardResponse.ErrorMessage = new ErrorMessage();
            objBasketRewardResponse.ErrorMessage.OfflineMessage = ConfigurationHelper.MyRewardsOfflineMsg;
            byte deviceId = 0;
            try
            {
                int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
                if (userId > 0)
                {
                    List<LM_GetBasketRewardForMobileApi_Result> basketRewardInfo = _commonMgr.GetBasketReward(userId).ToList();
                    if (basketRewardInfo.Count > 0)
                    {
                        BasketReward objBasketReward = null;
                        objBasketReward = new BasketReward();
                        objBasketReward.LMRewardId = basketRewardInfo[0].LMRewardId;
                        objBasketReward.Title = basketRewardInfo[0].Title;
                        objBasketReward.RewardTitle = basketRewardInfo[0].RewardTitle;
                        objBasketReward.ImageUrl = _imageMgr.GetImageUrl(userId, (basketRewardInfo[0].RewardTypeId == Convert.ToInt32(EnumMgr.SpecialsTypes.BasketDeals) ? EnumMgr.UploadLocations.SpecialsLogo : EnumMgr.UploadLocations.SpecialsLogo), basketRewardInfo[0].RewardImageURL, false);
                        objBasketReward.BuyQtyAmount = Convert.ToInt32(basketRewardInfo[0].BuyQtyAmount);
                        objBasketReward.PurchasedQty = Convert.ToInt32(basketRewardInfo[0].PurchasedQty);
                        objBasketReward.RoundedPurchasedAmount = Convert.ToInt32(Math.Floor(Convert.ToDecimal(basketRewardInfo[0].PurchasedAmount)));
                        objBasketRewardResponse.BasketRewardDetails = objBasketReward;
                        objBasketRewardResponse.TotalSavingsAmount = (basketRewardInfo[0].RedeemAmount != null ? Convert.ToDecimal(basketRewardInfo[0].RedeemAmount) : 0);

                    }
                    objBasketRewardResponse.ErrorMessage.ErrorCode = 1;
                    objBasketRewardResponse.ErrorMessage.ErrorDetails = string.Empty;
                
                }
                
                
                else
                {
                    objBasketRewardResponse.ErrorMessage.ErrorCode = -1001;
                    objBasketRewardResponse.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";
                }
            }catch(Exception ex)
            {
                objBasketRewardResponse.ErrorMessage.ErrorCode = -1001;
                objBasketRewardResponse.ErrorMessage.ErrorDetails = "Something went wrong. Please try again.";
                //objBasketRewardResponse.ErrorMessage.ErrorDetails = ex.Message;
            }
            return objBasketRewardResponse;
        }

        [HttpGet]
        [Route("GetRecentBaskets/{UserToken}")]
        public RecentBasketsResponce GetRecentBaskets(string UserToken)
        {
            RecentBasketsResponce objRecentBasketResponce = new RecentBasketsResponce();
            objRecentBasketResponce.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if(userId > 0)
                {
                    objRecentBasketResponce.RecentBaskets = (from dr in _commonMgr.GetRecentBaskets()
                                                             select new RecentBaskets
                                                             {
                                                                 StoreId = Convert.ToInt32(dr.StoreId),
                                                                 StoreName = dr.StoreName,
                                                                 Amount = Convert.ToDecimal(dr.Amount),
                                                                 MemberNumber = dr.MemberNumber,
                                                                 TransactionDate = Convert.ToDateTime(dr.TransactionDate),
                                                                 TransactionTime = dr.TransactionTime.ToString(),
                                                                 UserName = dr.UserName,
                                                                 
                                                             }
                                                           ).ToList();
                    objRecentBasketResponce.ErrorMessage.ErrorCode = 1;
                    objRecentBasketResponce.ErrorMessage.ErrorDetails=string.Empty;
                }
                else
                {
                    objRecentBasketResponce.ErrorMessage.ErrorCode = -1001;
                    objRecentBasketResponce.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";
                }

            }catch(Exception ex)
            {
                objRecentBasketResponce.ErrorMessage.ErrorCode = -1;
                objRecentBasketResponce.ErrorMessage.ErrorDetails = "Error occured. Please try again.";

            }

            return objRecentBasketResponce;
        }

        [HttpGet]
        [Route("GetRecentRedemptions/{UserToken}")]
        public RecentRedemptionsResponce GetRecentRedemptions(string UserToken)
        {
            RecentRedemptionsResponce objRecentRedemptionsResponce = new RecentRedemptionsResponce();
            objRecentRedemptionsResponce.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if(userId > 0)
                {
                    objRecentRedemptionsResponce.RecentRedemptions = (from dr in _commonMgr.GetRecentRedemptions()
                                                                      select new RecentRedemptions
                                                                      {
                                                                          MemberNumber = dr.MemberNumber,
                                                                          PromotionId = dr.PromotionId,
                                                                          RedeemAmount = Convert.ToDecimal(dr.RedeemAmount),
                                                                          CreatedDate = Convert.ToDateTime(dr.CreatedDate),   
                                                                          UserName = dr.UserName,   
                                                                      }
                                                                     ).ToList();
                    objRecentRedemptionsResponce.ErrorMessage.ErrorCode = 1;
                    objRecentRedemptionsResponce.ErrorMessage.ErrorDetails=string.Empty;
                }
                else
                {
                    objRecentRedemptionsResponce.ErrorMessage.ErrorCode = -1001;
                    objRecentRedemptionsResponce.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";

                }
            }catch(Exception ex)
            {
                objRecentRedemptionsResponce.ErrorMessage.ErrorCode = -1;
                objRecentRedemptionsResponce.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }

            return objRecentRedemptionsResponce;
        }
        [HttpGet]
        [Route("GetRecentClips/{UserToken}")]
        public RecentClipsResponce GetRecentClips(string UserToken)
        {
            RecentClipsResponce objRecentClipsResponce = new RecentClipsResponce();
            objRecentClipsResponce.ErrorMessage = new ErrorMessage();
            byte deviceId=0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if(userId > 0)
                {
                    objRecentClipsResponce.RecentClips = (from dr in _commonMgr.GetRecentClips()
                                                          select new RecentClips
                                                          {
                                                            MemberNumber = dr.BarcodeValue,
                                                            Title = dr.Title,
                                                            Details = dr.Details,
                                                            Username = dr.UserName,
                                                            NCRImpressionDate = Convert.ToDateTime(dr.NCRImpressionDate),
                                                          }
                                                          ).ToList();
                   objRecentClipsResponce.ErrorMessage.ErrorCode= 1;
                   objRecentClipsResponce.ErrorMessage.ErrorDetails=string.Empty;
                }
                else
                {
                    objRecentClipsResponce.ErrorMessage.ErrorCode = -1001;
                    objRecentClipsResponce.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";
                }
            }catch(Exception ex)
            {
                objRecentClipsResponce.ErrorMessage.ErrorCode = -1;
                objRecentClipsResponce.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }
            return objRecentClipsResponce;
        }
        [HttpGet]
        [Route("GetSlides/{UserToken}")]
        public SlidesResponce GetSlides(string UserToken)
        {
            SlidesResponce objSlidesResponce = new SlidesResponce();
            objSlidesResponce.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
               if(userId > 0)
                {
                    objSlidesResponce.Slides = (from dr in _commonMgr.GetSlides()
                                                select new Slide
                                                {
                                                    SlideId = Convert.ToInt32(dr.SlideId),
                                                    IsDealOfTheWeek = Convert.ToBoolean(dr.IsDealOfTheWeek),
                                                    IsActive = Convert.ToBoolean(dr.IsActive),
                                                    ImageUrl = string.Concat(ConfigurationHelper.AmazonS3Url, ConfigurationHelper.AmazonBucketName, "/", ConfigurationHelper.SlidesFolderNameInS3, "/", dr.ImageUrl),
                                                    FeaturedText = dr.FeaturedText,
                                                    CreatedDate=Convert.ToDateTime(dr.CreatedDatetime),

                                                }
                                                ).ToList();
                    objSlidesResponce.ErrorMessage.ErrorCode = 1;
                    objSlidesResponce.ErrorMessage.ErrorDetails=string.Empty;
                }
                else
                {
                    objSlidesResponce.ErrorMessage.ErrorCode = -1001;
                    objSlidesResponce.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";
                }

            }catch(Exception ex)
            {
                objSlidesResponce.ErrorMessage.ErrorCode = -1;
                objSlidesResponce.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }
            return objSlidesResponce;
        }
        [HttpGet]
        [Route("GetMenuList/{UserToken}")]
        public MenuListResponce GetMenuList(string UserToken)
        {
            MenuListResponce objMenuListResponce = new MenuListResponce();
            objMenuListResponce.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if(userId > 0) { 
                  objMenuListResponce.MenuList = (from dr in _commonMgr.GetMenuList()
                                                  select new Menu
                                                  {
                                                      MenuId = Convert.ToInt32(dr.MenuId),
                                                      MenuSequenceNumber = Convert.ToInt32(dr.MenuSequenceNumber),
                                                      IsActive = Convert.ToBoolean(dr.IsActive),
                                                      ImageUrl = string.Concat(ConfigurationHelper.AmazonS3Url, ConfigurationHelper.AmazonBucketName, "/", ConfigurationHelper.MenuImagesFolderNameInS3, "/", dr.ImageUrl),
                                                      MenuTitle = dr.MenuTitle,
                                                      CreatedDate = Convert.ToDateTime(dr.CreatedDateTime),
                                                      ColorCode = dr.ColorCode,
                                                  }
                                                  ).ToList() ;
                    objMenuListResponce.ErrorMessage.ErrorCode = 1;
                    objMenuListResponce.ErrorMessage.ErrorDetails =string.Empty;
                }
                else
                {
                    objMenuListResponce.ErrorMessage.ErrorCode = -1001;
                    objMenuListResponce.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";
                }
            }
            catch(Exception ex)
            {
                objMenuListResponce.ErrorMessage.ErrorCode = -1;
                objMenuListResponce.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }
            return objMenuListResponce;
        }
        [HttpGet]
        [Route("GetMyCardAndSaveAmountInfo/{UserToken}")]
        public UserMyCardResponce GetMyCardAndSaveAmountInfo(string UserToken)
        {
            UserMyCardResponce objUserMyCardResponce = new UserMyCardResponce();
            objUserMyCardResponce.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if (userId > 0)
                {
                    List<GetUserCardInfo_Result> userCardInfo= _userMgr.GetUserCardInfo(userId).ToList();
                    if (userCardInfo.Count > 0)
                    {
                        objUserMyCardResponce.BarCodeUrl = string.Concat(ConfigurationHelper.BarCodeUrlPath, "BarcodeImages/", userCardInfo[0].BarcodeImage);
                        objUserMyCardResponce.MemberNumber = userCardInfo[0].BarcodeValue;
                        objUserMyCardResponce.TotalPurchasedAmount =  (userCardInfo[0].TotalPurchaseAmount != null ? Convert.ToDecimal(userCardInfo[0].TotalPurchaseAmount) : 0);
                        objUserMyCardResponce.TotalSavingsAmount = (userCardInfo[0].RedeemAmount != null ? Convert.ToInt32(userCardInfo[0].RedeemAmount) : 0);

                        objUserMyCardResponce.ErrorMessage.ErrorCode = 1;
                        objUserMyCardResponce.ErrorMessage.ErrorDetails=string.Empty;
                     

                    }
                    else
                    {
                        objUserMyCardResponce.ErrorMessage.ErrorCode = -1;
                        objUserMyCardResponce.ErrorMessage.ErrorDetails = "Error occured while getting User Card Info. Please try again.";

                    }
                }
                else
                {
                    objUserMyCardResponce.ErrorMessage.ErrorCode = -1001;
                    objUserMyCardResponce.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";

                }
            }catch(Exception ex)
            {
                objUserMyCardResponce.ErrorMessage.ErrorCode = -1;
                objUserMyCardResponce.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }
            
            return objUserMyCardResponce;
        }
        [HttpGet]
        [Route("GetRecipeCategories/{UserToken}")]
        public RecipeCategoriesResponce GetRecipeCategories(string UserToken)
        {
            RecipeCategoriesResponce objRecipeCategoriesResponce = new RecipeCategoriesResponce();
            objRecipeCategoriesResponce.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if(userId > 0)
                {
                    objRecipeCategoriesResponce.RecipeCategories = (from dr in _commonMgr.GetRecipeCategories()
                                                                    select new RecipeCategories
                                                                    {
                                                                        RecipeCategoryId = Convert.ToInt32(dr.RecipeCategoryId),
                                                                        CategoryName = dr.CategoryName,
                                                                       ImageUrl = string.Concat(ConfigurationHelper.AmazonS3Url,ConfigurationHelper.AmazonBucketName,"/",ConfigurationHelper.RecipeCategoryImagesFolderNameInS3,"/",dr.ImageUrl),
                                                                       RecipesCount = Convert.ToInt32(dr.RecipesCount),
                                                                         
                                                                    }
                                                                   ).ToList();
                    objRecipeCategoriesResponce.ErrorMessage.ErrorCode = 1;
                    objRecipeCategoriesResponce.ErrorMessage.ErrorDetails=string.Empty;
                }
                else
                {
                    objRecipeCategoriesResponce.ErrorMessage.ErrorCode = -1001;
                    objRecipeCategoriesResponce.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";
                }

            }catch(Exception ex)
            {
                objRecipeCategoriesResponce.ErrorMessage.ErrorCode = -1;
                objRecipeCategoriesResponce.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }
            return objRecipeCategoriesResponce;
        }

        [HttpGet]
        [Route("WeeklyAdGallery/{UserToken}/{StoreId}")]
        public WeeklyAdGalleryResponse WeeklyAdGallery(string UserToken, string StoreId)
        {
                WeeklyAdGalleryResponse objWeeklyAdGalleryResponse = new WeeklyAdGalleryResponse();
            objWeeklyAdGalleryResponse.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if(userId > 0)
                {
                    List<GetWeeklyAdGallery_Result> weeklyAdGalleryList = new List<GetWeeklyAdGallery_Result>();
                    weeklyAdGalleryList = _userMgr.GetWeeklyAdGallery(Convert.ToInt32(StoreId)).ToList();
                    if(weeklyAdGalleryList.Count > 0)
                    {
                        objWeeklyAdGalleryResponse.AdStartDate = Convert.ToDateTime(weeklyAdGalleryList[0].ValidFromDate);
                        objWeeklyAdGalleryResponse.AdEndDate = Convert.ToDateTime(weeklyAdGalleryList[0].Expireson);
                        objWeeklyAdGalleryResponse.AdStartDateString = Convert.ToDateTime(weeklyAdGalleryList[0].ValidFromDate).ToString("MM/dd/yyyy");
                        objWeeklyAdGalleryResponse.AdEndDateString = Convert.ToDateTime(weeklyAdGalleryList[0].Expireson).ToString("MM/dd/yyyy");
                        objWeeklyAdGalleryResponse.GalleryItems = (from dr in weeklyAdGalleryList
                                                                   select new GalleryItems
                                                                   {
                                                                       PageNumber = dr.PageNumber,
                                                                       URL=string.Concat(ConfigurationHelper.AmazonS3Url,ConfigurationHelper.AmazonBucketName,ConfigurationHelper.WeeklyAdPdfFolderName,dr.PdfFileName),
                                                                       GalleryType = (dr.PdfFileName != null ? (_imageMgr.GetFileExtensionType(dr.PdfFileName)) : "")
                                                                   }
                                                                 ).ToList();
                        objWeeklyAdGalleryResponse.ErrorMessage.ErrorCode = 1;
                        objWeeklyAdGalleryResponse.ErrorMessage.ErrorDetails = string.Empty;

                    }
                    else
                    {
                        objWeeklyAdGalleryResponse.ErrorMessage.ErrorCode = -1;
                        objWeeklyAdGalleryResponse.ErrorMessage.ErrorDetails = "No WeeklyAds available."; 
                    }
                }
                else
                {
                    objWeeklyAdGalleryResponse.ErrorMessage.ErrorCode = -1001;
                    objWeeklyAdGalleryResponse.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";

                }

            }catch(Exception ex)
            {
                objWeeklyAdGalleryResponse.ErrorMessage.ErrorCode = -1;
                objWeeklyAdGalleryResponse.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }


            return objWeeklyAdGalleryResponse;
        }

        [HttpGet]
        [Route("GetWeeklyAdsBeforeLogin")]
        public SpecialSResponce GetWeeklyAdsBeforeLogin()
        {
            SpecialSResponce objSpecialResponce = new SpecialSResponce();
            objSpecialResponce.ErrorMessage = new ErrorMessage();

            try
            {
                objSpecialResponce.Specials = (from dr in _commonMgr.GetWeeklyAdsForBeforeLogin()
                                               select new Specials
                                               {
                                                   SSNewsId = dr.NewsID,
                                                   Title = dr.Title,
                                                   Details = dr.Details,
                                                   ImagePath = (dr.ImagePath.Contains("shoptocook") ? dr.ImagePath : (dr.ImagePath.Contains("/") ? dr.ImagePath :
                                                   (dr.ImagePath == ConstantMgr.CompanyLogo ? (dr.ProductImage.Contains("/") ? dr.ProductImage : _imageMgr.GetImageUrl(1, EnumMgr.UploadLocations.ProductsLogo, dr.ProductImage, false)) :
                                                     _imageMgr.GetImageUrl(1, (dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? EnumMgr.UploadLocations.WeeklySpecialsLogo : EnumMgr.UploadLocations.SpecialsLogo), dr.ImagePath, false)))),
                                                   CustomerID = 1,
                                                   ValidFromDate = Convert.ToDateTime(dr.ValidFromDate),
                                                   ExpiresOn = Convert.ToDateTime(dr.ExpiresOn),
                                                   SendNotification = false,
                                                   NewsCategoryDescription = dr.CategoryName,
                                                   // IsWeeklyCoupons =(dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? false : true),
                                                   IsWeeklyCoupons = (dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.ProductCoupons) || dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.BasketDeals)
                                                   || dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.ManufacturerCoupon)
                                                   || dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.GroupCoupon)
                                                   || dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.GroupBasketCoupon)
                                                   || dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.BogoCoupon)) ? true : false,
                                                   ProductName = dr.ProductName,
                                                   Amoount = Convert.ToDecimal(dr.Amount),
                                                   DiscountAmoount = Convert.ToDecimal(dr.DiscountAmount),
                                                   IsDiscountPercentage = Convert.ToBoolean(dr.IsDiscountPercentage),
                                                   ProductId = Convert.ToInt32(dr.ProductId),
                                                   IsRedeem = (dr.ISRedeemed == 1 ? true : false),
                                                   IsInCart = (dr.IsInCart == 1 ? true : false),
                                                   //PLUCode = dr.PUICode,
                                                  // NCRPromotionCode =dr.NCRPromotionCode,
                                                  //IsInNCRImpressions = Convert.ToBoolean(dr.IsInNCRImpressions),
                                                  NewsCategoryId = Convert.ToInt32(dr.NewsCategoryID),
                                                  IsFeatured = Convert.ToBoolean(dr.IsFeatured),
                                                  ProductCategoryId = Convert.ToInt32(dr.ProductCategoryId),
                                                  SpecialPrice =(dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? (dr.SpecialPrice !=null ? dr.SpecialPrice :"0") :"0" ),
                                                  DepartmentName=(dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? (dr.DepartmentName !=null ? dr.DepartmentName : string.Empty) : string.Empty),

                                               }
                                            ).ToList();
                objSpecialResponce.ErrorMessage.ErrorCode = 1;
                objSpecialResponce.ErrorMessage.ErrorDetails=string.Empty;

            }catch(Exception ex)
            {
                objSpecialResponce.ErrorMessage.ErrorCode = -1;
                objSpecialResponce.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }
            return objSpecialResponce;
        }
        [HttpGet]
        [Route("GetTerms/{UserToken}")]
        public TermsResponse GetTerms(string UserToken)
        { 
            TermsResponse objTermsResponse = new TermsResponse();   
            objTermsResponse.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if(userId > 0)
                {
                    List<Terms> termsInfo = new List<Terms>();
                    termsInfo.Add(new Terms { 
                        Title=_appsettings?.Value.PrivacyTermsTitle.ToString(),
                        URL = _appsettings?.Value.PrivacyTermsUrl.ToString(),
                    });
                    termsInfo.Add(new Terms
                    {
                        Title = _appsettings?.Value.TermsAndConditionsTitle.ToString(),
                        URL = _appsettings?.Value.TermsAndConditionsUrl.ToString(),
                    });
                    objTermsResponse.Terms = (from dr in termsInfo
                                              select new Terms
                                              {
                                                  Title = dr.Title,
                                                  URL= dr.URL,  

                                              }).ToList<Terms>();
                    objTermsResponse.ErrorMessage.ErrorCode = 1;
                    objTermsResponse.ErrorMessage.ErrorDetails=string.Empty;
                }
                else
                {
                    objTermsResponse.ErrorMessage.ErrorCode = -1001;
                    objTermsResponse.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";
                }

            }catch(Exception ex)
            {
                objTermsResponse.ErrorMessage.ErrorCode = -1;
                objTermsResponse.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }
            return objTermsResponse;
        }
        [HttpGet]
        [Route("GetOrders/{UserToken}/{OrderId}")]
        public GetOrdersResponse GetOrders(string UserToken, string OrderId)
        {
            GetOrdersResponse objOrdersResponse = new GetOrdersResponse();
            objOrdersResponse.ErrorMessage = new ErrorMessage();
            try
            {
                byte deviceId = 0;
                int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
                if (userId > 0)
                {
                    List<TF_GETORDERS_Result> ordersList = _userMgr.GetOrders(userId).ToList();
                    if (ordersList.Count > 0) {
                        objOrdersResponse.OrderInfo = (from dr in ordersList
                                                       select new UserOrderInfo
                                                       {
                                                           OrderId = Convert.ToInt32(dr.OrderID),
                                                           UserID = userId,
                                                           OrderNumber = dr.OrderNumber,
                                                           OrderDate = Convert.ToDateTime(dr.OrderDate),
                                                           ShippingAddressID = Convert.ToInt32(dr.ShippingAddressID),
                                                           DeliveryDate = Convert.ToDateTime(dr.DeliveryDate),
                                                           ServicingLocationID = Convert.ToInt32(dr.ServicingLocationID),
                                                           //CreatedDate = Convert.ToDateTime(dr.CreatedDateTime)
                                                           OrderDetailInfo = (from item in _userMgr.GetOrderDetails(Convert.ToInt32(dr.OrderID)).ToList()
                                                                              select new UserOrderDetails
                                                                              {
                                                                                  OrderId = Convert.ToInt32(item.OrderID),
                                                                                  OrderItemID = Convert.ToInt32(item.OrderItemID),
                                                                                  NewsID = Convert.ToInt32(item.NewsID),
                                                                                  Qty = Convert.ToInt32(item.Qty),
                                                                                  Price = Convert.ToDecimal(item.Price),
                                                                                  Amount = Convert.ToDecimal(item.Amount),
                                                                                  CreatedDate = Convert.ToDateTime(item.CreatedDateTime)



                                                                              }
                                                                              ).ToList(),
                                                           UserOrderPaymentInfo = (from dt in _userMgr.GetOrderPayments(Convert.ToInt32(dr.OrderID)).ToList()
                                                                                   select new UserOrderPayments
                                                                                   {
                                                                                       OrderId = Convert.ToInt32(dt.OrderID),
                                                                                       PaymentTypeID = Convert.ToInt32(dt.PaymentTypeID),
                                                                                       PaymentConfirmation = Convert.ToBoolean(dt.PaymentConfirmation),
                                                                                       Amount = Convert.ToDecimal(dt.Amount)
                                                                                   }).FirstOrDefault()

                                                       }
                                                       ).ToList();
                        objOrdersResponse.ErrorMessage.ErrorCode = 1;
                        objOrdersResponse.ErrorMessage.ErrorDetails = string.Empty;
                    }
                    else
                    {
                        objOrdersResponse.ErrorMessage.ErrorCode = 1;
                        objOrdersResponse.ErrorMessage.ErrorDetails = "No Orders";
                    }
                }
                else
                {
                    objOrdersResponse.ErrorMessage.ErrorCode = -1001;
                    objOrdersResponse.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";
                }

            } catch (Exception ex) {
                objOrdersResponse.ErrorMessage.ErrorCode = -1;
                objOrdersResponse.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }
            return objOrdersResponse;
        }
        [HttpPost]
        [Route("GetAllMenu")]
        public MenuResponse GetAllMenu(MenuRequest Model)
        {
            MenuResponse objMenuResponse = new MenuResponse();
            objMenuResponse.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(Model.UserToken, ref deviceId);
            try
            {
                if(userId > 0)
                {
                    List<TF_GetAllMenu_Result> menuList = _userMgr.GetAllMenu(0, userId, Model.StoreID, Model.DeliveryDate, Model.DeliverAddressID).ToList();
                    if(menuList.Count > 0)
                    {
                        objMenuResponse.MenuList = (from dr in  menuList
                                                    select new MenuItems
                                                    {
                                                        SSNewsId = Convert.ToInt32(dr.NewsID),
                                                        Title = dr.Title,
                                                        Details = dr.Details,
                                                        ImagePath = (dr.ImagePath.Contains("shoptocook") ? dr.ImagePath : (dr.ImagePath.Contains("/") ? dr.ImagePath :
                                                        (
                                                        dr.ImagePath == ConstantMgr.CompanyLogo ? (dr.ProductImage.Contains("/") ?  dr.ProductImage : 
                                                        _imageMgr.GetImageUrl(userId,EnumMgr.UploadLocations.ProductsLogo,dr.ProductImage,false) )  :
                                                        _imageMgr.GetImageUrl(
                                                            userId,(dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? EnumMgr.UploadLocations.WeeklySpecialsLogo : EnumMgr.UploadLocations.WeeklySpecialsLogo), dr.ImagePath,false
                                                            )
                                                        ) )),
                                                        CustomerID = Convert.ToInt32(dr.CustomerID),    
                                                        CustomerName = dr.CustomerName,
                                                        ValidFromDate = Convert.ToDateTime(dr.ValidFromDate),
                                                        ExpiresOn = Convert.ToDateTime(dr.ExpiresOn),
                                                        SendNotification =Convert.ToBoolean(dr.SendNotification),
                                                        NewsCategoryDescription = dr.CategoryName,
                                                       // IsWeeklyCoupons =(dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? false : true),
                                                       IsWeeklyCoupons = (
                                                       dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.ProductCoupons) ||
                                                       dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.BasketDeals) ||
                                                       dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.ManufacturerCoupon) ||
                                                       dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.BogoCoupon) ||
                                                       dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.GroupCoupon)    ? true : false),
                                                       ProductName = dr.ProductName,
                                                       Amount = Convert.ToDecimal(dr.Amount),   
                                                       DiscountAmount = Convert.ToDecimal(dr.DiscountAmount),   
                                                       IsDiscountPercentage =Convert.ToBoolean(dr.IsDiscountPercentage),
                                                       ProductId = Convert.ToInt32(dr.ProductId),
                                                       RedeemDate = (dr.RedeemOn !=null ? Convert.ToDateTime(dr.RedeemOn).ToString("MM/dd/yyyy HH:mm:ss") : ""),
                                                       IsRedeem = (dr.ISRedeemed == 1 ? true : false),
                                                       IsInCart = (dr.IsInCart == 1 ? true : false),    
                                                       PLUCode = dr.PUICode,
                                                       NCRPromotionCode = dr.NCRPromotionCode,
                                                       IsInNCRImpressions = Convert.ToBoolean(dr.IsInNCRImpression),
                                                       NewsCategoryId = Convert.ToInt32(dr.NewsCategoryID),
                                                       IsFeatured = Convert.ToBoolean(dr.IsFeatured),
                                                       ProductCategoryId = Convert.ToInt32(dr.ProductCategoryId),
                                                       SpecialPrice = (dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials)  ?  (dr.SpecialPrice !=null ? dr.SpecialPrice : "0") :"0" ),
                                                       DepartmentName = (dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? (dr.DepartmentName !=null ? dr.DepartmentName :"0" ) : "0")


                                                    }
                                                    ).ToList();
                        objMenuResponse.ErrorMessage.ErrorCode = 1;
                        objMenuResponse.ErrorMessage.ErrorDetails=string.Empty;

                    }
                    else
                    {
                        objMenuResponse.ErrorMessage.ErrorCode = 1;
                        objMenuResponse.ErrorMessage.ErrorDetails = "No Items available.";
                    }
                }
                else
                {
                        objMenuResponse.ErrorMessage.ErrorCode= -1001;
                        objMenuResponse.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";

                }
                

            }catch(Exception ex)
            {
                objMenuResponse.ErrorMessage.ErrorCode = -1;
                objMenuResponse.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }
            return objMenuResponse;
        }

        [HttpGet]
        [Route("GetUserRedeemedCoupons/{UserToken}/{UserId}")]
        public UserRedeemedCouponsResponse GetUserRedeemedCoupons(string UserToken, string UserId)
        {
           UserRedeemedCouponsResponse objUserRedeemedCouponsResponse = new UserRedeemedCouponsResponse();
            objUserRedeemedCouponsResponse.ErrorMessage = new ErrorMessage();
           // byte deviceId = 0;  
           // int userId= _servicesMgr.IsTokenValid(UserToken, ref deviceId);
           int userId = Convert.ToInt32(UserId);
            try
            {
               if(userId > 0)
                {
                    List<GetUserRedeemedCoupons_Result> userRedeemedCouponsList = _couponsMgr.GetUserRedeemedCoupons(userId).ToList();
                    //List<int> litem = new List<int>();  
                    if(userRedeemedCouponsList.Count > 0)
                    {
                        objUserRedeemedCouponsResponse.CouponIds = userRedeemedCouponsList.Select(m=>m.NewsId).ToArray();

                        //foreach(var item in userRedeemedCouponsList)
                        //{
                        //    litem.Add(item.NewsId);
                        //}
                    }
                   // objUserRedeemedCouponsResponse.CouponIds = litem.ToArray();
                   objUserRedeemedCouponsResponse.ErrorMessage.ErrorCode = 1;
                   objUserRedeemedCouponsResponse.ErrorMessage.ErrorDetails =string.Empty;
                }
                else
                {
                    objUserRedeemedCouponsResponse.ErrorMessage.ErrorCode = -1001;
                    objUserRedeemedCouponsResponse.ErrorMessage.ErrorDetails ="Your session is expired. Please login again.";

                }
            }catch(Exception ex)
            {
                objUserRedeemedCouponsResponse.ErrorMessage.ErrorCode = -1;
                objUserRedeemedCouponsResponse.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }
            return objUserRedeemedCouponsResponse;  
        }

        [HttpGet]
        [Route("GetUserGroups/{UserToken}/{UserId}")]
        public UserGroupsResponse GetUserGroups(string UserToken, string UserId)
        {
            UserGroupsResponse objUserGroupResponse = new UserGroupsResponse();
            objUserGroupResponse.ErrorMessage = new ErrorMessage();
           // byte deviceId = 0;
           // int userId= _servicesMgr.IsTokenValid(UserToken,ref deviceId);
             int userId = Convert.ToInt32(UserId); try
            {
                if(userId > 0)
                {
                    List<GetUserGroups_Result>  userGroupsList = _userMgr.GetUserGroups(userId);
                  //  List<int> litem = new List<int>();
                    if(userGroupsList.Count > 0)
                    {
                        objUserGroupResponse.GroupIds = userGroupsList.Select(m => m.ClubId).ToArray();
                        //foreach(var item in userRedeemedCouponsList)
                        //{
                        //    litem.Add(item.NewsId);
                        //}
                    }
                    // objUserRedeemedCouponsResponce.CouponIds = litem.ToArray();
                    objUserGroupResponse.ErrorMessage.ErrorCode = 1;
                    objUserGroupResponse.ErrorMessage.ErrorDetails=string.Empty;

                }
                else
                {
                    objUserGroupResponse.ErrorMessage.ErrorCode = -1001;
                    objUserGroupResponse.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";

                }
            }catch(Exception ex)
            {
                objUserGroupResponse.ErrorMessage.ErrorCode = -1;
                objUserGroupResponse.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }

            return objUserGroupResponse;
        }

        [HttpGet]
        [Route("GetUserCouponsAndGroups/{UserToken}/{UserId}")]
        public UserCouponsAndGroupsResponse GetUserCouponsAndGroups(string UserToken, string UserId)
        {
            UserCouponsAndGroupsResponse objUserCouponsAndGroupsResponse = new UserCouponsAndGroupsResponse();
            objUserCouponsAndGroupsResponse.ErrorMessage = new ErrorMessage();
           // byte deviceId = 0;
           // int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
           int userId = Convert.ToInt32(UserId);
            try
            {
                if(userId > 0)
                {
                   FinalUserCouponsandGroups userCouponsAndGroupsList = _multipleResultSets.GetUserCouponsandGroups(userId);
                    objUserCouponsAndGroupsResponse.RedeemedCouponIds = userCouponsAndGroupsList.UserRedeemedCoupons.Select(m=>m.NewsID).ToArray();
                    objUserCouponsAndGroupsResponse.OptInCouponIds =userCouponsAndGroupsList.UserOptionCoupons.Select(m=>m.SSNewsID).ToArray();
                    objUserCouponsAndGroupsResponse.GroupIds = userCouponsAndGroupsList.UserGroups.Select(m=>m.ClubID).ToArray();

                    objUserCouponsAndGroupsResponse.ErrorMessage.ErrorCode = 1;
                    objUserCouponsAndGroupsResponse.ErrorMessage.ErrorDetails =string.Empty;

                }
                else
                {
                    objUserCouponsAndGroupsResponse.ErrorMessage.ErrorCode = -1001;
                    objUserCouponsAndGroupsResponse.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";
                }

            }catch(Exception ex)
            {

                objUserCouponsAndGroupsResponse.ErrorMessage.ErrorCode = -1;
                objUserCouponsAndGroupsResponse.ErrorMessage.ErrorDetails = "Error occured. Please try again.";

            }

            return objUserCouponsAndGroupsResponse; 
        }

        [HttpGet]
        [Route("GetAllCouponsBeforeLogIn/{Token}")]
        public SpecialSResponce GetAllCouponsBeforeLogIn(string Token)
        {
            SpecialSResponce objSpecialSResponce = new SpecialSResponce();
            objSpecialSResponce.ErrorMessage = new ErrorMessage();

            objSpecialSResponce.ErrorMessage.OfflineMessage = ConfigurationHelper.JustForYouOfflineMsg;
            byte deviceId = 0;
            int userId = 1;
            try
            {
                if(userId > 0)
                {
                    List<GetAllCouponsBeforeLogin_Result> finalCouponsList = new List<GetAllCouponsBeforeLogin_Result>();
                    finalCouponsList = _commonMgr.GetAllCouponsBeforeLogin(Token).ToList();
                    objSpecialSResponce.Specials =(from dr in  finalCouponsList
                                                   select new Specials
                                                   {
                                                       SSNewsId = dr.NewsID,
                                                       Title = dr.Title,
                                                       Details = dr.Details,
                                                       ImagePath = (dr.ImagePath.Contains("shoptocook") ? dr.ImagePath : (dr.ImagePath.Contains("/") ? dr.ImagePath :
                                                                (dr.ImagePath == ConstantMgr.CompanyLogo ? (dr.ProductImage.Contains("/") ? dr.ProductImage : _imageMgr.GetImageUrl(userId, EnumMgr.UploadLocations.ProductsLogo, dr.ProductImage, false)) :
                                                                  _imageMgr.GetImageUrl(userId, (dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? EnumMgr.UploadLocations.WeeklySpecialsLogo : EnumMgr.UploadLocations.SpecialsLogo), dr.ImagePath, false)))),
                                                       CustomerID =Convert.ToInt32(dr.CustomerID),
                                                       CustomerName = dr.CustomerName,
                                                       ValidFromDate = Convert.ToDateTime(dr.ValidFromDate),
                                                       ExpiresOn = Convert.ToDateTime(dr.ExpiresOn),
                                                       SendNotification = Convert.ToBoolean(dr.SendNotification),
                                                       NewsCategoryDescription = dr.CategoryName,
                                                       // IsWeeklyCoupons =(dr.NewsCategoryID  == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? false : true)
                                                       IsWeeklyCoupons = (
                                                       dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.ProductCoupons)  ||
                                                       dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.ManufacturerCoupon) ||
                                                       dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.GroupBasketCoupon) ||
                                                       dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.BogoCoupon) ||
                                                       dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.GroupCoupon) ? true : false),
                                                       ProductName = dr.ProductName,
                                                       Amoount = Convert.ToDecimal(dr.Amount),
                                                       DiscountAmoount = Convert.ToDecimal(dr.DiscountAmount),
                                                       IsDiscountPercentage = Convert.ToBoolean(dr.IsDiscountPercentage),
                                                       ProductId = Convert.ToInt32(dr.ProductId),
                                                       RedeemDate = (dr.RedeemOn != null ? Convert.ToDateTime(dr.RedeemOn).ToString("MM/dd/yyyy HH:mm:ss") : ""),
                                                       IsRedeem = (dr.ISRedeemed ==1 ? true :false),
                                                       IsInCart = (dr.IsInCart == 1 ? true :false),
                                                       PLUCode = dr.PUICode,
                                                       NCRPromotionCode = dr.NCRPromotionCode,
                                                       IsInNCRImpressions = Convert.ToBoolean(dr.IsInNCRImpression),
                                                       NewsCategoryId = Convert.ToInt32(dr.NewsCategoryID),
                                                       IsFeatured = Convert.ToBoolean(dr.IsFeatured),
                                                       ProductCategoryId = Convert.ToInt32(dr.ProductCategoryId),
                                                       SpecialPrice = (dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? (dr.SpecialPrice !=null ? dr.SpecialPrice :"0") : "0"),
                                                       DepartmentName = (dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? (dr.DepartmentName != null ? dr.DepartmentName : string.Empty) : string.Empty),
                                                       ExpiresOnDateString =(dr.ExpiresOn != null ? Convert.ToDateTime(dr.ExpiresOn).ToString("MMMM,dd,yyyy") :""),
                                                       NoOfDaysLeftString = Convert.ToString( dr.ExpiresOn != null ? _helpers.GetNoOfDays(Convert.ToDateTime(dr.ExpiresOn)) : 0)
                                                   }
                                                   ).ToList();
                    objSpecialSResponce.ErrorMessage.ErrorCode = 1;
                    objSpecialSResponce.ErrorMessage.ErrorDetails = string.Empty;
                    objSpecialSResponce.AndroidVersion = ConfigurationHelper.AndroidVersion;
                    objSpecialSResponce.iPhoneVersion = ConfigurationHelper.iPhoneVersion;
                    objSpecialSResponce.UpdateConfigSettings = ConfigurationHelper.UpdateConfigSettings;
                    objSpecialSResponce.RequiredAcceptTerms = ConfigurationHelper.RequiredAcceptTerms;
                    objSpecialSResponce.NewTermsAcceptanceRequired = (finalCouponsList.Count > 0 ? Convert.ToBoolean(finalCouponsList[0].NewTermsAcceptanceRequired) : false);
                    objSpecialSResponce.SettingsLastChangeDate = ConfigurationHelper.SettingsLastChangeDate;
                }
                else
                {
                    objSpecialSResponce.ErrorMessage.ErrorCode = -1001;
                    objSpecialSResponce.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";
                }
            }catch(Exception ex)
            {
                objSpecialSResponce.ErrorMessage.ErrorCode = -1;
                objSpecialSResponce.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }
            return objSpecialSResponce;
        }

        [HttpGet]
        [Route("GetRewardCountsByDepartment/{UserToken}")]
        public RewardCountsByDepartmentResponse GetRewardCountsByDepartment(string UserToken)
        {
            RewardCountsByDepartmentResponse objRewardCountsByDepartmentResponse = new RewardCountsByDepartmentResponse();
            objRewardCountsByDepartmentResponse.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if(userId > 0)
                {
                    objRewardCountsByDepartmentResponse.RewardCountsByDepartment = (from dr in _commonMgr.GetRewardCountsByDepartment()
                                                                                    select new RewardCountsByDepartment
                                                                                    {
                                                                                        DepartmentId = Convert.ToInt32(dr.DEPARTMENTID),
                                                                                        DepartmentName = dr.DEPARTMENTNAME,
                                                                                        NoOfRewards = Convert.ToInt32(dr.NOOFREWARDS),
                                                                                        DepartmentImageUrl = string.Concat(ConfigurationHelper.AmazonS3Url,ConfigurationHelper.AmazonBucketName,ConfigurationHelper.DepartmentImagesFolderName,dr.DEPARTMENTIMAGENAME)
                                                                                    }
                                                                                ).ToList();
                    objRewardCountsByDepartmentResponse.ErrorMessage.ErrorCode = 1;
                    objRewardCountsByDepartmentResponse.ErrorMessage.ErrorDetails = string.Empty;
                }
                else
                {
                    objRewardCountsByDepartmentResponse.ErrorMessage.ErrorCode = -1001;
                    objRewardCountsByDepartmentResponse.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";
                }
                

            }catch(Exception ex)
            {
                objRewardCountsByDepartmentResponse.ErrorMessage.ErrorCode = -1;
                objRewardCountsByDepartmentResponse.ErrorMessage.ErrorDetails = "Error occured. Please try again.";

            }
            return objRewardCountsByDepartmentResponse; 
        }

        [HttpGet]
        [Route("GetAllRewardsForDepartment/{UserToken}/{DepartmentId}")]
        public LMRewardForDepartmentResponse GetAllRewardsForDepartment(string UserToken, string DepartmentId)
        {
            LMRewardForDepartmentResponse objLMRewardForDepartmentResponse = new LMRewardForDepartmentResponse();
            objLMRewardForDepartmentResponse.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if(userId > 0)
                {
                    objLMRewardForDepartmentResponse.LMRewardsForDepartment = (from dr in _commonMgr.GetAllRewardsForDepartment(Convert.ToInt32(DepartmentId), userId)
                                                                               select new LMRewardsForDepartment
                                                                               {
                                                                                   LMRewardId = dr.LMRewardId,
                                                                                   Title = dr.Title,
                                                                                   RewardTypeId = dr.RewardTypeId,
                                                                                   RewardDetails = dr.AdditionalDetails,
                                                                                   BuyQtyAmount = Convert.ToInt32(dr.BuyQtyAmount),
                                                                                   PurchasedQty = Convert.ToInt32(dr.PurchasedQty),
                                                                                   PurchasedAmount = Convert.ToInt32(dr.PurchasedAmount),   
                                                                                   ImageUrl =_imageMgr.GetImageUrl(userId,(dr.RewardTypeId == Convert.ToInt32(EnumMgr.SpecialsTypes.BasketDeals) ? EnumMgr.UploadLocations.SpecialsLogo : EnumMgr.UploadLocations.SpecialsLogo),dr.RewardTypeName,false),
                                                                                   ValidUPCs = dr.productUpcs

                                                                               }
                                                                              ).ToList();
                    objLMRewardForDepartmentResponse.ErrorMessage.ErrorCode = 1;
                    objLMRewardForDepartmentResponse.ErrorMessage.ErrorDetails = string.Empty;

                }
                else
                {
                    objLMRewardForDepartmentResponse.ErrorMessage.ErrorCode = -1001;
                    objLMRewardForDepartmentResponse.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";

                }

            }catch(Exception ex)
            {
                objLMRewardForDepartmentResponse.ErrorMessage.ErrorCode = -1;
                objLMRewardForDepartmentResponse.ErrorMessage.ErrorDetails = "Error occured. Please try again.";

            }
            return objLMRewardForDepartmentResponse;
        }
        [HttpGet]
        [Route("GetDepartmentWiseCoupons/{ProductDepartmentId}/{UserToken}/{NewsCategoryId}")]
        public SpecialSResponce GetDepartmentWiseCoupons(string ProductDepartmentId, string UserToken, string NewsCategoryId)
        {
            SpecialSResponce specialSResponce = new SpecialSResponce();
            specialSResponce.ErrorMessage = new ErrorMessage();
            specialSResponce.ErrorMessage.OfflineMessage = ConfigurationHelper.JustForYouOfflineMsg;
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken,ref deviceId); 
            try
            {
               if(userId > 0)
                {
                    List<GetDepartmentWiseCoupons_Result> finalCouponList = new List<GetDepartmentWiseCoupons_Result>();
                    finalCouponList = _commonMgr.GetDepartmentWiseCoupons(Convert.ToInt32(ProductDepartmentId), Convert.ToInt32(userId), Convert.ToInt32(NewsCategoryId)).Where(m => m.IsExpired != 1).ToList();
                    specialSResponce.Specials = (from dr in finalCouponList
                                                 select new Specials
                                                 {
                                                    SSNewsId = dr.NewsID,
                                                    Title = dr.Title,
                                                    Details = dr.Details,
                                                    ImagePath = (dr.ImagePath.Contains("shoptocook") ? dr.ImagePath : (dr.ImagePath.Contains("/") ? dr.ImagePath :
                                                                (dr.ImagePath == ConstantMgr.CompanyLogo ? (dr.ProductImage.Contains("/") ? dr.ProductImage : _imageMgr.GetImageUrl(userId, EnumMgr.UploadLocations.ProductsLogo, dr.ProductImage, false)) :
                                                                  _imageMgr.GetImageUrl(userId, (dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? EnumMgr.UploadLocations.WeeklySpecialsLogo : EnumMgr.UploadLocations.SpecialsLogo), dr.ImagePath, false)))),
                                                    CustomerID = Convert.ToInt32(dr.CustomerID),
                                                    CustomerName = dr.CustomerName,
                                                    ValidFromDate = Convert.ToDateTime(dr.ValidFromDate),
                                                    ExpiresOn = Convert.ToDateTime(dr.ExpiresOn),
                                                    SendNotification = Convert.ToBoolean(dr.SendNotification),
                                                    NewsCategoryDescription = dr.CategoryName,
                                                    IsWeeklyCoupons = (
                                                    dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.ProductCoupons) ||
                                                    dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.BasketDeals) || 
                                                    dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.ManufacturerCoupon) ||
                                                     dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.GroupBasketCoupon) ||
                                                    dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.BogoCoupon) || 
                                                    dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.GroupCoupon)
                                                    ? true : false
                                                    
                                                    ),
                                                   ProductName = dr.ProductName,
                                                   Amoount = Convert.ToDecimal(dr.Amount),
                                                   DiscountAmoount = Convert.ToDecimal(dr.DiscountAmount),  
                                                   IsDiscountPercentage = Convert.ToBoolean(dr.IsDiscountPercentage),
                                                   ProductId = Convert.ToInt32(dr.ProductId),
                                                   RedeemDate = (dr.RedeemOn != null ? Convert.ToDateTime(dr.RedeemOn).ToString("MM/dd/yyyy HH:mm:ss") : "" ),
                                                   IsRedeem =(dr.ISRedeemed ==1 ? true : false),
                                                   IsInCart = (dr.IsInCart ==1 ? true : false),
                                                   PLUCode = dr.PUICode,
                                                   NCRPromotionCode = dr.NCRPromotionCode,
                                                   IsInNCRImpressions = Convert.ToBoolean(dr.IsInNCRImpression),
                                                   NewsCategoryId =Convert.ToInt32(dr.NewsCategoryID),
                                                   IsFeatured = Convert.ToBoolean(dr.IsFeatured),
                                                   ProductCategoryId = Convert.ToInt32(dr.ProductCategoryId),
                                                   SpecialPrice =(dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? (dr.SpecialPrice !=null ? dr.SpecialPrice : "0") : "0"),
                                                   DepartmentName = (dr.NewsCategoryID == Convert.ToInt32(EnumMgr.SpecialsTypes.WeeklySpecials) ? (dr.DepartmentName !=null ? dr.DepartmentName : string.Empty) : string.Empty),
                                                   CouponLimit = Convert.ToInt32(dr.CouponLimit)
                                                   
                                                 }
                                                 ).ToList();
                    specialSResponce.ErrorMessage.ErrorCode = 1;
                    specialSResponce.ErrorMessage.ErrorDetails = string.Empty;
                    specialSResponce.AndroidVersion = ConfigurationHelper.AndroidVersion;
                    specialSResponce.iPhoneVersion = ConfigurationHelper.iPhoneVersion;
                    specialSResponce.UpdateConfigSettings = ConfigurationHelper.UpdateConfigSettings;
                    specialSResponce.RequiredAcceptTerms = ConfigurationHelper.RequiredAcceptTerms;
                    specialSResponce.NewTermsAcceptanceRequired = (finalCouponList.Count > 0 ? Convert.ToBoolean(finalCouponList[0].NewTermsAcceptanceRequired) : false);
                    specialSResponce.SettingsLastChangeDate = ConfigurationHelper.SettingsLastChangeDate;
                    
                   

                }
                else
                {
                    specialSResponce.ErrorMessage.ErrorCode = -1001;
                    specialSResponce.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";

                }
            }catch(Exception ex)
            {
                specialSResponce.ErrorMessage.ErrorCode = -1;
                specialSResponce.ErrorMessage.ErrorDetails = "Error occured. Please try again.";

            }
            return specialSResponce;
        }

        [HttpGet]
        [Route("GetQualifiedRewardTiers/{UserToken}/{MemberNumber}/{RewardId}")]
        public QualifiedRewardTiersResponse GetQualifiedRewardTiers(string UserToken, string MemberNumber, string RewardId)
        {
              QualifiedRewardTiersResponse objQualifiedRewardTiersResponse = new QualifiedRewardTiersResponse();
            objQualifiedRewardTiersResponse.ErrorMessage = new ErrorMessage();
            objQualifiedRewardTiersResponse.ErrorMessage.OfflineMessage = ConfigurationHelper.JustForYouOfflineMsg; 
                byte deviceId=0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if(userId > 0  )
                {
                    List<LM_GetQualifiedRewardTiersForMember_Result> qualifiedRewardTiersForMember = new List<LM_GetQualifiedRewardTiersForMember_Result>();
                    qualifiedRewardTiersForMember = _commonMgr.GetQualifiedRewardTiersForMember(MemberNumber,Convert.ToInt32(RewardId)).ToList();
                    objQualifiedRewardTiersResponse.QualifiedRewardTiers = (from dr in qualifiedRewardTiersForMember
                                                                            select new QualifiedRewardTiers
                                                                            {
                                                                                LMRewardTierID = dr.LMRewardTierID,
                                                                                LMrewardID = dr.LMrewardID,
                                                                                TierTitle = dr.TierTitle,
                                                                                 PointsRequired = Convert.ToInt32(dr.PointsRequired),
                                                                                 CouponValue = Convert.ToInt32(dr.CouponValue),
                                                                                 CurrentPoints = Convert.ToDecimal(dr.CurrentPoints),
                                                                            }).ToList();
                    objQualifiedRewardTiersResponse.ErrorMessage.ErrorCode = 1;
                    objQualifiedRewardTiersResponse.ErrorMessage.ErrorDetails=string.Empty;
                }
                else
                {
                    objQualifiedRewardTiersResponse.ErrorMessage.ErrorCode = -1001;
                    objQualifiedRewardTiersResponse.ErrorMessage.ErrorDetails = "Your session has expired. Please login again.";

                }

            }catch(Exception ex)
            {
                objQualifiedRewardTiersResponse.ErrorMessage.ErrorCode = -1;
                objQualifiedRewardTiersResponse.ErrorMessage.ErrorDetails = "Error occured. Please try again.";

            }
            return objQualifiedRewardTiersResponse; 
        }
        [HttpGet]
        [Route("GetQualifiedRewardTiersV2/{UserToken}/{MemberNumber}/{RewardId}")]
        public RewardQualifiedTiersResponse GetQualifiedRewardTiersV2(string UserToken, string MemberNumber, string RewardId)
        {
            RewardQualifiedTiersResponse objQualifiedRewardTiersResponse = null;
              objQualifiedRewardTiersResponse = new RewardQualifiedTiersResponse();

            objQualifiedRewardTiersResponse.ErrorMessage = new ErrorMessage();
            objQualifiedRewardTiersResponse.ErrorMessage.OfflineMessage = ConfigurationHelper.JustForYouOfflineMsg;
           
            try
            {
                byte deviceId = 0;
                int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
                if (userId > 0)
                {
                    List<LM_GetQualifiedPointsBasedRewardTiersForMember_Result> qualifiedRewardTiersForMember = _commonMgr.LM_GetQualifiedPointsBasedRewardTiersForMember(MemberNumber,Convert.ToInt32(RewardId)).ToList();
                    if(qualifiedRewardTiersForMember.Count > 0)
                    {
                        QualifiedTiersRewardDetails objQualifiedTiersRewardDetails = null;
                        objQualifiedTiersRewardDetails = new QualifiedTiersRewardDetails();
                        objQualifiedTiersRewardDetails.LMRewardID = qualifiedRewardTiersForMember[0].LMRewardID;
                        objQualifiedTiersRewardDetails.Title = qualifiedRewardTiersForMember[0].Title;
                        objQualifiedTiersRewardDetails.RewardTitle = qualifiedRewardTiersForMember[0].RewardTitle;
                        objQualifiedTiersRewardDetails.RewardDetails = qualifiedRewardTiersForMember[0].RewardPOSDetails;
                        objQualifiedTiersRewardDetails.RewardAdditionalDetails = qualifiedRewardTiersForMember[0].RewardAdditionalDetails;  
                        objQualifiedTiersRewardDetails.RewardPointsText = qualifiedRewardTiersForMember[0].RewardPointsText;
                        objQualifiedTiersRewardDetails.RewardOptionsText = qualifiedRewardTiersForMember[0].RewardOptionsText;
                        objQualifiedTiersRewardDetails.RewardOptionsNoteText =qualifiedRewardTiersForMember[0].RewardOptionsNoteText;
                        objQualifiedTiersRewardDetails.MemberPoints = Convert.ToDecimal(qualifiedRewardTiersForMember[0].MemberPoints);
                        objQualifiedTiersRewardDetails.RoundedMemberPoints = Convert.ToInt32(Math.Floor(Convert.ToDecimal(qualifiedRewardTiersForMember[0].MemberPoints)));
                        // objQualifiedTiersRewardDetails.MemberPointsString = ((qualifiedRewardTiersForMember[0].MemberPoints != null && qualifiedRewardTiersForMember[0].MemberPoints > 0) ? string.Concat(Convert.ToDecimal(qualifiedRewardTiersForMember[0].MemberPoints).ToString("0.##"), " pts") : "0 pts");
                        objQualifiedTiersRewardDetails.MemberPointsString = ((qualifiedRewardTiersForMember[0].MemberPoints != null && qualifiedRewardTiersForMember[0].MemberPoints > 0) ? string.Concat(Convert.ToDecimal(qualifiedRewardTiersForMember[0].MemberPoints).ToString("#,##0.##"), " pts") : "0 pts");
                        objQualifiedRewardTiersResponse.RewardDetails = objQualifiedTiersRewardDetails;
                        objQualifiedRewardTiersResponse.QualifiedRewardTiers = (from dr in qualifiedRewardTiersForMember
                                                                                select new RewardQualifiedTier
                                                                                {
                                                                                    LMRewardTierID = dr.LMRewardTierID,
                                                                                    TierTitle = dr.TierTitle,
                                                                                    TierTitleDesc = dr.TierTitleDesc,
                                                                                    PointsRequired = Convert.ToInt32(dr.PointsRequired),
                                                                                    //PointsRequiredString = ((dr.PointsRequired != null && dr.PointsRequired > 0) ? string.Concat(Convert.ToInt32(dr.PointsRequired), " pts") : ""),
                                                                                    PointsRequiredString = ((dr.PointsRequired != null && dr.PointsRequired > 0) ? string.Concat(Convert.ToInt32(dr.PointsRequired).ToString("#,##0"), " pts") : ""),
                                                                                    CouponValue = Convert.ToDecimal(dr.CouponValue),
                                                                                    CouponValueString =((dr.CouponValue !=null && dr.CouponValue > 0) ? string.Concat("$",Convert.ToDecimal(dr.CouponValue),"0.##") :""),
                                                                                    MinRequiredAmount = Convert.ToDecimal(dr.MinRequiredAmount),
                                                                                    TierRewardCouponTypeId = Convert.ToInt32(dr.TierRewardCouponTypeId),
                                                                                    IsItQualifiedforReward = Convert.ToBoolean(dr.IsItQualifiedforReward),
                                                                                    TierImageUrl = _imageMgr.GetImageUrl(userId, EnumMgr.UploadLocations.SpecialsLogo, dr.TierImageUrl, false)
                                                                                }).ToList();
                       
                    }

                    objQualifiedRewardTiersResponse.ErrorMessage.ErrorCode = 1;
                    objQualifiedRewardTiersResponse.ErrorMessage.ErrorDetails = "";
                }
                else
                {
                    objQualifiedRewardTiersResponse.ErrorMessage.ErrorCode = -1001;
                    objQualifiedRewardTiersResponse.ErrorMessage.ErrorDetails = "Your session has expired. Please login again.";
                }

            }catch(Exception ex) {
                objQualifiedRewardTiersResponse.ErrorMessage.ErrorCode = -1;
                objQualifiedRewardTiersResponse.ErrorMessage.ErrorDetails = "Something went wrong. Please try again.";
            }

           return objQualifiedRewardTiersResponse;  
        }
        [HttpGet]
        [Route("GetPointsBasedRewardDetails/{UserToken}/{MemberNumber}/{RewardId}")]
        public PointsBasedRewardDetailsResponse GetPointsBasedRewardDetails(string UserToken, string MemberNumber, string RewardId)
        {
            PointsBasedRewardDetailsResponse objPointsBasedRewardDetailsResponse = null;

            objPointsBasedRewardDetailsResponse = new PointsBasedRewardDetailsResponse();
            objPointsBasedRewardDetailsResponse.ErrorMessage = new ErrorMessage();
            objPointsBasedRewardDetailsResponse.ErrorMessage.OfflineMessage = ConfigurationHelper.JustForYouOfflineMsg;
            try
            {
                byte deviceId = 0;
                int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
                if(userId > 0)
                {
                    List<LM_GetPointsBasedRewardDetailsForMember_Result> pointsBasedRewardDetailsForMember = _commonMgr.LM_GetPointsBasedRewardDetailsForMember(MemberNumber,Convert.ToInt32(RewardId)).ToList();   
                      if(pointsBasedRewardDetailsForMember.Count > 0)
                    {
                        PointsBasedRewardDetails objPointsBasedRewardDetails = null;
                        objPointsBasedRewardDetails = new PointsBasedRewardDetails();
                        objPointsBasedRewardDetails.LMRewardID = pointsBasedRewardDetailsForMember[0].LMRewardID;
                        objPointsBasedRewardDetails.Title = pointsBasedRewardDetailsForMember[0].Title;
                        objPointsBasedRewardDetails.RewardTitle = pointsBasedRewardDetailsForMember[0].RewardTitle;
                        objPointsBasedRewardDetails.ImageUrl = _imageMgr.GetImageUrl(userId, (pointsBasedRewardDetailsForMember[0].RewardTypeId == Convert.ToInt32(EnumMgr.SpecialsTypes.BasketDeals) ? EnumMgr.UploadLocations.SpecialsLogo : EnumMgr.UploadLocations.SpecialsLogo), pointsBasedRewardDetailsForMember[0].RewardImageURL,false);
                        objPointsBasedRewardDetails.RewardDetails = pointsBasedRewardDetailsForMember[0].RewardDetails;
                        objPointsBasedRewardDetails.RewardAdditionalDetails = pointsBasedRewardDetailsForMember[0].RewardAdditionalDetails;
                        objPointsBasedRewardDetails.RewardPointsText = pointsBasedRewardDetailsForMember[0].RewardPointsText;
                        objPointsBasedRewardDetails.RewardOptionsText = pointsBasedRewardDetailsForMember[0].RewardOptionsText;
                        objPointsBasedRewardDetails.RewardAdditionalTermsText = pointsBasedRewardDetailsForMember[0].RewardAdditionalTermsText;
                        objPointsBasedRewardDetails.RewardDetailsNoteText = pointsBasedRewardDetailsForMember[0].RewardDetailsNoteText;
                        objPointsBasedRewardDetails.MemberPoints = Convert.ToDecimal(pointsBasedRewardDetailsForMember[0].MemberPoints);
                        objPointsBasedRewardDetails.RoundedMemberPoints = Convert.ToInt32(Math.Floor(Convert.ToDecimal(pointsBasedRewardDetailsForMember[0].MemberPoints)));
                        // objPointsBasedRewardDetails.MemberPointsString = ((pointsBasedRewardDetailsForMember[0].MemberPoints != null && pointsBasedRewardDetailsForMember[0].MemberPoints > 0) ? string.Concat(Convert.ToDecimal(pointsBasedRewardDetailsForMember[0].MemberPoints).ToString("0.##")," pts") : "0 pts");
                        objPointsBasedRewardDetails.MemberPointsString = ((pointsBasedRewardDetailsForMember[0].MemberPoints != null && pointsBasedRewardDetailsForMember[0].MemberPoints > 0) ? string.Concat(Convert.ToDecimal(pointsBasedRewardDetailsForMember[0].MemberPoints).ToString("#,##0.##"), " pts") : "0 pts");
                        objPointsBasedRewardDetails.RewardPointsTextWithBalance = pointsBasedRewardDetailsForMember[0].RewardPointsText + ": " + objPointsBasedRewardDetails.MemberPointsString;
                        objPointsBasedRewardDetailsResponse.RewardDetails = objPointsBasedRewardDetails;
                        objPointsBasedRewardDetailsResponse.RewardTiers = (from dr in pointsBasedRewardDetailsForMember
                                                                           select new PointsBasedRewardDetailsTierInfo
                                                                           {
                                                                               LMRewardTierID =dr.LMRewardTierID,
                                                                               TierTitle =dr.TierTitle,
                                                                               TierTitleDesc = dr.TierTitleDesc,
                                                                               PointsRequired = Convert.ToInt32(dr.PointsRequired),
                                                                               // PointsRequiredString = ( (dr.PointsRequired !=null && dr.PointsRequired > 0 )  ? string.Concat( Convert.ToInt32(dr.PointsRequired) ," pts" ) : ""),
                                                                               PointsRequiredString = ((dr.PointsRequired != null && dr.PointsRequired > 0) ? string.Concat(Convert.ToInt32(dr.PointsRequired).ToString("#,##0"), " pts") : ""),
                                                                                CouponValue = Convert.ToDecimal(dr.CouponValue),    
                                                                                CouponValueString = ((dr.CouponValue != null && dr.CouponValue > 0) ? string.Concat("$",Convert.ToDecimal(dr.CouponValue).ToString("0.##"))  :""),
                                                                                MinRequiredAmount = Convert.ToDecimal(dr.MinRequiredAmount),
                                                                                TierRewardCouponTypeId = Convert.ToInt32(dr.TierRewardCouponTypeId),
                                                                                TierImageUrl = _imageMgr.GetImageUrl(userId,EnumMgr.UploadLocations.SpecialsLogo,dr.TierImageUrl,false)


                                                                           }).ToList();
                    }
                    objPointsBasedRewardDetailsResponse.ErrorMessage.ErrorCode = 1;
                    objPointsBasedRewardDetailsResponse.ErrorMessage.ErrorDetails = "";
                }
                else
                {
                    objPointsBasedRewardDetailsResponse.ErrorMessage.ErrorCode = -1001;
                    objPointsBasedRewardDetailsResponse.ErrorMessage.ErrorDetails = "Your session has expired. Please login again.";
                }
            }catch(Exception ex)
            {
                objPointsBasedRewardDetailsResponse.ErrorMessage.ErrorCode = -1;
                objPointsBasedRewardDetailsResponse.ErrorMessage.ErrorDetails = "Something went wrong. Please try again.";
            }
            return objPointsBasedRewardDetailsResponse;
        }

        [HttpGet]
        [Route("GetClientGeneralInfo/{UserToken}")]
        public ClientGeneralInfoResponse GetClientGeneralInfo(string UserToken)
        {
            ClientGeneralInfoResponse objClientGeneralInfoResponse = new ClientGeneralInfoResponse();
            objClientGeneralInfoResponse.ErrorMessage = new ErrorMessage();
            ClientGeneralInfo clientGeneralInfo = new ClientGeneralInfo();
            List<SocialMediaSettings> socialMediaSettingsList = new List<SocialMediaSettings>();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            string contactUsToken = "";
            contactUsToken = _appsettings.Value.TokenForContactUs.ToString();
            try
            {
                if(contactUsToken ==  UserToken || userId > 0)
                {
                    objClientGeneralInfoResponse = _multipleResultSets.GetClientGeneralInfo();
                    objClientGeneralInfoResponse.ErrorMessage = new ErrorMessage();
                    objClientGeneralInfoResponse.ErrorMessage.ErrorCode = 1;
                    objClientGeneralInfoResponse.ErrorMessage.ErrorDetails =string.Empty;
                }
                else
                {
                    objClientGeneralInfoResponse.ErrorMessage.ErrorCode = -1001;
                    objClientGeneralInfoResponse.ErrorMessage.ErrorDetails = "Your session has expired. Please login again.";
                }
            }catch(Exception ex) {
                objClientGeneralInfoResponse.ErrorMessage.ErrorCode = -1;
                objClientGeneralInfoResponse.ErrorMessage.ErrorDetails = "Something went wrong. Please try again.";
            }
            return objClientGeneralInfoResponse;
        }
        [HttpGet]
        [Route("GetEvents/{UserToken}")]
        public GetAllEventsResponse GetEvents(string UserToken)
        {
            GetAllEventsResponse objGetAllEventsResponse = new GetAllEventsResponse();
            objGetAllEventsResponse.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if (userId > 0)
                {
                    List<GetAllEvents_Result> eventsList = _commonMgr.GetAllEvents(userId).ToList();
                    if(eventsList.Count > 0)
                    {
                        objGetAllEventsResponse.Events = (from dr in eventsList
                                                          select new Events
                                                          {
                                                              EventID = Convert.ToInt32(dr.EventID),
                                                              Title = dr.Title,
                                                              Details = dr.Details,
                                                              OtherDetails = dr.OtherDetails,
                                                              StartDate = Convert.ToDateTime(dr.StartDate),
                                                              EndDate = Convert.ToDateTime(dr.EndDate),
                                                              TermsAndConditions = string.Concat(ConfigurationHelper.AmazonS3Url, ConfigurationHelper.AmazonBucketName, "/SpecialsImages/", dr.TermsAndConditions),
                                                              EventButtonText = dr.EventButtonText,
                                                              ImagePath1 = string.Concat(ConfigurationHelper.AmazonS3Url, ConfigurationHelper.AmazonBucketName, "/SpecialsImages/", dr.ImagePath1),
                                                              ImagePath2 = string.Concat(ConfigurationHelper.AmazonS3Url, ConfigurationHelper.AmazonBucketName, "/SpecialsImages/", dr.ImagePath2),
                                                              ImagePath3 = string.Concat(ConfigurationHelper.AmazonS3Url, ConfigurationHelper.AmazonBucketName, "/SpecialsImages/", dr.ImagePath3),
                                                              EventCategoryID = Convert.ToInt32(dr.EventCategoryID),
                                                              IsTermsAccepted = Convert.ToBoolean(dr.IsTermsAccepted),
                                                              IsEnrolled = Convert.ToBoolean(dr.IsEnrolled),
                                                              ShowTitleOnSlider = Convert.ToBoolean(Convert.ToInt32(_appsettings.Value.ShowTitleOnSlider.ToString())),
                                                              EventTypeId = Convert.ToInt32(dr.EventTypeId)
                                                          }).ToList();

                    }
                    objGetAllEventsResponse.ErrorMessage.ErrorCode = 1;
                    objGetAllEventsResponse.ErrorMessage.ErrorDetails = "";
                }
                else
                {
                    objGetAllEventsResponse.ErrorMessage.ErrorCode = -1001;
                    objGetAllEventsResponse.ErrorMessage.ErrorDetails = "Your session has expired. Please login again.";
                }
               

            }
            catch(Exception ex) 
            {
                objGetAllEventsResponse.ErrorMessage.ErrorCode = -1;
                objGetAllEventsResponse.ErrorMessage.ErrorDetails = "Something went wrong. Please try again.";
            }
            return objGetAllEventsResponse;
        }
       [HttpGet]
       [Route("GetSurveys/{UserToken}")]
        public SurveyResponse GetSurveys(string UserToken)
        {
            SurveyResponse objSurveyResponse = new SurveyResponse();
            objSurveyResponse.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if (userId > 0)
                {
                    objSurveyResponse.Survey = _multipleResultSets.Survey();
                    objSurveyResponse.ErrorMessage.ErrorCode = 1;
                    objSurveyResponse.ErrorMessage.ErrorDetails = "";
                }
                else
                {
                    objSurveyResponse.ErrorMessage.ErrorCode = -1001;
                    objSurveyResponse.ErrorMessage.ErrorDetails = "Your session has expired. Please login again.";

                }
            }
            catch(Exception ex) {
                objSurveyResponse.ErrorMessage.ErrorCode = -1;
                objSurveyResponse.ErrorMessage.ErrorDetails = "Something went wrong. Please try again.";
            }
            return objSurveyResponse;
        }

        [HttpGet]
        [Route("GetLatestAppVersion/{UserToken}")]
        public MobileAppVersionResponse GetLatestAppVersion(string UserToken)
        {
            MobileAppVersionResponse objMobileAppVersionResponse = new MobileAppVersionResponse();  
            objMobileAppVersionResponse.ErrorMessage = new ErrorMessage();
            MobileAppVersion mobileAppVersion = new MobileAppVersion();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
               if(userId > 0)
                {
                    mobileAppVersion.androidappversion = _appsettings.Value.AndroidAppVersion.ToString();
                    mobileAppVersion.iosappversion = _appsettings.Value.IosAppVersion.ToString();
                    mobileAppVersion.iosversionupdatemessage = _appsettings.Value.iosversionupdatemessage.ToString();
                    mobileAppVersion.androidversionupdatemessage = _appsettings.Value.androidversionupdatemessage.ToString();
                    mobileAppVersion.iosappforceupdate = Convert.ToBoolean(Convert.ToInt32(_appsettings.Value.iosappforceupdate.ToString()));
                    mobileAppVersion.androidappforceupdate = Convert.ToBoolean(Convert.ToInt32(_appsettings.Value.androidappforceupdate.ToString()));
                    mobileAppVersion.iosappurl = _appsettings.Value.IosAppUrl.ToString();
                    mobileAppVersion.androidappurl = _appsettings.Value.AndroidAppUrl.ToString();
                    objMobileAppVersionResponse.MobileAppVersion = mobileAppVersion;
                    objMobileAppVersionResponse.ErrorMessage.ErrorCode = 1;
                    objMobileAppVersionResponse.ErrorMessage.ErrorDetails = "";
                }
                else
                {
                    objMobileAppVersionResponse.ErrorMessage.ErrorCode = -1001;
                    objMobileAppVersionResponse.ErrorMessage.ErrorDetails = "Your session has expired. Please login again.";
                }

            
                
            }catch(Exception ex)
            {
                objMobileAppVersionResponse.ErrorMessage.ErrorCode = -1;
                objMobileAppVersionResponse.ErrorMessage.ErrorDetails = "Something went wrong. Please try again.";
            }
            return objMobileAppVersionResponse;
        }

        [HttpGet]
        [Route("GetUPCTierProducts/{UserToken}/{RewardId}/{TierID}")]
        public RewardUPCTierProductsResponse GetUPCTierProducts(string UserToken, string RewardId, string TierID)
        {
            RewardUPCTierProductsResponse objGetUPCTierProducts = null;
            objGetUPCTierProducts = new RewardUPCTierProductsResponse();
            objGetUPCTierProducts.ErrorMessage = new ErrorMessage();
           
            try
            {
                byte deviceId = 0;
                int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
                if(userId > 0)
                {
                    List<LM_GetUPCTierProducts_Result> qualifiedRewardTiersForMember = _commonMgr.GetUPCTierProducts(Convert.ToInt32(RewardId), userId).ToList();
                    if (qualifiedRewardTiersForMember.Count > 0)
                    {
                        objGetUPCTierProducts.RewardUPCTierProducts = (from dr in qualifiedRewardTiersForMember
                                                                       select new RewardUPCTierProducts
                                                                       {
                                                                           LMRewardTierID = dr.LMRewardTierID,
                                                                           LMRewardID = dr.LMRewardID,
                                                                           TierTitle = dr.TierTitle,
                                                                           PointsRequired = Convert.ToInt32(dr.PointsRequired),
                                                                           PointsRequiredString =((dr.PointsRequired !=null && dr.PointsRequired > 0) ? string.Concat(Convert.ToInt32(dr.PointsRequired).ToString("#,##0")) : ""),
                                                                           CouponValue = Convert.ToDecimal(dr.CouponValue),
                                                                           TierRewardCouponTypeId = Convert.ToInt32(dr.TierRewardCouponTypeId),
                                                                           Title = dr.TierTitle,
                                                                           UPC = dr.UPC,
                                                                           ProductName = dr.ProductName,
                                                                           //DeductPointsText = dr.DeductPointsText,
                                                                           DeductPointsText = ((dr.PointsRequired != null && dr.PointsRequired > 0) ? string.Concat("Deducts",Convert.ToInt32(dr.PointsRequired).ToString("#,##0")," points") : "" ),
                                                                           ImageUrl = _imageMgr.GetImageUrl(userId, EnumMgr.UploadLocations.SpecialsLogo,dr.ImageUrl,false)

                                                                       }).ToList();

                    }
                    objGetUPCTierProducts.ErrorMessage.ErrorCode = 1;
                    objGetUPCTierProducts.ErrorMessage.ErrorDetails = "";

                }
                else
                {
                    objGetUPCTierProducts.ErrorMessage.ErrorCode = -1001;
                    objGetUPCTierProducts.ErrorMessage.ErrorDetails = "Your session has expired. Please login again";

                }

            }
            catch(Exception ex)
            {
                objGetUPCTierProducts.ErrorMessage.ErrorCode = -1;
                objGetUPCTierProducts.ErrorMessage.ErrorDetails = "Something went wrong. Please try again";
            }
            return objGetUPCTierProducts;
        }
        [HttpGet]
        [Route("GetMostRecentPurchaseItems/{UserToken}")]
        public MostRecentPurchaseItemsResponse GetMostRecentPurchaseItems(string UserToken)
        { 
           MostRecentPurchaseItemsResponse objMostRecentPurchaseItemsResponse = new MostRecentPurchaseItemsResponse();
            objMostRecentPurchaseItemsResponse.ErrorMessage = new ErrorMessage();
           
            try
                
            {
                byte deviceId = 0;
                int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
                if(userId > 0)
                {
                    List<GetMemberMostRecentBasketItems_Result> mostRecentPurchaseItems = _commonMgr.GetMostRecentPurchaseItems(userId).ToList();
                    if(mostRecentPurchaseItems.Count > 0)
                    {
                        objMostRecentPurchaseItemsResponse.PurchaseItems = (from dr in mostRecentPurchaseItems
                                                                            select new MostRecentPurchaseItems
                                                                            {
                                                                                ProductId = dr.ProductId,
                                                                                ProductCode = dr.ProductCode,
                                                                                ProductName = dr.ProductName,


                                                                            }).ToList();


                    }
                    objMostRecentPurchaseItemsResponse.ErrorMessage.ErrorCode = 1;
                    objMostRecentPurchaseItemsResponse.ErrorMessage.ErrorDetails = "";

                }
                else
                {
                    objMostRecentPurchaseItemsResponse.ErrorMessage.ErrorCode = -1001;
                    objMostRecentPurchaseItemsResponse.ErrorMessage.ErrorDetails = "Your session has expired. Please login again.";
                }

            }
            catch(Exception ex)
            {
                objMostRecentPurchaseItemsResponse.ErrorMessage.ErrorCode = -1;
                objMostRecentPurchaseItemsResponse.ErrorMessage.ErrorDetails = "Something went wrong. Please try again.";
            }
            return objMostRecentPurchaseItemsResponse;
        }
        [HttpGet]
        [Route("GetUserLocations/{UserToken}")]
        public UserLocationsResponse GetUserLocations(string UserToken)
        {
            UserLocationsResponse objUserLocationsResponse = new UserLocationsResponse();
            objUserLocationsResponse.ErrorMessage = new ErrorMessage();
            byte deviceId = 0;
            int userId = _servicesMgr.IsTokenValid(UserToken, ref deviceId);
            try
            {
                if(userId > 0)
                {
                    List<TF_GETUSERLOCATIONS_Result> userLocationsList = new List<TF_GETUSERLOCATIONS_Result>();
                    userLocationsList = _userMgr.GetUserLocations(userId).ToList();
                    if(userLocationsList.Count > 0)
                    {
                        objUserLocationsResponse.UserLocations = (from dr in userLocationsList
                                                                  select new UserLocations
                                                                  {
                                                                      Address1 = dr.Address1,
                                                                      Address2 = dr.Address2,
                                                                      StateName = dr.StateName,
                                                                      CountryName = dr.CountryName,
                                                                      ZipCode = dr.ZipCode,
                                                                      AddressTypeId = Convert.ToInt32(dr.AddressTypeId),
                                                                      DrivingInstructions = dr.DrivingInstructions,
                                                                      FirstName = dr.FirstName,
                                                                      LastName = dr.LastName,
                                                                      UserName = dr.UserName,
                                                                      UserAddressID = Convert.ToInt32(dr.UserAddressID),


                                                                  }).ToList();


                    }
                    objUserLocationsResponse.ErrorMessage.ErrorCode = 1;
                    objUserLocationsResponse.ErrorMessage.ErrorDetails = "";
                }
                else
                {
                    objUserLocationsResponse.ErrorMessage.ErrorCode = -1001;
                    objUserLocationsResponse.ErrorMessage.ErrorDetails = "Your session is expired. Please login again.";

                }
                

            }catch(Exception ex) 
            {
                objUserLocationsResponse.ErrorMessage.ErrorCode = -1;
                objUserLocationsResponse.ErrorMessage.ErrorDetails = "Error occured. Please try again.";
            }
            return objUserLocationsResponse;
        }
        }
    
}
 
