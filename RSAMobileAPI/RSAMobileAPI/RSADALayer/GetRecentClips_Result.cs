namespace RSAMobileAPI.RSADALayer
{
    public class GetRecentClips_Result
    {
        public string UserName { get; set; }
        public string BarcodeValue { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? NCRImpressionDate { get; set; }
    }
}
