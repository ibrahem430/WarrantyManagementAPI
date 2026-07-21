namespace WarrantyManagement.Application.Requests.Sales;


public class CreateSaleRequest
{
  

    public Guid ProductId {get; set;}

    public Guid CustomerId {get; set;}

    public string SerialNumber { get;  set; }

    public decimal Price {get; set;}
}