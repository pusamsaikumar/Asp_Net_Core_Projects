using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SQSWebApi.Models;
using static SQSWebApi.Models.UserModel;
using Amazon;
using Amazon.Lambda.Core;
using System.Runtime;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;


namespace SQSWebApi.Helpers
{
    public class AWSSQSHelper : IAWSSQSHelper
    {
        private readonly IOptions<ServiceConfiguaration> _config;
        private readonly IAmazonSQS _amazonSQS;
        private readonly ILogger<AWSSQSHelper> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly List<Users> _users;

        public AWSSQSHelper(

            IOptions<ServiceConfiguaration> config,
            IAmazonSQS amazonSQS,
            ILogger<AWSSQSHelper> logger,
            IMemoryCache memoryCache,
            List<Users> users


            )
        {
            _config = config;
            _amazonSQS = amazonSQS;
            _logger = logger;
           _memoryCache = memoryCache;
            _users = users;
        }
        public async Task<bool> DeleteMessageAsync(string messageReceiptHandle)
        {
            try
            {
                var delete = await _amazonSQS.DeleteMessageAsync(_config.Value.QUEUEURL, messageReceiptHandle);
                _logger.LogInformation($"deleted message");
                return  delete.HttpStatusCode == System.Net.HttpStatusCode.OK;
               
            }catch (Exception ex)
            {
                throw ex;
            }
        }

      

        public async Task<List<Message>> ReceiveMessageAsync()
        {
            try
            {
                _logger.LogInformation($" calling ReceiveMessageAsync method ");
                var accesskey = _config.Value.ACCESSKEY.ToString();
                var secretKey = _config.Value.SECRETKEY.ToString();
                //var credentials = new BasicAWSCredentials("AKIATRDUIJVI6XDUH447", "Dvv+0I/SSfFq2VGX0fEg0F4d/lZJsY0aU+/VtKWo");
                var credentials = new BasicAWSCredentials(accesskey, secretKey);




                var sqsClient = new AmazonSQSClient(credentials, RegionEndpoint.APSouth1);

                //Create New instance  
                var request = new ReceiveMessageRequest
                {
                    QueueUrl = _config.Value.QUEUEURL,
                    MaxNumberOfMessages = 10,
                    //WaitTimeSeconds = 5
                   
                };
                //CheckIs there any new message available to process  
               var result = await _amazonSQS.ReceiveMessageAsync(request);
                //   var result = await sqsClient.ReceiveMessageAsync(request);

                _logger.LogInformation($"Response : {result}");
             
                    foreach (var message in result.Messages)
                {
                    _logger.LogInformation($"Message Received From  Amazon SQS Service: {message.Body}");
                    //var jsonMessage = JsonConvert.DeserializeObject<DLQModel>(stringMessage);
                    await MoveToDeadLetterQueueAsync($"{message.Body}");
                }

                return result.Messages.Any() ? result.Messages : new List<Message>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Occured : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        private async Task MoveToDeadLetterQueueAsync(string jsonMessage)
        {
           
            var accesskey = _config.Value.ACCESSKEY.ToString();
            var secretKey = _config.Value.SECRETKEY.ToString();
            //var credentials = new BasicAWSCredentials("AKIATRDUIJVI6XDUH447", "Dvv+0I/SSfFq2VGX0fEg0F4d/lZJsY0aU+/VtKWo");
            var credentials = new BasicAWSCredentials(accesskey, secretKey);

            var sqsClient = new AmazonSQSClient(credentials, RegionEndpoint.APSouth1);
           
            var messageRequest = new SendMessageRequest
            {
                QueueUrl = _config.Value.DEADLETTERQUEUEURL.ToString(),
                MessageBody = jsonMessage,
            };
            
            //  await sqsClient.SendMessageAsync(messageRequest);
            await _amazonSQS.SendMessageAsync(messageRequest);
            
        }

        public async Task<bool> SendMessageAsync(UserDetail userDetail)
        {
            try
            {

                _logger.LogInformation($"Sending message info : {userDetail}");
              var accesskey = _config.Value.ACCESSKEY.ToString();
                var secretKey= _config.Value.SECRETKEY.ToString();  
                //var credentials = new BasicAWSCredentials("AKIATRDUIJVI6XDUH447", "Dvv+0I/SSfFq2VGX0fEg0F4d/lZJsY0aU+/VtKWo");
                var credentials = new BasicAWSCredentials(accesskey, secretKey);    




                var sqsClient = new AmazonSQSClient(credentials, RegionEndpoint.APSouth1);
                var message = JsonConvert.SerializeObject(userDetail);
                var messageRequest = new SendMessageRequest()
                {
                    QueueUrl = _config.Value.AWSSQS.ToString(),
                    MessageBody = message
                };
               // var result = await _amazonSQS.SendMessageAsync(messageRequest);
               _logger.LogInformation($"Sending message Request: {messageRequest}"); 

                var response = await sqsClient.SendMessageAsync(messageRequest);
                _logger.LogInformation($"Sending message to SQS : {response}"); 

              //  return result.HttpStatusCode == System.Net.HttpStatusCode.OK;
              return response.HttpStatusCode == System.Net.HttpStatusCode.OK;   

                //return true;  
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error Ocurred :  {ex.Message}");    
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> SendMemoryCacheMessage()
        {
            try
            {
                var accesskey = _config.Value.ACCESSKEY.ToString();
                var secretKey = _config.Value.SECRETKEY.ToString();
                
                var credentials = new BasicAWSCredentials(accesskey, secretKey);
                var sqsClient = new AmazonSQSClient(credentials, RegionEndpoint.APSouth1);
                var jsonData = _users;
                // var data = _memoryCache.Get("myJosnData");
                var data = _memoryCache.Set("myJsonData", JsonConvert.SerializeObject(jsonData));
                var message = data != null ? "Add json data into memory catch" : "failed json data." ;
                var messageRequest = new SendMessageRequest()
                {
                    QueueUrl = _config.Value.AWSSQS.ToString(),
                    MessageBody = message
                };
                // var result = await _amazonSQS.SendMessageAsync(messageRequest);
                _logger.LogInformation($"Sending message Request: {messageRequest}");

                var response = await sqsClient.SendMessageAsync(messageRequest);
                if(response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    return "Send json data successfully into memory catch";
                }
                return "failed";
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
                var jsonData = new List<Users>();
                jsonData = _users;
                var cacheCata = _memoryCache.Get("myJsonData");


                var accesskey = _config.Value.ACCESSKEY.ToString();
                var secretKey = _config.Value.SECRETKEY.ToString();
               
                var credentials = new BasicAWSCredentials(accesskey, secretKey);
               var sqsClient = new AmazonSQSClient(credentials, RegionEndpoint.APSouth1);
              
               
                var message = cacheCata != null ? "Json data has been found" : "Json data not found";
                var messageRequest = new SendMessageRequest()
                {
                    QueueUrl = _config.Value.AWSSQS.ToString(),
                    MessageBody = message
                };
                var response = await sqsClient.SendMessageAsync(messageRequest);
                if (cacheCata != null)
                {
                    return jsonData;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }
    }
}
