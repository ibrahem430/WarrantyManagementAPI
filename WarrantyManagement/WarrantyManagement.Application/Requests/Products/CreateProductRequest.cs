namespace WarrantyManagement.Application.Requests.Products;


public class CreateProductRequest
{
    public string Name{get; set;}

    public string Brand{get; set;}

    public  int WarrantyMonths {get; set;}
}