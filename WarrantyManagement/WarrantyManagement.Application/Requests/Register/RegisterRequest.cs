using WarrantyManagement.Domain.Enums;

namespace WarrantyManagement.Application.Requests.Register;

public class RegisterRequest
{
    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public RoleStatus Role { get; set; }
}