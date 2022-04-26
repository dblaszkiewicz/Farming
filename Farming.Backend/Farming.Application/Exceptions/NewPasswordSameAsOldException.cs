using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class NewPasswordSameAsOldException : FarmingException
    {
        public NewPasswordSameAsOldException() : base("New password can't be like the old")
        {
        }
    }
}
