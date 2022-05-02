using Farming.Domain.Entities;

namespace Farming.Application.Auth
{
    public interface IAuthenticateService
    {
        string Authenticate(User user);
    }
}
