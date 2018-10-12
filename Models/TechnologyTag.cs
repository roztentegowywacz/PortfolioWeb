using System.ComponentModel.DataAnnotations;

namespace PortfolioWeb.Models
{
    public class TechnologyTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CssClassName { get; set; }

        // [Required]
        // public DevelopTechnologyTagType Type { get; set; }
    }
}

// namespace PortfolioWeb.Models
// {
//     public enum DevelopTechnologyTagType
//     {
//         Frontend, Backend, Tools, Deployment
//     }
// }