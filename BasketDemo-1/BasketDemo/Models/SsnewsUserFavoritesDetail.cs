using System;
using System.Collections.Generic;

namespace BasketDemo.Models
{
    public partial class SsnewsUserFavoritesDetail
    {
        public int UserFavoriteListDetailsId { get; set; }
        public int UserFavoriteListId { get; set; }
        public int NewsId { get; set; }
        public int StoreId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
