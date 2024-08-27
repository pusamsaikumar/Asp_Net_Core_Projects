using Amazon.S3;
using Amazon.S3.Model;

namespace RSAECRSAPI.Models
{
    public class S3BucketHelpers
    {
        private readonly IAmazonS3 _amazonS3;

        public S3BucketHelpers(IAmazonS3 amazonS3)
        {
            _amazonS3 = amazonS3;
        }

        public async Task<string> GetS3BucketObjectDetails(string bucketName, string key)
        {
            var response = await _amazonS3.GetObjectAsync(bucketName, key);
            using (var reader = new StreamReader(response.ResponseStream)) { 
                return  await reader.ReadToEndAsync();
            }
        }
        public async Task<BucketResponse> SaveS3BucketObject(string bucketName, string key, string jsonData)
        {
            BucketResponse bucketResponse = new BucketResponse();
            try
            {
                var putObjectRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = key,
                    ContentBody = jsonData,
                    ContentType = "application/json",
                };
                await _amazonS3.PutObjectAsync(putObjectRequest);
                bucketResponse.ErrorCode = "200";
                bucketResponse.ErrorDesc = "Successfully saved bucket details";
                bucketResponse.Status = "Success";
            }
            catch (Exception ex) {
                bucketResponse.ErrorCode = "500";
                bucketResponse.ErrorDesc = ex.Message;
                bucketResponse.Status = "Internel server error";
            }
           
            return bucketResponse;
        }   

        public async Task<BucketResponse> DeleteBucketObject(string bucketName,string key)
        {
            BucketResponse bucketResponse = new BucketResponse();
            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = bucketName,
                    Key = key
                };
                await _amazonS3.DeleteObjectAsync(deleteObjectRequest);
                bucketResponse.ErrorCode = "200";
                bucketResponse.ErrorDesc = "Deleted bucket object successfully.";
                bucketResponse.Status = "Success";
            }
            catch (Exception ex) {
                bucketResponse.ErrorCode = "500";
                bucketResponse.ErrorDesc = ex.Message;
                bucketResponse.Status = "Internel server error";
            }
            return bucketResponse;
        }

        public async Task<bool> ValidateKeyPath(string bucketName,string folderName, string transactionDate,int storeId,string fileName)
        {
            var request = new ListObjectsV2Request
            {
                BucketName = bucketName,
                Prefix = "",
            };
            var s3BucketObjects = await  _amazonS3.ListObjectsV2Async(request);
            var validatePath = s3BucketObjects.S3Objects.FirstOrDefault(x =>
            {
                return x.Key.Split("/")[0] == folderName &&
                  x.Key.Split("/")[1].Length > 1 && x.Key.Split("/")[1] == transactionDate &&
                  x.Key.Split("/")[2].Length > 2 && x.Key.Split("/")[2] == (storeId).ToString() &&
                  x.Key.Split("/")[3].Length > 3 && x.Key.Split("/")[3] == fileName; 
            });
            if (validatePath != null) { 
                return true;
            }
            return false;
        }
        public async Task<string> ValidateKeyPathAsync(string bucketName, string folderName, string transactionDate, int storeId, string fileName)
        {
            string key = string.Empty;
            var request = new ListObjectsV2Request
            {
                BucketName = bucketName,
                Prefix = ""
            };
            var result = await _amazonS3.ListObjectsV2Async(request);
            var validPath = result.S3Objects.FirstOrDefault(x =>
            {
                return x.Key.Split("/")[0] == folderName &&
                    x.Key.Split("/")[1] == transactionDate &&
                    x.Key.Split("/")[2] == storeId.ToString() &&
                    x.Key.Split("/")[3] == fileName;
            });
            if (validPath != null)
            {
                key = validPath.Key;
               
            }
            return key;
        }

        
    }
}
