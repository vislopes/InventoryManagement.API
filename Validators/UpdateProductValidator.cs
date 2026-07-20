using FluentValidation;
using InventoryManagement.API.DTOs.Products;

namespace InventoryManagement.API.Validators;

public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");
        
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Product description must not exceed 500 characters.");
        
        RuleFor(x => x.SKU)
            .NotEmpty()
            .MaximumLength(50).WithMessage("Product SKU must not exceed 50 characters.");

        RuleFor(x => x.CostPrice)
            .GreaterThan(0).WithMessage("Product price must be greater than zero.");
        
        RuleFor(x => x.SalesPrice)
            .GreaterThan(0).WithMessage("Product price must be greater than zero.");

        RuleFor(x => x.QuantityInStock)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity in stock cannot be negative.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Category ID must be greater than zero.");

        RuleFor(x => x.SupplierId)
            .GreaterThan(0).WithMessage("Supplier ID must be greater than zero.");
    }
}
