using AutoMapper;
using Ryze.Application.Services.Lead.UserCreateLead.Dtos;
using Ryze.Domain.Entities;
using Ryze.Domain.Interfaces.Repositories;
using Ryze.Infrastructure.Exceptions;

namespace Ryze.Application.Services.Lead.UserCreateLead;

public class UserCreateLeadService(ILeadRepository leadRepository, IMapper mapper)
{
    private readonly ILeadRepository _leadRepository = leadRepository;
    private readonly IMapper _mapper = mapper;
    
    public async Task CreateLeadAsync(UserCreateLeadRequestDto request, Guid userId)
    {
        Validate(request);
        var lead = _mapper.Map<Domain.Entities.Lead>(request);
        
        lead.AssignedTo.Id = userId;
        
        lead.Products = request.ProductIds.Select(p => new Product
        {
            Id = p
        }).ToList();
        
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