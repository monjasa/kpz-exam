using ApplicationModel.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.DataAccess
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {
        }

        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Playlist>()
                .ToTable("Playlist")
                .HasMany(playlist => playlist.Tracks)
                .WithOne(track => track.Playlist)
                .HasForeignKey(track => track.PlaylistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Playlist>().Property(playlist => playlist.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Playlist>().Property(playlist => playlist.Name).IsRequired();

            modelBuilder.Entity<Track>()
                .ToTable("Track")
                .HasKey(track => track.Id);
            modelBuilder.Entity<Track>().Property(track => track.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Track>().Property(track => track.Title).IsRequired();
            modelBuilder.Entity<Track>().Property(track => track.FilePath).IsRequired();
        }
    }
}