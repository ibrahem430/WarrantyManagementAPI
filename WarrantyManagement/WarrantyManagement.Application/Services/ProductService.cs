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



       public async Task<ProductResponse> GetProductAsync(Guid id)
    {
    if (id == Guid.Empty)
        throw new ArgumentException("Product id cannot be empty.", nameof(id));

    var product = await repository.GetByIdAsync(id);

    if (product is null)
        throw new KeyNotFoundException("Product not found.");

    return ProductResponse.FromModel(product);
    }


        public async Task<ProductResponse> UpdateProductAsync(UpdateProductRequest request)
    {
       
       ArgumentNullException.ThrowIfNull(request);
       var product = await repository.GetByIdAsync(request.Id);

       if(product==null)
       throw new KeyNotFoundException("product not founded");
         
       product.ChangeName(request.Name);
       product.ChangeBrand(request.Brand);
       product.ChangeWarrantyMonths(request.WarrantyMonths);

        await repository.UpdateAsync(product);

        return ProductResponse.FromModel(product);
    }


 public async Task DeleteProductAsync(Guid Id)
    {
       
      if(Id==Guid.Empty)
      throw new ArgumentException("Product id cannot be empty.",nameof(Id));
       var product = await repository.GetByIdAsync(Id);

       if(product==null)
       throw new KeyNotFoundException("product not found");
         
        await repository.DeleteAsync(product);
    }

 
       public async Task <IEnumerable <ProductResponse>> GetAllProductAsync()
    {
   
      var products= await repository.GetAllAsync();

    return ProductResponse.FromModels(products);
    }


    
 
    
}