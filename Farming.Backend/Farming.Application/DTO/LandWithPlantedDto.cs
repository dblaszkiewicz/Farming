
namespace Farming.Application.DTO
{
    public class LandWithPlantedDto
    {
        public Guid Id { get; set; }
        public string LandClass { get; set; }
        public string Name { get; set; }
        public decimal Area { get; set; }
        public int Status { get; set; }
        public bool IsPlanted { get; set; }
        public PlantedDto Planted { get; set; }
    }


    public class PlantedDto
    {
        public Guid PlantId { get; set; }
        public string PlantName { get; set; }
    }
}
