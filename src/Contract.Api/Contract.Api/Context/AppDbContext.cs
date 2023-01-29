using Contract.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contract.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Entities.Contract>? Contracts { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderProduct>? OrderProducts { get; set; }
        public DbSet<ContractOrder>? Products {get;set;}
       
    }
}
