using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortfolioWeb.Models;

namespace PortfolioWeb.ViewModels
{
    public class AddAssociatedProjectViewModel
    {
        public TechnologyTag TechnologyTag { get; set; }
        public List<SelectListItem> Projects { get; set; }

        public int TechnologyTagId { get; set; }
        public int ProjectId { get; set; }

        public AddAssociatedProjectViewModel() { }

        public AddAssociatedProjectViewModel(TechnologyTag technologyTag, IEnumerable<Project> projects)
        {
            Projects = new List<SelectListItem>();

            foreach (var project in projects)
            {
                Projects.Add(new SelectListItem
                {
                    Value = project.Id.ToString(),
                    Text = project.Title
                });
            }

            TechnologyTag = technologyTag;
        }
    }
}