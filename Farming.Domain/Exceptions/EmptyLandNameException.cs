using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyLandNameException : FarmingException
    {
        public EmptyLandNameException() : base("Land Name cannot be empty.")
        {
        }
    }
}
