using DataAgregatorWeb.Controllers;
using DataAgregatorWeb.Models;
using DataAgregatorWeb.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace DataAgregatorWebTest
{
    [TestClass]
    public class WaysControllerTest
    {
        private Mock<IRepository<Way>> _wayRepositoryMock;
        private WaysController _controller;
        private Way _testWay;

        private Mock<ISimpleLogger> _loggerMock;

        public WaysControllerTest()
        {
            _wayRepositoryMock = new Mock<IRepository<Way>>();
            _loggerMock = new Mock<ISimpleLogger>();

            _controller = new WaysController(_wayRepositoryMock.Object, _loggerMock.Object);

            _testWay = new Way() { Id = 1, Name = "Way1" };

            _wayRepositoryMock.Setup(x => x.GetOne(1)).Returns(_testWay);

            _loggerMock.Setup(x => x.Log(It.IsAny<LogLevel>(), It.IsAny<string>())).Verifiable();
        }

        [TestMethod]
        public void GetAllTest()
        {
            _wayRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Way>() { _testWay, new Way { Id = 2, Name = "Way2" } });

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
            Assert.AreEqual(result.Name, "Way1");
        }

        [TestMethod]
        public void UpdateTest()
        {
            _wayRepositoryMock.Setup(x => x.Update(It.IsAny<Way>())).Returns(true);

            var result = _controller.Put(1, new Way() { Id = 1, Name = "way3" });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            _wayRepositoryMock.Setup(x => x.Delete(1)).Returns(true);

            var result = _controller.Delete(1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddTest()
        {
            _wayRepositoryMock.Setup(x => x.Create(It.IsAny<Way>())).Returns(true);

            var result = _controller.Post(new Way() { Name = "way3" });

            Assert.IsTrue(result);
        }
    }
}
