using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RSAMobileAPI.RSAEntities
{
    public class AppSettings
    {
        public string EnableSendEmailActivationLinkToNewUsers { get; set; }
        public string EnableUserNameEmailVerification { get; set; }
        public string EnablePhoneNumberVerification { get; set; }
        public string UsePhoneNumberAsLoyaltyNumber { get; set; }
        public string IsQTokenEnable { get; set; }
        public string PhoneNumberLength { get; set; }
        public string MPMDbConnectionString { get; set; }
        public string TOKEN_EXPIRATION { get; set; }
        public string ClientStoreId { get; set; }
        public string PrivacyAndPolicy { get; set; }
        public string TermsAndConditions { get; set; }
        public string SupportUrl { get; set; }
        public string ClientWebSiteUrl { get; set; }
        public string AllowLinkCardRegistration { get; set; }
        public string AllowNewRegistration { get; set; }
        public string MemberCardMinLength { get; set; }
        public string MemberCardMaxLength { get; set; }
        public string MyRewardsOfflineMsg { get; set; }
        public string FileUploadMode { get; set; }
        public string WebSiteUrl { get; set; }
        public string AmazonBucketName { get; set; } 
        public string AmazonS3Url { get; set; } 

        public string SlidesFolderNameInS3 { get; set; }  
        public string MenuImagesFolderNameInS3 { get;set; }  
        public string BarCodeImagePath {  get; set; }  
        public string RecipeCategoryImagesFolderNameInS3 { get; set; }  
        public string WeeklyAdType {  get; set; }
         public string WeeklyAdPdfs {  get; set; }  
        public string? PrivacyTermsTitle { get; set; }
        public string? PrivacyTermsUrl { get; set; }
        public string? TermsAndConditionsTitle { get; set; }
        public string? TermsAndConditionsUrl { get; set; }   
        public string? JustForYouOfflineMsg { get; set; }    
        public string AndroidVersion {  get; set; } 
        public string iPhoneVersion { get; set; }   
        public string UpdateConfigSettings { get; set;}
        public string RequiredAcceptTerms { get; set; } 
        public string SettingsLastChangeDate { get; set; }  
        public string HoursDifferenceBetweenGMTAndClient { get; set;}
        public string AmazonDepartmentImagesFolderName {  get; set; } 
        public string TokenForContactUs { get; set; }
        public string ShowTitleOnSlider {  get; set; }  
        public string AndroidAppVersion {  get; set; }  
        public string IosAppVersion { get; set; }   
        public string iosversionupdatemessage { get; set; } 
        public string androidversionupdatemessage { get; set;}  
        public string iosappforceupdate {  get; set; }  
        public string androidappforceupdate { get; set; }   
        public string IosAppUrl { get; set; }   
        public string AndroidAppUrl { get; set; }   

    }
}

