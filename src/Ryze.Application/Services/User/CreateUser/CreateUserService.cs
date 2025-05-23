﻿using AutoMapper;
using Ryze.Application.Services.User.CreateUser.Dto;
using Ryze.Domain.Interfaces.Generators;
using Ryze.Domain.Interfaces.Repositories;
using Ryze.Infrastructure.Exceptions;

namespace Ryze.Application.Services.User.CreateUser;

public class CreateUserService(IMapper mapper, IPasswordEncripterGenerator encripterGenerator, IUserRepository userRepository)
{
    private readonly IMapper _mapper = mapper;
    private readonly IPasswordEncripterGenerator _passwordEncripterGenerator = encripterGenerator;
    private readonly IUserRepository _userRepository = userRepository;
    
    public async Task<Guid> CreateUserAsync(CreateUserRequestDto request)
    {
        ValidateRequest(request);
        
        var user = _mapper.Map<Domain.Entities.User>(request);

        user.Password = _passwordEncripterGenerator.Encrypt(user.Password);
        
        user.BirthDate = DateTime.SpecifyKind(user.BirthDate, DateTimeKind.Utc);
        
        var userAlreadyExists = await _userRepository.GetUserByEmailAsync(user.Email);
        
        if (userAlreadyExists != null)
        {
            throw new ValidationException(["User already exists."]);
        }
        
        user = await _userRepository.CreateUserAsync(user);

        return user!.Id;
    }
    
    private void ValidateRequest(CreateUserRequestDto request)
    {
        var validator = new CreateUserValidator();
        
        var validationResult = validator.Validate(request);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}