using RSAMobileAPI.RSADALayer;
using RSAMobileAPI.RSAEntities;
using RSAMobileAPI.RSARepositories.Interfaces;

namespace RSAMobileAPI.RSARepositories.Services
{
    public class ServicesMgr : IServicesMgr
    {
        private readonly ServicesDA _servicesDA;

        public ServicesMgr(ServicesDA servicesDA)
        {
            _servicesDA = servicesDA;
        }
        //public ValidateUserResponse ValidateUser(string Username, string Password, byte DeviceId, string DeviceInfo, string DeviceRegistrationId, string MobileOS, string MobileOSVersion, string MobileModel)
        //{
          
        //}

        public int IsTokenValid(String Token, ref byte DeviceId)
        {
            
            List<ValidateToken_Result> validateTokens = new List<ValidateToken_Result>();

            // validateTokens = _servicesDA.ValidateToken(0, Token, true, false, DeviceId, string.Empty, "", ",", ",", "");
            validateTokens = _servicesDA.ValidateToken(1, Token, true, false, DeviceId, string.Empty, "", ",", ",", "");
            if (validateTokens.Count > 0 )
            {
                DeviceId =Convert.ToByte(validateTokens[0].DeviceId);
                return Convert.ToInt32(validateTokens[0].UserId);
            }
            else
            {
                return -1;
            }
        }
    }
}
