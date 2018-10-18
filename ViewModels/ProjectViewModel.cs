using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using PortfolioWeb.Models;

namespace PortfolioWeb.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";
        public string Summary { get; set; } = "";
        public string Body { get; set; } = "";
        public string CurrentImage { get; set; } = "";
        public IFormFile Image { get; set; } = null;
        public bool IsCommercial { get; set; } = false;
        public bool IsWebProject { get; set; } = true;

        // public List<CheckBoxItem> AvailableTechnologyTags { get; set; }

        public List<TechnologyTag> AvailableTechnologyTags { get; set; }

        public DateTime Created { get; set; }
    }
}