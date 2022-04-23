
namespace Farming.Application.DTO
{
    public class WeatherDto
    {
        public CurrentConditionDto CurrentConditions { get; set; }
        public IEnumerable<NextDayDto> Next_days { get; set; }
        public string Region { get; set; }
        public string Location { get; set; }
        public bool IsEmergency { get; set; }
    }

    public class CurrentConditionDto
    {
        public string Comment { get; set; }
        public string DayHour { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }
        public string Humidity { get; set; }
        public string IconURL { get; set; }
        public string Precip { get; set; }
        public TempDto Temp { get; set; }
        public WindDto Wind { get; set; }
    }
    public class NextDayDto
    {
        public string Comment { get; set; }
        public string Day { get; set; }
        public string IconURL { get; set; }
        public TempDto Max_temp { get; set; }
        public TempDto Min_temp { get; set; }
    }

    public class TempDto
    {
        public decimal C { get; set; }
        public decimal F { get; set; }
    }

    public class WindDto
    {
        public decimal Km { get; set; }
        public decimal Mile { get; set; }
    }
}
