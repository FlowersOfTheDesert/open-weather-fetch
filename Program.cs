using Microsoft.Extensions.DependencyInjection;
using Refit;
using Microsoft.Extensions.Http;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        
        services.AddRefitClient<IWeatherApiService>()
            .ConfigureHttpClient(c => 
            {
                c.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5");
            });

        var serviceProvider = services.BuildServiceProvider();
        var weatherService = serviceProvider.GetRequiredService<IWeatherApiService>();

        try
        {
            string apiKey = "561c37a8b75aed0f4757fd92e2994a4e";
            double latitude = 32.50513000;
            double longitude = -115.14771000;

            var weather = await weatherService.GetCurrentWeatherByCoordinates(
                latitude,
                longitude,
                apiKey
            );
            Console.WriteLine($"Temperature: {weather.Main.Temp}°C");
        }
        catch (ApiException ex)
        {
            Console.WriteLine($"Error fetching weather: {ex.Message}");
        }
    }
}