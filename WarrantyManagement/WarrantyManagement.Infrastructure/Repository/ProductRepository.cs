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

    public Task DeleteAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }
}