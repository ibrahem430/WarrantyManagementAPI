using FluentValidation;
using WarrantyManagement.Application.Requests.Sales;

namespace WarrantyManagement.Application.Validators.Sales;


public class UpdateSaleRequestValidator:AbstractValidator<UpdateSaleRequest>
{
    

    public UpdateSaleRequestValidator()
    {

          RuleFor(s=>s.Id)
        .NotEmpty().WithMessage("The Id is required");

         RuleFor(s=>s.CustomerId)
        .NotEmpty().WithMessage("The CustomerId is required");

        RuleFor(s=>s.ProductId)
        .NotEmpty().WithMessage("The ProductId is required");


        RuleFor(s=>s.SerialNumber)
        .NotEmpty().WithMessage("The SerialNumber is required")
        .MaximumLength(300).WithMessage("SerialNumber must be less than 300 characters");

        RuleFor(s=>s.Price).GreaterThan(0).WithMessage("The price must be Grater than 0 ");
        
    }
}