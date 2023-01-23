using Dashboard.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace Dashboard.Data.Data;

public class AppDbContext: DbContext
{
    public DbSet<Product>? Products { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> context) : base(context){ }
}