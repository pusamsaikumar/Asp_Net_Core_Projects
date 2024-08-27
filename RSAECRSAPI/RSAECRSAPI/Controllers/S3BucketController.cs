using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using RSAECRSAPI.ECRSBLL;
using RSAECRSAPI.Models;

namespace RSAECRSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3BucketController : ControllerBase
    {
        private readonly IS3Service _s3Service;
        private readonly IAmazonS3 _amazonS3;

        public S3BucketController(
          IS3Service s3Service,
          IAmazonS3 amazonS3

            )
        {
            _s3Service = s3Service;
            _amazonS3 = amazonS3;
        }
        [HttpPost]
        [Route("CreateBucket")]
        public async Task<IActionResult> CreateBucket(string bucketName)
        {

      
            var result = await _s3Service.CreateBucket(bucketName);
            switch (result.ErrorCode) {
                case "200":
                    return Ok(result);
                case "400":
                    return BadRequest(400);
                case "500":
                   return StatusCode(Convert.ToInt32(result.ErrorCode) , new {ErrorCode = result.ErrorCode , ErrorDesc = result.ErrorDesc , Status = result.Status});
                default:
                    return StatusCode(Convert.ToInt32(result.ErrorCode) , result);
            }

        }
        [HttpDelete]
        [Route("DeleteBucket")]
        public async Task<IActionResult> DeleteBucket(string bucketName)
        {
        //    var deleteBucket = await _amazonS3.DeleteBucketAsync(bucketName);
         //   return NoContent();
           var result = await _s3Service.DeleteBucket(bucketName);
            switch (result.ErrorCode)
            {
                case "200":
                    return Ok(result);
                case "400":
                    return BadRequest(400);
                case "500":
                    return StatusCode(Convert.ToInt32(result.ErrorCode), new { ErrorCode = result.ErrorCode, ErrorDesc = result.ErrorDesc, Status = result.Status });
                default:
                    return StatusCode(Convert.ToInt32(result.ErrorCode), result);
            }
        }

        [HttpPost]
        [Route("transaction")]
        public async Task<IActionResult> transaction(string site, string customer, string transaction, UpdateTransactionRequest TranRequest)
        {
           

            var result = await _s3Service.transaction(site, customer, transaction, TranRequest);
            switch (result.ErrorCode)
            {
                case "200":
                    return Ok(result);
                case "400":
                    return BadRequest(400);
                case "500":
                    return StatusCode(Convert.ToInt32(result.ErrorCode), new { ErrorCode = result.ErrorCode, ErrorDesc = result.ErrorDesc, Status = result.Status });
                default:
                    return StatusCode(Convert.ToInt32(result.ErrorCode), result);
            }


             
        }

        [HttpPost]
        [Route("transaction/commit")]
        public async Task<IActionResult> commit(string site, string customer, string transaction, string sharedkey, string secretKey, CommitTransactionRequest commitTranRequest)
        {
            var result = await _s3Service.commit(site,customer, transaction, sharedkey, secretKey, commitTranRequest);
            switch (result.ErrorCode)
            {
                case "200":
                    return Ok(result);
                case "400":
                    return BadRequest(result);
                case "500":
                    return StatusCode(Convert.ToInt32(result.ErrorCode), new { ErrorCode = result.ErrorCode, ErrorDesc = result.ErrorDesc, Status = result.Status });
                default:
                    return StatusCode(Convert.ToInt32(result.ErrorCode), result);
            }
        }
    }
}
