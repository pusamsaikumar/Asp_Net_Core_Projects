using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Webblog.Models;

namespace Webblog.Data
{
    public class IssueDbContext:DbContext
    { 
        public IssueDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
                  
        }

        public DbSet<Issue> Issues { get; set; }


    }
}
