using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;
using WebApplication.DataAccess.Repositories;
using WebApplication.DataAccess.UnitOfWork;

namespace WebApplication.Services
{
    public class TrackService : ITrackService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Track> GetTrackByIdAsync(int id)
        {
            return await _unitOfWork.TrackRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Track>> GetAllTracksAsync()
        {
            return await _unitOfWork.TrackRepository.ListAsync();
        }

        public async Task<Track> CreateTrackAsync(Track track)
        {
            var trackEntry = await _unitOfWork.TrackRepository.SaveAsync(track);
            await _unitOfWork.ApplyChangesAsync();

            return trackEntry.Entity;
        }

        public async Task<Track> UpdateTrackAsync(Track trackToUpdate, Track track)
        {
            var playlist = await _unitOfWork.PlaylistRepository.FindAsync(track.PlaylistId);
            
            trackToUpdate.Title = track.Title;
            trackToUpdate.FilePath = track.FilePath;
            trackToUpdate.Playlist = playlist;
            trackToUpdate.PlaylistId = track.PlaylistId;

            var updatedTrack = _unitOfWork.TrackRepository.Update(trackToUpdate);
            await _unitOfWork.ApplyChangesAsync();

            return updatedTrack.Entity;
        }

        public async Task<Track> DeleteTrackAsync(Track track)
        {
            var trackEntry = _unitOfWork.TrackRepository.Remove(track);
            await _unitOfWork.ApplyChangesAsync();

            return trackEntry.Entity;
        }
    }
}