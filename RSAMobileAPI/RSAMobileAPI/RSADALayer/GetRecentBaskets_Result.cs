namespace RSAMobileAPI.RSADALayer
{
    public class GetRecentBaskets_Result
    {
        public int? StoreId { get; set; }
        public string StoreName { get; set; }
        public DateTime? TransactionDate { get; set; }
        public TimeSpan? TransactionTime { get; set; }
        public decimal? Amount { get; set; }
        public string MemberNumber { get; set; }
        public string UserName { get; set; }
    }
}
