using API.Chapter04.WeatherForecastService;
using Microsoft.AspNetCore.Mvc;

namespace API.Chapter04.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(IWeatherService weatherService) : ControllerBase
{
    private static List<string> _leakyList = new List<string>();
    private List<string> _properList = new List<string>();
    private readonly IWeatherService _weatherService = weatherService;

    [HttpGet]
    public IEnumerable<string> Get()
    {
        // Simulate memory leak
        _leakyList.Add(new string('a', 1024 * 1024)); // Add 1MB to the list

        return new string[] { "Data added to the leaky list. Total items: " + _leakyList.Count };
    }

    [HttpGet]
    [Route("GetRefactored")]
    public IEnumerable<string> GetRefactored()
    {
        // Simulate memory leak
        _properList.Add(new string('a', 1024 * 1024)); // Add 1MB to the list

        return new string[] { "Data added to the proper list. Total items: " + _properList.Count };
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetWeather(string city)
    {
        try
        {
            var weatherData = await _weatherService.GetWeatherAsync(city);
            return Ok(weatherData);
        }
        catch (HttpRequestException ex)
        {
            return BadRequest("Error fetching weather data");
        }
    }

}
