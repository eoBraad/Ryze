using AutoMapper;
using Ryze.Application.Services.Lead.UserCreateLead.Dtos;
using Ryze.Domain.Entities;
using Ryze.Domain.Interfaces;
using Ryze.Domain.Interfaces.Repositories;
using Ryze.Infrastructure.Exceptions;

namespace Ryze.Application.Services.Lead.UserCreateLead;

public class UserCreateLeadService(ILeadRepository leadRepository, IMapper mapper, IProductRepository productRepository)
{
    private readonly ILeadRepository _leadRepository = leadRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IProductRepository _productRepository = productRepository;
    
    public async Task CreateLeadAsync(UserCreateLeadRequestDto request, Guid userId)
    {
        Validate(request);
        var lead = _mapper.Map<Domain.Entities.Lead>(request);
        
        lead.AssignedToId = userId;

        lead.Products = await _productRepository.GetProductsWithListIdsAsync(request.ProductIds);
        
        await _leadRepository.CreateAsync(lead);
    }

    private static void Validate(UserCreateLeadRequestDto request)
    {
        var validator = new UserCreateLeadRequestValidator();
        var validationResult = validator.Validate(request);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }
    }
}