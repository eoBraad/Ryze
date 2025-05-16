namespace Ryze.Application.Services.Product.CreateProduct.Dto;

public class CreateProductDtoRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}