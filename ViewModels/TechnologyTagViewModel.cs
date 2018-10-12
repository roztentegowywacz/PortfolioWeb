using System.ComponentModel.DataAnnotations;

namespace PortfolioWeb.ViewModels
{
    public class TechnologyTagViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "CSS class name from Devicon")]
        public string CssClassName { get; set; }
    }
}