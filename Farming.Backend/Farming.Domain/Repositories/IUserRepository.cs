﻿using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;

namespace Farming.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetAsync(UserId id);
        Task<User> GetAsync(UserId id, Guid tenantId);
        Task<User> GetByLoginAndPasswordAsync(string login, string password);
        Task UpdateAsync(User season);
    }
}
