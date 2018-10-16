using System.Collections.Generic;
using PortfolioWeb.Models;

namespace PortfolioWeb.ViewModels
{
    public class ViewTagViewModel
    {
        public List<ProjectTechnologyTag> AssociatedProjects { get; set; }
        public TechnologyTag TechnologyTag { get; set; }
    }
}