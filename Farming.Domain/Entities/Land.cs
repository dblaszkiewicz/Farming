using Farming.Domain.Consts;
using Farming.Domain.Exceptions;
using Farming.Domain.ValueObjects.Land;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class Land : AggregateRoot<LandId>
    {
        public LandId Id { get; }
        public LandClass LandCLass { get; }
        public LandStatus Status { get; private set; }
        public LandName Name { get; }
        public LandArea Area { get; }

        public ICollection<LandRealization> LandRealizations { get; }

        public Land()
        {
            // for EF
        }

        public Land(LandClass landClass, LandStatus status, LandName name, LandArea area)
        {
            Id = new LandId(Guid.NewGuid());
            LandCLass = landClass;
            Status = status;
            Name = name;
            Area = area;

            LandRealizations = new HashSet<LandRealization>();
        }

        public bool IsStatusSuitableForPlantAction()
        {
            return Status.IsSuitableForPlantAction();
        }

        internal void ChangeStatusAfterPlantAction()
        {
            if (!IsStatusSuitableForPlantAction())
            {
                throw new BadLandStatusForPlantActionException();
            }

            Status = new LandStatus(LandStatusEnum.Planted);
        }
    }
}
