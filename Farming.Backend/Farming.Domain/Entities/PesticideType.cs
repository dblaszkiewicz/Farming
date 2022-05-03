using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PesticideType : AggregateRoot<PesticideTypeId>
    {
        public PesticideTypeName Name { get; }
        public PesticideTypeDescription Description { get; }

        public ICollection<Pesticide> Pesticides { get; }

        public PesticideType(PesticideTypeName name, PesticideTypeDescription description)
        {
            Id = new PesticideTypeId(Guid.NewGuid());
            Name = name;
            Description = description;

            Pesticides = new HashSet<Pesticide>();
        }

        public void AddPesticide(Pesticide pesticide)
        {
            Pesticides.Add(pesticide);
            IncrementVersion();
        }
    }
}
