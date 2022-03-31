using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class ValidateCommandException : FarmingException
    {
        public ValidateCommandException(string message) : base(message)
        {
        }
    }
}
