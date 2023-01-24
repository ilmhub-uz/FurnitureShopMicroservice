using Dashboard.Api.Entities;
using Dashboard.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Api.Context;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OrganizationUser> OrganizationUsers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<OrganizationUser>().HasKey(o => new { o.UserId, o.OrganizationId });
    }
}
