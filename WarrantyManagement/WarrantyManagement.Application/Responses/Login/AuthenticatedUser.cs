using WarrantyManagement.Domain.Enums;

namespace WarrantyManagement.Application.Responses.Login;


public class AuthenticatedUser
{

   public Guid Id {get;set;}
    public string UserName {get;set;}

    public string Email{get;set;}

    public string password{get;set;}

    public RoleStatus Role {get;set;}
}