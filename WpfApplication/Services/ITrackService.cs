using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;

namespace WpfApplication.Services
{
    public interface ITrackService
    {
        Task<Track> GetTrackByIdAsync(int id);
        Task<IEnumerable<Track>> GetTracksAsync();
        Task<Track> CreateTrackAsync(Track track);
        Task DeleteTrackAsync(int id);
    }
}