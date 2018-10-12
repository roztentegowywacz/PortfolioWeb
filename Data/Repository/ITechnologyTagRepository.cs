using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioWeb.Models;

namespace PortfolioWeb.Data.Repository
{
    public interface ITechnologyTagRepository
    {
        TechnologyTag GetTechnologyTag(int id);
        List<TechnologyTag> GetAllTechnologyTags();
        void AddTechnologyTag(TechnologyTag technologyTag);
        void RemoveTechnologyTag(int id);
        void UpdateTechnologyTag(TechnologyTag technologyTag);

        Task<bool> SaveChangesAsync();
    }
}