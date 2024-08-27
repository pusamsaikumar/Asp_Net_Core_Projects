using System.Runtime.Serialization;

namespace RSAECRSAPI.ECRSDAL.Models
{
    public class UpdateTransactionRequest
    {
        public string sharedKey { get; set; }


        public string Secret { get; set; }


        public string Customer { get; set; }


        public int Site { get; set; }


        public string Transaction { get; set; }


        public int Cashier { get; set; }


        public int Terminal { get; set; }


        public string Time { get; set; }
       // public List<UpdateTransactionItem> items { get; set; }


        public double SubTotal { get; set; }



        public double TaxTotal { get; set; }



        public double GrossTotal { get; set; }



        public string PhoneNumber { get; set; }


        public bool PosDiscountApplied { get; set; }
    }
}





