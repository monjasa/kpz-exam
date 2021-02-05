using System.Threading.Tasks;
using ApplicationModel.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication.DataAccess.Repositories;

namespace WebApplication.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        
        private IRepository<Playlist> _playlistRepository;
        private IRepository<Track> _trackRepository;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IRepository<Playlist> PlaylistRepository
        {
            get
            {
                return _playlistRepository ??= new PlaylistRepository(_context); 
            }
        }

        public IRepository<Track> TrackRepository
        {
            get
            {
                return _trackRepository ??= new TrackRepository(_context); 
            }
        }

        public async Task ApplyChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}