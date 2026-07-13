using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Application.Requests.Products;
using WarrantyManagement.Application.Responses.Products;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Services;


public class ProductService(IProductRepository repository)
{
    

    public async Task<ProductResponse> CreateProductAsync(CreateProductRequest request)
    {
       
        ArgumentNullException.ThrowIfNull(request); 

         var newProduct=new Product(request.Name,request.Brand,request.WarrantyMonths);
         
       var savedProduct = await repository.AddAsync(newProduct);

        return ProductResponse.FromModel(savedProduct );
    }

}