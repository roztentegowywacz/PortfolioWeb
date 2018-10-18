using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public List<ProjectTechnologyTag> GetAllPTT()
        {
            return _ctx.ProjectTechnologyTags.ToList();
        }

        public void AddPTT(ProjectTechnologyTag projectTechnologyTag)
        {
            _ctx.ProjectTechnologyTags.Add(projectTechnologyTag);
        }

        public ProjectTechnologyTag GetPTT(int projectId, int tagId)
        {
            return _ctx.ProjectTechnologyTags.FirstOrDefault(x => x.ProjectID == projectId && x.TechnologyTagID == tagId);
        }

        public void RemovePTT(int projectId, int tagId)
        {
            _ctx.ProjectTechnologyTags.Remove(GetPTT(projectId, tagId));
        }
    }
}