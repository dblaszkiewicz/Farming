using Farming.Domain.Consts;

namespace Farming.Domain.ValueObjects.Land
{
    public record LandStatus
    {
        public LandStatusEnum Value { get; }

        public LandStatus(LandStatusEnum value)
        {
            Value = value;
        }

        public static implicit operator LandStatusEnum(LandStatus status)
            => status.Value;

        public static implicit operator LandStatus(LandStatusEnum status)
            => new(status);

        public bool IsSuitableForPlantAction()
        {
            return Value != LandStatusEnum.Planted;
        }

        public bool IsSuitableForHarvest()
        {
            return Value == LandStatusEnum.Planted;
        }

        public bool IsSuitableForDestroy()
        {
            return Value == LandStatusEnum.Planted;
        }
    }
}
