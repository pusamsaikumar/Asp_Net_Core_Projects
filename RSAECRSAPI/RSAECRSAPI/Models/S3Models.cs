namespace RSAECRSAPI.Models
{
    public class S3Models
    {
    }
    public class S3Model
    {
        public string Name { get; set; }
        public string PresignedUrl { get; set; }
    }
    public class BucketResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string Status { get; set; }
    }
    
}
