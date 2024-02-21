using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SQSWebApi.Models
{
    public class ServiceConfiguaration
    {
        //public AWSSQS AWSSQS { get; set; }
        public string AWSSQS { get; set; }  
        public string QUEUEURL { get; set; }
        public string DEADLETTERQUEUEURL { get; set; }
        public string ACCESSKEY { get; set; }
        public string SECRETKEY { get; set; }

    }
    public class AWSSQS
    {
        public string QueueUrl { get; set; }
    }
}
