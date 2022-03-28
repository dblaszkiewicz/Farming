using Farming.Application.DTO;
using Farming.Infrastructure.EF.Models;

namespace Farming.Infrastructure.EF.Queries
{
    internal static class Extensions
    {
        public static PlantDto AsDto(this PlantReadModel readModel)
        {
            return new PlantDto()
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Description = readModel.Description,
                RequiredAmountPerHectare = readModel.RequiredAmountPerHectare
            };
        }
    }
}
