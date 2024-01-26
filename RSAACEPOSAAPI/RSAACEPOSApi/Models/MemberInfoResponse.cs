using System.Reflection;

namespace RSAACEPOSApi.Models
{
    public class MemberInfoResponse
    {
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public MemberInfo memberInfo { get; set; }
        // public MemberBalance memberBalance { get; set; }
    }
}
