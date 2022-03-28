using Farming.Domain.Entities;

namespace Farming.Domain.Services
{
    public interface IPlantDomainService
    {
        void ProcessPlantAction(Season season, PlantWarehouse warehouse, PlantAction action, Land land, Plant plant);
    }
}
