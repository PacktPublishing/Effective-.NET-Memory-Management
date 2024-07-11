namespace API.Chapter04.WeatherForecastService;

public class OpenWeatherMapService : IWeatherService
{
    private readonly HttpClient _httpClient;
    public OpenWeatherMapService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetWeatherAsync(string city)
    {
        string requestUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}";
        HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
