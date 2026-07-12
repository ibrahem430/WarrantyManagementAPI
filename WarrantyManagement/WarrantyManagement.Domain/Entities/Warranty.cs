namespace WarrantyManagement.Domain.Entities;


public class Warranty
{
    public Guid Id { get; private set; }

    public Guid SaleId { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public bool IsActive => EndDate >=DateTime.UtcNow;


    public Warranty(Guid saleId ,DateTime startDate,  DateTime endDate )
    {
        ValidateSaleId(saleId);
        ValidateStartDate(startDate);
        ValidateEndDate(startDate,endDate);
        Id=Guid.NewGuid();
        SaleId=saleId;
        StartDate=startDate;
        EndDate=endDate;
    }
     
    
    private static void ValidateSaleId(Guid saleId)
    {
        if(saleId==Guid.Empty)
        throw new ArgumentException("saleId must have Value");
    }

    private static void ValidateStartDate(DateTime startDate)
    {
        if(startDate>DateTime.UtcNow)
        throw new ArgumentException("Warranty start date cannot be in the future.");
    }
    
       private static void ValidateEndDate(DateTime startDate,DateTime endDate)
    {
        if(endDate<=startDate)
        throw new ArgumentException("Warranty end date must be after start date");
    }


}

