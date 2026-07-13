using WarrantyManagement.Application.Requests.Products;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Interfaces;


public interface IProductRepository
{
    public Task <Product> AddAsync(Product product);

     public Task <IEnumerable<Product>>GetAllAsync();

     public Task <Product> GetByIdAsync(Guid id);

     public Task  UpdateAsync(Product product);

     public Task DeleteAsync(Product product);
}