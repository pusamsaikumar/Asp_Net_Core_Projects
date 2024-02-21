using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class ViewCustomUserDetail
    {
        public string? Name { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public int Userdetailid { get; set; }
        public int? Usertypeid { get; set; }
        public string? Usertype { get; set; }
        public string? Zipcode { get; set; }
        public string? Mobile { get; set; }
        public bool? Isactive { get; set; }
        public Guid? Roleid { get; set; }
        public string? Rolename { get; set; }
        public int? Clientstoreid { get; set; }
        public string? Barcodevalue { get; set; }
        public Guid Userid { get; set; }
    }
}
