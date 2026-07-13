using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Infrastructure.dataBase.Configration;



public class ProductConfigration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        

        builder.HasKey(p=>p.Id);

        builder.Property(p=>p.Name)
        .IsRequired()
        .HasMaxLength(150);

        builder.Property(p=>p.Brand)
        .IsRequired()
        .HasMaxLength(150);

        builder.Property(p=>p.WarrantyMonths)
        .IsRequired();


    }
}