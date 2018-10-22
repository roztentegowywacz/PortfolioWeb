namespace PortfolioWeb.Models
{
    public class PostTechnologyTag
    {
        public int PostID { get; set; }
        public Post Post { get; set; }

        public int TechnologyTagID { get; set; }
        public TechnologyTag TechnologyTag { get; set; }
    }
}