using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApplication.DataAccess.Repositories
{
    public class PlaylistRepository : RepositoryBase, IPlaylistRepository
    {
        public PlaylistRepository(MusicContext context) : base(context)
        {
        }

        public async Task<Playlist> FindAsync(int id)
        {
            return await _context.Playlists.FindAsync(id);
        }

        public async Task<IEnumerable<Playlist>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<EntityEntry<Playlist>> SaveAsync(Playlist playlist)
        {
            return await _context.Playlists.AddAsync(playlist);
        }

        public EntityEntry<Playlist> Update(Playlist playlist)
        {
            throw new System.NotImplementedException();
        }

        public EntityEntry<Playlist> Remove(Playlist playlist)
        {
            throw new System.NotImplementedException();
        }
    }
}