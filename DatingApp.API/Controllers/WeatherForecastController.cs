using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatingApp.API.Data;

namespace DatingApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    // public WeatherForecastController(DataContext context)
    // {
    //     _context = context; 
    // }
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly DataContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext context)
    {
        _logger = logger;
        _context = context; 
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> GetValues()
    {
        var values = await _context.Values.ToListAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public  async Task<IActionResult> GetValue(int id)
    {
        var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
        return Ok(value);
    }
}
