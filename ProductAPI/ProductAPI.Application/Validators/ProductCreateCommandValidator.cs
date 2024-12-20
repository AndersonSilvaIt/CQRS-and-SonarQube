using FluentValidation;
using ProductAPI.Application.Commands;

namespace ProductAPI.Application.Validators
{
    public class ProductCreateCommandValidator : AbstractValidator<ProductCreateCommand>
    {
        public ProductCreateCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product Name is required")
                .MaximumLength(100).WithMessage("Product name max lengh is 100");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("The price is required");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Invalid Stock");
        }
    }
}