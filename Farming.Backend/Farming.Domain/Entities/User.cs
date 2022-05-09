using Farming.Domain.Events;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.User;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class User : AggregateRoot<UserId>
    {
        public UserLogin Login { get; }
        public UserPassword Password { get; private set; }
        public UserName Name { get; }
        public UserActive Active { get; private set; }
        public UserIsAdmin IsAdmin { get; private set; }
        public UserCreated Created { get; private set; }

        public ICollection<FertilizerWarehouseDelivery> FertilizerDeliveries { get; }
        public ICollection<PesticideWarehouseDelivery> PesticideDeliveries { get; }
        public ICollection<PlantWarehouseDelivery> PlantDeliveries { get; }
        public ICollection<PesticideAction> PesticideActions { get; }
        public ICollection<FertilizerAction> FertilizerActions { get; }
        public ICollection<PlantAction> PlantActions { get; }


        public User(UserLogin login, UserPassword password, UserName name)
        {
            Id = Guid.NewGuid();
            Created = DateTimeOffset.UtcNow;
            Login = login;
            Name = name;
            Password = password;
            IsAdmin = false;
            Active = true;
        }

        public void ChangeActive()
        {
            Active = new UserActive(!Active);
            AddEvent(new UserChangeActive(this, Active));
            IncrementVersion();
        }

        public void ChangeRole()
        {
            IsAdmin = new UserIsAdmin(!IsAdmin);
            AddEvent(new UserChangeIsAdmin(this, IsAdmin));
            IncrementVersion();
        }

        public void ChangePassword(UserPassword password)
        {
            Password = password;
            AddEvent(new UserChangePassword(this, Password));
            IncrementVersion();
        }
    }
}
