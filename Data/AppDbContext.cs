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
        
        public DbSet<Project> Projects { get; set; }
        public DbSet<TechnologyTag> TechnologyTags { get; set; }
        public DbSet<ProjectTechnologyTag> ProjectTechnologyTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTechnologyTag>()
                .HasKey(x => new { x.ProjectID, x.TechnologyTagID});

            modelBuilder.Entity<ProjectTechnologyTag>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectTechnologyTags)
                .HasForeignKey(pt => pt.ProjectID);

            modelBuilder.Entity<ProjectTechnologyTag>()
                .HasOne(pt => pt.TechnologyTag)
                .WithMany(t => t.ProjectTechnologyTags)
                .HasForeignKey(pt => pt.TechnologyTagID);

            base.OnModelCreating(modelBuilder);
        }
    }
}