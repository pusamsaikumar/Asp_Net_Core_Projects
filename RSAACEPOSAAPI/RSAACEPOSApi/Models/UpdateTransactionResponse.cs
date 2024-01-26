namespace RSAACEPOSApi.Models
{
    public class UpdateTransactionResponse
    {
         public List<Applied> applied { get; set; }
        public string errorCode { get; set; }
        public string errorDesc { get; set; }
        public string status { get; set; }
    }
}
