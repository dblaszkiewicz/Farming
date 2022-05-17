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

                try
                {
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

                            return JsonConvert.DeserializeObject<WeatherDto>(ExampleData());
                        }

                        weather.IsEmergency = false;

                        SetDayHourRegion(weather);
                        return weather;
                    }
                } 
                catch (Exception ex)
                {

                }

                return JsonConvert.DeserializeObject<WeatherDto>(ExampleData());
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

        private string ExampleData()
        {
            return "{\"region\":\"Kraków, Poland\",\"currentConditions\":{\"dayhour\":\"Monday 3:00 PM\",\"temp\":{\"c\":24,\"f\":75}," +
                "\"precip\":\"0%\",\"humidity\":\"30%\",\"wind\":{\"km\":8,\"mile\":5},\"iconURL\":\"https://ssl.gstatic.com/onebox/weather/64/partly_cloudy.png\",\"comment\":\"Partly cloudy\"},\"next_days\":[" +
                "{\"day\":\"Monday\",\"comment\":\"Scattered showers\",\"max_temp\":{\"c\":24,\"f\":75},\"min_temp\":{\"c\":11,\"f\":51},\"iconURL\":\"https://ssl.gstatic.com/onebox/weather/48/rain_s_cloudy.png\"}," +
                "{\"day\":\"Tuesday\",\"comment\":\"Scattered showers\",\"max_temp\":{\"c\":20,\"f\":68},\"min_temp\":{\"c\":5,\"f\":41},\"iconURL\":\"https://ssl.gstatic.com/onebox/weather/48/rain_s_cloudy.png\"}," +
                "{\"day\":\"Wednesday\",\"comment\":\"Sunny\",\"max_temp\":{\"c\":18,\"f\":65},\"min_temp\":{\"c\":4,\"f\":40},\"iconURL\":\"https://ssl.gstatic.com/onebox/weather/48/sunny.png\"}," +
                "{\"day\":\"Thursday\",\"comment\":\"Mostly sunny\",\"max_temp\":{\"c\":25,\"f\":77},\"min_temp\":{\"c\":9,\"f\":49},\"iconURL\":\"https://ssl.gstatic.com/onebox/weather/48/partly_cloudy.png\"}," +
                "{\"day\":\"Friday\",\"comment\":\"Scattered thunderstorms\",\"max_temp\":{\"c\":26,\"f\":79},\"min_temp\":{\"c\":14,\"f\":58},\"iconURL\":\"https://ssl.gstatic.com/onebox/weather/48/rain_s_cloudy.png\"}," +
                "{\"day\":\"Saturday\",\"comment\":\"Thunderstorm\",\"max_temp\":{\"c\":24,\"f\":76},\"min_temp\":{\"c\":13,\"f\":55},\"iconURL\":\"https://ssl.gstatic.com/onebox/weather/48/thunderstorms.png\"}," +
                "{\"day\":\"Sunday\",\"comment\":\"Showers\",\"max_temp\":{\"c\":21,\"f\":69},\"min_temp\":{\"c\":11,\"f\":51},\"iconURL\":\"https://ssl.gstatic.com/onebox/weather/48/rain_light.png\"}," +
                "{\"day\":\"Monday\",\"comment\":\"Showers\",\"max_temp\":{\"c\":21,\"f\":70},\"min_temp\":{\"c\":11,\"f\":51},\"iconURL\":\"https://ssl.gstatic.com/onebox/weather/48/rain_light.png\"}]" +
                ",\"contact_author\":{\"email\":\"communication.with.users@gmail.com\",\"auth_note\":\"Mail me for feature requests, improvement, bug, help, ect... " +
                "Please tell me if you want me to provide any other free easy-to-use API services\"},\"data_source\":\"https://www.google.com/search?lr=lang_en&q=weather+in+krakow\"}";
        }
    }
}
