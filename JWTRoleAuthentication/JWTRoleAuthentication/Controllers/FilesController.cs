using JWTRoleAuthentication.CommonLayer.Models;
using JWTRoleAuthentication.JWTBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JWTRoleAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly List<RSAClient> _rSAClients;
        private readonly IFileService _fileService;

        public FilesController(
            List<RSAClient> rSAClients,
            IFileService fileService
            )
        {
            _rSAClients = rSAClients;
            _fileService = fileService;
        }
        [HttpGet]
        [Route("ReadJsonFile")]

        public async Task<IActionResult> ReadJsonFile(string sharedKey, string secretKey)
        {
            var result  = await _fileService.ReadJsonFile(sharedKey, secretKey);
            if (result == null)
            {
                return NotFound(new {message = result?.StatusMessage});
            }
            return Ok(result);
        }


        //public IActionResult ReadJsonFile(string sharedKey,string secretKey)
        //{
        //    //var json = System.IO.File.ReadAllText("D:\\csharpprojects\\JWTRoleAuthentication\\JWTRoleAuthentication\\JSONFiles\\RSAClient.json");

        //    // var json = System.IO.File.ReadAllText(fullpath);
        //    //var jsonData = JsonConvert.DeserializeObject<List<RSAClient>>(json);

        //    var json = System.IO.File.ReadAllText("D:\\csharpprojects\\JWTRoleAuthentication\\JWTRoleAuthentication\\JSONFiles\\RSAClientData.json");
        //   var jsonData = JsonConvert.DeserializeObject<RSAClientDataWrapper>(json);

        //    var data = jsonData?.RSAClientData.FirstOrDefault(item => item.SharedKey == sharedKey && item.SecretKey == secretKey);
        //    var model = new RSAClient
        //    {
        //        RSAClientId = data.RSAClientId,
        //        RSAClientName = data?.RSAClientName,
        //         UserName = data?.UserName,
        //         Email = data?.Email,
        //         MobileNumber = data?.MobileNumber,
        //         Address = data?.Address
        //    };
        //    var connectionStringBuilder = new AuthDBCon
        //    {
        //        DataSource = data.ServerName,
        //        InitialCatalog = data.DatabaseName,
        //        UserID = data.UserId,
        //        Password = data.Password,
        //    };
        //    var connectionstring = connectionStringBuilder.BuildConnectionString();
        //    Console.WriteLine(connectionstring);
        //    return Ok(model);

        //}

        [HttpPost]
        [Route("CreateCustomerwithJsonfile")]
        public async Task<IActionResult> AddCustomer(string sharedKey,string secretKey,CustomerModel model)
        {
            var result = await _fileService.AddCustomerWithJsonfile(sharedKey, secretKey, model);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("LoginWithJSONFile")]
        public async Task<IActionResult> LoginWithJSONFile(string sharedKey,string secretKey,LoginModel model)
        {
            var result = await _fileService.LoginWithJSONFile(sharedKey, secretKey, model);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetCouponsData")]
        public async Task<IActionResult> GetCouponsData()
        {
            var result = await _fileService.GetCouponsData();
            return Ok(result);
        }
    }
}

