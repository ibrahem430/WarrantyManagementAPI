using FluentValidation;
using WarrantyManagement.Application.Requests.Register;

namespace WarrantyManagement.Application.Validators.Register;


public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
{
    
    public RegisterRequestValidator()
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

       RuleFor(x => x.Role)
       .IsInEnum()
       .WithMessage("Invalid role.");
        
    }
}