using JWTRoleAuthentication.CommonLayer.Models;

namespace JWTRoleAuthentication.CommonLayer.Models
{
    public class Coupon
    {
        public string CouponId { get; set; }    
        public string ExternalId { get; set; }  
        public string ReceiptAlias { get; set; }  
        public List<Item> Items { get; set; }
        public double TotalDiscount { get; set; }   
        public bool ReducesTax { get; set; }

        //public override bool Equals(object? obj)
        //{
        //    if (obj is Coupon coupon)
        //    {
        //        return CouponId == coupon.CouponId &&
        //               TotalDiscount == coupon.TotalDiscount &&
        //               Items.SequenceEqual(coupon.Items);
        //    }
        //    return false;
        //}

        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(CouponId, TotalDiscount, Items);
        //}
    }
    public class Item
    {
        public string LineId { get; set; }  
        public double Discount { get; set; }
        public int Quantity { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Item item &&
                   LineId == item.LineId &&
                   Discount == item.Discount &&
                   Quantity == item.Quantity;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LineId, Discount, Quantity);
        }

    }
    public class CouponResponse
    {
        public List<Coupon> Applied { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string Status { get; set; }  
    }
    public class AppliedData
    {
       public List<Coupon> NewApplied { get; set; }
        public List<Coupon> OldApplied { get; set; }
    }


   
}

public class AppliedCouponComparer : IEqualityComparer<Coupon>
{
    public bool Equals(Coupon x, Coupon y)
    {
       
        if (x is null || y is null) return false;

        return x.CouponId == y.CouponId &&
               x.TotalDiscount == y.TotalDiscount


            && x.Items.SequenceEqual(y.Items);
    }

    //public int GetHashCode(Coupon obj)
    //{
    //    if (obj == null) return 0;

    //     //return (obj.CouponId + obj.TotalDiscount).GetHashCode();

    //   return (obj.CouponId + obj.TotalDiscount + obj.Items).GetHashCode();
    //}
    public int GetHashCode(Coupon obj)
    {
        if (obj == null) return 0;

        int hashCouponId = obj.CouponId == null ? 0 : obj.CouponId.GetHashCode();
        int hashTotalDiscount = obj.TotalDiscount.GetHashCode();
        int hashItems = obj.Items == null ? 0 : obj.Items.Aggregate(0, (hash, item) => hash ^ item.GetHashCode());
        //return hashCouponId ^ hashTotalDiscount;
        return hashCouponId ^ hashTotalDiscount ^ hashItems;
        
    }


}