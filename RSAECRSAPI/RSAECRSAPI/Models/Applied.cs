namespace RSAECRSAPI.Models
{
    public class Applied
    {
		public string CouponId { get; set; }	
		public string ExternelId { get; set; }
		public List<Item> Items { get; set; }
		public string ReceiptAlias { get; set; }
		public bool ReducesTax { get; set; }
		public decimal TotalDiscount { get; set; }	
    }
	public class Item
	{
		public decimal Discount { get; set; }
		public int LineId { get; set; }
	}
}

