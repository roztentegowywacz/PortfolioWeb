using System;

namespace PortfolioWeb.Models
{
    public class PortfolioProject
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";
        public string Summary { get; set; } = "";
        public string Body { get; set; } = "";
        public string Image { get; set; } = "";
        public bool IsCommercial { get; set; } = false;
        public bool IsWebProject { get; set; } = true;

        public DateTime Created { get; set; } = DateTime.Now;
    }
}