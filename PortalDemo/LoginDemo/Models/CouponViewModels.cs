using System.ComponentModel.DataAnnotations;

namespace LoginDemo.Models
{
    public class CouponViewModels
    {
        public class RNPMMOdels
        {
            [Key]
            public int Id { get; set; }    
            public string Coupon { get; set; }
            public Nullable<int> ManufacturerCouponID { get; set; }
            public Nullable<decimal> CouponValue { get; set; }
            public Nullable<int> Number_of_Redemptions { get; set; }
            public Nullable<decimal> RedeemedAmount { get; set; }
            public string FACEVALUE { get; set; }
            public string SubmittedCount { get; set; }
            public Nullable<decimal> SubmittedFaceValue { get; set; }
        }
    }
}
