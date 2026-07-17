using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Infrastructure.dataBase.Configration;


public class WarrantyConfigration : IEntityTypeConfiguration<Warranty>
{
    public void Configure(EntityTypeBuilder<Warranty> builder)
    {
        
        builder.HasKey(w=>w.Id);

        builder.HasOne<Sale>()
        .WithMany()
        .HasForeignKey(w=>w.SaleId)
        .OnDelete(DeleteBehavior.Cascade);


        builder.Property(w=>w.StartDate)
        .IsRequired(); 

        builder.Property(w=>w.EndDate)
        .IsRequired(); 


    }
}