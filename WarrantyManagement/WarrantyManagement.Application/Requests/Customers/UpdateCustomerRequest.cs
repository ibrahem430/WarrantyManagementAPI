namespace WarrantyManagement.Application.Requests.Customers;


public class UpdateCustomerRequest
{
     public Guid Id{get;private set;}

    public string FullName {get; set;}

    public string Email {get; set;}

    public string Phone{get; set;}
}