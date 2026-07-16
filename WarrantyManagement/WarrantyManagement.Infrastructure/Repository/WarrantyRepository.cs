using Microsoft.EntityFrameworkCore;
using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Domain.Entities;
using WarrantyManagement.Infrastructure.dataBase;

namespace WarrantyManagement.Infrastructure.Repository;


public class WarrantyRepository(AppDbContext context) : IWarrantyRepository
{
    public async Task<Warranty> AddAsync(Warranty warranty)
    {
        await context.Warranties.AddAsync(warranty);
         await context.SaveChangesAsync();
        return warranty;
    }

    public async Task DeleteAsync(Warranty warranty)
    {
         context.Warranties.Remove(warranty);
         await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Warranty>> GetAllAsync()
    {
       var warranties= await context.Warranties.ToListAsync();
       return warranties;
    }

    public async Task<Warranty?> GetByIdAsync(Guid id)
    {
       var warranty= await context.Warranties.FirstOrDefaultAsync(w=>w.Id==id);
       return warranty; 
       
          }

    public async Task<Warranty?> GetBySaleIdAsync(Guid saleId)
    {
       var warranty= await context.Warranties.FirstOrDefaultAsync(w=>w.SaleId==saleId);
       return warranty;    }
}