using Microsoft.Extensions.Options;
using RSAMobileAPI.RSAEntities;

namespace RSAMobileAPI.RSARepositories.Services
{
    public class ConfigurationHelper
    {
        private readonly IOptions<AppSettings>? _appsettings;

        public ConfigurationHelper(IOptions<AppSettings> appsettings)
        {
            _appsettings = appsettings;
        }

        public  string MyRewardsOfflineMsg
        {
            get { return _appsettings?.Value.MyRewardsOfflineMsg.ToString(); 
            }
        }
        public  string AmazonBucketName
        {
            get{ return _appsettings.Value.AmazonBucketName.ToString(); }
        }
        public  string AmazonS3Url
        {
            get { return _appsettings.Value.AmazonS3Url.ToString(); }
        }
        public  string WebSiteUrl
        {
            get { return Convert.ToString(_appsettings.Value.WebSiteUrl); }
        }
        public  EnumMgr.FileUploadMode FileUploadMode
        {
            get
            {
                //Default is Local Physical IO
                int location = 1;
                if(_appsettings?.Value.FileUploadMode != null)
                {
                    location = Convert.ToInt32(_appsettings?.Value.FileUploadMode.ToString());
                }
                return (EnumMgr.FileUploadMode)location;    
            }
        }
        public  bool EnableSendEmailActivationLinkToNewUsers
        {
            get { return Convert.ToBoolean(Convert.ToInt32(_appsettings?.Value.EnableSendEmailActivationLinkToNewUsers.ToString())); }
        }
        public  bool EnableUserNameEmailVerification
        {
            get { return Convert.ToBoolean(Convert.ToInt32(_appsettings?.Value.EnableUserNameEmailVerification.ToString())); }
        }
        public  bool EnablePhoneNumberVerification
        {
            get { return Convert.ToBoolean(Convert.ToInt32(_appsettings?.Value.EnablePhoneNumberVerification.ToString())); }
        }
        public  bool UsePhoneNumberAsLoyaltyNumber
        {
            get { return Convert.ToBoolean(Convert.ToInt32(_appsettings?.Value.UsePhoneNumberAsLoyaltyNumber.ToString())); }
        }

        public  int ClientStoreId
        {
            get { return Convert.ToInt32(_appsettings?.Value.ClientStoreId.ToString()); }
        }

        public  string PrivacyAndPolicy
        {
            get { return _appsettings?.Value.PrivacyAndPolicy; }
        }
        public  string TermsAndConditions
        {
            get { return _appsettings?.Value.TermsAndConditions.ToString(); }
        }
        public  string SupportUrl
        {
            get { return _appsettings?.Value.SupportUrl.ToString(); }
        }
        public  string ClientWebSiteUrl
        {
            get { return _appsettings?.Value.ClientWebSiteUrl.ToString(); }
        }

        public  bool AllowLinkCardRegistration
        {
            get { return Convert.ToBoolean(Convert.ToInt32(_appsettings?.Value.AllowLinkCardRegistration.ToString())); }
        }
        public  bool AllowNewRegistration
        {
            get { return Convert.ToBoolean(Convert.ToInt32(_appsettings?.Value.AllowNewRegistration.ToString())); }
        }
        public string SlidesFolderNameInS3
        {
            get { return _appsettings?.Value.SlidesFolderNameInS3.ToString(); }
        }
        public string MenuImagesFolderNameInS3
        {
            get { return _appsettings?.Value?.MenuImagesFolderNameInS3?.ToString(); }

        }
        public string BarCodeUrlPath
        {
            get { return _appsettings?.Value.BarCodeImagePath.ToString(); }
        }
        public string RecipeCategoryImagesFolderNameInS3
        {
            get { return _appsettings?.Value.RecipeCategoryImagesFolderNameInS3.ToString(); }
        }
        public string WeeklyAdType
        {
            get { return _appsettings?.Value.WeeklyAdType.ToString(); }
        }
        public string WeeklyAdPdfFolderName
        {
            get { return _appsettings?.Value.WeeklyAdPdfs.ToString(); }
        }
        public string JustForYouOfflineMsg
        {
            get { return _appsettings?.Value.JustForYouOfflineMsg.ToString(); }
        }
        public string AndroidVersion
        {
            get { return _appsettings?.Value.AndroidVersion.ToString(); }
        }
        public string iPhoneVersion
        {
            get { return _appsettings?.Value.iPhoneVersion.ToString(); }
        }
        public bool UpdateConfigSettings
        {
            get { return Convert.ToBoolean(Convert.ToInt32(_appsettings?.Value.UpdateConfigSettings.ToString())); }
        }
        public bool RequiredAcceptTerms
        {
            get { return Convert.ToBoolean(Convert.ToInt32(_appsettings?.Value.RequiredAcceptTerms.ToString())); }
        } 
        public string SettingsLastChangeDate
        {
            get { return _appsettings?.Value.SettingsLastChangeDate.ToString(); }
        }
        public int HoursDifferenceBetweenGMTAndClient
        {
            get
            {
                return Convert.ToInt32(_appsettings?.Value.HoursDifferenceBetweenGMTAndClient.ToString());
            }
        }
        public string DepartmentImagesFolderName
        {
            get
            {
                return Convert.ToString(_appsettings?.Value.AmazonDepartmentImagesFolderName);
            }
        }
       
    }


}
