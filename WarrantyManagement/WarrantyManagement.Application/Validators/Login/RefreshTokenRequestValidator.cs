using FluentValidation;
using WarrantyManagement.Application.Requests.Login;

namespace WarrantyManagement.Application.Validators.Login;


public class RefreshTokenRequestValidator:AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator()
    {
        RuleFor(r=>r.RefreshJWTToken)
        .NotEmpty().WithMessage("Refresh Token is required");

    }
}