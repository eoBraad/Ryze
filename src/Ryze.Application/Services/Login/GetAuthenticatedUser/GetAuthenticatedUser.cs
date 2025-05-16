using AutoMapper;
using Ryze.Infrastructure.Exceptions;
using Ryze.Application.Services.Login.GetAuthenticatedUser.Dto;
using Ryze.Domain.Interfaces.Repositories;

namespace Ryze.Application.Services.Login.GetAuthenticatedUser
{
    public class GetAuthenticatedUser(IUserRepository repository, IMapper mapper)
    {
        private readonly IUserRepository _userRepository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<GetAuthenticatedUserDto?> ExecuteAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            
            if (user == null)
            {
                throw new ValidationException(["User not found"]);
            }
            
            return _mapper.Map<GetAuthenticatedUserDto>(user);
        }
    }
}