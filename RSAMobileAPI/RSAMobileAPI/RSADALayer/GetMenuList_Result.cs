namespace RSAMobileAPI.RSADALayer
{
    public class GetMenuList_Result
    {
        public int MenuId { get; set; }
        public int? MenuSequenceNumber { get; set; }
        public string MenuTitle { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string ColorCode { get; set; }
    }
}
