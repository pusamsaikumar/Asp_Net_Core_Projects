using Amazon.Runtime.Internal.Util;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Model.Internal.MarshallTransformations;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace StudentThreeTier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IAmazonS3 _amazonS3;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;

        public FilesController(
            IAmazonS3 amazonS3,
            IWebHostEnvironment webHostEnvironment,
            IMemoryCache memoryCache,
            IDistributedCache distributedCache
            


            )
        {
            _amazonS3 = amazonS3;
            _webHostEnvironment = webHostEnvironment;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;   
        }

        [HttpPost]
        [Route("UploadFileAsync")]
        public async Task<IActionResult> UploadFileAsync(IFormFile file, string bucketName, string? prefix)
        {
            var bucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_amazonS3, bucketName);
            //if (bucketExists)
            //{
            //    return BadRequest($"Bucket {bucketName} alread existed.");


            if (!bucketExists)
            {
                return NotFound($"Bucket {bucketName} does not existed.");
            }
            var request = new PutObjectRequest()
            {
                BucketName = bucketName,
                Key = string.IsNullOrEmpty(prefix) ? file.FileName : $"{prefix?.TrimEnd('/')}/{file.FileName}",
                InputStream = file.OpenReadStream(),
            };
            request.Metadata.Add("Content-Type", file.ContentType);
            await _amazonS3.PutObjectAsync(request);
            return Ok($"File {prefix}/{file.FileName} uploaded to s3 successfully");
        }


        [HttpGet]
        [Route("GetAllFilesAsync")]
        public async Task<IActionResult> GetAllFilesAsync(string bucketName, string? prefix)
        {
            var bucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_amazonS3, bucketName);
            if (!bucketExists)
            {
                return NotFound($"Bucket {bucketName} does not existed.");
            }
            var request = new ListObjectsV2Request()
            {
                BucketName = bucketName,
                Prefix = prefix
            };
            var result = await _amazonS3.ListObjectsV2Async(request);
            var s3Objects = result.S3Objects.Select(s =>
            {
                var urlRequest = new GetPreSignedUrlRequest()
                {
                    BucketName = bucketName,
                    Key = s.Key,
                    Expires = DateTime.UtcNow.AddMinutes(30)
                };
                return new S3Model
                {
                    Name = s.Key.ToString(),
                    PresignedUrl = _amazonS3.GetPreSignedURL(urlRequest),
                };
            });
            return Ok(s3Objects);
        }

        // geyby name and key
        [HttpGet]
        [Route("GetFileByKeyAsync")]
        public async Task<IActionResult> GetFileByKeyAsync(string bucketName, string key)
        {
           // var cachemem = _distributedCache.GetString("s3BucketData");
         

            try
            {

                var bucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_amazonS3, bucketName);
                if (!bucketExists)
                {
                    return NotFound($"Bucket {bucketName} does not existed.");
                }

                GetObjectRequest request = new GetObjectRequest()
                {
                    BucketName = bucketName,
                    Key = key
                };
                //  var s3object = await _amazonS3.GetObjectAsync(bucketName, key);


                //var data = File(s3object.ResponseStream, s3object.Headers.ContentType);


                using (GetObjectResponse response = await _amazonS3.GetObjectAsync(request))

                using (var reader = new StreamReader(response.ResponseStream))
                {
                    var conttent = await reader.ReadToEndAsync();


                    // Imemory cache:
                    _memoryCache.Set("JsonFile", conttent, TimeSpan.FromSeconds(80));


                    // Distributed cache timeout option
                    var options = new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(80),
                    };
                    // distribution cache setstring  value
                    _distributedCache.SetString("JsonFile", conttent, options);


                    return Ok(conttent);
                }
            }
            catch (AmazonS3Exception ex)
            {
                throw new Exception(ex.Message);

            }
        

}

        [HttpDelete]
        [Route("DeleteFileByKeyAsync")]
        public async Task<IActionResult> DeleteFileByKeyAsync(string bucketName, string key)
        {
            var bucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_amazonS3, bucketName);
            if (!bucketExists)
            {
                return NotFound($"Bucket {bucketName} does not existed.");
            }
            await _amazonS3.DeleteObjectAsync(bucketName, key);
            return NoContent();
        }


        [HttpGet]
        [Route("ReadJsonFile")]
        public IActionResult ReadJsonFile(int id)
        {

            //var uploadpath = _webHostEnvironment.WebRootPath;
            //var destinationPath = Path.Combine(uploadpath, "D:\\csharpprojects\\StudentThreeTier\\StudentThreeTier\\Content\\");

            //if (!Directory.Exists(destinationPath))
            //{
            //    Directory.CreateDirectory(destinationPath);
            //}
            //var sourcePath = Path.GetFileName(formFile.Name);
            //var fullpath = Path.Combine(destinationPath, sourcePath);   
            //using(FileStream stream = new FileStream(fullpath, FileMode.Create))
            //{
            //    formFile.CopyTo(stream);
            //}

            var json = System.IO.File.ReadAllText("D:\\csharpprojects\\StudentThreeTier\\StudentThreeTier\\Content\\Uploads\\client.json");
           // var json = System.IO.File.ReadAllText(fullpath);
            var jsonData = JsonConvert.DeserializeObject<List<RSAClient>>(json);
                 

            var data = jsonData.FirstOrDefault(j => j.RSAClientId == id);
            if (data == null)
            {
                return NotFound($" id {id} is not found.");
            }
            else
            {
                var clientModel = new RSAClient
                {
                    RSAClientId = data.RSAClientId,
                    RSAClientName = data.RSAClientName,
                    Stores = data.Stores,
                };
                return Ok(clientModel);
            }
        }
        [HttpPost]
        [Route(" UplaodAndReadJsonFile")]
        public IActionResult UplaodAndReadJsonFile(IFormFile formFile,int id)
        {

            var uploadpath = _webHostEnvironment.WebRootPath;
            var destinationPath = Path.Combine(uploadpath, "JSONFILES");

            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }
            var sourcePath = Path.GetFileName(formFile.FileName);
            var fullpath = Path.Combine(destinationPath, sourcePath);
            using (FileStream stream = new FileStream(fullpath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            Console.WriteLine(fullpath);
            // read json file
             var json = System.IO.File.ReadAllText(fullpath);
            var jsonData = JsonConvert.DeserializeObject<List<RSAClient>>(json);
            var data = jsonData?.FirstOrDefault(item => item.RSAClientId == id);

            if(data == null)
            {
                return NotFound($" Id {id} is invalid");
            }
            //  return Ok(jsonData);
            RSAClient clientModel = new RSAClient();
            clientModel.RSAClientId = data.RSAClientId;
            clientModel.RSAClientName = data.RSAClientName;
            clientModel.Stores = data.Stores;
            return Ok(clientModel);

        }


        [HttpGet]
        [Route("ReadJsonFromFolder")]
        public IActionResult ReadJsonFromFolder(int Id)
        {
            //  var basepath = Path.Combine(Environment.CurrentDirectory, @"XMLFiles\");
            // var basePath = Path.Combine(_webHostEnvironment.ContentRootPath, @"JSONFiles\client.json");

            // string fileName = @"client.json";
            string fileName = @"RSAClient.json";
            string currentDirectory = Directory.GetCurrentDirectory();
            // get full path with folders names dynamically 
            string[] fullFilePath = Directory.GetFiles(currentDirectory,fileName, SearchOption.AllDirectories);

         
           var jsonData = System.IO.File.ReadAllText(fullFilePath[0]);
            var dataobj = JsonConvert.DeserializeObject<List<RSAClient>>(jsonData);
            var data = dataobj?.FirstOrDefault(d => d.RSAClientId == Id);
            if(data == null)
            {
                return NotFound("Invalid id ");
            }
            
            return Ok(data);
        }
    }
}
