
namespace Farming.Application.DTO
{
    public class FertilizerActionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public decimal Quantity { get; set; }
        public DateTimeOffset RealizationDate { get; set; }
    }
}
