using Microsoft.EntityFrameworkCore;
using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Domain.Entities;
using WarrantyManagement.Infrastructure.dataBase;

namespace WarrantyManagement.Infrastructure.Repository;


public class CustomerRepository(AppDbContext context) : ICustomerRepository
{
    public async Task<Customer> CreateAsync(Customer customer)
    {
        await context.customers.AddAsync(customer);
        await context.SaveChangesAsync();
        return  customer;
    }

    public async Task DeleteAsync(Customer customer)
    {
         context.customers.Remove(customer);
        await context.SaveChangesAsync();
        
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
      var customers= await context.customers.AsNoTracking().ToListAsync();
        return customers;
          }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
      var customer= await context.customers.FirstOrDefaultAsync(c=>c.Id==id);
         
        return customer;   
        
         }

    public async Task UpdateAsync(Customer customer)
    {
   
        await context.SaveChangesAsync();  
         
    }
}