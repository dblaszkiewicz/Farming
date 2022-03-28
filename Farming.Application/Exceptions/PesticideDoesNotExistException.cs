using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class PesticideDoesNotExistException : FarmingException
    {
        public Guid PesticideId { get; set; }
        public PesticideDoesNotExistException(Guid pesticideId) : base($"Pesticide with ID: '{pesticideId}' does not exist")
        {
            PesticideId = pesticideId;
        }
    }
}
