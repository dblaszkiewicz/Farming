using MediatR;

namespace Farming.Application.Queries
{
    public class GetFertilizerNameByIdQuery : IRequest<string>
    {
        public Guid FertilizerId { get; set; }

        public GetFertilizerNameByIdQuery(Guid fertilizerId)
        {
            FertilizerId = fertilizerId;
        }
    }
}
