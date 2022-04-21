using Farming.Application.DTO;

namespace Farming.Infrastructure.EF.Services
{
    internal interface IWeatherService
    {
        Task<WeatherDto> GetWeatherAsync(string place);
    }
}
