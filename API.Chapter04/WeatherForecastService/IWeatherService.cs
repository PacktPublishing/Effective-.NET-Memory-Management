namespace API.Chapter04.WeatherForecastService;

public interface IWeatherService
{
    Task<string> GetWeatherAsync(string city);
}
