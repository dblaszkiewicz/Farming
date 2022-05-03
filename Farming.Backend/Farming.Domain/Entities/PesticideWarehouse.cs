using Farming.Domain.Events;
using Farming.Domain.Exceptions;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PesticideWarehouse : AggregateRoot<PesticideWarehouseId>
    {
        public PesticideWarehouseName Name { get; }

        public ICollection<PesticideWarehouseState> States { get; }

        public PesticideWarehouse(PesticideWarehouseName name)
        {
            Id = new PesticideWarehouseId(Guid.NewGuid());
            Name = name;

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
                IncrementVersion();
            }

            state.AddDelivery(delivery);
        }

        internal void ProcessPesticideAction(PesticideId pesticideId, PesticideActionQuantity quantity)
        {
            var state = GetStateByPesticideId(pesticideId);
            if (state is null)
            {
                throw new PesticideWarehouseStateNotFoundException(pesticideId, Id);
            }

            if (!state.IsEnoughPesticide(new PesticideWarehouseQuantity(quantity)))
            {
                throw new PesticideActionNotEnoughQuantityException(quantity);
            }

            state.SpendPesticide(quantity);
        }

        private PesticideWarehouseState GetStateByPesticideId(PesticideId pesticideId)
        {
            return States.FirstOrDefault(x => x.PesticideId == pesticideId);
        }
    }
}
