using ApplicationModel.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.DataAccess
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {
        }

        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>()
                .ToTable("Track");
        }
    }
}