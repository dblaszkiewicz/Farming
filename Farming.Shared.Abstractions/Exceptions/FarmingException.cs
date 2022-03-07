
namespace Farming.Shared.Abstractions.Exceptions
{
    public abstract class FarmingException : Exception
    {
        protected FarmingException(string message) : base(message)
        { 
        }
    }
}
