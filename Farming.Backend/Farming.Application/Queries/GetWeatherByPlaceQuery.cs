using Farming.Application.DTO;
using MediatR;

namespace Farming.Application.Queries
{
    public class GetWeatherByPlaceQuery : IRequest<WeatherDto>
    {
        public string Place { get; set; }
        public GetWeatherByPlaceQuery(string place)
        {
            Place = place;
        }
    }
}
