using Farming.Domain.Entities;

namespace Farming.Domain.Services
{
    public interface IFertilizerDomainService
    {
        void ProcessFertilizerAction(Season season, FertilizerWarehouse warehouse, FertilizerAction action, Fertilizer fertilizer, Land land);
    }
}
