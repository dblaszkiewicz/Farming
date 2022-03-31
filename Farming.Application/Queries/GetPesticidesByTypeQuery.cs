using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetPesticidesByTypeQuery : IRequest<IEnumerable<PesticideDto>>
    {
        public Guid PesticideTypeId { get; set; }
        public GetPesticidesByTypeQuery(Guid pesticideTypeId)
        {
            PesticideTypeId = pesticideTypeId;
        }
    }
}
