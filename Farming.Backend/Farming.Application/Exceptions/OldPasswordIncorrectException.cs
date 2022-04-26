using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class OldPasswordIncorrectException : FarmingException
    {
        public OldPasswordIncorrectException() : base("Old password incorrect")
        {
        }
    }
}
