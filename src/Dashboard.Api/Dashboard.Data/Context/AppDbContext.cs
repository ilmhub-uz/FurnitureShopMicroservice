using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.Data.Entites;

namespace Dashboard.Data.Context;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrganizationUser> OrganizationUsers { get; set; }
}
