using WarrantyManagement.Domain.Enums;

namespace WarrantyManagement.Application.Responses.Register;


public class RegisterResponse
{
     public string UserName{get; set;}

    public string Email{get; set;}

    public RoleStatus Role {get; set;}
}
