using FluentValidation;
using WarrantyManagement.Application.Requests.Products;

namespace WarrantyManagement.Application.Validators.Products;


public class UpdateProductRequestValidator:AbstractValidator<UpdateProductRequest>
{
      

     public UpdateProductRequestValidator(){

         RuleFor(p=>p.Id).NotEmpty().WithMessage("The Id is required");

        RuleFor(P=>P.Name)
        .NotEmpty().WithMessage("The name is required")
        .MaximumLength(100).WithMessage("Name must be less than 100 characters");

        RuleFor(p=>p.Brand)
        .NotEmpty().WithMessage("The Brand is required")
        .MaximumLength(100).WithMessage("Brand must be less than 100 characters");


        RuleFor(p=>p.WarrantyMonths)
        .GreaterThanOrEqualTo(0)
        .WithMessage("The Warranty months can not be negative ");
        }
}