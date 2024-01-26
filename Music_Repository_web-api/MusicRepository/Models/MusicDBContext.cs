using Microsoft.EntityFrameworkCore;

namespace MusicRepository.Models
{
    public class MusicDBContext : DbContext
    {
        public MusicDBContext(DbContextOptions<MusicDBContext>options)  : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Music> Music { get; set; }
    }
}
