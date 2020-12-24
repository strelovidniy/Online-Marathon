using Microsoft.EntityFrameworkCore;

namespace Sprint_16.Models
{
    public class ShoppingContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SuperMarket> SuperMarkets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public ShoppingContext(DbContextOptions<ShoppingContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().Property(property => property.Quantity).HasColumnType("decimal(18,2), not null");
            base.OnModelCreating(modelBuilder);
        }
    }
}
