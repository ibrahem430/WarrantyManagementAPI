// public Guid ProductId {get;private set;}

// public Guid CustomerId {get;private set;}

// public string SerialNumber { get; private set; }

// public decimal Price {get;private set;}
using FluentValidation;
using WarrantyManagement.Application.Requests.Sales;

namespace WarrantyManagement.Application.Validators.Sales;


    public class CreateSaleRequestValidator:AbstractValidator<CreateSaleRequest>
    {

   public CreateSaleRequestValidator()
    {
        RuleFor(s=>s.CustomerId)
        .NotEmpty().WithMessage("The CustomerId is required");

        RuleFor(s=>s.ProductId)
        .NotEmpty().WithMessage("The ProductId is required");


        RuleFor(s=>s.SerialNumber)
        .NotEmpty().WithMessage("The SerialNumber is required")
        .MaximumLength(300).WithMessage("SerialNumber must be less than 300 characters");

        RuleFor(s=>s.Price).GreaterThan(0).WithMessage("The price must be grater than 0 ");
        


    }
    }