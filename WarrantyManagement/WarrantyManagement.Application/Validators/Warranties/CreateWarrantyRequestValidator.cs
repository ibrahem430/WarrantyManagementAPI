using FluentValidation;
using WarrantyManagement.Application.Requests.Warranty;

namespace WarrantyManagement.Application.Validators.Warranties;


public class CreateWarrantyRequestValidator:AbstractValidator<CreateWarrantyRequest>
{
    

    public CreateWarrantyRequestValidator()
    {
        RuleFor(w=>w.SaleId)
          .NotEmpty().WithMessage("The SaleId is required");
    }
}