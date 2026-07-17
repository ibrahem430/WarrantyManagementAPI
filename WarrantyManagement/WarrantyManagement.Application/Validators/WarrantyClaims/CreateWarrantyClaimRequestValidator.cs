using FluentValidation;
using WarrantyManagement.Application.Requests.WarrantyClaim;

namespace WarrantyManagement.Application.Validators.WarrantyClaims;

public class CreateWarrantyClaimRequestValidator:AbstractValidator<CreateWarrantyClaimRequest>
{
    
    public  CreateWarrantyClaimRequestValidator()
    {
          RuleFor(w=>w.WarrantyId)
        .NotEmpty().WithMessage("The Warranty Claim Id is required");


        RuleFor(w=>w.ProblemDescription)
        .NotEmpty().WithMessage("The ProblemDescription is required");

    }

}
