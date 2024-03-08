namespace RSAMobileAPI.RSADALayer
{
    public class GetRecipeCategories_Result
    {
        public int RecipeCategoryId { get; set; } 
        public string CategoryName { get;}
        public string ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }   
        public int? RecipesCount { get; set; }
    }
}

