
namespace Farming.Infrastructure.EF.Models
{
    internal class UserReadModel : BaseReadModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool IsAdmin { get; set; }
        public DateTimeOffset Created { get; set; }

        public ICollection<FertilizerWarehouseDeliveryReadModel> FertilizerDeliveries { get; set; }
        public ICollection<PesticideWarehouseDeliveryReadModel> PesticideDeliveries { get; set;  }
        public ICollection<PlantWarehouseDeliveryReadModel> PlantDeliveries { get; set; }
        public ICollection<PesticideActionReadModel> PesticideActions { get; set; }
        public ICollection<FertilizerActionReadModel> FertilizerActions { get; set; }
        public ICollection<PlantActionReadModel> PlantActions { get; set; }

        internal UserReadModel(string login, string password, string name)
        {
            Id = Guid.NewGuid();
            Active = true;
            IsAdmin = true;
            Login = login;
            Password = password;
            Name = name;

            Created = DateTimeOffset.UtcNow;

            FertilizerDeliveries = new HashSet<FertilizerWarehouseDeliveryReadModel>();
            PesticideDeliveries = new HashSet<PesticideWarehouseDeliveryReadModel>();
            PlantDeliveries = new HashSet<PlantWarehouseDeliveryReadModel>();
            PesticideActions = new HashSet<PesticideActionReadModel>();
            FertilizerActions = new HashSet<FertilizerActionReadModel>();
            PlantActions = new HashSet<PlantActionReadModel>();
        }
    }
}
