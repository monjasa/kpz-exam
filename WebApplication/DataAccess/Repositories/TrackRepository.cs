using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApplication.DataAccess.Repositories
{
    public class TrackRepository : RepositoryBase, ITrackRepository
    {
        public TrackRepository(MusicContext context) : base(context)
        {
        }

        public async Task<Track> FindAsync(int id)
        {
            return await _context.Tracks.FindAsync(id);
        }

        public async Task<IEnumerable<Track>> ListAsync()
        {
            return await _context.Tracks
                .Include(track => track.Playlist)
                .ToListAsync();
        }

        public async Task<EntityEntry<Track>> SaveAsync(Track track)
        {
            return await _context.Tracks.AddAsync(track);
        }

        public EntityEntry<Track> Update(Track track)
        {
            return _context.Tracks.Update(track);
        }

        public EntityEntry<Track> Remove(Track track)
        {
            return _context.Tracks.Remove(track);
        }
    }
}