using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Infrastructure.dataBase.Configration;


public class WarrantyClaimConfigration : IEntityTypeConfiguration<WarrantyClaim>
{
    public void Configure(EntityTypeBuilder<WarrantyClaim> builder)
    {
        
        builder.HasKey(w=>w.Id);

        builder.HasOne<Warranty>()
        .WithMany()
        .HasForeignKey(w=>w.WarrantyId)
        .OnDelete(DeleteBehavior.Cascade);


        builder.Property(w=>w.ClaimDate)
        .IsRequired(); 

        builder.Property(w=>w.ProblemDescription)
        .IsRequired()
        .HasMaxLength(1000);


         builder.Property(w=>w.TechnicianNotes)
        .IsRequired()
        .HasMaxLength(2000);
    
        
         }
}