using Amazon.SQS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SQSWebApi.Services;
using static SQSWebApi.Models.UserModel;

namespace SQSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AWSSQSController : ControllerBase
    {
        private readonly IAWSSQSService _aWSSQSService;

        public AWSSQSController(
          IAWSSQSService aWSSQSService
            )
        {
           _aWSSQSService = aWSSQSService;
        }
        [HttpGet]
        [Route("getAllMessage")]
       public async Task<IActionResult>  GetAllMessages()
        {
            var result = await _aWSSQSService.GetAllMessagesAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("postmessage")]
        public async Task<IActionResult> PostMessageService([FromBody] User user)
        {
            var result = await _aWSSQSService.PostSendMessageAsync(user);
            return Ok( new {issue = result});
        }
        [HttpDelete]
        [Route("deleteMessage")]
        public async Task<IActionResult> DeleteMessage(DeleteMessage deleteMessage)
        {
           var result = await _aWSSQSService.DeleteMessageAsync(deleteMessage); 
            return Ok( new {issue = result});   
        }

        // deploy url:  https://24cklsr4gh.execute-api.ap-south-1.amazonaws.com/dev/api/AWSSQS/GetName?Name=hellow
        [HttpGet]
        [Route("GetName")]
        public IActionResult GetMessages(string Name)
        {
            return Ok(new {name = Name});
        }

        [HttpPost]
        [Route("SendMemoryCacheMessasge")]
        public async Task<IActionResult> SendMemoryCacheMessasge()
        {
            var result = await _aWSSQSService.SendMemoryCacheMessage();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetMemoryCacheData")]
        public async Task<IActionResult> GetMemoryCacheData()
        {
            try
            {
                var result = await _aWSSQSService.GetMemorycacheData();
                if(result == null)
                {
                    return NotFound("Not Found Memory Catch Data...");
                }
                return Ok(result);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
