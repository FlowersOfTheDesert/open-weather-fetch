using Refit;

public interface IWeatherApiService
{
    [Get("/weather")]
    Task<WeatherResponse> GetCurrentWeatherByCoordinates(
        [AliasAs("lat")] double latitude,
        [AliasAs("lon")] double longitude,
        string appid,
        [AliasAs("units")] string units = "metric");
}