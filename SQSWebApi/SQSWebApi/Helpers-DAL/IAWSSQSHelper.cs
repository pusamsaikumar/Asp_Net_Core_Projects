using Amazon.SQS.Model;
using SQSWebApi.Models;
using static SQSWebApi.Models.UserModel;

namespace SQSWebApi.Helpers
{
    public interface IAWSSQSHelper
    {
        Task<bool> SendMessageAsync(UserDetail userDetail);
        Task<List<Message>> ReceiveMessageAsync();
        Task<bool> DeleteMessageAsync(string messageReceiptHandle);
        Task<string> SendMemoryCacheMessage();
        Task<List<Users>> GetMemorycacheData();
    }
}
