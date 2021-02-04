using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;

namespace WpfApplication.Services
{
    public interface ITrackService
    {
        Task<IEnumerable<Track>> GetTracksAsync();
        Task<Track> CreateTrackAsync(Track track);
        Task DeleteTrackAsync(int id);
    }
}