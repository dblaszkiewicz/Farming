using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class Pesticide : Tenant
    {
        public PesticideId Id { get; }
        public PesticideTypeId PesticideTypeId { get; }
        public PesticideRequiredAmountPerHectare RequiredAmountPerHectare { get; }
        public PesticideName Name { get; }
        public PesticideDescription Description { get; }

        public PesticideType PesticideType { get; }
        public ICollection<Plant> SuitablePlants { get; }
        public ICollection<PesticideAction> PesticideActions { get; }
        public ICollection<PesticideWarehouseDelivery> PesticideWarehouseDeliveries { get; }
        public ICollection<PesticideWarehouseState> PesticideWarehouseStates { get; }
    }
}
