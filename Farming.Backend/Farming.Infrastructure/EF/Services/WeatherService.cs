using Farming.Application.DTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

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
                            SetDayHourRegion(emergencyWeather);
                            return emergencyWeather;
                        }
                        return null;
                    }

                    weather.IsEmergency = false;

                    SetDayHourRegion(weather);
                    return weather;
                }

                return null;
            }
        }

        private void SetDayHourRegion(WeatherDto weather)
        {
            var split = weather.CurrentConditions.DayHour.Split(' ');
            if (split.Length != 3)
            {
                return;
            }

            var day = split[0];
            var hour = split[1].Split(":").First();
            var modifier = split[2];

            var hourInt = Int16.Parse(hour);

            if (modifier.Equals("PM") && hourInt < 12)
            {
                hourInt += 12;
            }

            if (modifier.Equals("AM") && hourInt == 12)
            {
                hourInt -= 12;
            }

            weather.CurrentConditions.Hour = hourInt < 10 ? $"0{hourInt}:00" : $"{hourInt}:00";
            weather.CurrentConditions.Day = day;

            var regionSplit = weather.Region.Split(',');
            if (regionSplit.Length == 2)
            {
                weather.Location = Regex.Replace(regionSplit[0], @"\s+", "");
                weather.Region = Regex.Replace(regionSplit[1], @"\s+", "");
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
