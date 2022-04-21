using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Services;
using MediatR;
using System.Text;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetWeatherByPlaceHandler : IRequestHandler<GetWeatherByPlaceQuery, WeatherDto>
    {
        private readonly IWeatherService _weatherService;

        public GetWeatherByPlaceHandler(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<WeatherDto> Handle(GetWeatherByPlaceQuery request, CancellationToken cancellationToken)
        {
            return await _weatherService.GetWeatherAsync(request.Place);
        }
    }
}
