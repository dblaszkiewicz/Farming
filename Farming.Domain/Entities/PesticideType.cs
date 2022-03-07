
using Farming.Domain.ValueObjects.Pesticide;

namespace Farming.Domain.Entities
{
    public class PesticideType
    {
        public PesticideTypeId Id { get; }
        public string Name { get; }
        public string Description { get; }

        public ICollection<Pesticide> Pesticides { get; }
    }
}
