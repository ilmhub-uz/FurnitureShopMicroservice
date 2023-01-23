using Merchant.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Merchant.Api.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	public DbSet<Organization>? Organizations { get; set; }
	public DbSet<OrganizationUser>? OrganizationUsers { get; set; }

}
