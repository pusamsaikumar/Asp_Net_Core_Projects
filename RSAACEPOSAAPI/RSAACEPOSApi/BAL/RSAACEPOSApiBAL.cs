using Microsoft.Extensions.Options;
using RSAACEPOSApi.DAL;
using RSAACEPOSApi.Models;

namespace RSAACEPOSApi.BAL
{
    public class RSAACEPOSApiBAL
    {
        private readonly RSAACEPOSApiDALcs _rSAACEPOSApiDALcs;
        private readonly IOptions<Configs> _options;
        private readonly IOptions<List<ConfigSettings>> _configSettings;

        public RSAACEPOSApiBAL(
            RSAACEPOSApiDALcs rSAACEPOSApiDALcs,
              IOptions<Configs> options,
               IOptions<List<ConfigSettings>> configSettings
            )
        {
            _rSAACEPOSApiDALcs = rSAACEPOSApiDALcs;
            _options = options;
            _configSettings = configSettings;
        }
      public  UpdateTransactionResponse transaction(string site, string customer, string transaction, UpdateTransactionRequest TranRequest)
        {
            var data = _rSAACEPOSApiDALcs.transaction(site, customer, transaction, TranRequest);
            return data;
        }

        public CancelResponse cancel(string site, string customer, string transaction, string sharedkey, string secret)
        {
            var data = _rSAACEPOSApiDALcs.cancel(site, customer, transaction, sharedkey, secret);
            return data;
        }
        public CommitResponse commit(string site, string customer, string transaction, string sharedkey, string secret, CommitTransactionRequest commitTranRequest)
        {
            var data = _rSAACEPOSApiDALcs.commit(site, customer, transaction, sharedkey, secret, commitTranRequest);
            return data;
        }

        public CancelResponse canceltransaction(CancelTransactionRequest cancelTranRequest)
        {
            var data = _rSAACEPOSApiDALcs.canceltransaction(cancelTranRequest);
            return data;
        }

        public MemberInfoResponse getcustomerinfo(MemberInfoRequest MemberInfoRequest)
        {
            var  data = _rSAACEPOSApiDALcs.getcustomerinfo(MemberInfoRequest);
            return data;
        }

        // configdata
        public List<ConfigSettings> GetConfigs()
        {
            var result = _rSAACEPOSApiDALcs.GetConfigs();
            return result;
        }

        public ConfigSettings GetbyRetailerId(string id)
        {
            var result = _rSAACEPOSApiDALcs.GetbyRetailerId((string)id);
            return result;
        }
    }
   
}
