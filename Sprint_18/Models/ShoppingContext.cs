using Microsoft.EntityFrameworkCore;

namespace TaskAuthenticationAuthorization.Models
{
    public class ShoppingContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BuyerType> BuyerTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SuperMarket> SuperMarkets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        
        

        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options) =>
            Database.EnsureCreated();
    }
}
