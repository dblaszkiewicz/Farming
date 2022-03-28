using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class PlantActionNotEnoughQuantityException : FarmingException
    {
        public decimal PlantNeeded { get; set; }
        public PlantActionNotEnoughQuantityException(decimal plantNeeded) : base($"There is no needed plant quantity ('{plantNeeded}')")
        {
            PlantNeeded = plantNeeded;
        }
    }
}
