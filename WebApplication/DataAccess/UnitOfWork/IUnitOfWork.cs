using System.Threading.Tasks;

namespace WebApplication.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task ApplyChangesAsync();
    }
}