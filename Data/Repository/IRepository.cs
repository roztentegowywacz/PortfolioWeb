using System.Threading.Tasks;

namespace PortfolioWeb.Data.Repository
{
    public interface IRepository
    {
        Task<bool> SaveChangesAsync();
    }
}