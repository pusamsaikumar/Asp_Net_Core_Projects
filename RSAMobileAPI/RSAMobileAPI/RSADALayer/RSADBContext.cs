using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using RSAMobileAPI.RSADALayer;
using RSAMobileAPI.RSAEntities;
using RSAMobileAPI.RSARepositories.Services;
using System;
using static RSAMobileAPI.RSAEntities.GetClientStoreForAppResponse;

namespace RSAMobileAPI.RSADALayer
{
    public class RSA_QAEntities : DbContext
    {

        //public RSA_QAEntities()
        //{

        //}
        public RSA_QAEntities(DbContextOptions<RSA_QAEntities> options) : base(options)
        {

        }

        public virtual DbSet<BasketCoupon> BasketCoupons { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<BasketData> BasketData { get; set; }
        public virtual DbSet<GetClientStores_App_Result> GetClientStores_App_Result { get;set;}

         public DbSet<GetClientStores_Result> GetClientStoresResults { get; set; }
         public virtual DbSet<GetCustomersList_Result> GetCustomersList_Resu {  get; set; } 
        public virtual DbSet<ValidateToken_Result> ValidateToken_Result { get; set; }
        public virtual DbSet<GetUserProfile_Result> GetUserProfile_Resul {  get; set; } 
        public virtual DbSet<GetRecentBaskets_Result> GetRecentBaskets_Result {  get; set; }    
        public virtual DbSet<GetRecentRedemptions_Result> GetRecentRedemptions_Results { get; set; }
        public virtual DbSet<GetRecentClips_Result> GetRecentClips_Results { get; set; }
        public virtual DbSet<GetSlides_Result> GetSlides_Results { get; set; }
        public virtual DbSet<GetMenuList_Result> GetMenuList_Results { get; set; }
        public virtual DbSet<GetUserCardInfo_Result> GetUserCardInfo_Results { get; set; }
        public virtual DbSet<GetRecipeCategories_Result> GetRecipeCategories_Results { get; set; }
        public virtual DbSet<GetWeeklyAdGallery_Result> GetWeeklyAdGallery_Results { get; set; }
        public virtual DbSet<GetWeeklyAdsForBeforeLogin_Result> GetWeeklyAdsForBeforeLogin_Results { get; set; }
        public virtual DbSet<TF_GETORDERS_Result> TF_GETORDERS_Results { get; set; }
        public virtual DbSet<TF_GetAllMenu_Result> TF_GetAllMenu_Results { get; set; }

        public virtual DbSet<TF_GETORDERDETAILS_Result> TF_GETORDERDETAILS_Results { get; set; }
        public virtual DbSet<TF_GETORDERPAYMENTS_Result> TF_GETORDERPAYMENTS_Results { get; set; }
        public virtual DbSet<GetUserGroups_Result> GetUserGroups_Results { get; set; }
        public virtual DbSet<GetUserRedeemedCoupons_Result> GetUserRedeemedCoupons_Results { get; set; }    
        public virtual DbSet<GetAllCouponsBeforeLogin_Result> GetAllCouponsBeforeLogin_Results { get; set; }  
        public virtual DbSet<LM_GetRewardCountsByDepartment_Result> LM_GetRewardCountsByDepartment_Results { get; set; }    
        public virtual DbSet<LM_GetAllRewardsForDepartment_Result>LM_GetAllRewardsForDepartment_Results { get; set; }  
        public virtual DbSet<GetDepartmentWiseCoupons_Result> GetDepartmentWiseCoupons_Results { get; set; } 
        public virtual DbSet<LM_GetQualifiedRewardTiersForMember_Result> LM_GetQualifiedRewardTiersForMember_Results { get; set; }  
        public virtual DbSet<LM_GetQualifiedPointsBasedRewardTiersForMember_Result> LM_GetQualifiedPointsBasedRewardTiersForMember_Results { get; set; }
        public virtual DbSet<LM_GetPointsBasedRewardDetailsForMember_Result> LM_GetPointsBasedRewardDetailsForMember_Results { get; set; }  
        public virtual DbSet<GetAllEvents_Result> GetAllEvents_Results { get; set; }
        public virtual DbSet<LM_GetUPCTierProducts_Result> LM_GetUPCTierProducts_Results { get; set; }  
        public virtual DbSet<GetMemberMostRecentBasketItems_Result> GetMemberMostRecentBasketItems_Results { get; set; }
        public virtual DbSet<TF_GETUSERLOCATIONS_Result> TF_GETUSERLOCATIONS_Results { get; set; }  

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=veritrarsadevdb.clkbmvhusrdv.us-east-1.rds.amazonaws.com;Initial Catalog=RSA_GroceryDEV;MultipleActiveResultSets=true;User ID=Veritragrocerydblogin;Password=otTL5kd0buqb7erEuTqX");
        //    }
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetClientStores_Result>().HasKey(x => x.ClientStoreId);
            modelBuilder.Entity<ValidateToken_Result>().HasKey(x => x.UserTokenId);
            modelBuilder.Entity<GetUserProfile_Result>().HasKey(x => x.UserDetailId);
            modelBuilder.Entity<GetRecentBaskets_Result>().HasKey(x => x.StoreId);
            modelBuilder.Entity<GetRecentRedemptions_Result>().HasKey(x => x.PromotionId);
            modelBuilder.Entity<GetRecentClips_Result>().HasKey(x => x.UserName);
            modelBuilder.Entity<GetSlides_Result>().HasKey(x => x.SlideId);
            modelBuilder.Entity<GetMenuList_Result>().HasKey(x => x.MenuId);
            modelBuilder.Entity<GetUserCardInfo_Result>().HasKey(x => x.UserDetailId);
            modelBuilder.Entity<GetRecipeCategories_Result>().HasKey(x => x.RecipeCategoryId);
            modelBuilder.Entity<GetWeeklyAdGallery_Result>().HasKey(x => x.StoreId);
            modelBuilder.Entity<GetWeeklyAdsForBeforeLogin_Result>().HasKey(x=>x.NewsID);
            modelBuilder.Entity<TF_GETORDERS_Result>().HasKey(x => x.OrderID);
            modelBuilder.Entity<TF_GETORDERDETAILS_Result>().HasKey(x=>x.OrderDetailID);
            modelBuilder.Entity<TF_GETORDERPAYMENTS_Result>().HasKey(x => x.OrderPaymentID);
            modelBuilder.Entity<TF_GetAllMenu_Result>().HasKey(x => x.NewsID);
            modelBuilder.Entity<GetUserGroups_Result>().HasKey(x => x.ClubId);
            modelBuilder.Entity<GetUserRedeemedCoupons_Result>().HasKey(x => x.NewsId);
            modelBuilder.Entity<GetAllCouponsBeforeLogin_Result>().HasKey(x =>x.NewsID);
            modelBuilder.Entity<LM_GetRewardCountsByDepartment_Result>().HasKey(x => x.DEPARTMENTID);
            modelBuilder.Entity<LM_GetAllRewardsForDepartment_Result>().HasKey(x => x.LMRewardId);
            modelBuilder.Entity<GetDepartmentWiseCoupons_Result>().HasKey(x => x.NewsID);
            modelBuilder.Entity<LM_GetQualifiedRewardTiersForMember_Result>().HasKey(x => x.LMRewardTierID);
            modelBuilder.Entity<LM_GetQualifiedPointsBasedRewardTiersForMember_Result>().HasKey(x => x.LMRewardTierID);
            modelBuilder.Entity<LM_GetPointsBasedRewardDetailsForMember_Result>().HasKey(x => x.LMRewardTierID);
            modelBuilder.Entity<GetAllEvents_Result>().HasKey(x => x.EventID);
            modelBuilder.Entity<LM_GetUPCTierProducts_Result>().HasKey(x => x.LMRewardTierID);
            modelBuilder.Entity<GetMemberMostRecentBasketItems_Result>().HasKey(x => x.ProductId);
            modelBuilder.Entity<TF_GETUSERLOCATIONS_Result>().HasKey(x => x.UserAddressID);
        }








    }
}
