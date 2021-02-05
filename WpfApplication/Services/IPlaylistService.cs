using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;

namespace WpfApplication.Services
{
    public interface IPlaylistService
    {
        Task<Playlist> GetPlaylistByIdAsync(int id);
        Task<IEnumerable<Playlist>> GetPlaylistsAsync();
    }
}