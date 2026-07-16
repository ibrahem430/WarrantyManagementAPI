using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Application.Requests.Sales;
using WarrantyManagement.Application.Responses.Sales;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Services;


public class SaleService(ISaleRepository repository, IProductRepository productRepository,ICustomerRepository customerRepository)
{
        public async Task<SalesResponse> CreateSaleAsync(CreateSaleRequest request)
    {
       
        ArgumentNullException.ThrowIfNull(request); 

        var product=await productRepository.GetByIdAsync(request.ProductId);
        var customer=await customerRepository.GetByIdAsync(request.CustomerId);

        if (product is null)
        {
            throw new KeyNotFoundException("Product not found");
        }

         if (customer is null)
        {
            throw new KeyNotFoundException("Customer not found");
        }



         var newSale=new Sale(request.ProductId,request.CustomerId,request.SerialNumber,request.Price);
         
       var savedSale = await repository.AddAsync(newSale);

        return SalesResponse.FromModel(savedSale );
    }



       public async Task<SalesResponse> GetSaleAsync(Guid id)
    {
    if (id == Guid.Empty)
        throw new ArgumentException("Sale id cannot be empty.", nameof(id));

    var sale = await repository.GetByIdAsync(id);

    if (sale is null)
        throw new KeyNotFoundException("Sale not found.");

    return SalesResponse.FromModel(sale);
    }


        public async Task<SalesResponse> UpdateSaleAsync(UpdateSaleRequest request)
    {
       
       ArgumentNullException.ThrowIfNull(request);
       var sale = await repository.GetByIdAsync(request.Id);

       if(sale is null)
       throw new KeyNotFoundException("Sale not founded");
         
       sale.ChangeSerialNumber(request.SerialNumber);
       sale.ChangePrice(request.Price);
     

        await repository.UpdateAsync(sale);

        return SalesResponse.FromModel(sale);
    }


 public async Task DeleteSaleAsync(Guid id)
    {
       
      if(id==Guid.Empty)
      throw new ArgumentException("Sale id cannot be empty.",nameof(id));
       var sale = await repository.GetByIdAsync(id);

       if(sale is null)
       throw new KeyNotFoundException("Sale not found");
         
        await repository.DeleteAsync(sale);
    }

 
 public async Task<IEnumerable<SalesResponse>> GetAllSalesAsync()
{
    var sales = await repository.GetAllAsync();

    return SalesResponse.FromModels(sales);
}
}