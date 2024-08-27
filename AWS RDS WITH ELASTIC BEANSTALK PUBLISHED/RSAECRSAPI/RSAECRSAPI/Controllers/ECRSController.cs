using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RSAECRSAPI.ECRSBLL;
using RSAECRSAPI.ECRSDAL.Models;
using System.Data.SqlClient;

namespace RSAECRSAPI.Controllers
{
    //[Route("api/[controller]")]
     [Route("/[controller]")]
    [ApiController]
    public class ECRSController : ControllerBase
    {
        private readonly IOptions<AppConfigurations> _options;
        private readonly ITransactionService _transactionService;

        public ECRSController(
            IOptions<AppConfigurations> options,
            ITransactionService transactionService
            )
        {
            _options = options;
            _transactionService = transactionService;
        }
        [HttpPost]
        [Route("transaction")]
        public async Task<IActionResult> transaction(string site, string customer, string transaction, UpdateTransactionRequest TranRequest)
        {
            var result = await _transactionService.transaction(site, customer, transaction, TranRequest);
            if (result == null) {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("transaction/commit")]
        public async Task<IActionResult> commit(string site, string customer, string transaction, string sharedkey, string secretkey, CommitTransactionRequest commitTranRequest)
        {
            var result = await _transactionService.commit(site, customer, transaction, sharedkey, secretkey, commitTranRequest);
            if (result == null) {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("transaction/cancel")]
        
        public async Task<IActionResult> cancel(string site, string customer, string transaction, string sharedkey,  string secretKey)
        {
            var result = await _transactionService.cancel(site, customer, transaction, sharedkey, secretKey);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("canceltransaction")]
        public async Task<IActionResult> canceltransaction(CancelTransactionRequest cancelTranRequest)
        {

            var result = await _transactionService.canceltransaction(cancelTranRequest);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
