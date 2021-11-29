using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamProject.Domain.Data.Entities;

namespace TeamProject.Domain.Data;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Project> Projects { get; set; }
}