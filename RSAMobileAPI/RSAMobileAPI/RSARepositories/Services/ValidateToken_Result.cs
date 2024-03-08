namespace RSAMobileAPI.RSARepositories.Services
{
    public class ValidateToken_Result
    {
        public long UserTokenId { get; set; }
        public long UserId { get; set; }
        public string LoginToken { get; set; }
        public DateTime LastAccessed { get; set; }
        public short? DeviceId { get; set; }
        public string DeviceRegistrationId { get; set; }
    }
}
