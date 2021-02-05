using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;
using WebApplication.DataAccess.UnitOfWork;

namespace WebApplication.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlaylistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Playlist> GetPlaylistByIdAsync(int id)
        {
            return await _unitOfWork.PlaylistRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Playlist>> GetAllPlaylistsAsync()
        {
            return await _unitOfWork.PlaylistRepository.ListAsync();
        }

        public async Task<Playlist> CreatePlaylistAsync(Playlist playlist)
        {
            var playlistEntry = await _unitOfWork.PlaylistRepository.SaveAsync(playlist);
            await _unitOfWork.ApplyChangesAsync();

            return playlistEntry.Entity;
        }
    }
}