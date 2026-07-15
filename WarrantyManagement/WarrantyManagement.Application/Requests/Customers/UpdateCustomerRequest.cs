namespace WarrantyManagement.Application.Requests.Customers;


public class UpdateCustomerRequest
{
     public Guid Id{get;private set;}

    public string FullName {get;private set;}

    public string Email {get;private set;}

    public string Phone{get;private set;}
}