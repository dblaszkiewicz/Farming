using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class PlantDoesNotExistException : FarmingException
    {
        public Guid PlantId { get; set; }
        public PlantDoesNotExistException(Guid plantId) : base($"Plant with ID: '{plantId}' does not exist")
        {
            PlantId = plantId;
        }
    }
}
