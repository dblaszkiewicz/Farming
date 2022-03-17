using Farming.Domain.ValueObjects.Plant;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PlantWarehouse : AggregateRoot<PlantWarehouseId>
    {
        public PlantWarehouseId Id { get; }

        public ICollection<PlantWarehouseState> States { get; }

        public PlantWarehouse()
        {
            Id = new PlantWarehouseId(Guid.NewGuid());
            States = new HashSet<PlantWarehouseState>();
        }
    }
}
