namespace BasketProject.Models
{
    public class ResponseModel
    {
        
        public int StatusCode { get; set; } 
        public string? StatusMessage { get; set; }
        public List<BasketData>? Baskets { get; set; }
        public PaginationData? PaginationData { get; set; }
        public BasketData? Basket { get; set; }

    }
    public  class PaginationData
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; } 
    }
    
}
