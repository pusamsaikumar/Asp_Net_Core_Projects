namespace RSAECRSAPI.Models
{
    public class UpdateTransactionItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string Upc { get; set; }

        public double Price { get; set; }

        public double DiscountPrice { get; set; }

        public int Dept { get; set; }

        public decimal Weight { get; set; }

        public string WeightUnit { get; set; }// EX GRAMS, OUNCES, POUNDS, ETC. 

        public string ItemType { get; set; } // EBT,Non EBT

        public bool IsDiscountable { get; set; }

    }

}
