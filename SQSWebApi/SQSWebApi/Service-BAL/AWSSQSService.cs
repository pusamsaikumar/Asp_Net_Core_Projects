using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SQSWebApi.Helpers;
using SQSWebApi.Models;
using static SQSWebApi.Models.UserModel;

namespace SQSWebApi.Services
{
    public class AWSSQSService : IAWSSQSService
    {
        private readonly IAWSSQSHelper _aWSSQSHelper;
        private readonly IOptions<ServiceConfiguaration> _config;
        private readonly IAmazonSQS _amazonSQS;

        public AWSSQSService(
            
            IAWSSQSHelper aWSSQSHelper,
            IOptions<ServiceConfiguaration> config,
               IAmazonSQS amazonSQS
            )
        {
            _aWSSQSHelper = aWSSQSHelper;
            _config = config;
            _amazonSQS = amazonSQS;
        }
        public async Task<bool> DeleteMessageAsync(DeleteMessage deleteMessage)
        {
            try
            {
                return await _aWSSQSHelper.DeleteMessageAsync(deleteMessage.ReceiptHandle); 
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<AllMessage>> GetAllMessagesAsync()
        {
            List<AllMessage> allMessages = new List<AllMessage>();
            try
            {
                List<Message> messages = await _aWSSQSHelper.ReceiveMessageAsync();
                allMessages = messages.Select(c => new AllMessage { MessageId = c.MessageId, ReceiptHandle = c.ReceiptHandle, UserDetail = JsonConvert.DeserializeObject<UserDetail>(c.Body) }).ToList();
                return  allMessages;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<List<Users>> GetMemorycacheData()
        {
            try
            {
                return await _aWSSQSHelper.GetMemorycacheData();
            }catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> PostSendMessageAsync(User user)
        {

            try
            {
                UserDetail userDetail = new UserDetail();
                //userDetail.Id = Guid.NewGuid().ToString();
                userDetail.Id = new Random().Next(999999999);
                userDetail.FirstName = user.FirstName;
                userDetail.LastName = user.LastName;
                userDetail.UserName = user.UserName;
                userDetail.EmailId = user.EmailId;
                userDetail.CreatedOn = DateTime.UtcNow;
                userDetail.UpdatedOn = DateTime.UtcNow;

              return  await _aWSSQSHelper.SendMessageAsync(userDetail);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public  async Task<string> SendMemoryCacheMessage()
        {
            try
            {
                return await _aWSSQSHelper.SendMemoryCacheMessage();
            }catch(Exception ex) { 
              throw ex;
            }
        }
    }
}
