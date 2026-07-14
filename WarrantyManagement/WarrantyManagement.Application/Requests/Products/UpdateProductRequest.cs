namespace WarrantyManagement.Application.Requests.Products;



public class UpdateProductRequest
{
    public Guid Id {get; set;}
    public string Name{get; set;}

    public string Brand{get; set;}

    public  int WarrantyMonths {get; set;}
}