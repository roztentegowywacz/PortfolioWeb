using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWeb.Models
{
    public class TechnologyTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CssClassName { get; set; }

        [NotMapped]
        public bool Selected { get; set; }

        public List<ProjectTechnologyTag> ProjectTechnologyTags { get; set; }
    }
}

// namespace PortfolioWeb.Models
// {
//     public enum DevelopTechnologyTagType
//     {
//         Frontend, Backend, Tools, Deployment
//     }
// }