using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.TaskManagementSys.Domain.Entites;

namespace TaskManagementSystem.TaskManagementSys.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
         public DbSet<User> Users { get; set; }
         public DbSet<Project> Projects { get; set; }
         public DbSet<Tasks> Taskses{ get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // User - Project (One-to-Many)
            modelBuilder.Entity<Project>()
                .HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Project - Tasks (One-to-Many)
            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Taskses)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
