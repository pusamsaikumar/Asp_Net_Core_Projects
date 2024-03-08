namespace RSAMobileAPI.RSADALayer
{
    public class GetWeeklyAdGallery_Result
    {
        public int StoreId { get; set; }
        public int PageNumber { get; set; }
        public DateTime ValidFromDate { get; set; }
        public DateTime Expireson { get; set; }
        public string PdfFileName { get; set; }
    }

}
