﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Ryze.Domain.Entities;
using Ryze.Domain.Interfaces.Repositories;
using Ryze.Infrastructure.Database;

namespace Ryze.Infrastructure.Repositories;

public class UserRepository(RyzeDbContext context, IWorkUnity workUnity) : IUserRepository
{
    private readonly RyzeDbContext _context = context;
    private readonly IWorkUnity _workUnity = workUnity;
    

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public Task<User?> GetByIdAsync(Guid userId)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }
}