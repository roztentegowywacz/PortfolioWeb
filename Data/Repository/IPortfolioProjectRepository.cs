using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioWeb.Models;

namespace PortfolioWeb.Data.Repository
{
    public interface IPortfolioProjectRepository
    {
        PortfolioProject GetPortfolioProject(int id);
        List<PortfolioProject> GetAllPortfolioProjects();
        void AddPortfolioProject(PortfolioProject portfolioProject);
        void RemovePortfolioProject(int id);
        void UpdatePortfolioProject(PortfolioProject portfolioProject);

        Task<bool> SaveChangesAsync();
    }
}