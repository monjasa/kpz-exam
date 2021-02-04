using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApplication.DataAccess.Repositories
{
    public interface ITrackRepository
    {
        Task<Track> FindAsync(int id);
        Task<IEnumerable<Track>> ListAsync();
        Task<EntityEntry<Track>> SaveAsync(Track track);
        EntityEntry<Track> Update(Track track);
        EntityEntry<Track> Remove(Track track);
    }
}