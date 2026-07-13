using Microsoft.EntityFrameworkCore;
using WarrantyManagement.Domain.Entities;
using WarrantyManagement.Infrastructure.dataBase.Configration;

namespace WarrantyManagement.Infrastructure.dataBase;



public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
   public DbSet <Product> products=>Set<Product>();
  public  DbSet<Sale> sales=>Set<Sale>();

   public DbSet<Customer> customers=>Set<Customer>();

   public DbSet<Warranty> Warranties=>Set<Warranty>();

   public DbSet<WarrantyClaim> warrantyClaims=>Set<WarrantyClaim>();


 protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfigration).Assembly);
    }
}