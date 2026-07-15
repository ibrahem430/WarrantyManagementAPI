using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Application.Requests.Customers;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Services;




public class CustomerService(ICustomerRepository repository)
{
     public async Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
    {
       
        ArgumentNullException.ThrowIfNull(request); 

         var newCustomer=new Customer(request.FullName,request.Email,request.Phone);
         
       var savedCustomer = await repository.CreateAsync(newCustomer);

        return CustomerResponse.FromModel(savedCustomer );
    }



       public async Task<CustomerResponse> GetCustomerAsync(Guid id)
    {
    if (id == Guid.Empty)
        throw new ArgumentException("Customer id cannot be empty.", nameof(id));

    var customer = await repository.GetByIdAsync(id);

    if (customer is null)
        throw new KeyNotFoundException("customer not found.");

    return CustomerResponse.FromModel(customer);
    }


        public async Task<CustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request)
    {
       
       ArgumentNullException.ThrowIfNull(request);
       var customer = await repository.GetByIdAsync(request.Id);

       if(customer==null)
       throw new KeyNotFoundException("customer not found");
         
       customer.ChangeName(request.FullName);
       customer.ChangeEmail(request.Email);
       customer.ChangePhone(request.Phone);

        await repository.UpdateAsync(customer);

        return CustomerResponse.FromModel(customer);
    }


 public async Task DeleteCustomerAsync(Guid id)
    {
       
      if(id==Guid.Empty)
      throw new ArgumentException("customer id cannot be empty.",nameof(id));
       var customer = await repository.GetByIdAsync(id);

       if(customer==null)
       throw new KeyNotFoundException("customer not found");
         
        await repository.DeleteAsync(customer);
    }

 
       public async Task <IEnumerable <CustomerResponse>> GetAllCustomerAsync()
    {
   
      var customers= await repository.GetAllAsync();

    return CustomerResponse.FromModels(customers);
    }


    
}