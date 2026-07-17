using FluentValidation;
using WarrantyManagement.Application.Requests.Customers;

namespace WarrantyManagement.Application.Validators.Customers;


public class UpdateCustomerRequestValidator:AbstractValidator<UpdateCustomerRequest>
{
      
      public UpdateCustomerRequestValidator()
        {

         RuleFor(c=>c.Id).NotEmpty().WithMessage("The Id is required");
        
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


//      public UpdateCustomerRequestValidators(){
        // RuleFor(c=>c.fu)
        // .NotEmpty().WithMessage("The name is required")
        // .MaximumLength(100).WithMessage("Name must be less than 100 characters");

        // RuleFor(p=>p.Brand)
        // .NotEmpty().WithMessage("The Brand is required")
        // .MaximumLength(100).WithMessage("Brand must be less than 100 characters");


        // RuleFor(p=>p.WarrantyMonths)
        // .GreaterThanOrEqualTo(0)
        // .WithMessage("The Warranty months can not be negative ");
        // }
}