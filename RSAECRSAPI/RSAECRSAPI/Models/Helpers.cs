using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Newtonsoft.Json;

namespace RSAECRSAPI.Models
{
    public class Helpers
    {
        private readonly List<AppConfigurations> _appConfigurations;

        public Helpers(List<AppConfigurations> appConfigurations)
        {
            _appConfigurations = appConfigurations;
        }
        public async Task<string> ConnectionStringBuilder(ConnectionString model)
        {
           string connectionstring = "";
            try
            {
                connectionstring = "Data Source =" + model.DataSource + ";Initial Catalog=" + model.Database + ";uid=" + model.UserId + ";Password=" + model.Password;

                    
            }
            catch (Exception ex) {
            
            }
            return await Task.FromResult(connectionstring);
        }
        public async Task<AppConfiguartionsResponse> ReadJsonFile(string sharedKey, string secret)
        {
            AppConfiguartionsResponse appConfiguartionsResponse = new AppConfiguartionsResponse();
           
            try
            {
                var json = await File.ReadAllTextAsync("D:\\csharpprojects\\RSAECRSAPI\\RSAECRSAPI\\Appconfigurations.json");
                var jsonData = JsonConvert.DeserializeObject<List<AppConfigurations>>(json);
                var appConfigurationData = jsonData?.FirstOrDefault(x => x.SharedKey == sharedKey && x.SecretKey == secret);
                if (jsonData?.Count < 0 || appConfigurationData == null)
                {
                    appConfiguartionsResponse.ErrorCode = "404";
                    appConfiguartionsResponse.ErrorDesc = "";
                    appConfiguartionsResponse.Status = "No json file data";
                    return appConfiguartionsResponse;

                }
                
                appConfiguartionsResponse.AppConfigurations = new AppConfigurations
                {
                    SharedKey = appConfigurationData?.SharedKey,
                    SecretKey = appConfigurationData?.SecretKey,
                    RetailerName = appConfigurationData?.RetailerName,
                    RemoveCheckDigitFromBasketUPC = appConfigurationData?.RemoveCheckDigitFromBasketUPC,
                    MemberNumberLength = appConfigurationData?.MemberNumberLength,
                    MaxCouponValueForClient = appConfigurationData?.MaxCouponValueForClient,
                    RSACoreAPIUrl = appConfigurationData?.RSACoreAPIUrl,
                    SystemNotificationsARN = appConfigurationData?.SystemNotificationsARN,
                    EnableRemoveNCRImpression = appConfigurationData?.EnableRemoveNCRImpression,
                    EnterpriseId = appConfigurationData?.EnterpriseId,
                    EnterpriseSecret = appConfigurationData?.EnterpriseSecret,
                    NCRImpressionAPIUrl = appConfigurationData?.NCRImpressionAPIUrl,
                    UPCCouponTypeIds = appConfigurationData?.UPCCouponTypeIds,
                    CrossSellCouponTypeIds = appConfigurationData?.CrossSellCouponTypeIds,
                    MFRUPCCouponTypeIds = appConfigurationData?.MFRUPCCouponTypeIds,
                    SetCouponMultiLineIdsToZero = appConfigurationData?.SetCouponMultiLineIdsToZero,
                    CrossSellCouponsPurchaseUPCsOrderByAmount = appConfigurationData?.CrossSellCouponsPurchaseUPCsOrderByAmount,
                    EnableWriteLogs = appConfigurationData?.EnableWriteLogs,
                    EnableEmailNotificationAlerts = appConfigurationData?.EnableEmailNotificationAlerts,
                    SendTransactionsToCloud = appConfigurationData?.SendTransactionsToCloud,
                    POSType = appConfigurationData?.POSType,
                    DBInstanceName = appConfigurationData?.DBInstanceName,
                    DBName = appConfigurationData?.DBName,
                    CloudRetailerName = appConfigurationData?.CloudRetailerName,
                    SendTransactionToCloudURL = appConfigurationData?.SendTransactionToCloudURL,
                    SendCommitToCloudURL = appConfigurationData?.SendCommitToCloudURL,
                    GetTransactionCloudURL = appConfigurationData?.GetTransactionCloudURL,
                    MoveTransactionToProcessedFolderCloudURL = appConfigurationData?.MoveTransactionToProcessedFolderCloudURL,
                    RetailerConnectionString = appConfigurationData?.RetailerConnectionString.ToString(),
                    SqlCommandTimeout = appConfigurationData?.SqlCommandTimeout,
                    ApplyOnlyOneBasketCouponFlag = appConfigurationData?.ApplyOnlyOneBasketCouponFlag,
                    SaveRealtimeTransactionData = appConfigurationData?.SaveRealtimeTransactionData
                };
                appConfiguartionsResponse.ErrorCode = "200";
                appConfiguartionsResponse.ErrorDesc = "";
                appConfiguartionsResponse.Status = "Success";

            }
            catch (Exception ex)
            {
                appConfiguartionsResponse.ErrorCode = "500";
                appConfiguartionsResponse.ErrorDesc = ex.Message;
                appConfiguartionsResponse.Status = "Internel server error";
            }
            return appConfiguartionsResponse;   
        }
    }
}

