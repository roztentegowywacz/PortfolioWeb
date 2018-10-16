namespace PortfolioWeb.Models
{
    public class ProjectTechnologyTag
    {
        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public int TechnologyTagID { get; set; }
        public TechnologyTag TechnologyTag { get; set; }
    }
}