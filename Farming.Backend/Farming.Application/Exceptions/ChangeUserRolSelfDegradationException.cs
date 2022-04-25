using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class ChangeUserRolSelfDegradationException : FarmingException
    {
        public ChangeUserRolSelfDegradationException() : base("You cannot lower role yourself")
        {
        }
    }
}
