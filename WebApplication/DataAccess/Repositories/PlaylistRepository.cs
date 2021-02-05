using ApplicationModel.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.DataAccess.Repositories
{
    public class PlaylistRepository : RepositoryBase<Playlist>
    {
        public PlaylistRepository(DbContext context) : base(context)
        {
        }
    }
}