namespace Farming.Application.Requests
{
    public class AddPlantActionRequest
    {
        public Guid LandId { get; set; }
        public Guid PlantId { get; set; }
        public Guid PlantWarehouseId { get; set; }
        public decimal Quantity { get; set; }
    }
}
