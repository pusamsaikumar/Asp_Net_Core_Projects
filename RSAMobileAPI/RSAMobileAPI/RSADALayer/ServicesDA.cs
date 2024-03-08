using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RSAMobileAPI.RSAEntities;
using RSAMobileAPI.RSARepositories.Services;

namespace RSAMobileAPI.RSADALayer
{
    public class ServicesDA 
    {
        private readonly RSA_QAEntities _rSADBContext;
        private readonly IOptions<AppSettings> _appsettings;

        public ServicesDA(
            RSA_QAEntities rSADBContext,
            IOptions<AppSettings> appsettings
            
            )
        {
            _rSADBContext = rSADBContext;
            _appsettings = appsettings;
        }
       


        public List<ValidateToken_Result> ValidateToken(int UserId, String LoginToken, bool RenewToken, bool CreateToken, byte DeviceId, String DeviceInfo, String DeviceRegistrationId, String MobileOS, String MobileOSVersion, String MobileModel)
        {
            // return dbContext.ValidateToken(UserId, LoginToken, Convert.ToInt32(TOKEN_EXPIRATION_TIME_IN_MINUTES), RenewToken, CreateToken, DeviceId, DeviceInfo, DeviceRegistrationId, MobileOS, MobileOSVersion, MobileModel).ToList<ValidateToken_Result>();

            string TOKEN_EXPIRATION_TIME_IN_MINUTES = _appsettings.Value.TOKEN_EXPIRATION.ToString();

            var userIdParam = new SqlParameter("@UserId", UserId);
            var  loginTokenParam =new SqlParameter("@LoginToken", LoginToken);
           var validDurationParam = new SqlParameter("@ValidDuration", Convert.ToInt32(TOKEN_EXPIRATION_TIME_IN_MINUTES));
            var renewTokenParam = new SqlParameter("@RenewToken", RenewToken);
            var createTokenParam = new SqlParameter("@CreateToken", CreateToken);
            var  deviceIdParam= new SqlParameter("@DeviceId", DeviceId);
             var  deviceInfoParam=new SqlParameter("@DeviceInfo", DeviceInfo);
            var  deviceRegistrationParam= new SqlParameter("@DeviceRegistrationId", DeviceRegistrationId);
            var mobileOSParam = new SqlParameter("@MobileOS", MobileOS);
            var mobileVersionParam = new SqlParameter("@MobileOSVersion", MobileOSVersion);
            var mobileModelParam = new SqlParameter("@MobileModel", MobileModel);


             

            var validtoken = _rSADBContext.Set<ValidateToken_Result>().
                FromSqlRaw($"EXEC ValidateToken @UserId,@LoginToken,@ValidDuration,@RenewToken,@CreateToken,@DeviceId,@DeviceInfo,@DeviceRegistrationId,@MobileOS,@MobileOSVersion,@MobileModel",
                 userIdParam, loginTokenParam,validDurationParam, renewTokenParam,createTokenParam,deviceIdParam, deviceInfoParam,deviceRegistrationParam, mobileOSParam,mobileVersionParam,mobileModelParam
                
                ).ToList();

            return validtoken;
        }
    }
}
