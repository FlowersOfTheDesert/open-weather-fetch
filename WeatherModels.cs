public class WeatherResponse
{
    public required MainInfo Main { get; set; }
    public required List<Weather> Weather { get; set; }
    public required string Name { get; set; }
}

public class MainInfo
{
    public double Temp { get; set; }
}

public class Weather
{
    public required string Main { get; set; }
    public required string Description { get; set; }
}