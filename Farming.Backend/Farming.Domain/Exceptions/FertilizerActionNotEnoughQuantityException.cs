using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class FertilizerActionNotEnoughQuantityException : FarmingException
    {
        public decimal FertilizerNeeded { get; set; }
        public FertilizerActionNotEnoughQuantityException(decimal fertilizerNeeded) : base($"There is no needed fertilizer quantity ('{fertilizerNeeded}'")
        {
            FertilizerNeeded = fertilizerNeeded;
        }
    }
}
