using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarrantyManagement.Application.Requests.Customers;
using WarrantyManagement.Application.Services;

namespace WarrantyManagement.Api.Controllers;

[ApiController]
[Route ("api/customer")]
[Authorize]
public class CustomerController(CustomerService customerService):ControllerBase
{
    [Authorize (Roles ="Admin,Employee")]
     [HttpPost]
    public async Task<IActionResult> AddCustomer(CreateCustomerRequest request)
    {
      var customer=await customerService.CreateCustomerAsync(request);
      
       return  CreatedAtRoute("GetCustomerById",new {customerId=customer.Id},customer);
       

    }
[Authorize (Roles ="Admin,Employee")]
     [HttpPut]
    public async Task<IActionResult> UpdateCustomer(UpdateCustomerRequest request)
    {
     await customerService.UpdateCustomerAsync(request);
      
       return  NoContent();
       

    }
[Authorize (Roles ="Admin,Employee")]
         [HttpDelete("{customerId:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid customerId)
    {
      await customerService.DeleteCustomerAsync(customerId);
      
       return  NoContent();
       

    }
[Authorize (Roles ="Admin,Employee")]
       [HttpGet("{customerId:guid}",Name ="GetCustomerById")]
    public async Task<IActionResult> GetCustomerById(Guid customerId)
    {
      var customer=await customerService.GetCustomerAsync(customerId);
      
       return  Ok(customer);
       

    }
[Authorize (Roles ="Admin,Employee")]
       [HttpGet]
    public async Task<IActionResult> GetAllCustomer()
    {
      var customers=await customerService.GetAllCustomerAsync();
      
       return  Ok(customers);
 
 
 
    }



    // #################################################

    [HttpGet("test-error")]
public IActionResult TestError()
{
    throw new InvalidOperationException(
        "This is a test exception.");
}
}