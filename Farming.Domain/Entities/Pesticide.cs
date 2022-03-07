using Farming.Domain.ValueObjects.Pesticide;

namespace Farming.Domain.Entities
{
    public class Pesticide
    {
        public PesticideId Id { get; }
        public PesticideTypeId PesticideTypeId { get; }
        public PesticideRequiredAmountPerHectare RequiredAmountPerHectare { get; }
        public PesticideName Name { get; }
        public PesticideDescription Description { get; }

        public PesticideType PesticideType { get; }
        public ICollection<Plant> SuitablePlants { get; }
    }
}
