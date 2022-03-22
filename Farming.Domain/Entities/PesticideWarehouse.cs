using Farming.Domain.Events;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PesticideWarehouse : AggregateRoot<PesticideWarehouseId>
    {
        public PesticideWarehouseId Id { get; }

        public ICollection<PesticideWarehouseState> States { get; }

        public PesticideWarehouse()
        {
            Id = new PesticideWarehouseId(Guid.NewGuid());

            States = new HashSet<PesticideWarehouseState>();
        }

        public void AddDelivery(PesticideWarehouseDelivery delivery)
        {
            var state = GetStateByPesticideId(delivery.PesticideId);
            if (state is null)
            {
                state = new PesticideWarehouseState(delivery.PesticideId);
                States.Add(state);
                AddEvent(new PesticideWarehouseStateAdded(this, state));
            }

            state.AddDelivery(delivery);
        }

        private PesticideWarehouseState GetStateByPesticideId(PesticideId pesticideId)
        {
            return States.FirstOrDefault(x => x.PesticideId == pesticideId);
        }
    }
}
