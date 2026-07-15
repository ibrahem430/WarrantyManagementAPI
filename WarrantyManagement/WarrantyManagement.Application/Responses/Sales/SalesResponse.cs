using WarrantyManagement.Application.Responses.Products;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Responses.Sales;


public class SalesResponse
{
     public Guid Id {get;private set;}

    public Guid ProductId {get;private set;}

    public Guid CustomerId {get;private set;}
     
    public DateTime SaleDate {get;private set;}

    public string SerialNumber { get; private set; }

    public decimal Price {get;private set;}

      public static SalesResponse FromModel(Sale sale)
    {
        if(sale==null)
        throw new ArgumentNullException(nameof(sale));

        var salesResponse=new SalesResponse
        {
            Id=sale.Id,
            ProductId=sale.ProductId,
            CustomerId=sale.CustomerId,
            SaleDate=sale.SaleDate,
            SerialNumber=sale.SerialNumber,
            Price=sale.Price
            
        };
        return salesResponse;
    }
        public static IEnumerable<SalesResponse> FromModels(IEnumerable<Sale> sales)
    {
        if(sales==null)
        throw new ArgumentNullException(nameof(sales));

        return sales.Select(FromModel);
    }
}