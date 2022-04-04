﻿
namespace Farming.Infrastructure.EF.Models
{
    internal class PlantWarehouseReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PlantWarehouseStateReadModel> States { get; set; }
    }
}