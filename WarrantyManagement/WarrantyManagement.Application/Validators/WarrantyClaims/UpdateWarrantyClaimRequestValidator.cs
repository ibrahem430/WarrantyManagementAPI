using FluentValidation;
using WarrantyManagement.Application.Requests.WarrantyClaim;

namespace WarrantyManagement.Application.Validators.WarrantyClaims;

    public class UpdateWarrantyClaimRequestValidator:AbstractValidator<UpdateWarrantyClaimRequest>
    {
        
        public UpdateWarrantyClaimRequestValidator()
    {
       RuleFor(w=>w.Id)
        .NotEmpty().WithMessage("The WarrantyId is required");

            RuleFor(w=>w.WarrantyId)
        .NotEmpty().WithMessage("The WarrantyId is required");


        RuleFor(w=>w.ProblemDescription)
        .NotEmpty().WithMessage("The ProblemDescription is required");


         RuleFor(w=>w.TechnicianNotes)
        .NotEmpty().WithMessage("The TechnicianNotes is required");

    }
    }