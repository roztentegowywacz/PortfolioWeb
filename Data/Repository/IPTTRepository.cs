using System.Threading.Tasks;
using PortfolioWeb.Models;

namespace PortfolioWeb.Data.Repository
{
    public interface IPTTRepository
    {
        void AddPTT(ProjectTechnologyTag projectTechnologyTag);

        Task<bool> SaveChangesAsync();
    }
}