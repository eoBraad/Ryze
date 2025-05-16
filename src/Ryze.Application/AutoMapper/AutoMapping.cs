using AutoMapper;
using Ryze.Application.Services.Lead.UserCreateLead.Dto;
using Ryze.Application.Services.User.CreateUser.Dto;
using Ryze.Application.Services.Login.GetAuthenticatedUser.Dto;
using Ryze.Application.Services.Product.CreateProduct.Dto;
using Ryze.Domain.Entities;

namespace Ryze.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntityMapping();
        EntityToDto();
    }

    private void RequestToEntityMapping()
    {
        CreateMap<CreateUserRequestDto, User>();
        CreateMap<UserCreateLeadRequestDto, Lead>();
        CreateMap<CreateProductDtoRequest, Product>();
    }

    private void EntityToDto()
    {
        CreateMap<User, GetAuthenticatedUserDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.IsActive,
                opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.FirstLogin, opt => opt.MapFrom(src => src.FirstLogin))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}