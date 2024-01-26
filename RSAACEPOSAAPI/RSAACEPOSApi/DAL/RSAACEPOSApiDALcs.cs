using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RSAACEPOSApi.Models;


namespace RSAACEPOSApi.DAL
{
    public class RSAACEPOSApiDALcs
    {
        public ConfigsValues ConfigsValues { get; set; }
        private readonly IOptions<Configs> _options;
        private readonly IOptions<List<ConfigSettings>> _config;
        private readonly IOptions<ConfigsValues> _configValues;

        public RSAACEPOSApiDALcs(
                IOptions<Configs> options,
                 IOptions<List<ConfigSettings>> config,
                 IOptions<ConfigsValues> configValues
            )
        {
           _options = options;
            _config = config;
            _configValues = configValues;
        }
       
        public UpdateTransactionResponse transaction(string site, string customer, string transaction, UpdateTransactionRequest TranRequest)
        {
            UpdateTransactionResponse response = new UpdateTransactionResponse();
            List<Applied> applieds = new List<Applied>();
            try
            {
                response.status = "success";
                response.errorDesc = "sucess";
                response.errorCode = "200";
                response.applied = applieds;

            }catch (Exception ex)
            {
                response.status = "Internal server error";
                response.errorDesc = ex.Message;
                response.errorCode = "500";
                response.applied = null;

            }
          
           

            return response;
        }

       public CancelResponse cancel(string site, string customer, string transaction, string sharedkey, string secret)
        {
            Console.WriteLine(_configValues);
           
            CancelResponse response = new CancelResponse();
            try
            {
                response.status = "success";
                response.errorDesc = "sucess";
                response.errorCode = "200";

            }
            catch (Exception ex)
            {
                response.status = "Internal server error";
                response.errorDesc = ex.Message;
                response.errorCode = "500";

            }
            return response;
        }


        public CommitResponse commit(string site, string customer, string transaction, string sharedkey, string secret, CommitTransactionRequest commitTranRequest)
        {

            CommitResponse response = new CommitResponse();
            try
            {
                response.status = "success";
                response.errorDesc = "sucess";
                response.errorCode = "200";

            }
            catch (Exception ex)
            {
                response.status = "Internal server error";
                response.errorDesc = ex.Message;
                response.errorCode = "500";

            }
            return response;
        }
      public  CancelResponse canceltransaction(CancelTransactionRequest cancelTranRequest)
        {
            CancelResponse response = new CancelResponse();
            try
            {
                response.status = "success";
                response.errorDesc = "sucess";
                response.errorCode = "200";

            }
            catch (Exception ex)
            {
                response.status = "Internal server error";
                response.errorDesc = ex.Message;
                response.errorCode = "500";

            }
            return response;

        }

     public  MemberInfoResponse getcustomerinfo(MemberInfoRequest MemberInfoRequest)
        {
            MemberInfoResponse response = new MemberInfoResponse();

            try
            {
                response.status = "success";
                response.errorMessage = "sucess";
                response.errorCode = "200";
                response.message = "success";
                
        
           }
            catch (Exception ex)
            {
                response.status = "Internal server error";
                response.errorMessage = ex.Message;
                response.errorCode = "500";
                response.message ="Internal server error";

            }
            return response;
        }
     public List<ConfigSettings> GetConfigs()
        {
            
             try {
                var data = _configValues.Value.ConfigSettings.ToArray();

                if(data != null)
                {
                    var configSettings = JsonConvert.SerializeObject(data);
                    var jsonData = JsonConvert.DeserializeObject<List<ConfigSettings>>(configSettings);
                    return jsonData;
                }
                else
                {
                    return null;
                }
              
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
        public ConfigSettings GetbyRetailerId(string id)
        {

            try
            {
                var data = _configValues.Value.ConfigSettings.ToArray();

                if (data != null)
                {
                    var configSettings = JsonConvert.SerializeObject(data);
                    var jsonData = JsonConvert.DeserializeObject<List<ConfigSettings>>(configSettings);
                   
                   var  getData = jsonData?.FirstOrDefault(item => item.RetailerId == id);
                    return getData!;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
   
}
