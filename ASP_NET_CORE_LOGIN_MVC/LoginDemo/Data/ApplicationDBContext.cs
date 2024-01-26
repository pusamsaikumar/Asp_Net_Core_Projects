using LoginDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoginDemo.Data
{
    public class ApplicationDBContext  : IdentityDbContext<ApplicationUser>

    {
    

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

       public DbSet<ShopperInfo> ShopperInfos { get; set; }
        public DbSet<RetailersModel> Retailers { get; set; }
        public DbSet<RetailersStoreModel> RetailersStore { get; set;}
        public DbSet<LMGetReward> lMGetRewards { get; set; }
        public DbSet<LoyalityMember> LoyalityMembers { get; set;}
        public DbSet<Table> Basket { get; set; }
        public DbSet<Table1> Redemption { get; set; }
        public DbSet<Table2> OptIns { get; set; }
        public DbSet<Table3> Reward { get; set; }
        public DbSet<Table4> UserRegister { get; set; }
    }
} 
