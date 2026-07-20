using FluentValidation;
using InventoryManagement.API.DTOs.Products;

namespace InventoryManagement.API.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100).WithMessage("The product name cannot exceed 100 characters");

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("The product description cannot exceed 500 characters.");

        RuleFor(x => x.SKU)
            .NotEmpty().WithMessage("The SKU is required.")
            .MaximumLength(50).WithMessage("The SKU cannot exceed 50 characters.");

        RuleFor(p => p.CostPrice)
            .GreaterThan(0).WithMessage("The cost price must be greater than zero.");

        RuleFor(p => p.QuantityInStock)
            .GreaterThanOrEqualTo(0).WithMessage("The quantity in stock cannot be negative.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("A valid category must be selected.");
    }
}
