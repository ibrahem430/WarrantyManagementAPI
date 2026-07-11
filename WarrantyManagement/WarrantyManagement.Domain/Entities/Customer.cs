namespace WarrantyManagement.Domain.Entities;


public class Customer
{
    public Guid Id{get;private set;}

    public string FullName {get;private set;}

    public string Email {get;private set;}

    public string Phone{get;private set;}


    public Customer(string fullName,string email,string phone)
    {
        ValidateName(fullName);
        ValidateEmail(email);
        ValidatePhone(phone);
        Id=Guid.NewGuid();
        FullName=fullName;
        Email=email;
        Phone=phone;
    }

   public void ChangeName(string fullname)
    {
        ValidateName(fullname);
        FullName =fullname;
    }

       public void ChangeEmail(string email)
    {
        ValidateEmail(email);
        Email =email;
    }

       public void ChangePhone(string phone)
    {
        ValidatePhone(phone);
        Phone =phone;
    }
    private static void ValidateName(string fullName)
    {
        if(string.IsNullOrWhiteSpace(fullName))
        throw new ArgumentException("Customer name is required");
    }
        private static void ValidateEmail(string email)
    {
        if(string.IsNullOrWhiteSpace(email))
        throw new ArgumentException("Customer email is required");
    }

    private static void ValidatePhone(string phone)
    {
        if(string.IsNullOrWhiteSpace(phone))
        throw new ArgumentException("Customer phone is required");
    }

}

