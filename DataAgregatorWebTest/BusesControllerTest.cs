using Moq;
using DataAgregatorWeb.Services;
using DataAgregatorWeb.Models;
using DataAgregatorWeb.Controllers;
using Microsoft.Extensions.Logging;

namespace DataAgregatorWebTest
{
    [TestClass]
    public class BusesControllerTest
    {
        private Mock<IRepository<Bus>> _busRepositoryMock;
        private BusesController _controller;
        private Bus _testBus;

        private Mock<ISimpleLogger> _loggerMock;

        public BusesControllerTest()
        {
            _busRepositoryMock = new Mock<IRepository<Bus>>();
            _loggerMock = new Mock<ISimpleLogger>();

            _controller = new BusesController(_busRepositoryMock.Object, _loggerMock.Object);

            _testBus = new Bus() { Id = 1, Model = "model1", Capacity = 100 };

            _busRepositoryMock.Setup(x => x.GetOne(1)).Returns(_testBus);

            _loggerMock.Setup(x => x.Log(It.IsAny<LogLevel>(), It.IsAny<string>())).Verifiable();
        }

        [TestMethod]
        public void GetAllTest()
        {
            _busRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Bus>());

            var result = _controller.GetAll();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetOneTest()
        {
            var result = _controller.Get(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Model, "model1");
        }

        [TestMethod]
        public void UpdateTest()
        {
            //new Bus()
            _busRepositoryMock.Setup(x => x.Update(It.IsAny<Bus>())).Returns(true);           

            var result = _controller.Put(1, new Bus() { Id = 1, Model = "model2", Capacity = 98 });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            _busRepositoryMock.Setup(x => x.Delete(1)).Returns(true);

            var result = _controller.Delete(1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddTest()
        {
            _busRepositoryMock.Setup(x => x.Create(It.IsAny<Bus>())).Returns(true);

            var result = _controller.Post(new Bus() { Model = "model2", Capacity = 150 });

            Assert.IsTrue(result);
        }
    }
}