namespace RSAMobileAPI.RSARepositories.Interfaces
{
    public interface IServicesMgr 
    {
        int IsTokenValid(string Token, ref byte DeviceId);
        
    }
}
