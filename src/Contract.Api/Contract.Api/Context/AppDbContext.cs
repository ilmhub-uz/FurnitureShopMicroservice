using Contract.Api.Dto;
using Contract.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contract.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Entities.Contract> Contract { get; set; }
    }
}
