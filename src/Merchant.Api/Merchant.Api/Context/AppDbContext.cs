using Merchant.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Merchant.Api.Context;

public class AppDbContext : DbContext
{
	public DbSet<Organization>? Organizations { get; set; }
	public DbSet<OrganizationUser>? OrganizationUsers { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{
        base.OnModelCreating(builder);
        builder.Entity<OrganizationUser>().HasKey(user => new { user.UserId, user.OrganizationId });
  	}
}
