using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SsnewsUserFavoritesList
    {
        public int UserFavoriteListId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
