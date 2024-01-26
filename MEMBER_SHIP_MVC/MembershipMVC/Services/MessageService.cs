namespace MembershipMVC.Services
{
    public class MessageService : IEmailSender, IMessageSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
          return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            return Task.FromResult(0);
        }
    }
}
