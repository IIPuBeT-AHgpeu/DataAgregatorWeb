namespace DataAgregatorWeb.Services
{
    public interface IWeatherService<T> where T : class
    {
        public Task<T?> GetRealtimeWeather();

        public Task<T?> GetPredict(DateTime datetime, double lat, double lon);
    }
}
