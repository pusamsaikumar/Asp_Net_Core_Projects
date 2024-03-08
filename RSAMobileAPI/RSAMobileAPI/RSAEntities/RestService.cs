using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Transactions;

namespace RSAMobileAPI.RSAEntities
{
    public class RestService
    {
    }

    public class ErrorMessage
    {
        public int ErrorCode { get; set; }  
        public string ErrorDetails { get; set; }
        public string   OfflineMessage {  get; set; }   
    }

    public class RegisterResponse
    {
    
        public ErrorMessage ErrorMessage { get; set; }
    }

    public class ClubList
    {
        public int ClubId { get; set; } 
        public string ClubMemberId { get; set; }    
    }

   
    public class Register
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeviceType { get; set; }
        public int DeviceId { get; set; }
        public int CustomerId { get; set; }
        public string ZipCode { get; set; }
        public int ClientStoreId { get; set; }  
        public List<ClubList> ClubList { get; set; }
        public string ExistingMemberNumber { get; set; } 
        public string PhoneNumber { get; set; } 
        public int UserTypeId {  get; set; }    
        public string UserRoleName { get; set; }    

    }
    public class GetCouponsResponse
    {
        public ErrorMessage ErrorMessage { get; set; }
        public List<Coupon> Coupons { get; set; }   

    }

    public class Coupon
    {

        public int CouponId { get; set; }

        public Guid CouponUniqueId { get; set; }

        public string CouponCode { get; set; }
      
        public int ProductId { get; set; }
 
        public int NoDiscountCount { get; set; }
       
        public int UpSellCount { get; set; }
    
        public decimal DiscountPercentageCount { get; set; }
    
        public string ProductName { get; set; }
       
        public string ProductCode { get; set; }
        
        public Guid CustomerId { get; set; }
       
        public string CustomerCode { get; set; }
      
        public string Title { get; set; }
      
        public string Details { get; set; }
   
        public string ExpiryDate { get; set; }

        public string CouponQRCodeURL { get; set; }
     
        public string RedeemDate { get; set; }
     
        public bool IsRedeem { get; set; }
   
        public string ProductImage { get; set; }
       
        public bool IsInCart { get; set; }
     
        public string NCRPromotionCode { get; set; }
      
        public bool IsInNCRImpressions { get; set; }

        public string ValidFrom { get; set; }
      
        public string UpSellProductCode { get; set; }
   
        public int UpsellProductId { get; set; }
  
        public bool IsDiscountPercentage { get; set; }

        public decimal SalePrice { get; set; }

        public decimal UpsellPrice { get; set; }
    }
    public class ValidateUserResponse
    {
       
        public ErrorMessage ErrorMesasge { get; set; }

        public Guid UserId { get; set; }
    
        public String Username { get; set; }
   
        public String CustomerCode { get; set; }
       
        //public String ProfilePhotoURL { get; set; }
     
        public String FirstName { get; set; }
     
        public String LastName { get; set; }

        public String MemberNumber { get; set; }
   
        public String MyCardBarCodeImagePath { get; set; }
    
        public int CustomerId { get; set; }
      
        public string ZipCode { get; set; }
       
        public int UserDetailId { get; set; }
     
        public bool IsPOSIntegrationEnabled { get; set; }
   
        public Guid UserToken { get; set; }

        public bool ShowAddToCartForSpecials { get; set; }

        public bool EnableStoreManagement { get; set; }
  
        public int ClientStoreId { get; set; }
   
        public string ClientStoreName { get; set; }
       
        public bool EnableProductCouponPrice { get; set; }
       
        public bool EnableRecipes { get; set; }
  
        public bool EnableClubs { get; set; }
     
        public bool EnableCustomersAlsoBoughtTheseItems { get; set; }
   
        public bool ShowPriceInSpecials { get; set; }
      
        public int SpecialsDisplayFormat { get; set; }
       
        public bool ShowTotalSavings { get; set; }
       
        public decimal TotalSavingsAmount { get; set; }
    
        public string iPhoneVersion { get; set; }
     
        public string AndroidVersion { get; set; }
    
        public string iPhoneHomeImage { get; set; }
    
        public string AndroidHomeImage { get; set; }
  
        public string MobileNumber { get; set; }
    
        public string AOGApiEndPoint { get; set; }
    
        public string EnterpriseId { get; set; }
 
        public string SecurityKey { get; set; }

    }



    public class GetClientStoreForAppResponse
    {
  
        public ErrorMessage ErrorMessage { get; set; }

        public List<ClientStoresForApp> ClientStoresList { get; set; }
       
        public bool EnableStoreManagement { get; set; }
        public class ClientStoresForApp
        {
           
            public string? ClientStoreName { get; set; }
    
            public int? ClientStoreId { get; set; }
     
            public string? StorePhoneNumber { get; set; }
     
            public string? AddressLine1 { get; set; }
     
            public string? AddressLine2 { get; set; }
      
            public string? City { get; set; }
    
            public string? ZipCode { get; set; }
         
            public string? StoreTimings { get; set; }
        
            public decimal? Latitude { get; set; }
        
            public decimal? Longitude { get; set; }
           
            public string? StateName { get; set; }
      
            public string? StoreEmail { get; set; }
         
            public int? WeeklyAdStoreId { get; set; }
 
            public int? StoreNumber { get; set; }
     
            public bool? StoreEcomStatus { get; set; }

            public string? StoreImage { get; set; }

            public bool? mealkitandroidstatus { get; set; }
     
            public bool? mealkitiosstatus { get; set; }
    
            public string? mealkitlabel { get; set; }
  
            public int? mealkitdeptnumber { get; set; }
      
            public bool? ecomandroidstatus { get; set; }
  
            public bool? ecomiosstatus { get; set; }
       
            public string? ecomlabel { get; set; }
        }
        public class ClientStores
        {
          
            public string? ClientStoreName { get; set; }
        
            public int ClientStoreId { get; set; }
     
            public string? StorePhoneNumber { get; set; }
      
            public string? AddressLine1 { get; set; }
      
            public string? AddressLine2 { get; set; }
 
            public string? City { get; set; }
 
            public string? ZipCode { get; set; }
   
            public string? StoreTimings { get; set; }
     
            public decimal? Latitude { get; set; }
      
            public decimal Longitude { get; set; }

            public string StateName { get; set; }
       
            public string StoreEmail { get; set; }
      
            public int WeeklyAdStoreId { get; set; }
       
            public int StoreNumber { get; set; }

           // public bool? StoreEcomStatus { get; set; }

        }
        public class GetClientStoreResponce
        {
           
            public ErrorMessage ErrorMessage { get; set; }
          
            public List<ClientStores> GetClientStores { get; set; }
      
            public bool EnableStoreManagement { get; set; }
        }

        // Contact info
        public class GetContactInfoResponce
        {
         
            public ErrorMessage ErrorMessage { get; set; }
          
            public string ClientStoreName { get; set; }
         
            public int ClientStoreId { get; set; }
      
            public string StorePhoneNumber { get; set; }
       
            public string AddressLine1 { get; set; }
          
            public string AddressLine2 { get; set; }
          
            public string City { get; set; }
          
            public string State { get; set; }
 
            public string ZipCode { get; set; }
     
            public string StoreTimings { get; set; }
        
            public string ClientProfile { get; set; }
          
            public string StoreEmail { get; set; }
           
            public string WebSiteURL { get; set; }
         
            public string SupportURL { get; set; }
        
            public string TermsAndConditions { get; set; }
         
            public string PrivacyAndPolicy { get; set; }
        
            public bool AllowNewRegistration { get; set; }
           
            public bool AllowLinkCardRegistration { get; set; }
          
            public int MemberCardMinLength { get; set; }
           
            public int MemberCardMaxLength { get; set; }
        }

        public class UserInfo
        {
            [DataMember]
            public string FirstName { get; set; }
            [DataMember]
            public string LastName { get; set; }
            [DataMember]
            public string Email { get; set; }
            [DataMember]
            public string MemberNumber { get; set; }
            [DataMember]
            public string PhoneNumber { get; set; }
            [DataMember]
            public string FMPhoneNumber { get; set; }
            [DataMember]
            public bool IsEmployee { get; set; }
        }
        // User Profile
        public class UserProfileResponse
        {
            [DataMember]
            public ErrorMessage ErrorMessage { get; set; }
            [DataMember]
            public UserInfo UserDetails { get; set; }
        }

        // BasketReward
        public class BasketReward
        {

     
            public int LMRewardId { get; set; }
           
            public string Title { get; set; }
    
            public string RewardTitle { get; set; }
      
            public string ImageUrl { get; set; }
        
            public int BuyQtyAmount { get; set; }

            public int PurchasedQty { get; set; }
 
            public int RoundedPurchasedAmount { get; set; }
        }
        public class BasketRewardResponse
        {
  
            public ErrorMessage ErrorMessage { get; set; }

            public decimal TotalSavingsAmount { get; set; }

            public BasketReward BasketRewardDetails { get; set; }
        }

        // Recent Baskets
        public class RecentBaskets
        {
            public int StoreId { get; set; }    
            public string StoreName { get; set; }   
            public DateTime TransactionDate { get; set; }
            public string? TransactionTime { get; set; } 
            public decimal Amount { get; set; } 
            public string MemberNumber { get; set; }  
            public string UserName { get; set; }
        }

        public class RecentBasketsResponce
        {
          
            public ErrorMessage ErrorMessage { get; set; }
    
            public List<RecentBaskets> RecentBaskets { get; set; }

        }

        // Recent Reedemptions
        public class RecentRedemptions
        {
            public string PromotionId { get; set; } 
            public decimal RedeemAmount{ get; set; }
            public DateTime CreatedDate { get; set; }    
            public string MemberNumber { get; set; }  
            public string UserName { get; set; }    
        }

        public class RecentRedemptionsResponce
        {
            public ErrorMessage ErrorMessage { get; set; }
            public List<RecentRedemptions> RecentRedemptions { get; set; }

        }

        // Recent clips
        public class RecentClips
        {
            public string Title { get; set; }   
            public string Details { get; set; } 
            public DateTime NCRImpressionDate { get; set; }
            public string MemberNumber { get; set; }    
            public string Username { get; set; }
        }

        public class RecentClipsResponce
        {
            public ErrorMessage ErrorMessage { get; set;}
            public List<RecentClips> RecentClips { get; set; }
        }

        // GET Slides
        public class Slide
        {
            public int SlideId { get; set; }    
            public string ImageUrl { get; set; }
            public string FeaturedText { get; set; } 
            public bool IsActive { get; set; }
            public bool IsDealOfTheWeek { get; set; }   
            public DateTime CreatedDate { get; set; }
        }
        public class SlidesResponce
        {
            public ErrorMessage ErrorMessage { get; set; }
            public List<Slide> Slides { get; set; }

        }

        // Menulist
        public class MenuListResponce
        {
            public ErrorMessage ErrorMessage { get; set; }
            public List<Menu> MenuList { get; set; }
            public bool ShowHomePageSlider { get; set; }    
            public bool EnableSendToList { get; set; }  
        }
   
       
        public class Menu 
        {
            public int MenuId { get; set; }   
        public string ImageUrl { get; set; }
        public int MenuSequenceNumber { get; set; } 
        public bool IsActive { get; set; }
        public string MenuTitle { get; set; }   
        public DateTime CreatedDate { get;set; }
        public string ColorCode { get; set; }   
        }

        // 
        public class UserMyCardResponce
        {
            public ErrorMessage ErrorMessage { get; set; }
            public string MemberNumber { get; set; }   
            public string BarCodeUrl { get; set; }  
            public decimal TotalSavingsAmount { get; set; } 
            public decimal TotalPurchasedAmount { get; set; }   
        }


        // RecipeCategories
        public class RecipeCategoriesResponce
        {
            public ErrorMessage ErrorMessage { get; set; }
            public List<RecipeCategories> RecipeCategories { get; set; }
        }
       public class RecipeCategories
        {
            public int RecipeCategoryId { get; set; }
            public string ImageUrl { get; set; }
            public string? CategoryName { get; set; }
            public int? RecipesCount { get; set; }
        }

        //WeeklyAdGallery
        public class WeeklyAdGalleryResponse
        {
            public ErrorMessage ErrorMessage { get; set; }
            public DateTime AdStartDate { get; set; }
            public DateTime AdEndDate { get; set; } 
            public List<GalleryItems> GalleryItems { get; set; }
            public string AdStartDateString { get; set; }   
            public string AdEndDateString { get; set; } 
        }
    
     
         public class GalleryItems
        {
            public int PageNumber { get; set; }
            public string URL { get; set; }
            public string GalleryType {  get; set; }    


        }

       public class Specials
        {
            public int SSNewsId { get; set; }  
            public string Title { get; set; }
            public string Details { get; set; }
            public string ImagePath { get; set; }
            public DateTime ValidFromDate { get; set; }
            public DateTime ExpiresOn { get; set; }
            public bool SendNotification { get; set; }
            public int CustomerID { get; set; } 
            public string CustomerName { get; set; }
            public string NewsCategoryDescription { get; set; }
            public bool IsWeeklyCoupons { get; set; }   
            public string ProductName { get; set; } 
            public decimal Amoount {  get; set; }   
            public decimal DiscountAmoount { get; set; }  
            public bool IsDiscountPercentage { get; set; }  
            public int ProductId {  get; set; }
            public string RedeemDate { get; set; }  
            public bool IsRedeem { get; set; }  
            public bool IsInCart { get; set; }  
            public string PLUCode { get; set; } 
            public string NCRPromotionCode { get; set; }    
            public bool IsInNCRImpressions { get; set; } 
            public int NewsCategoryId { get; set; } 
            public bool IsFeatured {  get; set; }  
            public int ProductCategoryId { get; set; }  
            public string SpecialPrice { get; set; }   
            public string DepartmentName { get; set; }  
            public int CouponLimit { get; set; }    
            public string ExpiresOnDateString { get; set; } 
            public string NoOfDaysLeftString { get; set; }  
        }
        
      
        public class SpecialSResponce
        {
            public ErrorMessage ErrorMessage { get; set; }
            public List<Specials> Specials { get; set; }
            public string iPhoneVersion { get; set; }   
            public string AndroidVersion { get; set;}
            public bool UpdateConfigSettings { get; set; }
            public bool RequiredAcceptTerms { get; set; }   
            public bool RequiredIOSAppUpdate { get; set;}
            public bool RequiredAndroidAppUpdate { get; set; } 
            public bool NewTermsAcceptanceRequired { get; set; }    
            public string SettingsLastChangeDate { get; set; }
        }

        // Terms
        public class TermsResponse
        {
            public ErrorMessage ErrorMessage { get; set; }
            public List<Terms> Terms { get; set; }  
        }
        public class Terms
        {
            public string Title { get; set; }   
            public string URL { get; set;}  
        }
        // orders:

        public class GetOrdersResponse
        {
            public ErrorMessage ErrorMessage { get; set; }
            public List<UserOrderInfo> OrderInfo { get; set; }
        }

        public class UserOrderInfo
          
        {
            public int OrderId { get; set; }
            public int UserID { get; set; }
            public string OrderNumber { get; set; }
            public DateTime OrderDate { get; set; }
            public int ShippingAddressID { get; set; }
            public DateTime DeliveryDate { get; set; }
            public int ServicingLocationID { get; set; }
            //public DateTime CreatedDate { get; set; }
            public List<UserOrderDetails> OrderDetailInfo { get; set; }   
            public UserOrderPayments UserOrderPaymentInfo { get; set; }
        }

        public class UserOrderDetails
        {
            public int OrderId { get; set; }   
            public int UserID { get; set; } 
            public int OrderItemID { get; set; } 
            public int NewsID { get; set; }
            public int Qty { get; set; }   
            public decimal Price { get; set; }
            public decimal Amount { get; set; }
            public DateTime CreatedDate { get; set; }   
        }
          
        public class UserOrderPayments
        {
            public int? OrderId { get; set; }    
            public int? PaymentTypeID { get; set; }
            public bool? PaymentConfirmation {  get; set; }  
            public decimal? Amount { get; set; } 
        }
        public class MenuResponse
        {

  
            public ErrorMessage ErrorMessage { get; set; }
  
            public List<MenuItems> MenuList { get; set; }

        }

        public class MenuItems
        {
            
            public int SSNewsId { get; set; }

            public string Title { get; set; }

            public string Details { get; set; }
  
            public string ImagePath { get; set; }

            public DateTime ValidFromDate { get; set; }
        
            public DateTime ExpiresOn { get; set; }
   
            public bool SendNotification { get; set; }
    
            public int CustomerID { get; set; }
     
            public string CustomerName { get; set; }
      
            public string NewsCategoryDescription { get; set; }

            public bool IsWeeklyCoupons { get; set; }
           
            public string ProductName { get; set; }
        
            public decimal Amount { get; set; }

            public decimal DiscountAmount { get; set; }
    
            public bool IsDiscountPercentage { get; set; }
  
            public int ProductId { get; set; }
           
            public string RedeemDate { get; set; }
        
            public bool IsRedeem { get; set; }

            public bool IsInCart { get; set; }

            public string PLUCode { get; set; }

            public string NCRPromotionCode { get; set; }
   
            public bool IsInNCRImpressions { get; set; }
   
            public int NewsCategoryId { get; set; }
        
            public bool IsFeatured { get; set; }
   
            public int ProductCategoryId { get; set; }

            public string SpecialPrice { get; set; }
       
            public string DepartmentName { get; set; }
        }

        public class MenuRequest
        {
            public string UserToken { get; set; }   
            public int StoreID { get; set; }    
            public string DeliveryDate { get; set; }    
            public int DeliverAddressID { get; set; }   
        }

        public class UserGroupsResponse
        {
            public ErrorMessage ErrorMessage { get; set; }
            public int[] GroupIds { get; set; }  
        }
        public class UserRedeemedCouponsResponse
        {
            public ErrorMessage ErrorMessage { get; set; }
            public int[] CouponIds { get; set; }
        }
        public class UserCouponsAndGroupsResponse
        {
            public ErrorMessage ErrorMessage { get; set;}
            public int[] GroupIds { get; set; } 
            public int[] RedeemedCouponIds { get; set; }
            public int[] OptInCouponIds { get; set; }

        }


        public class UserCouponsandGroups
        {
            public int NewsID { get; set; }
            public int UserID { get; set; }
            
        }
        public class UserOptInCoupons
        {
            public int SSNewsID { get; set;}
            public int UserID { get; set; }
        }

        public class UserGroups
        {
            public int ClubID { get; set; } 
            public int UserID { get; set; }

        }
        public class FinalUserCouponsandGroups
        {
            public List<UserCouponsandGroups> UserRedeemedCoupons { get; set; }
            public List<UserOptInCoupons> UserOptionCoupons { get; set;}
            public List<UserGroups> UserGroups { get; set; }    

        }

        public class RewardCountsByDepartmentResponse
        {
            public ErrorMessage ErrorMessage { get; set;}   
            public List<RewardCountsByDepartment> RewardCountsByDepartment { get; set; }    
        }

        public class RewardCountsByDepartment
        {
            public int DepartmentId { get; set; }   
            public string DepartmentName { get; set; }  
            public int NoOfRewards { get; set; }   
            public string DepartmentImageUrl { get; set; }    

        }
        public class LMRewardForDepartmentResponse
        {
            public ErrorMessage ErrorMessage { get; set;}    
            public List<LMRewardsForDepartment> LMRewardsForDepartment { get; set; }   
        }
        public class LMRewardsForDepartment
        {
            public int LMRewardId { get; set; } 
            public string Title { get; set; }   
            public int RewardTypeId { get; set; }   
            public string RewardTypeName { get; set; } 
            public int BuyQtyAmount { get; set; }   
            public int PurchasedQty { get; set; } 
            public int PurchasedAmount { get; set; } 
            public string ImageUrl { get; set; }    
            public string RewardDetails { get; set; }   
            public string ValidUPCs { get; set; }   


        }

        public class QualifiedRewardTiersResponse
        {
            public ErrorMessage ErrorMessage { get; set;}
            public List<QualifiedRewardTiers> QualifiedRewardTiers { get; set; }    
        }
       
        public class QualifiedRewardTiers
        {
            public int LMRewardTierID { get; set; }  
            public int LMrewardID {  get; set; }
            public string? TierTitle { get; set; }   
            public  int PointsRequired { get; set; } 
            public decimal CouponValue { get; set; }    
            public decimal CurrentPoints { get; set; }  

        }

        public class RewardQualifiedTiersResponse
        {
            public ErrorMessage ErrorMessage { get; set;}
            public QualifiedTiersRewardDetails RewardDetails { get; set; }
            public List<RewardQualifiedTier> QualifiedRewardTiers { get; set; } 
        }
        public class QualifiedTiersRewardDetails
        {
            public int LMRewardID { get; set; } 
            public string Title {  get; set; }  
            public string RewardTitle { get; set; } 
            public string RewardDetails { get; set; }   
            public string RewardAdditionalDetails { get; set; } 
            public string RewardPointsText { get; set; } 
            public string RewardOptionsText { get; set; }   
            public string RewardOptionsNoteText { get; set; }   
            public decimal MemberPoints { get; set; }   
            public int RoundedMemberPoints {  get; set; }  
            public string MemberPointsString { get; set; }  

        }
        public class RewardQualifiedTier 
        {
            public int LMRewardTierID { get; set; } 
            public string TierTitle { get; set; }   
            public string TierTitleDesc { get; set; }   
            public int PointsRequired { get; set; } 
            public string PointsRequiredString { get; set; }    
            public decimal CouponValue { get; set; } 
            public string CouponValueString { get; set; }  
            public decimal MinRequiredAmount { get; set; }  
            public int TierRewardCouponTypeId { get; set; } 
            public bool IsItQualifiedforReward { get; set; } 
            public string TierImageUrl { get; set; }   
            public bool IsDiscountPercentage { get; set; }   
        }

       public class PointsBasedRewardDetailsResponse
        {
            public ErrorMessage ErrorMessage { get; set; }
            public PointsBasedRewardDetails RewardDetails { get; set; }
            public List<PointsBasedRewardDetailsTierInfo> RewardTiers { get; set; }
        }
        public class PointsBasedRewardDetails
        {
            public int LMRewardID {  get; set; } 
            public string Title { get; set; }   
            public string ImageUrl { get; set; }   
            public string RewardTitle { get; set; }
            public string RewardDetails { get; set; }   
            public string RewardAdditionalDetails { get; set; }
            public string RewardPointsText { get; set; }    
            public string RewardPointsTextWithBalance { get; set; }
            public string RewardOptionsText { get; set; } 
            public string RewardAdditionalTermsText { get; set; }  
            public string RewardDetailsNoteText { get; set; }   
            public decimal MemberPoints {  get; set; }  
            public int RoundedMemberPoints { get; set; } 
            public string MemberPointsString { get; set; }  
        }
       
        public class PointsBasedRewardDetailsTierInfo
        {
            public int LMRewardTierID { get; set; } 
            public string TierTitle { get; set; }
            public string TierTitleDesc { get; set; }
            public int PointsRequired { get; set; } 
            public string PointsRequiredString { get; set; }    
            public decimal CouponValue { get; set; }   
            public string CouponValueString { get; set; }   
            public decimal MinRequiredAmount { get; set; }
            public int TierRewardCouponTypeId { get; set; } 
            public string TierImageUrl { get; set; }    
            public bool IsDiscountPercentage { get; set; }  

        }

        public class ClientGeneralInfoResponse
        {
            public ErrorMessage ErrorMessage { get; set; }
            public ClientGeneralInfo ClientGeneralInfo { get; set; }   
            public List<SocialMediaSettings> SocialMediaSettings { get; set; }
        }
        public class ClientGeneralInfo 
        {
            public string ClientStoreName { get; set; } 
            public string City { get; set; }    
            public string State { get; set; }
            public string ZipCode { get; set; }
            public string StoreTimings { get; set; }   
            public string StorePhoneNumber { get; set; }
            public string WebSiteURL { get; set; }  
            public int ClientStoreId { get; set; } 
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }    
            public string StoreEmail { get; set; } 
            public string SupportEmail { get; set; }
            public bool AllowLinkCardRegistration { get; set; } 
            public string LinkCardRegistrationText { get; set; }
            public bool AllowNewRegistration { get; set; }  
            public string ClientProfile {  get; set; }  
            public int MemberCardMinLength { get; set; }
            public int MemberCardMaxLength { get; set; }   
            public bool EnableStoreEvents { get; set; } 
            public string StoreTimingLable {  get; set; }   
            public string ClientLogo { get; set; }  
            public bool UsePhoneNumberAsLoyaltyNumber { get; set; }  
            public bool EnableEmailAddressUpdate { get; set; }  
           public bool IsPhoneNumberMandatory { get; set; } 
            public bool EnableShopMenu { get; set; }    
            public string EnableShopMenuWebSiteUrl { get; set; }   
            public bool EnableCateringMenu { get; set; }    
            public string EnableCateringMenuWebSiteUrl { get; set; }
            public string PrescriptionRefillsLinkUrl { get; set; }  
            public string PrescriptionRefillsText { get; set; }
        }
        public class SocialMediaSettings
        {
            public string Title { get; set; }   
            public string Value { get; set; }
            public string ImageURL { get; set; }   
            public bool IsSocialMedia { get; set; } 
            public int SequenceNumber { get; set; } 

        }

        public class GetAllEventsResponse
        {
            public ErrorMessage ErrorMessage { get; set; }  
            public List<Events> Events { get; set; }
        }
        public class Events
        {
            public int EventID { get; set; }
            public string Title { get; set; }   
            public string Details { get; set; } 
            public string OtherDetails { get; set; }
            public DateTime? StartDate { get; set; } 
            public DateTime? EndDate { get; set; }
            public string TermsAndConditions { get; set; }  
            public string EventButtonText { get; set; } 
            public string ImagePath1 { get; set; }  
            public string ImagePath2 { get; set; }
            public string ImagePath3 { get; set; }  
            public int EventCategoryID { get; set; }  
            public bool IsTermsAccepted { get; set; } 
            public bool IsEnrolled { get; set; }    
            public bool ShowTitleOnSlider { get; set; }
            public int EventTypeId { get; set; }    
        }

        public class SurveyResponse
        {
            public ErrorMessage ErrorMessage { get; set; }
            public Survey Survey { get; set; }
        }
        public class Survey
        {
            public List<SurveyQuestions> SurveyQuestions { get; set; }
            public int SurveyID { get; set; }  
            public DateTime StartsOn { get; set; }
            public DateTime ExpiresOn { get; set; }
            public string Title { get; set; }   
            public string Details { get; set; } 
            public string SurveyImageURL { get; set; }  
            public bool IsStoreSpecific { get; set; }   
            public bool IsTargetSpecific { get; set; }  
            public int RewardCouponID { get; set; } 
            public decimal RewardPoints { get; set; }   
            public int NumberOfQuestions { get; set; }  
            public int StatusID { get; set; }   
        }
        public class SurveyQuestions
        {
           public List<SurveyQuestionOptions> SurveyQuestionOptions { get; set; } 
           public int SurveyQuestionID { get; set; }    
           public int SurveyID { get; set; }    
           public int SortPosition { get; set; }    
           public int QuestionType { get; set; }
           public string QuestionTitle { get; set; }
           public string QuestionInfoDetails { get; set; }
           public string SurveyQuestionImageURL { get; set; }  
           public bool IsOptionsEnabled { get; set; }   
           public int TotalOptions { get; set; }   

        }
        public class SurveyQuestionOptions
        {
            public int SurveyQuestionOptionID { get; set; } 
            public int SurveyQuestionID { get; set; }   
            public int SortPosition { get; set; }    
            public string OptionTitle { get; set; } 
            public int OptionIconTypeID { get; set; }   
            public string OptionIconImageURL { get; set; }  
        }
        public class MobileAppVersionResponse
        {
           public ErrorMessage ErrorMessage { get; set; }
            public MobileAppVersion MobileAppVersion { get; set; }  
        }
        public class MobileAppVersion
        {
            public string androidappversion { get; set; }   
            public string iosappversion { get; set; }   
            public string iosversionupdatemessage { get; set; } 
            public string androidversionupdatemessage { get; set; } 
            public bool iosappforceupdate { get; set; } 
            public bool androidappforceupdate { get; set; } 
            public string iosappurl { get; set; }   
            public string androidappurl { get; set; }   
            
        }

        public class RewardUPCTierProductsResponse
        {
            public ErrorMessage ErrorMessage { get; set; }
            public List<RewardUPCTierProducts> RewardUPCTierProducts { get; set; }  
        }
        public class RewardUPCTierProducts
        {   
            public int LMRewardTierID { get; set; }
            public int LMRewardID { get; set; } 
            public string TierTitle { get; set; }   
            public int PointsRequired { get; set; } 
            public string PointsRequiredString { get; set; }    
            public decimal CouponValue { get; set; }    
            public int TierRewardCouponTypeId { get; set; } 
            public string Title { get; set; }  
            public string UPC {  get; set; }   
            public string ProductName { get; set; } 
            public string DeductPointsText {  get; set; }   
            public string ImageUrl { get; set; }    
            
        }
        public class MostRecentPurchaseItemsResponse
        {
            public ErrorMessage ErrorMessage { get; set; }
            public List<MostRecentPurchaseItems> PurchaseItems { get; set; }    
        }
        public class MostRecentPurchaseItems
        {
            public int ProductId { get; set; } 
            public string ProductCode { get; set; } 
            public string ProductName { get; set; }
        }
        public class UserLocationsResponse
        {
            public ErrorMessage ErrorMessage { get; set; }
            public List<UserLocations> UserLocations { get; set; }
        }
        public class UserLocations
        {
            public int UserAddressID { get; set; }  
            public int UserID { get; set; } 
            public string Address1 { get; set; }
            public string Address2 { get; set; } 
            public string City { get; set; }    
            public int StateId { get; set; }
            public string StateName { get; set; }  
            public string CountryName { get; set; }
            public string ZipCode { get; set; } 
            public int AddressTypeId {  get; set; } 
            public string DrivingInstructions { get; set; } 
            public string UserName { get; set; }   
            public string FirstName { get; set; }   
            public string LastName { get; set; }    
        }
       public class ShoppingCartDetails
        {
            public int MyCartId { get; set; }   
            public int OfferId { get; set; }    
            public string Title { get; set; }   
            public string Details { get; set; }
          //  public string RedeemDate { get; set; }  
         // public bool RedeemOn { get; set; }
           public string ImagePath { get; set; }
          // public bool IsDiscountPercentage { get; set; }  
          public DateTime ExpiresOn { get; set; }   
          public decimal DiscountAmount { get; set; } 
           public decimal Amount { get; set; }   
           public int ProductId { get; set; } 
           public int CategoryId { get; set; } 
           public string ProductName { get; set; }  
           public int ItemQty {  get; set; }   
           public decimal ItemTotalAmount {  get; set; }     
           public int DepartmentId { get; set; }    
           public string ValidFrom { get; set; }    
           public string ProductCode { get; set; }  
            public int NewsCategoryId { get; set; } 
            public string SpecialPrice { get; set; }  
            public string DepartmentName {  get; set; } 
            public bool AddToCart { get; set; }
            public bool IsCoupon { get; set; }  
        }

    }


}
