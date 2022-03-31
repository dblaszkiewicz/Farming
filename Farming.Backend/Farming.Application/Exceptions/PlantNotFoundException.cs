using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class PlantNotFoundException : FarmingException
    {
        public Guid PlantId { get; set; }
        public PlantNotFoundException(Guid plantId) : base($"Plant with ID: '{plantId}' was not found")
        {
            PlantId = plantId;
        }
    }
}
