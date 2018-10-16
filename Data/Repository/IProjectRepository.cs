using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioWeb.Models;

namespace PortfolioWeb.Data.Repository
{
    public interface IProjectRepository
    {
        Project GetProject(int id);
        List<Project> GetAllProjects();
        void AddProject(Project project);
        void RemoveProject(int id);
        void UpdateProject(Project project);

        List<ProjectTechnologyTag> GetAssociatedTechnologyTags(int id);

        Task<bool> SaveChangesAsync();
    }
}