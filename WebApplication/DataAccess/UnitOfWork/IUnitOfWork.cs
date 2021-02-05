using System.Threading.Tasks;
using ApplicationModel.Models;
using WebApplication.DataAccess.Repositories;

namespace WebApplication.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Playlist> PlaylistRepository { get; }
        IRepository<Track> TrackRepository { get; }
        
        Task ApplyChangesAsync();
    }
}