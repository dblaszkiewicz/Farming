﻿
namespace Farming.Application.Services
{
    public interface IUserReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
        Task<bool> IsLoginAlreadyTakenAsync(string login);
        Task<bool> IsAdminByIdAsync(Guid id);
        Task<bool> AreMoreActiveAdministratorsAsync(Guid id);
        Task<bool> IsUserActiveByIdAsync(Guid id);
    }
}
