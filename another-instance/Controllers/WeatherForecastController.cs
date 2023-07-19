using Microsoft.AspNetCore.Mvc;

namespace another_instance.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly HttpClient _httpClient = new() { BaseAddress = new Uri("http://localhost:5161") };

    [HttpGet(Name = "callPlaylist")]
    public async Task<object> Get()
    {
        HttpResponseMessage res = await _httpClient.GetAsync("/playlist");

        return res.Content.ReadAsStringAsync();

    }
}
