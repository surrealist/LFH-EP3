using EP3.Models;
using Microsoft.EntityFrameworkCore;

namespace EP3.Data
{
  public class AppDb : DbContext
  {

    public AppDb(DbContextOptions<AppDb> options) : base(options)
    {
      //
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // EF Core FluentAPI
      modelBuilder.Entity<OrderDetail>()
        .ToTable("OrderDetails");
    }
  }
}
