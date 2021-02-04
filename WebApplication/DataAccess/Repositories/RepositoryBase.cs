namespace WebApplication.DataAccess.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly MusicContext _context;

        protected RepositoryBase(MusicContext context)
        {
            _context = context;
        }
    }
}