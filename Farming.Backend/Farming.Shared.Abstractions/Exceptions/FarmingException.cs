
namespace Farming.Shared.Abstractions.Exceptions
{
    public abstract class FarmingException : Exception
    {
        public string Message { get; set; }

        protected FarmingException(string message) : base(message)
        {
            Message = message;
        }
    }
}
