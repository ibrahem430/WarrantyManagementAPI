using Microsoft.AspNetCore.Identity;
using WarrantyManagement.Application.Interfaces;
using WarrantyManagement.Application.Requests.Register;
using WarrantyManagement.Application.Responses.Register;
using WarrantyManagement.Domain.Entities;

namespace WarrantyManagement.Application.Services;

public class RegisterService(IRegisterRepository register)
{
    public async Task<RegisterResponse> AddUserAsync(RegisterRequest request)
    {
        var userByName =
            await register.GetUserByUserNameAsync(request.UserName);

        if (userByName is not null)
        {
            throw new ArgumentException(
                "Username is already in use.");
        }

        var userByEmail =
            await register.GetUserByEmailAsync(request.Email);

        if (userByEmail is not null)
        {
            throw new ArgumentException(
                "Email is already in use.");
        }

 var passwordHasher = new PasswordHasher<User>();

// كائن مؤقت فقط لاستخدام PasswordHasher
var tempUser = new User(
    request.UserName,
    request.Email,
    "temp",
    request.Role
);

var hashedPassword = passwordHasher.HashPassword(
    tempUser,
    request.Password
);

var newAccount = new User(
    request.UserName,
    request.Email,
    hashedPassword,
    request.Role
);

        await register.AddUserAsync(newAccount);

        return new RegisterResponse
        {
            UserName = newAccount.UserName,
            Email = newAccount.Email,
            Role = newAccount.Role
        };
    }
}