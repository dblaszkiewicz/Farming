using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetFertilizersByTypeQuery : IRequest<IEnumerable<FertilizerDto>>
    {
        public Guid FertilizerTypeId { get; set; }
        public GetFertilizersByTypeQuery(Guid fertilizerTypeId)
        {
            FertilizerTypeId = fertilizerTypeId;
        }
    }
}
