using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class ChangeUserSelfDeactivationException : FarmingException
    {
        public ChangeUserSelfDeactivationException() : base("You cannot deactivate yourself")
        {
        }
    }
}
