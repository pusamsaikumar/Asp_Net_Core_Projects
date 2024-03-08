using RSAMobileAPI.RSARepositories.Services;

namespace RSAMobileAPI.RSARepositories.Interfaces
{
    public interface IImageMgr
    {
        string GetImageUrl(int userId, EnumMgr.UploadLocations uploadLocation, string ImageName, bool useThumbNail);
        string GetThumbNailLogo(string extension);
        string GetFileExtensionType(string FileName);
    }
}
