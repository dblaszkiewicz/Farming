
namespace Farming.Infrastructure.EF.Models
{
    internal class UserReadModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }

        public ICollection<FertilizerWarehouseDeliveryReadModel> FertilizerDeliveries { get; set; }
        public ICollection<PesticideWarehouseDeliveryReadModel> PesticideDeliveries { get; set;  }
        public ICollection<PlantWarehouseDeliveryReadModel> PlantDeliveries { get; set; }
        public ICollection<PesticideActionReadModel> PesticideActions { get; set; }
        public ICollection<FertilizerActionReadModel> FertilizerActions { get; set; }
        public ICollection<PlantActionReadModel> PlantActions { get; set; }
    }
}
