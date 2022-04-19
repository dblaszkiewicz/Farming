
namespace Farming.Application.DTO
{
    public class PesticideActionDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public decimal Quantity { get; set; }
        public DateTimeOffset RealizationDate { get; set; }
    }
}
