
namespace Farming.Application.DTO
{
    public class PesticideStateDto
    {
        public Guid PesticideId { get; set; }
        public Guid PesticideTypeId { get; set; }
        public string PesticideName { get; set; }
        public string PesticideDescription { get; set; }
        public string PesticideTypeName { get; set; }
        public string PesticideTypeDescription { get; set; }
        public decimal Quantity { get; set; }
        public decimal RequiredAmountPerHectare { get; set; }
        public decimal EnoughForArea { get; set; }
    }
}
