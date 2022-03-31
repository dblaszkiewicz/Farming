using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class PesticideActionNotEnoughQuantityException : FarmingException
    {
        public decimal PesticideNeeded { get; set; }
        public PesticideActionNotEnoughQuantityException(decimal pesticideNeeded) : base($"There is no needed pesticide quantity ('{pesticideNeeded}')")
        {
            PesticideNeeded = pesticideNeeded;
        }
    }
}
