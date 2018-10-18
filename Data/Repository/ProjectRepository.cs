using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioWeb.Models;

namespace PortfolioWeb.Data.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private AppDbContext _ctx;

        public ProjectRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddProject(Project project)
        {
            _ctx.Projects.Add(project);
        }

        public List<Project> GetAllProjects()
        {
            return _ctx.Projects.ToList();
        }

        public Project GetProject(int id)
        {
            return _ctx.Projects.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveProject(int id)
        {
            _ctx.Projects.Remove(GetProject(id));
        }

        public void UpdateProject(Project project)
        {
            _ctx.Projects.Update(project);
        }

        public List<ProjectTechnologyTag> GetAssociatedTechnologyTags(int id)
        {
            return _ctx.ProjectTechnologyTags.Include(x => x.TechnologyTag).Where(x => x.ProjectID == id).ToList();           
        }
    }
}