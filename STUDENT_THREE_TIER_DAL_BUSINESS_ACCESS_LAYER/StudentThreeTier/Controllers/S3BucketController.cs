using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentThreeTier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3BucketController : ControllerBase
    {
        private readonly IAmazonS3 _amazonS3;

        public S3BucketController(IAmazonS3 amazonS3)
        {
           _amazonS3 = amazonS3;
        }

        // create bucket:
        [HttpPost]
        [Route("CreateBucketAsync")]
        public async Task<IActionResult> CreateBucketAsync(string bucketName)
        {
            var bucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_amazonS3,bucketName);
            if (bucketExists)
            {
                return BadRequest($"Bucket {bucketName} alread existed.");
            }
            await _amazonS3.PutBucketAsync(bucketName);
            return Created("Created" ,$"Bucket {bucketName} created.");
        }


        [HttpGet]
        [Route("GelAllBucketsAsync")]
        public async Task<IActionResult> GelAllBucketsAsync()
        {
            var data = await _amazonS3.ListBucketsAsync();
            var buckets = data.Buckets.Select(b => b.BucketName);
            return Ok(buckets);
        }

        [HttpDelete]
        [Route(" DeleteBucketAsyn")]
        public async Task<IActionResult> DeleteBucketAsyn(string bucketName)
        {
            await _amazonS3.DeleteBucketAsync(bucketName);
            return NoContent();
        }
    }
   
}
