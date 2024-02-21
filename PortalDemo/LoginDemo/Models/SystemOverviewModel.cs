using System.ComponentModel.DataAnnotations;

namespace LoginDemo.Models
{
    //basket
    public class Table
    {
        [Key]
        public int Id { get; set; }
        public double TOTALBASKETAMOUNT { get; set; }
        public string LOYALTYID { get; set; }
        public string TransactionDate { get; set; }
        public int STOREID { get; set; }
        public string STORENAME { get; set; }
        public string BasketJSON { get; set; }
    }
    // Redemption 
    public class Table1
    {
        [Key]
        public int Id { get; set; }
        public DateTime RedemptionDate { get; set; }
        public string MemberNumber { get; set; }
        public string Title { get; set; }
        public int NewscategoryID { get; set; }
        public string PreferredStore { get; set; }
        public string RDJson { get; set; }
    }
    public class Table2
    {
        [Key]
        public int Id { get; set; }
        public DateTime NCRImpressionDate { get; set; }
        public string MemberNumber { get; set; }
        public string Title { get; set; }
        public int NewscategoryID { get; set; }
        public string PreferredStore { get; set; }
    }

    public class Table3
    {
        [Key]
        public int Id { get; set; }
        public string USERNAME { get; set; }
        public string MEMBERNUMBER { get; set; }
        public string REWARDTITLE { get; set; }
        public int REWARDSCOUNT { get; set; }
    }
    public class Table4
    {
        [Key]
        public int Id { get; set; }
        public string USERNAME { get; set; }
        public string BARCODEVALUE { get; set; }
        public int USERDETAILID { get; set; }
        public int STOREID { get; set; }
        public string STORENAME { get; set; }
        public DateTime SIGNUPDATE { get; set; }
    }

    public class RootObject
    {
        public List<Table> Table { get; set; }
        public List<Table1> Table1 { get; set; }
        public List<Table2> Table2 { get; set; }
        public List<Table3> Table3 { get; set; }
        public List<Table4> Table4 { get; set; }
    }


    public class Table5
    {
        [Key]
        public int Id { get; set; }
        public string DatabaseName { get; set; }
        public int Older_Than_Days { get; set; }
        public int OptIn_Count { get; set; }
    }

    public class RootTableobject
    {
        public List<Table5> Table { get; set; }
    }
    public class RootObjects
    {
        public List<Table> Table { get; set; }
    }

    //public class RootObject1
    //{
    //    public List<Table1> Table1 { get; set; }
    //}


}
