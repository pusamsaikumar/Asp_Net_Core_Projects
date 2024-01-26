using IdentityMemberMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityMemberMVC.Data
{
    // public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options) : base(options) 
        { 
        }
    }
}
