using System.Threading.Tasks;
using PortfolioWeb.Models;

namespace PortfolioWeb.Data.Repository
{
    public class PTTRepository : IPTTRepository
    {
        private AppDbContext _ctx;

        public PTTRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddPTT(ProjectTechnologyTag projectTechnologyTag)
        {
            _ctx.ProjectTechnologyTags.Add(projectTechnologyTag);
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