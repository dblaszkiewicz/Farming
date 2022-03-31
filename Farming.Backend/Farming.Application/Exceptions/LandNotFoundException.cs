using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class LandNotFoundException : FarmingException
    {
        public Guid LandId { get; set; }
        public LandNotFoundException(Guid landId) : base($"Land with ID: '{landId}' was not found.")
        {
            LandId = landId;
        }
    }
}
