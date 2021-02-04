using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;

namespace WebApplication.Services
{
    public interface ITrackService
    {
        Task<Track> GetTrackByIdAsync(int id);
        Task<IEnumerable<Track>> GetAllTracksAsync();
        Task<Track> CreateTrackAsync(Track track);
        Task<Track> UpdateTrackAsync(Track trackToUpdate, Track track);
        Task<Track> DeleteTrackAsync(Track track);
    }
}