using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class AddUserNoPermissionException : FarmingException
    {
        public AddUserNoPermissionException() : base("You dont have permission to add new user")
        {
        }
    }
}
