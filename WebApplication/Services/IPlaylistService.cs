using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;

namespace WebApplication.Services
{
    public interface IPlaylistService
    {
        Task<Playlist> GetPlaylistByIdAsync(int id);
        Task<IEnumerable<Playlist>> GetAllPlaylistsAsync();
        Task<Playlist> CreatePlaylistAsync(Playlist playlist);
        Task<Playlist> UpdatePlaylistAsync(Playlist playlistToUpdate, Track playlist);
        Task<Playlist> DeletePlaylistAsync(Playlist playlist);
    }
}