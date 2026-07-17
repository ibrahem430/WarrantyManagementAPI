using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Infrastructure.dataBase.Configration;


public class CustomerConfigration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {

        builder.HasKey(c=>c.Id);

        builder.Property(c=>c.FullName)
        .IsRequired()
        .HasMaxLength(300);

        builder.Property(c=>c.Email)
        .IsRequired()
        .HasMaxLength(300);

        builder.Property(c=>c.Phone)
        .IsRequired()
        .HasMaxLength(300); 
           }
}