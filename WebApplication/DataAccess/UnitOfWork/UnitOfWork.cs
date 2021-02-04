using System.Threading.Tasks;

namespace WebApplication.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicContext _context;

        public UnitOfWork(MusicContext context)
        {
            _context = context;
        }

        public async Task ApplyChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}