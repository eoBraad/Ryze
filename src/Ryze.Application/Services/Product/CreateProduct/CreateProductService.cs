using AutoMapper;
using Ryze.Application.Services.Product.CreateProduct.Dto;
using Ryze.Domain.Interfaces.Repositories;
using Ryze.Infrastructure.Exceptions;

namespace Ryze.Application.Services.Product.CreateProduct;

public class CreateProductService(IProductRepository repository, IMapper mapper)
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task CreateProduct(CreateProductDtoRequest request)
    {
        Validate(request);

        var product = _mapper.Map<Domain.Entities.Product>(request);

        await _repository.CreateProductAsync(product);
    }

    private static void Validate(CreateProductDtoRequest request)
    {
        var validator = new CreateProductValidator();
        
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
    }
}