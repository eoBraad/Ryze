using AutoMapper;
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
}