using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Responses.Products;



public  class ProductResponse
{
    public Guid Id {get;set;}
    public string Name{get;set;}

    public string Brand{get;set;}

    public  int WarrantyMonths {get; set;}

    public static ProductResponse FromModel(Product product)
    {
        if(product==null)
        throw new ArgumentNullException(nameof(product));

        var productResponse=new ProductResponse
        {
            Id=product.Id,
            Name=product.Name,
            Brand=product.Brand,
            WarrantyMonths=product.WarrantyMonths
        };
        return productResponse;
    }
        public static IEnumerable<ProductResponse> FromModels(IEnumerable<Product> product)
    {
        if(product==null)
        throw new ArgumentNullException(nameof(product));

        return product.Select(FromModel);
    }
}