﻿
namespace Farming.Infrastructure.EF.Models
{
    internal class PesticideReadModel : BaseTenantReadModel
    {
        public Guid Id { get; set; }
        public Guid PesticideTypeId { get; set; }
        public decimal RequiredAmountPerHectare { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PesticideTypeReadModel PesticideType { get; set; }
        public ICollection<PlantReadModel> SuitablePlants { get; set; }
        public ICollection<PesticideActionReadModel> PesticideActions { get; set; }
        public ICollection<PesticideWarehouseDeliveryReadModel> PesticideWarehouseDeliveries { get; set; }
        public ICollection<PesticideWarehouseStateReadModel> PesticideWarehouseStates { get; set; }

        public PesticideReadModel()
        {

        }

        internal PesticideReadModel(string name, string description, decimal requiredAmountPerHectare, Guid tenantId, List<PlantReadModel> suitablePlants)
        {
            Id = Guid.NewGuid();
            SuitablePlants = suitablePlants;
            Name = name;
            Description = description;
            RequiredAmountPerHectare = requiredAmountPerHectare;
            TenantId = tenantId;

            PesticideActions = new HashSet<PesticideActionReadModel>();
            PesticideWarehouseDeliveries = new HashSet<PesticideWarehouseDeliveryReadModel>();
            PesticideWarehouseStates = new HashSet<PesticideWarehouseStateReadModel>();
        }
    }
}
