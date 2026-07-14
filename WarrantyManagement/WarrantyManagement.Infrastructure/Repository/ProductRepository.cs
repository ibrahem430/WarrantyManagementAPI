using Microsoft.EntityFrameworkCore;
using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Domain.Entities;
using WarrantyManagement.Infrastructure.dataBase;

namespace WarrantyManagement.Infrastructure.Repository;


public class ProductRepository(AppDbContext context) : IProductRepository
{
    public  async Task<Product> AddAsync(Product product)
    {
        if(product==null)
        throw new ArgumentNullException(nameof(product));
        
       await context.products.AddAsync(product);
       await context.SaveChangesAsync();
       
       return  product;
    }

    public async Task DeleteAsync(Product product)
    {
         context.products.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
       var products = await context.products.AsNoTracking().ToListAsync();
       return products;

    }

    public  async Task<Product?> GetByIdAsync(Guid id)
    {

       var product= await context.products.FirstOrDefaultAsync(p=>p.Id==id);

       return product;

    }

    public async Task UpdateAsync(Product product)
    {
       await context.SaveChangesAsync();

    }
}