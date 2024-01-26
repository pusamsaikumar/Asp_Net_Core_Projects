namespace MembershipMVC.Services
{
    public interface IMessageSender
    {
        Task SendSmsAsync(string number,string message);
    }
}
