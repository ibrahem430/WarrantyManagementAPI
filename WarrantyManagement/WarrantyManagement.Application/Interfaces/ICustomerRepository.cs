using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Interfaces;



public interface ICustomerRepository
{
   public Task <IEnumerable<Customer>> GetAllAsync();
   public Task UpdateAsync(Customer customer);
   public Task<Customer> CreateAsync(Customer customer);
   public Task DeleteAsync(Customer customer);
   public Task<Customer?> GetByIdAsync(Guid id);


}