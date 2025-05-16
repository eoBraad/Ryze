using FluentValidation;
using Ryze.Application.Services.Product.CreateProduct.Dto;

namespace Ryze.Application.Services.Product.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductDtoRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required");
        
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required")
            .LessThan(0)
            .WithMessage("price must be greater than 0");
    }
}