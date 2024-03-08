namespace RSAMobileAPI.RSADALayer
{
    public class GetSlides_Result
    {
        public int SlideId { get; set; }
        public string ImageUrl { get; set; }
        public string FeaturedText { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDealOfTheWeek { get; set; }
        public DateTime CreatedDatetime { get; set; }
    }
}
