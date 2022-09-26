using AppAPI.Application.ViewModels.Products;
using FluentValidation;

namespace AppAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please insert a name")
                .MaximumLength(150)
                .MinimumLength(3)
                .WithMessage("Please insert a name in between 3-150 chars!");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please insert an amount of the stock!")
                .Must(s => s >= 0)
                .WithMessage("Stock can not be negative");


            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please insert a value for price!")
                .Must(s => s >= 0)
                .WithMessage("Price can not be negative");

        }
    }
}
