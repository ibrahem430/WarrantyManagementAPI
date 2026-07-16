using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Application.Requests.Warranty;
using WarrantyManagement.Application.Responses.Warranties;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Services;


public class WarrantyService(IWarrantyRepository warrantyRepository,ISaleRepository saleRepository,IProductRepository productRepository)
{
       public async Task<WarrantyResponse> CreateWarrantyAsync(CreateWarrantyRequest request)
    {
       
        ArgumentNullException.ThrowIfNull(request); 

        var sale=await saleRepository.GetByIdAsync(request.SaleId);

        if (sale is null)
        {
            throw new KeyNotFoundException("Sale not found");
        }
        var existingWarranty =await warrantyRepository.GetBySaleIdAsync(sale.Id);

          if (existingWarranty  is not null)
           throw new InvalidOperationException(
        "A warranty already exists for this sale.");

        var product= await productRepository.GetByIdAsync(sale.ProductId);

        if(product is  null )
        throw new KeyNotFoundException("Product not found");

        if(product.WarrantyMonths<=0)
        throw new InvalidOperationException("The product does not have a warranty.");

        var endDate= sale.SaleDate.AddMonths(product.WarrantyMonths);

         var newWarranty=new Warranty(sale.Id,sale.SaleDate,endDate);
         
       var savedWarranty = await warrantyRepository.AddAsync(newWarranty);

        return WarrantyResponse.FromModel(savedWarranty);
        }   



       public async Task<WarrantyResponse> GetWarrantyAsync(Guid id)
    {
    
    validateId(id);
    var warranty = await warrantyRepository.GetByIdAsync(id);

    if (warranty is null)
        throw new KeyNotFoundException("Warranty not found.");

    return WarrantyResponse.FromModel(warranty);
    }



 public async Task DeleteWarrantyAsync(Guid id)
    {
       
     validateId(id);
       var warranty = await warrantyRepository.GetByIdAsync(id);

       if(warranty is null)
       throw new KeyNotFoundException("Warranty not found");
         
        await warrantyRepository.DeleteAsync(warranty);
    }

 
 public async Task<IEnumerable<WarrantyResponse>> GetAllWarrantiesAsync()
{
    var warranties = await warrantyRepository.GetAllAsync();

    return WarrantyResponse.FromModels(warranties);
}

private static void validateId(Guid id)
    {
       if (id == Guid.Empty)
        throw new ArgumentException("Warranty id cannot be empty.", nameof(id)); 
    }
}