using AutoMapper;
using Ryze.Application.Services.User.GetAuthenticatedUser.Dtos;
using Ryze.Application.Services.User.Login.Dtos;

namespace Ryze.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntityMapping();
    }

    private void RequestToEntityMapping()
    {
        
    }

    private void EntityToDto()
    {
        CreateMap<Domain.Entities.User, GetAuthenticatedUserDto>();
    }
}