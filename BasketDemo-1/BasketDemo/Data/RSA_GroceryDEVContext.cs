using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BasketDemo.Models
{
    public partial class RSA_GroceryDEVContext : DbContext
    {
        public RSA_GroceryDEVContext()
        {
        }

        public RSA_GroceryDEVContext(DbContextOptions<RSA_GroceryDEVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AddressType> AddressTypes { get; set; } = null!;
        public virtual DbSet<AspnetApplication> AspnetApplications { get; set; } = null!;
        public virtual DbSet<AspnetMembership> AspnetMemberships { get; set; } = null!;
        public virtual DbSet<AspnetPath> AspnetPaths { get; set; } = null!;
        public virtual DbSet<AspnetPersonalizationAllUser> AspnetPersonalizationAllUsers { get; set; } = null!;
        public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; } = null!;
        public virtual DbSet<AspnetProfile> AspnetProfiles { get; set; } = null!;
        public virtual DbSet<AspnetRole> AspnetRoles { get; set; } = null!;
        public virtual DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; } = null!;
        public virtual DbSet<AspnetUser> AspnetUsers { get; set; } = null!;
        public virtual DbSet<AspnetUsersInRole> AspnetUsersInRoles { get; set; } = null!;
        public virtual DbSet<AspnetWebEventEvent> AspnetWebEventEvents { get; set; } = null!;
        public virtual DbSet<BasketConsumerId> BasketConsumerIds { get; set; } = null!;
        public virtual DbSet<BasketCoupon> BasketCoupons { get; set; } = null!;
        public virtual DbSet<BasketCouponUpc> BasketCouponUpcs { get; set; } = null!;
        public virtual DbSet<BasketDataJson> BasketDataJsons { get; set; } = null!;
        public virtual DbSet<BasketDatum> BasketData { get; set; } = null!;
        public virtual DbSet<BasketItem> BasketItems { get; set; } = null!;
        public virtual DbSet<BiSpendByUpcAndMember> BiSpendByUpcAndMembers { get; set; } = null!;
        public virtual DbSet<BiSpendByUpcAndStore> BiSpendByUpcAndStores { get; set; } = null!;
        public virtual DbSet<BiSpendTotalByMember> BiSpendTotalByMembers { get; set; } = null!;
        public virtual DbSet<BuyingUnit> BuyingUnits { get; set; } = null!;
        public virtual DbSet<Circular> Circulars { get; set; } = null!;
        public virtual DbSet<ClientEnterprise> ClientEnterprises { get; set; } = null!;
        public virtual DbSet<ClientEnterpriseRoute> ClientEnterpriseRoutes { get; set; } = null!;
        public virtual DbSet<ClientJobDetail> ClientJobDetails { get; set; } = null!;
        public virtual DbSet<ClientMessage> ClientMessages { get; set; } = null!;
        public virtual DbSet<ClientMessageTarget> ClientMessageTargets { get; set; } = null!;
        public virtual DbSet<ClientMessagesDeleted> ClientMessagesDeleteds { get; set; } = null!;
        public virtual DbSet<ClientStore> ClientStores { get; set; } = null!;
        public virtual DbSet<ClientStoreGroup> ClientStoreGroups { get; set; } = null!;
        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<ClubUser> ClubUsers { get; set; } = null!;
        public virtual DbSet<ClubsDeleted> ClubsDeleteds { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Company1> Companies1 { get; set; } = null!;
        public virtual DbSet<CompanyAddress> CompanyAddresses { get; set; } = null!;
        public virtual DbSet<CompanyContact> CompanyContacts { get; set; } = null!;
        public virtual DbSet<CompanyUser> CompanyUsers { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<ContactMessage> ContactMessages { get; set; } = null!;
        public virtual DbSet<ContactType> ContactTypes { get; set; } = null!;
        public virtual DbSet<ContactU> ContactUs { get; set; } = null!;
        public virtual DbSet<ContentAppId> ContentAppIds { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Coupon> Coupons { get; set; } = null!;
        public virtual DbSet<CouponRule> CouponRules { get; set; } = null!;
        public virtual DbSet<CouponStatus> CouponStatuses { get; set; } = null!;
        public virtual DbSet<CouponsOfferNotExist> CouponsOfferNotExists { get; set; } = null!;
        public virtual DbSet<CouponsOfferRedemption> CouponsOfferRedemptions { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAddresss> CustomerAddressses { get; set; } = null!;
        public virtual DbSet<CustomerComment> CustomerComments { get; set; } = null!;
        public virtual DbSet<CustomerContact> CustomerContacts { get; set; } = null!;
        public virtual DbSet<CustomerType> CustomerTypes { get; set; } = null!;
        public virtual DbSet<CustomerUser> CustomerUsers { get; set; } = null!;
        public virtual DbSet<CustomersOld> CustomersOlds { get; set; } = null!;
        public virtual DbSet<DataImport> DataImports { get; set; } = null!;
        public virtual DbSet<DataImportDetail> DataImportDetails { get; set; } = null!;
        public virtual DbSet<DeviceType> DeviceTypes { get; set; } = null!;
        public virtual DbSet<DistributorCoupon> DistributorCoupons { get; set; } = null!;
        public virtual DbSet<DistributorCouponsOfferRedemption> DistributorCouponsOfferRedemptions { get; set; } = null!;
        public virtual DbSet<DistributorCouponsUpdateQueue> DistributorCouponsUpdateQueues { get; set; } = null!;
        public virtual DbSet<Exception> Exceptions { get; set; } = null!;
        public virtual DbSet<ExistingOffer> ExistingOffers { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<GroupPage> GroupPages { get; set; } = null!;
        public virtual DbSet<IntegrationSetting> IntegrationSettings { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceCoupon> InvoiceCoupons { get; set; } = null!;
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; } = null!;
        public virtual DbSet<JobIntervalType> JobIntervalTypes { get; set; } = null!;
        public virtual DbSet<LmJobHistory> LmJobHistories { get; set; } = null!;
        public virtual DbSet<LmReward> LmRewards { get; set; } = null!;
        public virtual DbSet<LmRewardDepartment> LmRewardDepartments { get; set; } = null!;
        public virtual DbSet<LmRewardGroup> LmRewardGroups { get; set; } = null!;
        public virtual DbSet<LmRewardProduct> LmRewardProducts { get; set; } = null!;
        public virtual DbSet<LmRewardProductType> LmRewardProductTypes { get; set; } = null!;
        public virtual DbSet<LmRewardTarget> LmRewardTargets { get; set; } = null!;
        public virtual DbSet<LmRewardTransaction> LmRewardTransactions { get; set; } = null!;
        public virtual DbSet<LmRewardType> LmRewardTypes { get; set; } = null!;
        public virtual DbSet<LmRewardUpdateQueue> LmRewardUpdateQueues { get; set; } = null!;
        public virtual DbSet<LmUserReward> LmUserRewards { get; set; } = null!;
        public virtual DbSet<MfgCoupon> MfgCoupons { get; set; } = null!;
        public virtual DbSet<MfgCouponsHold> MfgCouponsHolds { get; set; } = null!;
        public virtual DbSet<MfgCouponsHoldStore> MfgCouponsHoldStores { get; set; } = null!;
        public virtual DbSet<MfgCouponsUpdateQueue> MfgCouponsUpdateQueues { get; set; } = null!;
        public virtual DbSet<MyCart> MyCarts { get; set; } = null!;
        public virtual DbSet<MyCartProduct> MyCartProducts { get; set; } = null!;
        public virtual DbSet<NewsCategory> NewsCategories { get; set; } = null!;
        public virtual DbSet<NewsItem> NewsItems { get; set; } = null!;
        public virtual DbSet<NewsItemCategory> NewsItemCategories { get; set; } = null!;
        public virtual DbSet<NewsTarget> NewsTargets { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;
        public virtual DbSet<PageItem> PageItems { get; set; } = null!;
        public virtual DbSet<PaymentTerm> PaymentTerms { get; set; } = null!;
        public virtual DbSet<Possoftware> Possoftwares { get; set; } = null!;
        public virtual DbSet<Posvendor> Posvendors { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Product1> Products1 { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductImport> ProductImports { get; set; } = null!;
        public virtual DbSet<ProductMajorCategory> ProductMajorCategories { get; set; } = null!;
        public virtual DbSet<ProductsTest> ProductsTests { get; set; } = null!;
        public virtual DbSet<Promotion> Promotions { get; set; } = null!;
        public virtual DbSet<PushNotificationsQueue> PushNotificationsQueues { get; set; } = null!;
        public virtual DbSet<QualifyingProduct> QualifyingProducts { get; set; } = null!;
        public virtual DbSet<Redemption> Redemptions { get; set; } = null!;
        public virtual DbSet<RedemptionDataJson> RedemptionDataJsons { get; set; } = null!;
        public virtual DbSet<RedemptionDistribution> RedemptionDistributions { get; set; } = null!;
        public virtual DbSet<RedemptionDistributionJson> RedemptionDistributionJsons { get; set; } = null!;
        public virtual DbSet<RsaTransactionHistory> RsaTransactionHistories { get; set; } = null!;
        public virtual DbSet<SalesHeader> SalesHeaders { get; set; } = null!;
        public virtual DbSet<SalesHeaderDetail> SalesHeaderDetails { get; set; } = null!;
        public virtual DbSet<SalesQualifyingProduct> SalesQualifyingProducts { get; set; } = null!;
        public virtual DbSet<SalesRedeem> SalesRedeems { get; set; } = null!;
        public virtual DbSet<SalesReward> SalesRewards { get; set; } = null!;
        public virtual DbSet<SelectedProductIdForWeeklySpecial> SelectedProductIdForWeeklySpecials { get; set; } = null!;
        public virtual DbSet<SelectedStoresForCoupon> SelectedStoresForCoupons { get; set; } = null!;
        public virtual DbSet<SelectedStoresForIntelligentCoupon> SelectedStoresForIntelligentCoupons { get; set; } = null!;
        public virtual DbSet<SellingUnit> SellingUnits { get; set; } = null!;
        public virtual DbSet<Ssnews> Ssnews { get; set; } = null!;
        public virtual DbSet<SsnewsDepartment> SsnewsDepartments { get; set; } = null!;
        public virtual DbSet<SsnewsNcrpromotion> SsnewsNcrpromotions { get; set; } = null!;
        public virtual DbSet<SsnewsProduct> SsnewsProducts { get; set; } = null!;
        public virtual DbSet<SsnewsProductsDeleted> SsnewsProductsDeleteds { get; set; } = null!;
        public virtual DbSet<SsnewsRecurring> SsnewsRecurrings { get; set; } = null!;
        public virtual DbSet<SsnewsUserFavoritesDetail> SsnewsUserFavoritesDetails { get; set; } = null!;
        public virtual DbSet<SsnewsUserFavoritesList> SsnewsUserFavoritesLists { get; set; } = null!;
        public virtual DbSet<SsnewsUsersNcrimpression> SsnewsUsersNcrimpressions { get; set; } = null!;
        public virtual DbSet<SsnewsUsersRedeem> SsnewsUsersRedeems { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<StoreCouponsUpdatequeue> StoreCouponsUpdatequeues { get; set; } = null!;
        public virtual DbSet<SubCategory> SubCategories { get; set; } = null!;
        public virtual DbSet<TimeZone> TimeZones { get; set; } = null!;
        public virtual DbSet<UserAdminStore> UserAdminStores { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;
        public virtual DbSet<UserDevice> UserDevices { get; set; } = null!;
        public virtual DbSet<UserDeviceInfo> UserDeviceInfos { get; set; } = null!;
        public virtual DbSet<UserProductUsage> UserProductUsages { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;
        public virtual DbSet<UserStatus> UserStatuses { get; set; } = null!;
        public virtual DbSet<UserTermsAcceptance> UserTermsAcceptances { get; set; } = null!;
        public virtual DbSet<UserToken> UserTokens { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } = null!;
        public virtual DbSet<UsersCouponsRedeem> UsersCouponsRedeems { get; set; } = null!;
        public virtual DbSet<ViewCustomGetClubUser> ViewCustomGetClubUsers { get; set; } = null!;
        public virtual DbSet<ViewCustomUserDetail> ViewCustomUserDetails { get; set; } = null!;
        public virtual DbSet<VwAspnetApplication> VwAspnetApplications { get; set; } = null!;
        public virtual DbSet<VwAspnetMembershipUser> VwAspnetMembershipUsers { get; set; } = null!;
        public virtual DbSet<VwAspnetProfile> VwAspnetProfiles { get; set; } = null!;
        public virtual DbSet<VwAspnetRole> VwAspnetRoles { get; set; } = null!;
        public virtual DbSet<VwAspnetUser> VwAspnetUsers { get; set; } = null!;
        public virtual DbSet<VwAspnetUsersInRole> VwAspnetUsersInRoles { get; set; } = null!;
        public virtual DbSet<VwAspnetWebPartStatePath> VwAspnetWebPartStatePaths { get; set; } = null!;
        public virtual DbSet<VwAspnetWebPartStateShared> VwAspnetWebPartStateShareds { get; set; } = null!;
        public virtual DbSet<VwAspnetWebPartStateUser> VwAspnetWebPartStateUsers { get; set; } = null!;
        public virtual DbSet<VwBasketCouponItem> VwBasketCouponItems { get; set; } = null!;
        public virtual DbSet<VwRedemptionBasketItem> VwRedemptionBasketItems { get; set; } = null!;
        public virtual DbSet<VwTestView> VwTestViews { get; set; } = null!;
        public virtual DbSet<WebDepartment> WebDepartments { get; set; } = null!;
        public virtual DbSet<WebMenu> WebMenus { get; set; } = null!;
        public virtual DbSet<WebpagesMembership> WebpagesMemberships { get; set; } = null!;
        public virtual DbSet<WebpagesOauthMembership> WebpagesOauthMemberships { get; set; } = null!;
        public virtual DbSet<WebpagesRole> WebpagesRoles { get; set; } = null!;
        public virtual DbSet<WeeklyAddPdf> WeeklyAddPdfs { get; set; } = null!;
        public virtual DbSet<WeeklySpecialImport> WeeklySpecialImports { get; set; } = null!;
        public virtual DbSet<WeeklySpecialsExtension> WeeklySpecialsExtensions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=veritrarsadevdb.clkbmvhusrdv.us-east-1.rds.amazonaws.com;Initial Catalog=RSA_GroceryDEV;MultipleActiveResultSets=true;User ID=Veritragrocerydblogin;Password=otTL5kd0buqb7erEuTqX");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Zip)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("ZIP");

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_AddressType");
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.ToTable("AddressType");

                entity.Property(e => e.AddressType1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("AddressType");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<AspnetApplication>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .HasName("PK__aspnet_A__C93A4C982F785EEC")
                    .IsClustered(false);

                entity.ToTable("aspnet_Applications");

                entity.HasIndex(e => e.LoweredApplicationName, "UQ__aspnet_A__17477DE4BF736F4D")
                    .IsUnique();

                entity.HasIndex(e => e.ApplicationName, "UQ__aspnet_A__3091033198E50C55")
                    .IsUnique();

                entity.HasIndex(e => e.LoweredApplicationName, "aspnet_Applications_Index")
                    .IsClustered();

                entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ApplicationName).HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspnetMembership>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_M__1788CC4D9FC5CCD3")
                    .IsClustered(false);

                entity.ToTable("aspnet_Membership");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredEmail }, "aspnet_Membership_index")
                    .IsClustered();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredEmail).HasMaxLength(256);

                entity.Property(e => e.MobilePin)
                    .HasMaxLength(16)
                    .HasColumnName("MobilePIN");

                entity.Property(e => e.Password).HasMaxLength(128);

                entity.Property(e => e.PasswordAnswer).HasMaxLength(128);

                entity.Property(e => e.PasswordQuestion).HasMaxLength(256);

                entity.Property(e => e.PasswordSalt).HasMaxLength(128);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetMemberships)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Me__Appli__1F83A428");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AspnetMembership)
                    .HasForeignKey<AspnetMembership>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Me__UserI__2077C861");
            });

            modelBuilder.Entity<AspnetPath>(entity =>
            {
                entity.HasKey(e => e.PathId)
                    .HasName("PK__aspnet_P__CD67DC58F77C9FB8")
                    .IsClustered(false);

                entity.ToTable("aspnet_Paths");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredPath }, "aspnet_Paths_index")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.PathId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LoweredPath).HasMaxLength(256);

                entity.Property(e => e.Path).HasMaxLength(256);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetPaths)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pa__Appli__216BEC9A");
            });

            modelBuilder.Entity<AspnetPersonalizationAllUser>(entity =>
            {
                entity.HasKey(e => e.PathId)
                    .HasName("PK__aspnet_P__CD67DC5956E39570");

                entity.ToTable("aspnet_PersonalizationAllUsers");

                entity.Property(e => e.PathId).ValueGeneratedNever();

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PageSettings).HasColumnType("image");

                entity.HasOne(d => d.Path)
                    .WithOne(p => p.AspnetPersonalizationAllUser)
                    .HasForeignKey<AspnetPersonalizationAllUser>(d => d.PathId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pe__PathI__226010D3");
            });

            modelBuilder.Entity<AspnetPersonalizationPerUser>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__aspnet_P__3214EC063A762A5C")
                    .IsClustered(false);

                entity.ToTable("aspnet_PersonalizationPerUser");

                entity.HasIndex(e => new { e.PathId, e.UserId }, "aspnet_PersonalizationPerUser_index1")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => new { e.UserId, e.PathId }, "aspnet_PersonalizationPerUser_ncindex2")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PageSettings).HasColumnType("image");

                entity.HasOne(d => d.Path)
                    .WithMany(p => p.AspnetPersonalizationPerUsers)
                    .HasForeignKey(d => d.PathId)
                    .HasConstraintName("FK__aspnet_Pe__PathI__2354350C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspnetPersonalizationPerUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__aspnet_Pe__UserI__24485945");
            });

            modelBuilder.Entity<AspnetProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_P__1788CC4CA2F6C826");

                entity.ToTable("aspnet_Profile");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PropertyNames).HasColumnType("ntext");

                entity.Property(e => e.PropertyValuesBinary).HasColumnType("image");

                entity.Property(e => e.PropertyValuesString).HasColumnType("ntext");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AspnetProfile)
                    .HasForeignKey<AspnetProfile>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pr__UserI__253C7D7E");
            });

            modelBuilder.Entity<AspnetRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__aspnet_R__8AFACE1BC46C69C2")
                    .IsClustered(false);

                entity.ToTable("aspnet_Roles");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredRoleName }, "aspnet_Roles_index1")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredRoleName).HasMaxLength(256);

                entity.Property(e => e.RoleName).HasMaxLength(256);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetRoles)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Ro__Appli__2630A1B7");
            });

            modelBuilder.Entity<AspnetSchemaVersion>(entity =>
            {
                entity.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion })
                    .HasName("PK__aspnet_S__5A1E6BC16D82BDB9");

                entity.ToTable("aspnet_SchemaVersions");

                entity.Property(e => e.Feature).HasMaxLength(128);

                entity.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);
            });

            modelBuilder.Entity<AspnetUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_U__1788CC4D418BEB9F")
                    .IsClustered(false);

                entity.ToTable("aspnet_Users");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredUserName }, "aspnet_Users_Index")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => new { e.ApplicationId, e.LastActivityDate }, "aspnet_Users_Index2");

                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredUserName).HasMaxLength(256);

                entity.Property(e => e.MobileAlias).HasMaxLength(16);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetUsers)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__Appli__2724C5F0");
            });

            modelBuilder.Entity<AspnetUsersInRole>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("aspnet_UsersInRoles");

                entity.HasIndex(e => e.RoleId, "aspnet_UsersInRoles_index");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspnetUsersInRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__RoleI__2818EA29");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AspnetUsersInRole)
                    .HasForeignKey<AspnetUsersInRole>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__UserI__290D0E62");
            });

            modelBuilder.Entity<AspnetWebEventEvent>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__aspnet_W__7944C8108D88691E");

                entity.ToTable("aspnet_WebEvent_Events");

                entity.Property(e => e.EventId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ApplicationPath).HasMaxLength(256);

                entity.Property(e => e.ApplicationVirtualPath).HasMaxLength(256);

                entity.Property(e => e.Details).HasColumnType("ntext");

                entity.Property(e => e.EventOccurrence).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.EventSequence).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.EventTime).HasColumnType("datetime");

                entity.Property(e => e.EventTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.EventType).HasMaxLength(256);

                entity.Property(e => e.ExceptionType).HasMaxLength(256);

                entity.Property(e => e.MachineName).HasMaxLength(256);

                entity.Property(e => e.Message).HasMaxLength(1024);

                entity.Property(e => e.RequestUrl).HasMaxLength(1024);
            });

            modelBuilder.Entity<BasketConsumerId>(entity =>
            {
                entity.HasKey(e => e.BasketConsumerId1);

                entity.HasIndex(e => e.BasketDataId, "idx_BasketDataID");

                entity.HasIndex(e => e.LoyaltyId, "idx_LoyaltyID");

                entity.Property(e => e.BasketConsumerId1).HasColumnName("BasketConsumerId");

                entity.Property(e => e.AlternateId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoyaltyId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BasketCoupon>(entity =>
            {
                entity.HasKey(e => e.BasketCouponId)
                    .HasName("PK_BasketCoupons_1");

                entity.HasIndex(e => e.BasketDataId, "idx_BasketDataID");

                entity.HasIndex(e => e.Id, "idx_ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BasketCouponUpc>(entity =>
            {
                entity.ToTable("BasketCouponUPC");

                entity.Property(e => e.BasketCouponUpcid).HasColumnName("BasketCouponUPCID");

                entity.Property(e => e.BasketCouponId).HasColumnName("BasketCouponID");

                entity.Property(e => e.BasketCouponPromotionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BasketCouponPromotionID");

                entity.Property(e => e.BasketDataId).HasColumnName("BasketDataID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Upc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPC");
            });

            modelBuilder.Entity<BasketDataJson>(entity =>
            {
                entity.ToTable("BasketData_JSON");

                entity.Property(e => e.BasketDataJsonid).HasColumnName("BasketDataJSONID");

                entity.Property(e => e.BasketDataId).HasColumnName("BasketDataID");

                entity.Property(e => e.BasketJson)
                    .HasColumnType("text")
                    .HasColumnName("BasketJSON");
            });

            modelBuilder.Entity<BasketDatum>(entity =>
            {
                entity.HasKey(e => e.BasketDataId);

                entity.HasIndex(e => e.StoreId, "idx_StoreID");

                entity.HasIndex(e => e.TransactionDate, "idx_TransactionDate");

                entity.Property(e => e.BasketGuid)
                    .HasColumnName("BasketGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsProcessed).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsProcessedForMfg).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsUpcsplitComplete)
                    .HasColumnName("IsUPCSplitComplete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Posid).HasColumnName("POSId");

                entity.Property(e => e.Retailer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.Property(e => e.TransactionTenderType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BasketItem>(entity =>
            {
                entity.HasIndex(e => e.BasketDataId, "idx_BasketDataID");

                entity.HasIndex(e => e.Upc, "idx_UPC");

                entity.Property(e => e.CoPrefix)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FamilyCode1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyCode2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QtyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaleType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Upc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPC");
            });

            modelBuilder.Entity<BiSpendByUpcAndMember>(entity =>
            {
                entity.HasKey(e => e.SpendByUpcMemberId);

                entity.ToTable("BI_SPEND_BY_UPC_AND_MEMBER");

                entity.HasIndex(e => e.Upc, "idx_BI_SPEND_BY_UPC_AND_MEMBER");

                entity.Property(e => e.SpendByUpcMemberId).HasColumnName("SpendByUpcMemberID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MemberNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.Property(e => e.Upc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPC");
            });

            modelBuilder.Entity<BiSpendByUpcAndStore>(entity =>
            {
                entity.HasKey(e => e.SpendByUpcStoreId)
                    .HasName("PK_BI_SPEND_BY_SpendByUPCStoreID");

                entity.ToTable("BI_SPEND_BY_UPC_AND_STORE");

                entity.HasIndex(e => e.Upc, "idx_BI_SPEND_BY_UPC_AND_STORE_UPC");

                entity.HasIndex(e => e.StoreId, "idx_BI_SPEND_StoreID");

                entity.HasIndex(e => e.DeptId, "idx_Spend_DeptID");

                entity.Property(e => e.SpendByUpcStoreId).HasColumnName("SpendByUpcStoreID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.Property(e => e.Upc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPC");
            });

            modelBuilder.Entity<BiSpendTotalByMember>(entity =>
            {
                entity.HasKey(e => e.SpendTotalByMemberId)
                    .HasName("PK_SpendTotalByMeberID");

                entity.ToTable("BI_SPEND_TOTAL_BY_MEMBER");

                entity.Property(e => e.SpendTotalByMemberId).HasColumnName("SpendTotalByMemberID");

                entity.Property(e => e.BasketAmount).HasColumnType("money");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MemberNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate).HasColumnType("date");
            });

            modelBuilder.Entity<BuyingUnit>(entity =>
            {
                entity.Property(e => e.BuyingUnits)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Circular>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.CircularId).HasColumnName("circular_id");

                entity.Property(e => e.CircularName)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("circular_name");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ClientEnterprise>(entity =>
            {
                entity.HasKey(e => e.ClientEnterprisesId);

                entity.Property(e => e.ClientEnterprisesId).HasColumnName("ClientEnterprisesID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PosenterpriseId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("POSEnterpriseId");

                entity.Property(e => e.PosenterpriseSecretKey)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("POSEnterpriseSecretKey");

                entity.Property(e => e.Possoftware)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POSSoftware");

                entity.Property(e => e.PosvendorId).HasColumnName("POSVendorId");
            });

            modelBuilder.Entity<ClientEnterpriseRoute>(entity =>
            {
                entity.Property(e => e.ClientEnterpriseRouteId).HasColumnName("ClientEnterpriseRouteID");

                entity.Property(e => e.ClientEnterprisesId).HasColumnName("ClientEnterprisesID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PosenterpriseId)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("POSEnterpriseId");

                entity.Property(e => e.PosrouteId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("POSRouteID");

                entity.HasOne(d => d.ClientEnterprises)
                    .WithMany(p => p.ClientEnterpriseRoutes)
                    .HasForeignKey(d => d.ClientEnterprisesId)
                    .HasConstraintName("FK_ClientEnterpriseRoutes_ClientEnterprises");
            });

            modelBuilder.Entity<ClientJobDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JobStartDate).HasColumnType("datetime");

                entity.Property(e => e.LastRunDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ClientMessage>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Details).IsUnicode(false);

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.IsTargetSpecific).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScheduledDate).HasColumnType("datetime");

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<ClientMessageTarget>(entity =>
            {
                entity.HasKey(e => e.MessageTargetId);

                entity.ToTable("ClientMessage_Targets");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedUserId).HasColumnName("CreatedUserID");

                entity.Property(e => e.IsExclude).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedUserId).HasColumnName("ModifiedUserID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.ClientMessageTargets)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK_ClientMessage_Targets_Clubs");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.ClientMessageTargets)
                    .HasForeignKey(d => d.MessageId)
                    .HasConstraintName("FK_ClientMessage_Targets_SSNews");
            });

            modelBuilder.Entity<ClientMessagesDeleted>(entity =>
            {
                entity.HasKey(e => e.MessageDeleteId);

                entity.ToTable("ClientMessagesDeleted");

                entity.Property(e => e.MessageDeleteId).HasColumnName("MessageDeleteID");

                entity.Property(e => e.ClientMessageId).HasColumnName("ClientMessageID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ClientMessage)
                    .WithMany(p => p.ClientMessagesDeleteds)
                    .HasForeignKey(d => d.ClientMessageId)
                    .HasConstraintName("FK_ClientMessagesDeleted_ClientMessages");
            });

            modelBuilder.Entity<ClientStore>(entity =>
            {
                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientStorePosenterpriseSecretId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ClientStorePOSEnterpriseSecretId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GlobalStoreId).HasColumnName("GlobalStoreID");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.OtherPos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OtherPOS");

                entity.Property(e => e.PosrouteId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POSRouteId");

                entity.Property(e => e.PossoftwareId).HasColumnName("POSSoftwareId");

                entity.Property(e => e.PossoftwareVersionNumber)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("POSSoftwareVersionNumber");

                entity.Property(e => e.PosstoreId)
                    .HasColumnName("POSStoreId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Postype).HasColumnName("POStype");

                entity.Property(e => e.PosvendorId).HasColumnName("POSVendorId");

                entity.Property(e => e.StoreEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StorePhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreProfile).IsUnicode(false);

                entity.Property(e => e.StoreTimings)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClientEnterprises)
                    .WithMany(p => p.ClientStores)
                    .HasForeignKey(d => d.ClientEnterprisesId)
                    .HasConstraintName("FK_ClientStores_ClientEnterprises");
            });

            modelBuilder.Entity<ClientStoreGroup>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.ClientStoreGroupsId, "ci_azure_fixup_dbo_ClientStoreGroups")
                    .IsClustered();

                entity.Property(e => e.ClientStoreGroupsId).ValueGeneratedOnAdd();

                entity.Property(e => e.StoreGroupDescription).IsUnicode(false);

                entity.Property(e => e.StoreGroupName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.Property(e => e.ClubDetails)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Createddate)
                    .HasColumnType("datetime")
                    .HasColumnName("createddate");

                entity.Property(e => e.IsEnableOnSignOn).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsMemberIdrequired)
                    .HasColumnName("IsMemberIDRequired")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TopicArn)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClubUser>(entity =>
            {
                entity.HasIndex(e => e.UserId, "idx_UserID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClubMemberId)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsSubscribedToTopic).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.ClubUsers)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK_ClubUsers_Clubs1");
            });

            modelBuilder.Entity<ClubsDeleted>(entity =>
            {
                entity.ToTable("CLUBS_DELETED");

                entity.Property(e => e.ClubsDeletedId).HasColumnName("ClubsDeletedID");

                entity.Property(e => e.ClubId).HasColumnName("ClubID");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyLogo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyPhone)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfile)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyWebSite)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FederalId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Company1>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK_COMPANY");

                entity.ToTable("Company");

                entity.Property(e => e.BillingAddressId).HasColumnName("Billing_Address_ID");

                entity.Property(e => e.CompanyMailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FederalId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Federal_ID");

                entity.Property(e => e.IsBillingSameAsMailingAddress).HasColumnName("Is_Billing_SameAs_MailingAddress");

                entity.Property(e => e.LogoFileUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogoFile_URL");

                entity.Property(e => e.MaillingAddressId).HasColumnName("Mailling_Address_ID");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryContactId).HasColumnName("Primary_Contact_ID");

                entity.Property(e => e.SecondaryContactId).HasColumnName("Secondary_Contact_Id");

                entity.Property(e => e.WebsiteUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Website_URL");
            });

            modelBuilder.Entity<CompanyAddress>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("CompanyAddress");
            });

            modelBuilder.Entity<CompanyContact>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("CompanyContact");
            });

            modelBuilder.Entity<CompanyUser>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.ContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_ContactType");
            });

            modelBuilder.Entity<ContactMessage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.ToTable("ContactType");

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.HasKey(e => e.ContactUsId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HowDidYouKnow)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POS");

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Team)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContentAppId>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InstanceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryName).HasMaxLength(150);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.CouponCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountPercentageCount).HasColumnType("money");

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.NcrpromotionCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NCRPromotionCode");

                entity.Property(e => e.NcrpromotionCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("NCRPromotionCreatedDate");

                entity.Property(e => e.PromotionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PromotionID");

                entity.Property(e => e.RedeemOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CouponRule>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountPercentage).HasColumnType("money");
            });

            modelBuilder.Entity<CouponStatus>(entity =>
            {
                entity.Property(e => e.CouponStatusId).ValueGeneratedNever();

                entity.Property(e => e.CouponStatus1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CouponStatus");
            });

            modelBuilder.Entity<CouponsOfferNotExist>(entity =>
            {
                entity.HasKey(e => e.MpmId);

                entity.ToTable("Coupons_Offer_NOT_EXISTS");

                entity.Property(e => e.MpmId).HasColumnName("MPM_ID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.OfferIdguid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OfferIDGUID");

                entity.Property(e => e.Retailer)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CouponsOfferRedemption>(entity =>
            {
                entity.HasKey(e => e.CouponOfferRedemptionsId);

                entity.ToTable("Coupons_Offer_Redemptions");

                entity.HasIndex(e => e.ClearingStatusId, "idx_ClearingStatusID");

                entity.HasIndex(e => e.CouponOfferId, "idx_CouponOfferID");

                entity.HasIndex(e => e.MemberNumber, "idx_MemberNumber");

                entity.HasIndex(e => e.RedemptionDistributionId, "idx_RedemptionDistributionId");

                entity.Property(e => e.ClearingRecordId).HasColumnName("ClearingRecordID");

                entity.Property(e => e.ClearingStatusId)
                    .HasColumnName("ClearingStatusID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CouponOfferId).HasColumnName("CouponOfferID");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MemberNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OfferGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SentTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.BillingPercentage).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerGuid).HasColumnName("CustomerGUID");

                entity.Property(e => e.CustomerLogo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerProfile)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerWebSite)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FederalId)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsPosintegrationEnabled)
                    .HasColumnName("IsPOSIntegrationEnabled")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MfgcontentAppId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MFGContentAppId");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PrimaryColor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryColor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Siccode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SICCode");
            });

            modelBuilder.Entity<CustomerAddresss>(entity =>
            {
                entity.ToTable("CustomerAddresss");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<CustomerComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK_UserComments");

                entity.ToTable("Customer_Comments");

                entity.Property(e => e.CommentDescription).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CustomerContact>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.CustomerContacts)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_CustomerContacts_Contact");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerContacts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerContacts_Customers");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.Property(e => e.CustomerDescription)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerUser>(entity =>
            {
                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.CustomerUsers)
                    .HasForeignKey(d => d.ContactTypeId)
                    .HasConstraintName("FK_CustomerUsers_ContactType");
            });

            modelBuilder.Entity<CustomersOld>(entity =>
            {
                entity.ToTable("CustomersOld");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DataImport>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DataImportDetail>(entity =>
            {
                entity.Property(e => e.CouponCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.ToTable("DeviceType");

                entity.Property(e => e.DeviceTypeName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DistributorCoupon>(entity =>
            {
                entity.ToTable("DISTRIBUTOR_COUPONS");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CouponImage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DistCouponsOfferId).HasColumnName("Dist_Coupons_Offer_Id");

                entity.Property(e => e.DistributorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsProcessedForNcr).HasColumnName("IsProcessedForNCR");

                entity.Property(e => e.OfferActiveDate).HasColumnType("datetime");

                entity.Property(e => e.OfferDescription).IsUnicode(false);

                entity.Property(e => e.OfferDisclaimer).HasColumnType("text");

                entity.Property(e => e.OfferExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.OfferFeturedText).IsUnicode(false);

                entity.Property(e => e.OfferFinePrint).IsUnicode(false);

                entity.Property(e => e.OfferGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OfferGUID");

                entity.Property(e => e.OfferShutoffDate).HasColumnType("datetime");

                entity.Property(e => e.OfferSummary)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OfferType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OfferTypeId).HasColumnName("OfferTypeID");

                entity.Property(e => e.OfferUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.OfferValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Upc)
                    .HasColumnType("text")
                    .HasColumnName("UPC");
            });

            modelBuilder.Entity<DistributorCouponsOfferRedemption>(entity =>
            {
                entity.HasKey(e => e.DistributorCouponsRedemptionsId);

                entity.ToTable("DistributorCoupons_Offer_Redemptions");

                entity.Property(e => e.ClearingRecordId).HasColumnName("ClearingRecordID");

                entity.Property(e => e.ClearingStatusId)
                    .HasColumnName("ClearingStatusID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CouponOfferId).HasColumnName("CouponOfferID");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MemberNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OfferGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SentTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<DistributorCouponsUpdateQueue>(entity =>
            {
                entity.HasKey(e => e.DistCouponUpdateQueueId)
                    .HasName("PK_DIST_COUPONS_UpdateQueue");

                entity.ToTable("DISTRIBUTOR_COUPONS_UpdateQueue");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.DistCouponsOfferId).HasColumnName("Dist_Coupons_Offer_Id");

                entity.Property(e => e.OfferIdGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OfferIdGUID");
            });

            modelBuilder.Entity<Exception>(entity =>
            {
                entity.Property(e => e.ExceptionDate).HasPrecision(0);

                entity.Property(e => e.ExceptionDetails)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionMessage)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExistingOffer>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.OfferGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OfferGUID");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.Gid);

                entity.Property(e => e.Gid).HasColumnName("GID");

                entity.Property(e => e.ActiveDate)
                    .HasColumnType("datetime")
                    .HasColumnName("active_date");

                entity.Property(e => e.ActiveDateNum).HasColumnName("active_date_num");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("group_name");

                entity.Property(e => e.TerminationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("termination_date");

                entity.Property(e => e.TerminationDateNum).HasColumnName("termination_date_num");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK_Groups_Circulars");
            });

            modelBuilder.Entity<GroupPage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gid).HasColumnName("GID");

                entity.Property(e => e.PageId).HasColumnName("page_id");

                entity.Property(e => e.SortNum).HasColumnName("sort_num");

                entity.HasOne(d => d.GidNavigation)
                    .WithMany(p => p.GroupPages)
                    .HasForeignKey(d => d.Gid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupPages_Groups");
            });

            modelBuilder.Entity<IntegrationSetting>(entity =>
            {
                entity.Property(e => e.CouponExportLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CouponExportUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CouponExportUserPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomField1)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CustomField2)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CustomField3)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CustomField4)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CustomField5)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CustomField6)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DailySalesFileLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DailySalesImportUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DailySalesImportUserPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ScheduleTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InvoicePeriodFrom).HasColumnType("datetime");

                entity.Property(e => e.InvoicePeriodTo).HasColumnType("datetime");

                entity.Property(e => e.Memo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SentToDynamicsOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvoiceCoupon>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Modifieddate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.InvoicePeriodFrom).HasColumnType("datetime");

                entity.Property(e => e.InvoicePeriodTo).HasColumnType("datetime");
            });

            modelBuilder.Entity<JobIntervalType>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LmJobHistory>(entity =>
            {
                entity.ToTable("LM_JOB_HISTORY");

                entity.Property(e => e.LmJobHistoryId).HasColumnName("LM_Job_History_Id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastRunDateTime).HasColumnType("datetime");

                entity.Property(e => e.LogfileUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LmReward>(entity =>
            {
                entity.ToTable("LM_REWARD");

                entity.Property(e => e.LmRewardId).HasColumnName("LM_REWARD_ID");

                entity.Property(e => e.AdditionalDetails)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CouponId).HasColumnName("CouponID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedUserId).HasColumnName("CreatedUserID");

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.Posdetails)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("POSDetails");

                entity.Property(e => e.RewardCouponTypeId).HasColumnName("RewardCouponTypeID");

                entity.Property(e => e.RewardDepartmentId).HasColumnName("RewardDepartmentID");

                entity.Property(e => e.RewardGroupId).HasColumnName("RewardGroupID");

                entity.Property(e => e.RewardMustBeUsedByDate).HasColumnType("datetime");

                entity.Property(e => e.RewardQtyAmountMoney).HasColumnType("money");

                entity.Property(e => e.RewardTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RewardTypeId).HasColumnName("RewardTypeID");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");
            });

            modelBuilder.Entity<LmRewardDepartment>(entity =>
            {
                entity.ToTable("LM_REWARD_DEPARTMENTS");

                entity.Property(e => e.LmrewardDepartmentId).HasColumnName("LMRewardDepartmentID");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.IsExclude)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LmdepartmentExcludeTypeId).HasColumnName("LMDepartmentExcludeTypeID");

                entity.Property(e => e.LmrewardId).HasColumnName("LMRewardId");

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<LmRewardGroup>(entity =>
            {
                entity.ToTable("LM_REWARD_GROUPS");

                entity.HasIndex(e => e.CouponId, "idx_CouponID");

                entity.HasIndex(e => e.LmrewardId, "idx_LMRewardID");

                entity.HasIndex(e => e.RewardGroupId, "idx_RewardGroupID");

                entity.Property(e => e.LmRewardGroupId).HasColumnName("LM_REWARD_GROUP_ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LmrewardId).HasColumnName("LMRewardId");
            });

            modelBuilder.Entity<LmRewardProduct>(entity =>
            {
                entity.ToTable("LM_REWARD_PRODUCT");

                entity.HasIndex(e => e.LmRewardId, "idx_LM_Reward_ID");

                entity.HasIndex(e => e.ProductId, "idx_ProductID");

                entity.HasIndex(e => e.Upc, "idx_UPC");

                entity.Property(e => e.LmRewardProductId).HasColumnName("LM_REWARD_PRODUCT_ID");

                entity.Property(e => e.LmRewardId).HasColumnName("LM_Reward_ID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.RewardProductTypeId).HasColumnName("RewardProductTypeID");

                entity.Property(e => e.Upc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPC");
            });

            modelBuilder.Entity<LmRewardProductType>(entity =>
            {
                entity.HasKey(e => e.RewardProductTypeId);

                entity.ToTable("LM_REWARD_PRODUCT_TYPE");

                entity.Property(e => e.RewardProductTypeId).HasColumnName("RewardProductTypeID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RewardProductType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LmRewardTarget>(entity =>
            {
                entity.ToTable("LM_REWARD_TARGETS");

                entity.Property(e => e.LmrewardTargetId).HasColumnName("LMRewardTargetId");

                entity.Property(e => e.ClubId).HasColumnName("ClubID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedUserId).HasColumnName("CreatedUserID");

                entity.Property(e => e.IsExclude).HasDefaultValueSql("((0))");

                entity.Property(e => e.LmrewardId).HasColumnName("LMRewardId");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedUserId).HasColumnName("ModifiedUserID");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.LmRewardTargets)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK_LM_REWARD_TARGETS_Clubs");

                entity.HasOne(d => d.Lmreward)
                    .WithMany(p => p.LmRewardTargets)
                    .HasForeignKey(d => d.LmrewardId)
                    .HasConstraintName("FK_LM_REWARD_TARGETS_LM_REWARD");
            });

            modelBuilder.Entity<LmRewardTransaction>(entity =>
            {
                entity.HasKey(e => e.LmRewardTransactionsId);

                entity.ToTable("LM_REWARD_TRANSACTIONS");

                entity.Property(e => e.LmRewardTransactionsId).HasColumnName("LM_REWARD_TRANSACTIONS_ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Lmmessage)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("LMMessage");

                entity.Property(e => e.Lmsubject)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LMSubject");

                entity.Property(e => e.MemberNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MessageType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LmRewardType>(entity =>
            {
                entity.ToTable("LM_REWARD_TYPE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ExcludeDepartmentList)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LmRewardUpdateQueue>(entity =>
            {
                entity.HasKey(e => e.RewardUpdateQueueId);

                entity.ToTable("LM_Reward_Update_Queue");

                entity.Property(e => e.RewardUpdateQueueId).HasColumnName("RewardUpdateQueueID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.RewardId).HasColumnName("RewardID");

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<LmUserReward>(entity =>
            {
                entity.ToTable("LM_USER_REWARD");

                entity.HasIndex(e => e.LmrewardId, "idx_LMRewardID");

                entity.HasIndex(e => e.MemberNumber, "idx_MemberNumber");

                entity.HasIndex(e => e.SsnewsId, "idx_SSNewsID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppliedDate).HasColumnType("datetime");

                entity.Property(e => e.LmrewardId).HasColumnName("LMRewardID");

                entity.Property(e => e.MemberNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SsnewsId).HasColumnName("SSNewsID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<MfgCoupon>(entity =>
            {
                entity.ToTable("MFG_COUPONS");

                entity.HasIndex(e => e.CouponOfferId, "idx_CouponOfferID");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CouponImage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsProcessedForNcr).HasColumnName("IsProcessedForNCR");

                entity.Property(e => e.OfferActiveDate).HasColumnType("datetime");

                entity.Property(e => e.OfferDescription).IsUnicode(false);

                entity.Property(e => e.OfferDisclaimer).HasColumnType("text");

                entity.Property(e => e.OfferExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.OfferFeturedText).IsUnicode(false);

                entity.Property(e => e.OfferFinePrint).IsUnicode(false);

                entity.Property(e => e.OfferGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OfferGUID");

                entity.Property(e => e.OfferShutoffDate).HasColumnType("datetime");

                entity.Property(e => e.OfferSummary)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OfferType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OfferUpdateDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfferValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SsnewsId).HasColumnName("SSNewsId");

                entity.Property(e => e.Upc)
                    .HasColumnType("text")
                    .HasColumnName("UPC");
            });

            modelBuilder.Entity<MfgCouponsHold>(entity =>
            {
                entity.HasKey(e => e.MfgCouponHoldId);

                entity.ToTable("MFG_COUPONS_HOLD");

                entity.Property(e => e.MfgCouponHoldId).HasColumnName("MfgCouponHoldID");

                entity.Property(e => e.Comments).HasColumnType("text");

                entity.Property(e => e.CouponOfferId).HasColumnName("CouponOfferID");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.HoldDate).HasColumnType("datetime");

                entity.Property(e => e.ManucaturerCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacturerId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ManufacturerID");

                entity.Property(e => e.NchclearingHouseId).HasColumnName("NCHClearingHouseID");

                entity.Property(e => e.ResolutionComments).HasColumnType("text");

                entity.Property(e => e.ResolvedByUserId).HasColumnName("ResolvedByUserID");

                entity.Property(e => e.SsnewsId).HasColumnName("SSNewsID");

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<MfgCouponsHoldStore>(entity =>
            {
                entity.HasKey(e => e.MfgCouponHoldStoreId);

                entity.ToTable("MFG_COUPONS_HOLD_STORES");

                entity.Property(e => e.MfgCouponHoldStoreId).HasColumnName("MfgCouponHoldStoreID");

                entity.Property(e => e.CouponOfferId).HasColumnName("CouponOfferID");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.MfgCouponHoldId).HasColumnName("MfgCouponHoldID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<MfgCouponsUpdateQueue>(entity =>
            {
                entity.HasKey(e => e.MfgcouponUpdateQueueId);

                entity.ToTable("MFG_COUPONS_UpdateQueue");

                entity.HasIndex(e => e.OfferId, "idx_OfferID");

                entity.Property(e => e.MfgcouponUpdateQueueId).HasColumnName("MFGCouponUpdateQueueId");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.OfferIdGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OfferIdGUID");
            });

            modelBuilder.Entity<MyCart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK_MyCartInfo");

                entity.ToTable("MyCart");

                entity.HasIndex(e => e.OfferId, "idx_OfferID");

                entity.HasIndex(e => e.UserId, "idx_UserID");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.RedeemOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<MyCartProduct>(entity =>
            {
                entity.ToTable("MyCart_Products");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserAddedItem)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NewsCategory>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NewsItem>(entity =>
            {
                entity.ToTable("News_Items");

                entity.Property(e => e.NewsItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("NewsItemID");

                entity.Property(e => e.CreateDatetime).HasColumnType("smalldatetime");

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.NewsItemCategoryId).HasColumnName("NewsItemCategoryID");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ValidFrom).HasColumnType("smalldatetime");

                entity.Property(e => e.ValidTo).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<NewsItemCategory>(entity =>
            {
                entity.ToTable("News_Item_Categories");

                entity.Property(e => e.NewsItemCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("NewsItemCategoryID");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<NewsTarget>(entity =>
            {
                entity.HasIndex(e => e.ClubId, "idx_ClubID");

                entity.HasIndex(e => e.NewsId, "idx_NewsID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedUserId).HasColumnName("CreatedUserID");

                entity.Property(e => e.IsExclude).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedUserId).HasColumnName("ModifiedUserID");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.NewsTargets)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK_NewsTargets_Clubs");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.NewsTargets)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK_NewsTargets_SSNews");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.ImageFull)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("image_full");

                entity.Property(e => e.ImageMid)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("image_mid");

                entity.Property(e => e.ImageThumb)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("image_thumb");

                entity.Property(e => e.PageId).HasColumnName("page_id");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Pages)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK_Pages_Circulars");
            });

            modelBuilder.Entity<PageItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdItemId).HasColumnName("ad_item_id");

                entity.Property(e => e.DealDetails)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("deal_details");

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("department_id");

                entity.Property(e => e.DepartmentIdInt).HasColumnName("department_id_int");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.ItemImage)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("item_image");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("item_name");

                entity.Property(e => e.ItemPrice)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("item_price");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.RecipeImage)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("recipe_image");

                entity.Property(e => e.RecipeMoreKeyword)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("recipe_more_keyword");

                entity.Property(e => e.RecipeName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("recipe_name");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.PageItems)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK_PageItems_Pages");
            });

            modelBuilder.Entity<PaymentTerm>(entity =>
            {
                entity.HasKey(e => e.PaymentTermsId);

                entity.Property(e => e.PaymentTermDescription)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Possoftware>(entity =>
            {
                entity.ToTable("POSSoftwares");

                entity.Property(e => e.PossoftwareId).HasColumnName("POSSoftwareId");

                entity.Property(e => e.PosvendorId).HasColumnName("POSVendorId");

                entity.Property(e => e.SoftwareName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Posvendor>(entity =>
            {
                entity.ToTable("POSVendors");

                entity.Property(e => e.PosvendorId).HasColumnName("POSVendorId");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.ProductCode, "IX_Product");

                entity.HasIndex(e => e.ProductCategoryId, "idx_ProductCategoryId");

                entity.HasIndex(e => e.ProductCode, "idx_ProductCode");

                entity.Property(e => e.BarCodeImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BarCodeValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductImage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Sku)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .HasConstraintName("FK_Product_Company");
            });

            modelBuilder.Entity<Product1>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("Products");

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Product1s)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_ProductCategories");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasIndex(e => e.ClientDepartmentId, "idx_ClientDepartmentID");

                entity.HasIndex(e => e.MajorDepartmentId, "idx_MajorDepartmentID");

                entity.Property(e => e.ClientDepartmentId).HasColumnName("ClientDepartmentID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DefaultProductId).HasColumnName("DefaultProductID");

                entity.Property(e => e.MajorDepartmentId).HasColumnName("MajorDepartmentID");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductCategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductImport>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.SellingUnitId, "ci_azure_fixup_dbo_ProductImports")
                    .IsClustered();

                entity.Property(e => e.BarCodeImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BarCodeValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Sku)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKU");
            });

            modelBuilder.Entity<ProductMajorCategory>(entity =>
            {
                entity.ToTable("Product_Major_Categories");

                entity.HasIndex(e => e.ClientMajorDepartmentId, "idx_ClientMajorDepartmentID");

                entity.Property(e => e.ProductMajorCategoryId).HasColumnName("ProductMajorCategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientMajorDepartmentId).HasColumnName("ClientMajorDepartmentID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.DepartmentImageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductsTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PRODUCTS_Test");

                entity.Property(e => e.ClientDepartmentId).HasColumnName("ClientDepartmentID");

                entity.Property(e => e.ProductCategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Upc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPC");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("Promotion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiscountPercentageCount).HasColumnType("money");

                entity.Property(e => e.NcrpromotionCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NCRPromotionCode");

                entity.Property(e => e.NcrpromotionCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("NCRPromotionCreatedDate");

                entity.Property(e => e.PromotionId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PushNotificationsQueue>(entity =>
            {
                entity.ToTable("PushNotificationsQueue");

                entity.Property(e => e.AndriodNotificationDate).HasColumnType("datetime");

                entity.Property(e => e.AndriodNotificationSent).HasColumnName("andriodNotificationSent");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IPhoneNotificationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("iPhoneNotificationDate");

                entity.Property(e => e.IPhoneNotificationSent).HasColumnName("iPhoneNotificationSent");

                entity.Property(e => e.PickUpControlNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QualifyingProduct>(entity =>
            {
                entity.Property(e => e.DirectiveId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Redemption>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.BasketId, "idx_BasketID");

                entity.HasIndex(e => e.PromotionId, "idx_PromotionID");

                entity.HasIndex(e => e.RedemptionId, "idx_RedemptionID");

                entity.HasIndex(e => e.UserId, "idx_UserID");

                entity.Property(e => e.BasketId).HasColumnName("BasketID");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CostAmount).HasColumnType("money");

                entity.Property(e => e.PromotionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PromotionID");

                entity.Property(e => e.RedeemAmount).HasColumnType("money");

                entity.Property(e => e.RedemptionDate).HasColumnType("datetime");

                entity.Property(e => e.RedemptionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RedemptionID");

                entity.Property(e => e.SaleAmount).HasColumnType("money");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.TransactionDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Upc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPC");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserStoreId).HasColumnName("UserStoreID");
            });

            modelBuilder.Entity<RedemptionDataJson>(entity =>
            {
                entity.HasKey(e => e.RedeemOfferJsonId)
                    .HasName("PK_RedemptionData_JSON1");

                entity.ToTable("RedemptionData_JSON");

                entity.Property(e => e.CouponOfferGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CouponOfferGUID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RedemptionJson).HasColumnType("text");
            });

            modelBuilder.Entity<RedemptionDistribution>(entity =>
            {
                entity.ToTable("RedemptionDistribution");

                entity.HasIndex(e => e.MemberNumber, "idx_MemberNumber");

                entity.HasIndex(e => e.PromotionId, "idx_PromotionID");

                entity.HasIndex(e => e.RedemptionDate, "idx_RedemptionDate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Customer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DirectiveId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DirectiveType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DistributionOfferAlias)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MemberNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PromotionId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RdjsonId).HasColumnName("RDJsonID");

                entity.Property(e => e.RedeemAmount)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemEnterpriseId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RedemptionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RedemptionDistributionJson>(entity =>
            {
                entity.HasKey(e => e.RdjsonId);

                entity.ToTable("RedemptionDistribution_JSON");

                entity.Property(e => e.RdjsonId).HasColumnName("RDJsonID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Rdstatus).HasColumnName("RDStatus");

                entity.Property(e => e.RedemptionJson).HasColumnType("text");
            });

            modelBuilder.Entity<RsaTransactionHistory>(entity =>
            {
                entity.HasKey(e => e.TransactionHistoryId);

                entity.ToTable("RSA_Transaction_History");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Json).IsUnicode(false);

                entity.Property(e => e.RewardId).HasColumnName("RewardID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VersionId).HasColumnName("VersionID");
            });

            modelBuilder.Entity<SalesHeader>(entity =>
            {
                entity.ToTable("SalesHeader");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MemberNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionAmount)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SalesHeaderDetail>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NcrpromotionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NCRPromotionId");

                entity.Property(e => e.ProductUpc)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalesQualifyingProduct>(entity =>
            {
                entity.ToTable("SalesQualifyingProduct");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfferItemType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemSno).HasColumnName("RedeemSNO");

                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalesRedeem>(entity =>
            {
                entity.HasKey(e => e.RedeemSno);

                entity.ToTable("SalesRedeem");

                entity.Property(e => e.RedeemSno).HasColumnName("RedeemSNO");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Customer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OneTimeRedeemCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PromotionId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PromotionName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemAmount)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemDateTime).HasColumnType("datetime");

                entity.Property(e => e.RedeemEnterpriseId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemLaneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemStoreNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemTransactionNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalesReward>(entity =>
            {
                entity.HasKey(e => e.RewardNo)
                    .HasName("PK_SalesRewards");

                entity.ToTable("SalesReward");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfferItemType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RedeemSno).HasColumnName("RedeemSNO");

                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SelectedProductIdForWeeklySpecial>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SpecialPrice)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.News)
                    .WithMany(p => p.SelectedProductIdForWeeklySpecials)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK_SelectedProductIdForWeeklySpecials_SSNews");
            });

            modelBuilder.Entity<SelectedStoresForCoupon>(entity =>
            {
                entity.HasIndex(e => e.NewsId, "idx_NewsID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EnterpriseId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StoreRouteId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SelectedStoresForIntelligentCoupon>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EnterpriseId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StoreRouteId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SellingUnit>(entity =>
            {
                entity.Property(e => e.SellingUnits)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ssnews>(entity =>
            {
                entity.HasKey(e => e.NewsId);

                entity.ToTable("SSNews");

                entity.HasIndex(e => e.ExpiresOn, "idx_ExpiresOn");

                entity.HasIndex(e => e.MfgShutOffDate, "idx_MfgShutOffDate");

                entity.HasIndex(e => e.ValidFromDate, "idx_ValidFromDate");

                entity.Property(e => e.NewsId).HasColumnName("NewsID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CouponCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CouponLimit).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Details).IsUnicode(false);

                entity.Property(e => e.DiscountAmount).HasColumnType("money");

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.JsonPageId).HasDefaultValueSql("((0))");

                entity.Property(e => e.MfgShutOffDate).HasColumnType("datetime");

                entity.Property(e => e.NcrpromotionCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NCRPromotionCode");

                entity.Property(e => e.NcrpromotionCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("NCRPromotionCreatedDate");

                entity.Property(e => e.NewsCategoryId).HasColumnName("NewsCategoryID");

                entity.Property(e => e.NewsStatusId)
                    .HasColumnName("NewsStatusID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OtherDetails)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Puicode)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PUICode");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.Property(e => e.ValidFromDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SsnewsDepartment>(entity =>
            {
                entity.ToTable("SSNews_Departments");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsMajorDepartment).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.SsnewsDepartments)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK_SSNews_Departments_SSNews");
            });

            modelBuilder.Entity<SsnewsNcrpromotion>(entity =>
            {
                entity.ToTable("SSNews_NCRPromotions");

                entity.HasIndex(e => e.NcrpromotionId, "idx_NCRPromotionID");

                entity.HasIndex(e => e.SsnewsId, "idx_SSNewsID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EnterpriseId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NcrpromotionId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NCRPromotionId");

                entity.Property(e => e.SsnewsId).HasColumnName("SSNewsId");
            });

            modelBuilder.Entity<SsnewsProduct>(entity =>
            {
                entity.ToTable("SSNews_Products");

                entity.HasIndex(e => e.NewsId, "idx_NewsID");

                entity.HasIndex(e => e.ProductId, "idx_ProductID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CouponProductTypeId)
                    .HasColumnName("CouponProductTypeID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.NewsId).HasColumnName("NewsID");
            });

            modelBuilder.Entity<SsnewsProductsDeleted>(entity =>
            {
                entity.ToTable("SSNews_Products_Deleted");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.NewsId).HasColumnName("NewsID");
            });

            modelBuilder.Entity<SsnewsRecurring>(entity =>
            {
                entity.HasKey(e => e.RecurringId);

                entity.ToTable("SSNewsRecurrings");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RecurringEndDate).HasColumnType("datetime");

                entity.Property(e => e.RecurringStartDate).HasColumnType("datetime");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.SsnewsRecurrings)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK_SSNewsRecurrings_SSNewsRecurrings");
            });

            modelBuilder.Entity<SsnewsUserFavoritesDetail>(entity =>
            {
                entity.HasKey(e => e.UserFavoriteListDetailsId);

                entity.ToTable("SSNews_UserFavorites_Details");

                entity.Property(e => e.UserFavoriteListDetailsId).HasColumnName("UserFavoriteListDetailsID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.NewsId).HasColumnName("NewsID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserFavoriteListId).HasColumnName("UserFavoriteListID");
            });

            modelBuilder.Entity<SsnewsUserFavoritesList>(entity =>
            {
                entity.HasKey(e => e.UserFavoriteListId);

                entity.ToTable("SSNews_UserFavorites_List");

                entity.Property(e => e.UserFavoriteListId).HasColumnName("UserFavoriteListID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SsnewsUsersNcrimpression>(entity =>
            {
                entity.HasKey(e => e.NcrimpressionId);

                entity.ToTable("SSNewsUsersNCRImpressions");

                entity.HasIndex(e => e.NewsId, "idx_NewsID");

                entity.HasIndex(e => e.UserId, "idx_UserID");

                entity.Property(e => e.NcrimpressionId).HasColumnName("NCRImpressionId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.NcrimpressionCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NCRImpressionCode");

                entity.Property(e => e.NcrimpressionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("NCRImpressionDate");
            });

            modelBuilder.Entity<SsnewsUsersRedeem>(entity =>
            {
                entity.ToTable("SSNewsUsersRedeem");

                entity.HasIndex(e => e.NewsId, "idx_NewsID");

                entity.HasIndex(e => e.UserId, "idx_UserID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.RedeemOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.StateName).HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("states$FK_states_Country");
            });

            modelBuilder.Entity<StoreCouponsUpdatequeue>(entity =>
            {
                entity.HasKey(e => e.StoreCouponUpdateQueueId)
                    .HasName("PK_STORE_COUPONS_UpdateQueue");

                entity.ToTable("STORE_COUPONS_UPDATEQUEUE");

                entity.Property(e => e.StoreCouponUpdateQueueId).HasColumnName("StoreCouponUpdateQueueID");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.Isprocessed).HasDefaultValueSql("((0))");

                entity.Property(e => e.OfferId).HasColumnName("OfferID");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SubDepartmentName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TimeZone>(entity =>
            {
                entity.HasKey(e => e.TimeZoneId)
                    .HasName("PK_timezones_TimeZoneId");

                entity.Property(e => e.BaseUtcOffSet)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DaylightName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IphoneTimeZoneName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.StandardName)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAdminStore>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAdminStores)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserAdminStores_UserDetails");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasIndex(e => e.BarCodeValue, "idx_BarcodeValue");

                entity.HasIndex(e => e.IsDeleted, "idx_IsDeleted");

                entity.HasIndex(e => e.SignUpDate, "idx_SignUpDate");

                entity.Property(e => e.AlternateMemberNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BarCodeImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BarCodeValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomField1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomField2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NewTermsAcceptanceRequired).HasDefaultValueSql("((1))");

                entity.Property(e => e.QrcodeImage)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QRCodeImage");

                entity.Property(e => e.QrcodeValue)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QRCodeValue");

                entity.Property(e => e.Qtoken)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QToken");

                entity.Property(e => e.SignUpDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.XCustomerCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("xCustomerCode");

                entity.Property(e => e.XUserId).HasColumnName("xUserId");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserDevice>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserDeviceInfo>(entity =>
            {
                entity.ToTable("UserDeviceInfo");

                entity.HasIndex(e => e.UserId, "idx_UserID");

                entity.Property(e => e.UserDeviceInfoId).HasColumnName("UserDeviceInfoID");

                entity.Property(e => e.Awsarn)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("AWSARN");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceInfo)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserProductUsage>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserProf__1788CC4C18981236");

                entity.ToTable("UserProfile");

                entity.HasIndex(e => e.UserName, "UQ__UserProf__C9F28456AE5E6A6D")
                    .IsUnique();

                entity.Property(e => e.UserName).HasMaxLength(56);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "WebpagesUsersInRole",
                        l => l.HasOne<WebpagesRole>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_RoleId"),
                        r => r.HasOne<UserProfile>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK__webpages__AF2760AD844932F8");

                            j.ToTable("webpages_UsersInRoles");
                        });
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.Property(e => e.UserStatusDesc).HasMaxLength(40);
            });

            modelBuilder.Entity<UserTermsAcceptance>(entity =>
            {
                entity.Property(e => e.AcceptDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeviceId).HasColumnName("DeviceID");

                entity.Property(e => e.DeviceInfo)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasIndex(e => e.LoginToken, "idx_LoginToken");

                entity.HasIndex(e => e.UserId, "idx_UserID");

                entity.Property(e => e.DeviceInfo).HasMaxLength(500);

                entity.Property(e => e.DeviceRegistrationId).HasMaxLength(500);

                entity.Property(e => e.LastAccessed).HasPrecision(0);

                entity.Property(e => e.LoginToken).HasMaxLength(45);

                entity.Property(e => e.MobileModel).HasMaxLength(45);

                entity.Property(e => e.MobileOs)
                    .HasMaxLength(45)
                    .HasColumnName("MobileOS");

                entity.Property(e => e.MobileOsversion)
                    .HasMaxLength(45)
                    .HasColumnName("MobileOSVersion");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserType1)
                    .HasMaxLength(100)
                    .HasColumnName("UserType");
            });

            modelBuilder.Entity<UsersCouponsRedeem>(entity =>
            {
                entity.ToTable("UsersCouponsRedeem");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.RedeemOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ViewCustomGetClubUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEW_CUSTOM_GET_CLUB_USERS");

                entity.Property(e => e.Clubid).HasColumnName("CLUBID");

                entity.Property(e => e.Clubname)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("CLUBNAME");

                entity.Property(e => e.Userid).HasColumnName("USERID");
            });

            modelBuilder.Entity<ViewCustomUserDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEW_CUSTOM_USER_DETAILS");

                entity.Property(e => e.Barcodevalue)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BARCODEVALUE");

                entity.Property(e => e.Clientstoreid).HasColumnName("CLIENTSTOREID");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE");

                entity.Property(e => e.Name)
                    .HasMaxLength(66)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Roleid).HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(256)
                    .HasColumnName("ROLENAME");

                entity.Property(e => e.Userdetailid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERDETAILID");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Usertype)
                    .HasMaxLength(100)
                    .HasColumnName("USERTYPE");

                entity.Property(e => e.Usertypeid).HasColumnName("USERTYPEID");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ZIPCODE");
            });

            modelBuilder.Entity<VwAspnetApplication>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_Applications");

                entity.Property(e => e.ApplicationName).HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetMembershipUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_MembershipUsers");

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredEmail).HasMaxLength(256);

                entity.Property(e => e.MobileAlias).HasMaxLength(16);

                entity.Property(e => e.MobilePin)
                    .HasMaxLength(16)
                    .HasColumnName("MobilePIN");

                entity.Property(e => e.PasswordAnswer).HasMaxLength(128);

                entity.Property(e => e.PasswordQuestion).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_Profiles");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VwAspnetRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_Roles");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredRoleName).HasMaxLength(256);

                entity.Property(e => e.RoleName).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_Users");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredUserName).HasMaxLength(256);

                entity.Property(e => e.MobileAlias).HasMaxLength(16);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetUsersInRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_UsersInRoles");
            });

            modelBuilder.Entity<VwAspnetWebPartStatePath>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_WebPartState_Paths");

                entity.Property(e => e.LoweredPath).HasMaxLength(256);

                entity.Property(e => e.Path).HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetWebPartStateShared>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_WebPartState_Shared");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VwAspnetWebPartStateUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_WebPartState_User");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VwBasketCouponItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_BasketCouponItem");

                entity.Property(e => e.BasketCouponPromotionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BasketCouponPromotionID");

                entity.Property(e => e.BasketDataId).HasColumnName("BasketDataID");

                entity.Property(e => e.BasketItemId).HasColumnName("BasketItemID");

                entity.Property(e => e.BasktcouponUpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("basktcouponUPC");

                entity.Property(e => e.DiscountAmount).HasColumnType("money");

                entity.Property(e => e.ItemUpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ItemUPC");
            });

            modelBuilder.Entity<VwRedemptionBasketItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_RedemptionBasketItems");

                entity.Property(e => e.BasketGuid).HasColumnName("BasketGUID");

                entity.Property(e => e.ClearingRecordId).HasColumnName("ClearingRecordID");

                entity.Property(e => e.ClearingStatusId).HasColumnName("ClearingStatusID");

                entity.Property(e => e.CouponOfferId).HasColumnName("CouponOfferID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GlobalStoreId).HasColumnName("GlobalStoreID");

                entity.Property(e => e.IdType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsUpcsplitComplete).HasColumnName("IsUPCSplitComplete");

                entity.Property(e => e.MemberNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfferGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OfferGUID");

                entity.Property(e => e.Posid).HasColumnName("POSId");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.RedeemId).HasColumnName("RedeemID");

                entity.Property(e => e.Retailer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RetailerId).HasColumnName("RetailerID");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.Property(e => e.TransactionTenderType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Upc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPC");
            });

            modelBuilder.Entity<VwTestView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_TestView");

                entity.Property(e => e.BasketCouponPromotionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BasketCouponPromotionID");

                entity.Property(e => e.BasketDataId).HasColumnName("BasketDataID");

                entity.Property(e => e.BasketItemId).HasColumnName("BasketItemID");

                entity.Property(e => e.BasktcouponUpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("basktcouponUPC");

                entity.Property(e => e.DiscountAmount).HasColumnType("money");

                entity.Property(e => e.ItemUpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ItemUPC");
            });

            modelBuilder.Entity<WebDepartment>(entity =>
            {
                entity.ToTable("Web_Departments");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.WebDepartmentImage)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.WebDepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WebMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("WebMenu");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WebpagesMembership>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__webpages__1788CC4C9E755382");

                entity.ToTable("webpages_Membership");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.ConfirmationToken).HasMaxLength(128);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.IsConfirmed).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastPasswordFailureDate).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(128);

                entity.Property(e => e.PasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordSalt).HasMaxLength(128);

                entity.Property(e => e.PasswordVerificationToken).HasMaxLength(128);

                entity.Property(e => e.PasswordVerificationTokenExpirationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<WebpagesOauthMembership>(entity =>
            {
                entity.HasKey(e => new { e.Provider, e.ProviderUserId })
                    .HasName("PK__webpages__F53FC0EDB9564D6E");

                entity.ToTable("webpages_OAuthMembership");

                entity.Property(e => e.Provider).HasMaxLength(30);

                entity.Property(e => e.ProviderUserId).HasMaxLength(100);
            });

            modelBuilder.Entity<WebpagesRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__webpages__8AFACE1A56104F40");

                entity.ToTable("webpages_Roles");

                entity.HasIndex(e => e.RoleName, "UQ__webpages__8A2B61606445AAC5")
                    .IsUnique();

                entity.Property(e => e.RoleName).HasMaxLength(256);
            });

            modelBuilder.Entity<WeeklyAddPdf>(entity =>
            {
                entity.HasKey(e => e.WeeklyAdPdfId);

                entity.ToTable("WeeklyAddPDF");

                entity.Property(e => e.WeeklyAdPdfId).HasColumnName("WeeklyAdPdfID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Expireson).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PdfFileName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.ValidFromDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<WeeklySpecialImport>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OfferDetails)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Upc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPC");

                entity.Property(e => e.ValidFromDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<WeeklySpecialsExtension>(entity =>
            {
                entity.HasKey(e => e.ExtensionId);

                entity.ToTable("WeeklySpecialsExtension");

                entity.HasIndex(e => e.NewsId, "idx_NewsID");

                entity.Property(e => e.ExtensionId).HasColumnName("ExtensionID");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.NewsId).HasColumnName("NewsID");

                entity.Property(e => e.SpecialPrice)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.WeeklySpecialsExtensions)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK_WeeklySpecialExtension_SSNews");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
