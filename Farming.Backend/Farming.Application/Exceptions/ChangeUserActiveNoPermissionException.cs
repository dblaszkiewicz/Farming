using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class ChangeUserActiveNoPermissionException : FarmingException
    {
        public ChangeUserActiveNoPermissionException() : base("You dont have permission to change user activity")
        {
        }
    }
}
