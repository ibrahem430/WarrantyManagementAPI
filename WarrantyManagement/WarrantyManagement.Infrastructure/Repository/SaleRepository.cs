using Microsoft.EntityFrameworkCore;
using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Domain.Entities;
using WarrantyManagement.Infrastructure.dataBase;

namespace WarrantyManagement.Infrastructure.Repository;


public class SaleRepository(AppDbContext context) : ISaleRepository
{
    public async Task<Sale> AddAsync(Sale sale)
    {
      await context.sales.AddAsync(sale);
      await context.SaveChangesAsync();
       return  sale;
    }

    public async Task DeleteAsync(Sale sale)
    {
      context.sales.Remove(sale);   
      await context.SaveChangesAsync();
        
         }

    public async Task<IEnumerable<Sale>> GetAllAsync()
    {
       var sales= await context.sales.AsNoTracking().ToListAsync();

       return sales;
    }

    public async Task<Sale?> GetByIdAsync(Guid id)
    {
         var sale= await context.sales.FirstOrDefaultAsync(s=>s.Id==id);
       
       return sale;
    }

    public async Task UpdateAsync(Sale sale)
    {
        await context.SaveChangesAsync();
    }
}