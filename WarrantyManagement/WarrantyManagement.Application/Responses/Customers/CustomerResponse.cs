using WarrantyManagement.Domain.Entities;




public  class CustomerResponse
{
    public Guid Id{get;private set;}

    public string FullName {get;private set;}

    public string Email {get;private set;}

    public string Phone{get;private set;}

    public static CustomerResponse FromModel(Customer customer)
    {
        if(customer==null)
        throw new ArgumentNullException(nameof(customer));

        var customerResponse=new CustomerResponse
        {
            Id=customer.Id,
            FullName=customer.FullName,
            Email=customer.Email,
            Phone=customer.Phone
        };
        return customerResponse;
    }
        public static IEnumerable<CustomerResponse> FromModels(IEnumerable<Customer> customers)
    {
        if(customers==null)
        throw new ArgumentNullException(nameof(customers));

        return customers.Select(FromModel);
    }
}