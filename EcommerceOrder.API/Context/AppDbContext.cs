using EcommerceOrder.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceOrder.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
