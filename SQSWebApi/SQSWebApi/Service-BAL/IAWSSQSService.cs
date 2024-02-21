using SQSWebApi.Models;
using static SQSWebApi.Models.UserModel;

namespace SQSWebApi.Services
{
    public interface IAWSSQSService
    {
        Task<bool> PostSendMessageAsync(User user);
        Task<List<AllMessage>> GetAllMessagesAsync();
        Task<bool> DeleteMessageAsync(DeleteMessage deleteMessage);

         Task<string> SendMemoryCacheMessage();
        Task<List<Users>> GetMemorycacheData();
    }
}
