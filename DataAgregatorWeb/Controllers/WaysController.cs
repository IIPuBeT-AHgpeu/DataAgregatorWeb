using DataAgregatorWeb.Models;
using DataAgregatorWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAgregatorWeb.Controllers
{
    [Route("ways")]
    [ApiController]
    public class WaysController : ControllerBase
    {
        private IRepository<Way> _rep;
        private ISimpleLogger _logger;

        public WaysController(IRepository<Way> rep, ISimpleLogger logger)
        {
            _rep = rep;
            _logger = logger;
        }

        // GET: ways/all
        [HttpGet]
        [Route("all")]
        public IEnumerable<Way> GetAll()
        {
            _logger.Log(LogLevel.Information, "Get all ways.");

            return _rep.GetAll();
        }

        // GET ways/5
        [HttpGet("{id}")]
        public Way? Get(int id)
        {
            _logger.Log(LogLevel.Information, $"Get way with id == {id}.");

            return _rep.GetOne(id);
        }

        // POST ways/
        [HttpPost]
        public bool Post([FromBody] Way value)
        {
            _logger.Log(LogLevel.Information, $"Create way with way name == {value.Name}.");

            return _rep.Create(value);
        }

        // PUT ways/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Way value)
        {
            Way way = _rep.GetOne(id);

            if (way == null)
            {
                _logger.Log(LogLevel.Error, $"Update way with id == {id}. | Error info: Way with id == {id} didn't exist.");

                return false;
            }
            else
            {
                way.Id = value.Id;
                way.Name = value.Name;

                _logger.Log(LogLevel.Information, $"Update way with id == {id}.");

                return _rep.Update(way);
            }       
        }

        // DELETE ways/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _logger.Log(LogLevel.Information, $"Delete way with id == {id}.");

            return _rep.Delete(id);
        }
    }
}
