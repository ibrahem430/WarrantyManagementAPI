namespace WarrantyManagement.Domain.Entities;

public class Product
{
    public Guid Id {get;private set; }

    public string Name{get;private set;}

    public string Brand{get;private set;}

    public  int WarrantyMonths {get;private set;}

public Product(string name,string brand,int warrantyMonths)
    {
        ValidateName(name);
        ValidateBrand(brand);
        ValidateWarrantyMonths(warrantyMonths);
        Id=Guid.NewGuid();
        Name=name;
        Brand=brand;
        WarrantyMonths=warrantyMonths;
    }

    

    public void ChangeName(string name)
    {
        ValidateName(name);
        Name=name;
    }
       public void ChangeBrand(string brand)
    {
        ValidateBrand(brand);
        Brand=brand;
    }
       public void ChangeWarrantyMonths(int warrantyMonths)
    {
        ValidateWarrantyMonths(warrantyMonths);
        WarrantyMonths=warrantyMonths;
    }

    private static void ValidateName(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
        throw new ArgumentException("the name is required");

    }
    
    private static void ValidateBrand(string brand)
    {
        if(string.IsNullOrWhiteSpace(brand))
        throw new ArgumentException("the Brand is required");

    }
    
    private static void ValidateWarrantyMonths(int warrantyMonths)
    {

        if(warrantyMonths<0)
        throw new ArgumentException("Warranty Months must up or equal 0");

    }

}