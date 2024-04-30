using Microsoft.EntityFrameworkCore;
using webbutveckling_labb2_phuusie.Shared.Entities;

namespace webbutveckling_labb2_phuusie.DataAccess;

public class StoreDbContext : DbContext  
{
    public StoreDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<ProductCategory> Categories { get; set; }

    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(op => op.Category)
            .WithMany()
            .HasForeignKey(op => op.CategoryId).OnDelete(DeleteBehavior.SetNull);
    }

}