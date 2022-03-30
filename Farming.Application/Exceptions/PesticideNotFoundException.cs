using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class PesticideNotFoundException : FarmingException
    {
        public Guid PesticideId { get; set; }
        public PesticideNotFoundException(Guid pesticideId) : base($"Pesticide with ID: '{pesticideId}' was not found")
        {
            PesticideId = pesticideId;
        }
    }
}
