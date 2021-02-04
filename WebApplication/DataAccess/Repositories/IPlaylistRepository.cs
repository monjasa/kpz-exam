using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApplication.DataAccess.Repositories
{
    public interface IPlaylistRepository
    {
        Task<Playlist> FindAsync(int id);
        Task<IEnumerable<Playlist>> ListAsync();
        Task<EntityEntry<Playlist>> SaveAsync(Playlist playlist);
        EntityEntry<Playlist> Update(Playlist playlist);
        EntityEntry<Playlist> Remove(Playlist playlist);
    }
}