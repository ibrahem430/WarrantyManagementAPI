using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Interfaces;


public interface ISaleRepository
{
    
     public Task <Sale> AddAsync (Sale sale);

     public Task <IEnumerable<Sale>>GetAllAsync();

     public Task <Sale?> GetByIdAsync(Guid id);

     public Task  UpdateAsync(Sale sale);

     public Task DeleteAsync(Sale sale);
}