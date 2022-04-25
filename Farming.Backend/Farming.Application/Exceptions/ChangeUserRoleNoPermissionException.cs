using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class ChangeUserRoleNoPermissionException : FarmingException
    {
        public ChangeUserRoleNoPermissionException() : base("You dont have permission to change user role")
        {
        }
    }
}
