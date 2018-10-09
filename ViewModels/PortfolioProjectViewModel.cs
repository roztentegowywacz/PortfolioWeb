using Microsoft.AspNetCore.Http;

namespace PortfolioWeb.ViewModels
{
    public class PortfolioProjectViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";
        public string Summary { get; set; } = "";
        public string Body { get; set; } = "";
        public IFormFile Image { get; set; } = null;
        public bool IsCommercial { get; set; } = false;
        public bool IsWebProject { get; set; } = true;
    }
}