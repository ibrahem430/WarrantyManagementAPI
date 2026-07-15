namespace WarrantyManagement.Application.Requests.Sales;


public class UpdateSaleRequest
{
     public Guid Id {get;private set;}

    public Guid ProductId {get;private set;}

    public Guid CustomerId {get;private set;}

    public string SerialNumber { get; private set; }

    public decimal Price {get;private set;}
}