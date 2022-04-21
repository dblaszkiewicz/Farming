using Farming.Application.DTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Farming.Infrastructure.EF.Services
{
    internal class WeatherService : IWeatherService
    {
        public async Task<WeatherDto> GetWeatherAsync(string place)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://weatherdbi.herokuapp.com/data/weather/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                place = RemovePolishChars(place.ToLower());

                var response = await client.GetAsync(place);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var weather = JsonConvert.DeserializeObject<WeatherDto>(json);

                    if (weather.Region is null)
                    {
                        var emergencyResponse = await client.GetAsync("krakow");

                        if (emergencyResponse.IsSuccessStatusCode)
                        {
                            var emergencyJson = await emergencyResponse.Content.ReadAsStringAsync();
                            var emergencyWeather = JsonConvert.DeserializeObject<WeatherDto>(emergencyJson);
                            emergencyWeather.IsEmergency = true;
                            return emergencyWeather;
                        }
                        return null;
                    }

                    weather.IsEmergency = false;

                    // TODO: jezeli region nie jest Poland (zbieżność nazw miejscowosci) to zrobic awaryjna pogode na krakow 
                    return weather;
                }

                return null;
            }
        }

        private string RemovePolishChars(string input)
        {
            return input
                .Replace("ą", "a")
                .Replace("ć", "c")
                .Replace("ę", "e")
                .Replace("ł", "l")
                .Replace("ń", "n")
                .Replace("ó", "o")
                .Replace("ś", "s")
                .Replace("ż", "z")
                .Replace("ź", "z");
        }
    }
}
