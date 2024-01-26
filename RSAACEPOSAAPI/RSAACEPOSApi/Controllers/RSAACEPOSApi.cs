using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSAACEPOSApi.BAL;
using RSAACEPOSApi.Models;



namespace RSAACEPOSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSAACEPOSApi : ControllerBase
    {
        private readonly RSAACEPOSApiBAL _rSAACEPOSApiBAL;

        public RSAACEPOSApi(
            
                RSAACEPOSApiBAL rSAACEPOSApiBAL

            )
        {
           _rSAACEPOSApiBAL = rSAACEPOSApiBAL;
        }

        [HttpPost]
        [Route("transaction")]
        public IActionResult transaction(string site, string customer, string transaction, UpdateTransactionRequest TranRequest)
        {
            var data =  _rSAACEPOSApiBAL.transaction(site, customer, transaction, TranRequest);

            return Ok(data);
        }
        [HttpGet]
        [Route("cancel")]
        public IActionResult cancel(string site, string customer, string transaction, string sharedkey, string secret)
        {
            var data = _rSAACEPOSApiBAL.cancel(site, customer,transaction,sharedkey,secret);
            return Ok(data);
        }


        [HttpPost]
        [Route("commit")]
        public IActionResult commit(string site, string customer, string transaction, string sharedkey, string secret, CommitTransactionRequest commitTranRequest)
        {
            var data = _rSAACEPOSApiBAL.commit(site, customer, transaction, sharedkey, secret, commitTranRequest);
            return Ok(data);
        }
        [HttpPost]
        [Route("canceltransaction")]
        public IActionResult canceltransaction(CancelTransactionRequest cancelTranRequest)
        {
            var data = _rSAACEPOSApiBAL.canceltransaction(cancelTranRequest);
            return Ok(data);
        }

        [HttpPost]
        [Route("getcustomerinfo")]
        public IActionResult getcustomerinfo(MemberInfoRequest MemberInfoRequest)
        {
            var data = _rSAACEPOSApiBAL.getcustomerinfo(MemberInfoRequest);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetAllConfigJsonData")]
        public IActionResult GetAllConfigJsonData()
        {
            var data = _rSAACEPOSApiBAL.GetConfigs();
            return Ok(data);
        }
        [HttpGet]
        [Route("GetConfigDataByRetailerId")]
        public IActionResult GetConfigDataByRetailerId(string id)
        {
            var result = _rSAACEPOSApiBAL.GetbyRetailerId(id);
            return Ok(result);  
        }
    }
}
