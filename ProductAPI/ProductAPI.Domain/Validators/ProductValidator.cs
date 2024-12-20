using FluentValidation;
using ProductAPI.Domain.Entities;

namespace ProductAPI.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product Name is required")
                .MaximumLength(100).WithMessage("Product name max lengh is 100");

            RuleFor(x => x.Price.Value)
                .GreaterThan(0).WithMessage("The price is required");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Invalid Stock");
        }
    }
}