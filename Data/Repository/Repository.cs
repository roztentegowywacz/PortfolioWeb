using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioWeb.Models;

namespace PortfolioWeb.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddPortfolioProject(PortfolioProject portfolioProject)
        {
            _ctx.PortfolioProjects.Add(portfolioProject);
        }

        public List<PortfolioProject> GetAllPortfolioProjects()
        {
            return _ctx.PortfolioProjects.ToList();
        }

        public PortfolioProject GetPortfolioProject(int id)
        {
            return _ctx.PortfolioProjects.FirstOrDefault(x => x.Id == id);
        }

        public void RemovePortfolioProject(int id)
        {
            _ctx.PortfolioProjects.Remove(GetPortfolioProject(id));
        }

        public void UpdatePortfolioProject(PortfolioProject portfolioProject)
        {
            _ctx.PortfolioProjects.Update(portfolioProject);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}