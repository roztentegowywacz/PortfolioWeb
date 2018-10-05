using Microsoft.EntityFrameworkCore;
using PortfolioWeb.Models;

namespace PortfolioWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
         {
            
        }
        
        public DbSet<PortfolioProject> PortfolioProjects { get; set; }
    }
}