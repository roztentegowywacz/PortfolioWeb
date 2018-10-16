using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioWeb.Models;

namespace PortfolioWeb.Data.Repository
{
    public class TechnologyRepository : ITechnologyTagRepository
    {
        private AppDbContext _ctx;

        public TechnologyRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddTechnologyTag(TechnologyTag technologyTag)
        {
            _ctx.TechnologyTags.Add(technologyTag);
        }

        public List<TechnologyTag> GetAllTechnologyTags()
        {
            return _ctx.TechnologyTags.ToList();
        }

        public TechnologyTag GetTechnologyTag(int id)
        {
            return _ctx.TechnologyTags.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveTechnologyTag(int id)
        {
            _ctx.TechnologyTags.Remove(GetTechnologyTag(id));
        }

        public void UpdateTechnologyTag(TechnologyTag technologyTag)
        {
            _ctx.TechnologyTags.Update(technologyTag);
        }

        public List<ProjectTechnologyTag> GetAssociatedProjects(int id)
        {
            return _ctx.ProjectTechnologyTags
                .Include(x => x.Project)
                .Where(ptt => ptt.TechnologyTagID == id)
                .ToList();
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