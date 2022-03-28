﻿
namespace Farming.Application.DTO
{
    public class AddPlantActionDto
    {
        public Guid LandId { get; set; }
        public Guid UserId { get; set; }
        public Guid PlantId { get; set; }
        public Guid PlantWarehouseId { get; set; }
        public decimal Quantity { get; set; }
    }
}
