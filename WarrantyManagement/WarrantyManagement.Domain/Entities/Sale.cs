namespace WarrantyManagement.Domain.Entities;


public class Sale
{
    public Guid Id {get;private set;}

    public Guid ProductId {get;private set;}

    public Guid CustomerId {get;private set;}

    public DateTime SaleDate {get;private set;}

    public string SerialNumber { get; private set; }

    public decimal Price {get;private set;}

   public Sale(Guid productId,Guid customerId,string serialNumber,decimal price)
    {   
        
        ValidateId(productId);
        ValidateId(customerId);
        ValidateSerialNumber(serialNumber);
        ValidatePrice(price);
     
        Id=Guid.NewGuid();
        ProductId=productId;
        CustomerId=customerId;
        SaleDate=DateTime.UtcNow;
        SerialNumber=serialNumber;
        Price=price;
    }
   
   public void ChangeSerialNumber(string serialNumber)
    {
        ValidateSerialNumber(serialNumber);
        SerialNumber=serialNumber;
    }
      public void ChangePrice(decimal price)
    {
        ValidatePrice(price);
        Price=price;
    }


      private static void ValidateSerialNumber(string serialNumber)
    {
        if(string.IsNullOrWhiteSpace(serialNumber))
        throw new ArgumentException("product SerialNumber is required");
        
    }

      private static void ValidateId(Guid Id)
    {
        if(Id==Guid.Empty)
        throw new ArgumentException("the Id is required not empty");
    }
      
       private static void ValidatePrice(decimal price)
    {
        if(price <=0)
        throw new ArgumentException("product price must Greater than 0 ");
    }
}



