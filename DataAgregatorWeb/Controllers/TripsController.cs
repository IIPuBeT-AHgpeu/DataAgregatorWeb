using DataAgregatorWeb.Models;
using DataAgregatorWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataAgregatorWeb.Controllers
{
    [Route("trips")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private IRepository<Trip> _rep;
        private IWeatherService<FromWeatherAPIModel> _service;

        private ISimpleLogger _logger;

        public TripsController(IRepository<Trip> rep, IWeatherService<FromWeatherAPIModel> service, ISimpleLogger logger)
        {
            _rep = rep;
            _service = service;
            _logger = logger;
        }

        // GET: trips/all
        [HttpGet]
        [Route("all")]
        public IEnumerable<Trip> GetAll()
        {
            _logger.Log(LogLevel.Information, "Get all trips.");
            return _rep.GetAll();
        }

        // GET trips/5
        [HttpGet("{id}")]
        public Trip? Get(int id)
        {
            _logger.Log(LogLevel.Information, $"Get trip with id == {id}.");

            return _rep.GetOne(id);
        }

        // POST trips/
        [HttpPost]
        public bool Post([FromBody] FromClientTripModel model)
        {
            Trip trip = new Trip(_service.GetRealtimeWeather().Result, model);

            DateTime now = DateTime.Now;
            trip.Date = DateOnly.FromDateTime(now);
            trip.Time = TimeOnly.FromDateTime(now);

            _logger.Log(LogLevel.Information, "Create trip.");

            return _rep.Create(trip);
        }

        // PUT trips/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Trip value)
        {
            Trip trip = _rep.GetOne(id);

            trip.Copy(value);

            _logger.Log(LogLevel.Information, $"Update trip with id == {id}.");

            return _rep.Update(trip);
        }

        // DELETE trips/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _logger.Log(LogLevel.Information, $"Delete trip with id == {id}.");

            return _rep.Delete(id);
        }
    }
}
