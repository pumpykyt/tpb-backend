using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamProject.Domain.Data.Entities;

namespace TeamProject.Domain.Data;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Application> Applications { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>()
                    .HasOne(t => t.Owner)
                    .WithMany(t => t.MyProjects)
                    .HasForeignKey(t => t.OwnerId)
                    .HasConstraintName("FK_Projects_Users_OwnerId")
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Project>()
                    .HasMany(t => t.Users)
                    .WithMany(t => t.Projects);
    }
}