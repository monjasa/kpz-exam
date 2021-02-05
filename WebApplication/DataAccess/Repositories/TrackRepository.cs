using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.DataAccess.Repositories
{
    public class TrackRepository : RepositoryBase<Track>
    {
        public TrackRepository(DbContext context) : base(context)
        {
        }

        public override async Task<Track> FindAsync(int id)
        {
            return await Context.Set<Track>()
                .Include(track => track.Playlist)
                .SingleAsync(track => track.Id == id);
        }

        public override async Task<IEnumerable<Track>> ListAsync()
        {
            return await Context.Set<Track>()
                .Include(track => track.Playlist)
                .ToListAsync();
        }
    }
}