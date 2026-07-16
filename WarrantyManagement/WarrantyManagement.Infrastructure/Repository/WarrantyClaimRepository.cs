using Microsoft.EntityFrameworkCore;
using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Domain.Entities;
using WarrantyManagement.Infrastructure.dataBase;

namespace WarrantyManagement.Infrastructure.Repository;


public class WarrantyClaimRepository(AppDbContext context) : IWarrantyClaimRepository
{
    public async Task<WarrantyClaim> AddAsync(WarrantyClaim warrantyClaim)
    {
          await context.warrantyClaims.AddAsync(warrantyClaim);
         await context.SaveChangesAsync();
        return warrantyClaim;
    }

    public async Task DeleteAsync(WarrantyClaim warrantyClaim)
    {
        context.warrantyClaims.Remove(warrantyClaim);
         await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<WarrantyClaim>> GetAllAsync()
    {
         var warrantyClaims= await context.warrantyClaims.AsNoTracking().ToListAsync();
       return warrantyClaims;
    }

    public async Task<WarrantyClaim?> GetByIdAsync(Guid id)
    {
       var warrantyClaim= await context.warrantyClaims.FirstOrDefaultAsync(w=>w.Id==id);
       return warrantyClaim;     }

    public async Task<WarrantyClaim> GetByWarrantyIdAsync(Guid warrantyId)
    {
        var warranty= await context.warrantyClaims.FirstOrDefaultAsync(w=>w.WarrantyId==warrantyId);
        await context.SaveChangesAsync();
        return warranty;

    }

    public async Task UpdateAsync(WarrantyClaim warrantyClaim)
    {
        await context.SaveChangesAsync();
    }

    
}