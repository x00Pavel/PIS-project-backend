using Microsoft.AspNetCore.Mvc;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;

namespace video_pujcovna_back.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly DataContextFactory _contextFactory;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    private static readonly string[] Cities = new[]
    {
        "Prague", "Brno", "Ostrava", "Plzen", "Liberec", "Olomouc", "Ceske Budejovice", "Hradec Kralove", "Pardubice", "Usti nad Labem"
    };
    
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContextFactory contextFactory)
    {
        _logger = logger;
        _contextFactory = contextFactory;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        // Example usage of DB connection
        using (var context = _contextFactory.CreateDbContext())
        {
            context.Actors.Add(new Actor { FirstName = "jmeno", LastName = "prijmeni" });
            context.SaveChanges();
        }

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Location = Cities[Random.Shared.Next(Cities.Length)]
            })
            .ToArray();
    }
}