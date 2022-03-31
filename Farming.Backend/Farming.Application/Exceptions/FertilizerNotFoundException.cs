using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class FertilizerNotFoundException : FarmingException
    {
        public Guid FertilizerId { get; set; }
        public FertilizerNotFoundException(Guid fertilizerId) : base($"Fertilizer with ID '{fertilizerId}' was not found.")
        {
            FertilizerId = fertilizerId;
        }
    }
}
