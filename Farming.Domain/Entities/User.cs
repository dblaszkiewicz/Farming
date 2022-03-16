using Farming.Domain.ValueObjects.User;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class User : AggregateRoot<UserId>
    {
        public UserId Id { get; private set; }

        public UserLogin Login { get; }
        public UserPassword Password { get; }
        public UserFirstName FirstName { get; }
        public UserLastName LastName { get; }
        public UserActive Active { get; }

        public ICollection<FertilizerWarehouseDelivery> FertilizerWarehouseDeliveries { get; }
        public ICollection<PesticideAction> PesticideActions { get; }
    }
}
