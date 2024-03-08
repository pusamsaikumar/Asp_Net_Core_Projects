namespace RSAMobileAPI.RSADALayer
{
    public class GetAllEvents_Result
    {
        public int EventID { get; set; }
        public string Title { get; set; }   
        public string Details { get; set; } 
        public string OtherDetails { get; set; }    
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set;}
        public string TermsAndConditions { get; set; } 
        public string EventButtonText { get; set; } 
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set;}
        public string ImagePath3 { get; set;}
        public int? EventCategoryID { get; set; }
        public bool? IsTermsAccepted { get; set; }
        public int IsEnrolled { get; set; } 
        public int EventTypeId { get; set; }    


    }
}






