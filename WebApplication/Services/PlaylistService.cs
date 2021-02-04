using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModel.Models;
using WebApplication.DataAccess.Repositories;
using WebApplication.DataAccess.UnitOfWork;

namespace WebApplication.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlaylistService(IPlaylistRepository playlistRepository, IUnitOfWork unitOfWork)
        {
            _playlistRepository = playlistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Playlist> GetPlaylistByIdAsync(int id)
        {
            return await _playlistRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Playlist>> GetAllPlaylistsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Playlist> CreatePlaylistAsync(Playlist playlist)
        {
            var playlistEntry = await _playlistRepository.SaveAsync(playlist);
            await _unitOfWork.ApplyChangesAsync();

            return playlistEntry.Entity;
        }

        public async Task<Playlist> UpdatePlaylistAsync(Playlist playlistToUpdate, Track playlist)
        {
            throw new NotImplementedException();
        }

        public async Task<Playlist> DeletePlaylistAsync(Playlist playlist)
        {
            throw new NotImplementedException();
        }
    }
}