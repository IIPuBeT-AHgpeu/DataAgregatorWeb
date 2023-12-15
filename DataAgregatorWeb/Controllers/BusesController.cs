using DataAgregatorWeb.Models;
using DataAgregatorWeb.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataAgregatorWeb.Controllers
{
    [Route("buses")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private IRepository<Bus> _rep;
        private ISimpleLogger _logger;

        public BusesController(IRepository<Bus> rep, ISimpleLogger logger)
        {
            _rep = rep;
            _logger = logger;
        }

        // GET: buses/all
        [HttpGet]
        [Route("all")]
        public IEnumerable<Bus> GetAll()
        {
            _logger.Log(LogLevel.Information, "Get all buses.");

            return _rep.GetAll();
        }

        // GET buses/5
        [HttpGet("{id}")]
        public Bus? Get(int id)
        {
            _logger.Log(LogLevel.Information, $"Get bus with id == {id}.");

            return _rep.GetOne(id);
        }

        // POST buses/
        [HttpPost]
        public bool Post([FromBody] Bus value)
        {
            _logger.Log(LogLevel.Information, $"Create bus with model name == {value.Model}.");

            return _rep.Create(value);
        }

        // PUT buses/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Bus value)
        {
            Bus bus = _rep.GetOne(id);

            if (bus == null)
            {
                _logger.Log(LogLevel.Error, $"Update bus with id == {id}. | Error info: Bus with id == {id} didn't exist.");
                
                return false;
            }
            else
            {
                bus.Id = value.Id;
                bus.Capacity = value.Capacity;
                bus.Model = value.Model;

                _logger.Log(LogLevel.Information, $"Update bus with id == {id}.");

                return _rep.Update(bus);
            }
        }

        // DELETE buses/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _logger.Log(LogLevel.Information, $"Delete bus with id == {id}.");

            return _rep.Delete(id);
        }
    }
}
