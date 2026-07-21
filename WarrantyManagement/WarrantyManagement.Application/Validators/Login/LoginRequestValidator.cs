using FluentValidation;
using WarrantyManagement.Application.Requests.Login;

namespace WarrantyManagement.Application.Validators.Login;

public class LoginRequestValidator:AbstractValidator<LoginRequest>
{
    
public LoginRequestValidator()
    {
              RuleFor(l=>l.UserName)
        .NotEmpty().WithMessage("The UserName is required")
        .MaximumLength(200).WithMessage("UserName must be less than 200 characters");

        RuleFor(l => l.Email)
       .NotEmpty().WithMessage("Email is required.")
       .EmailAddress().WithMessage("Invalid email address.")
       .MaximumLength(300).WithMessage("Email must be less than 300 characters.");

        RuleFor(l=>l.Password)
        .NotEmpty()
        .WithMessage("The Password is required");     
    }

}