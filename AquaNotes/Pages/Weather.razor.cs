using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace AquaNotes.Pages;

public partial class WeatherBase : ComponentBase
{
    [Inject]
    public HttpClient? Http { get; set; }

    public IQueryable<WeatherForecast>? forecasts;

    protected override async Task OnInitializedAsync()
    {
        if (Http != null)
            forecasts = (await Http.GetFromJsonAsync<List<WeatherForecast>>("sample-data/weather.json"))!.AsQueryable();
    }

    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
