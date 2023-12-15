using DataAgregatorWeb.Controllers;
using DataAgregatorWeb.Models;
using DataAgregatorWeb.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace DataAgregatorWebTest
{
    [TestClass]
    public class TripsControllerTest
    {
        private Mock<IRepository<Trip>> _tripRepositoryMock;
        private Mock<IWeatherService<FromWeatherAPIModel>> _weatherServiceMock;
        private Mock<ISimpleLogger> _loggerMock;
        private TripsController _controller;
        private Trip _testTrip;

        public TripsControllerTest()
        {
            _tripRepositoryMock = new Mock<IRepository<Trip>>();
            _weatherServiceMock = new Mock<IWeatherService<FromWeatherAPIModel>>();
            _loggerMock = new Mock<ISimpleLogger>();

            _controller = new TripsController(_tripRepositoryMock.Object, _weatherServiceMock.Object, _loggerMock.Object);

            _testTrip = new Trip() { Id = 1, WayId = 1, Temperature = -10 };

            _tripRepositoryMock.Setup(x => x.GetOne(1)).Returns(_testTrip);

            _loggerMock.Setup(x => x.Log(It.IsAny<LogLevel>(), It.IsAny<string>())).Verifiable();
        }

        [TestMethod]
        public void GetAllTest()
        {
            _tripRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Trip>() { _testTrip, new Trip { Id = 2, WayId = 2, Temperature = -12 } });

            var result = _controller.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetOneTest()
        {
            var result = _controller.Get(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.WayId, 1);
            Assert.AreEqual(result.Temperature, -10);
        }

        [TestMethod]
        public void UpdateTest()
        {
            _tripRepositoryMock.Setup(x => x.Update(It.IsAny<Trip>())).Returns(true);

            var result = _controller.Put(1, new Trip() { Id = 1, WayId = 2 });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            _tripRepositoryMock.Setup(x => x.Delete(1)).Returns(true);

            var result = _controller.Delete(1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddTest()
        {
            _tripRepositoryMock.Setup(x => x.Create(It.IsAny<Trip>())).Returns(true);
            _weatherServiceMock
                .Setup(x => x.GetRealtimeWeather())
                .Returns(Task.FromResult(new FromWeatherAPIModel() { Current = new Current() { Temp_c = -8 } }));

            FromClientTripModel fromClient = new FromClientTripModel()
            {
                TrafficJams = 6,
                Join = 10,
                Left = 3
            };

            var result = _controller.Post(fromClient);

            Assert.IsTrue(result);
        }
    }
}
