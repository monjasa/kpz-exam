using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;
using WebApplication.DataAccess.Repositories;
using WebApplication.DataAccess.UnitOfWork;

namespace WebApplication.Services
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TrackService(ITrackRepository trackRepository, IUnitOfWork unitOfWork)
        {
            _trackRepository = trackRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Track> GetTrackByIdAsync(int id)
        {
            return await _trackRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Track>> GetAllTracksAsync()
        {
            return await _trackRepository.ListAsync();
        }

        public async Task<Track> CreateTrackAsync(Track track)
        {
            var trackEntry = await _trackRepository.SaveAsync(track);
            await _unitOfWork.ApplyChangesAsync();

            return trackEntry.Entity;
        }

        public async Task<Track> UpdateTrackAsync(Track trackToUpdate, Track track)
        {
            trackToUpdate.Title = track.Title;
            trackToUpdate.FilePath = track.FilePath;

            var updatedTrack = _trackRepository.Update(trackToUpdate);
            await _unitOfWork.ApplyChangesAsync();

            return updatedTrack.Entity;
        }

        public async Task<Track> DeleteTrackAsync(Track track)
        {
            var trackEntry = _trackRepository.Remove(track);
            await _unitOfWork.ApplyChangesAsync();

            return trackEntry.Entity;
        }
    }
}