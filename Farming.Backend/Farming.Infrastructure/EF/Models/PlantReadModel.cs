﻿
namespace Farming.Infrastructure.EF.Models
{
    internal class PlantReadModel : BaseTenantReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal RequiredAmountPerHectare { get; set; }

        public ICollection<FertilizerReadModel> SuitableFertilizers { get; set; }
        public ICollection<PesticideReadModel> SuitablePesticides { get; set; }
        public ICollection<PlantActionReadModel> PlantActions { get; set; }
        public ICollection<PlantWarehouseDeliveryReadModel> PlantWarehouseDeliveries { get; set; }
        public ICollection<PlantWarehouseStateReadModel> PlantWarehouseStates { get; set; }

        internal PlantReadModel(string name, decimal requiredAmountPerHectare, string unit, string description, Guid tenantId)
        {
            Id = Guid.NewGuid();
            Name = name;
            RequiredAmountPerHectare = requiredAmountPerHectare;
            Description = description;
            Unit = unit;
            TenantId = tenantId;

            SuitableFertilizers = new HashSet<FertilizerReadModel>();
            SuitablePesticides = new HashSet<PesticideReadModel>();
            PlantActions = new HashSet<PlantActionReadModel>();
            PlantWarehouseDeliveries = new HashSet<PlantWarehouseDeliveryReadModel>();
            PlantWarehouseStates = new HashSet<PlantWarehouseStateReadModel>();
        }
    }
}
