using DataAgregatorWeb.Models;
using System.Text.Json;

namespace DataAgregatorWeb.Services
{
    public class WeatherService : IWeatherService<FromWeatherAPIModel>
    {
        private HttpClient _httpClient;
        private string _url = @"http://api.weatherapi.com/v1/current.json?key=c919824117e64b3e82a93335232711&q=48.78496,44.75223";

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }       

        public async Task<FromWeatherAPIModel?> GetRealtimeWeather()
        {
            try
            {
                string response = await _httpClient.GetStringAsync(_url);

                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<FromWeatherAPIModel>(response, options);
            }
            catch (Exception)
            {
                return null;
            }           
        }

        public Task<FromWeatherAPIModel?> GetPredict(DateTime datetime, double lat, double lon)
        {
            throw new NotImplementedException();
        }
    }
}
