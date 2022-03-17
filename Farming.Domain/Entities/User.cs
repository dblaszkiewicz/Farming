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

        public ICollection<FertilizerWarehouseDelivery> FertilizerDeliveries { get; }
        public ICollection<PesticideWarehouseDelivery> PesticideDeliveries { get; }
        public ICollection<PlantWarehouseDelivery> PlantDeliveries { get; }
        public ICollection<PesticideAction> PesticideActions { get; }
        public ICollection<FertilizerAction> FertilizerActions { get; }
        public ICollection<PlantAction> PlantActions { get; }

        public User(UserId id, UserLogin login, UserPassword password, UserFirstName firstName, UserLastName lastName)
        {
            Id = id;
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Active = new UserActive(true);
        }
    }
}
