using FluentValidation;
using WarrantyManagement.Application.Requests.Customers;
// using WarrantyManagement.Application.Requests.Products;

namespace WarrantyManagement.Application.Validators.Customers;
public class CreateCustomerRequestValidator:AbstractValidator<CreateCustomerRequest>
{
    
    public CreateCustomerRequestValidator()
    {
         RuleFor(c=>c.FullName)
        .NotEmpty().WithMessage("The FullName is required")
        .MaximumLength(300).WithMessage("FullName must be less than 300 characters");

        RuleFor(c => c.Email)
       .NotEmpty().WithMessage("Email is required.")
       .EmailAddress().WithMessage("Invalid email address.")
       .MaximumLength(300).WithMessage("Email must be less than 300 characters.");

        RuleFor(c=>c.Phone)
        .NotEmpty()
        .WithMessage("The Phone is required");     
          }
}