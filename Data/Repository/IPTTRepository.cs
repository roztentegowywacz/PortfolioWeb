using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioWeb.Models;

namespace PortfolioWeb.Data.Repository
{
    public interface IPTTRepository
    {
        List<ProjectTechnologyTag> GetAllPTT();
        void AddPTT(ProjectTechnologyTag projectTechnologyTag);
        ProjectTechnologyTag GetPTT(int projectId, int tagId);
        void RemovePTT(int projectId, int tagId);
    }
}