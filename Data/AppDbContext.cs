using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioWeb.Models;

namespace PortfolioWeb.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }
        
        public DbSet<PortfolioProject> PortfolioProjects { get; set; }
        public DbSet<TechnologyTag> TechnologyTags { get; set; }
    }
}