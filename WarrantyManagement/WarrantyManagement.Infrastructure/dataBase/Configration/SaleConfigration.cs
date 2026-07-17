using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Infrastructure.dataBase.Configration;


public class SaleConfigration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(s=>s.Id);

        builder.HasOne<Customer>()
        .WithMany()
        .HasForeignKey(s=>s.CustomerId)
        .OnDelete(DeleteBehavior.Cascade);

       
        builder.HasOne<Product>()
        .WithMany()
        .HasForeignKey(s=>s.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.Property(s=>s.Price)
        .IsRequired(); 

        builder.Property(s=>s.SaleDate)
        .IsRequired(); 

         builder.Property(s=>s.SerialNumber)
        .IsRequired(); 

        



    }
}