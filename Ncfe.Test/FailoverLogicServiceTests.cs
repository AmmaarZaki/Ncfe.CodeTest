using Moq;
using Ncfe.CodeTest;
using Ncfe.CodeTest.Interfaces;
using Ncfe.CodeTest.Services;
using System.Configuration;

namespace Ncfe.Test
{
    public class FailoverLogicServiceTests
    {
        private readonly Mock<IFailoverRepository> _failoverRepository;
        private readonly FailoverLogicService _failoverLogicService;

        public FailoverLogicServiceTests()
        {
            _failoverRepository = new Mock<IFailoverRepository>();
            _failoverLogicService = new FailoverLogicService(_failoverRepository.Object);
        }

        [Fact]
        public void IsFailoverModeEnabled_LessThan100FailedRequests_IsFailoverModeEnabledIsFalse_ReturnFalse()
        {
            //Arrange
            var failoverEntries = new List<FailoverEntry>()
            {
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) }
            };

            _failoverRepository.Setup(x => x.GetFailoverEntries())
                .Returns(failoverEntries);

            ConfigurationManager.AppSettings["IsFailoverModeEnabled"] = "false";

            //Act
            var result = _failoverLogicService.IsFailoverModeEnabled();

            //Assert
            _failoverRepository.Verify(x => x.GetFailoverEntries(), Times.Once());

            Assert.IsType<bool>(result);
            Assert.False(result);
        }

        [Fact]
        public void IsFailoverModeEnabled_MoreThan100FailedRequests_IsFailoverModeEnabledIsTrue_ReturnTrue()
        {
            //Arrange
            var failoverEntries = new List<FailoverEntry>()
            {
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
            };

            _failoverRepository.Setup(x => x.GetFailoverEntries())
                .Returns(failoverEntries);

            ConfigurationManager.AppSettings["IsFailoverModeEnabled"] = "true";

            //Act
            var result = _failoverLogicService.IsFailoverModeEnabled();

            //Assert
            _failoverRepository.Verify(x => x.GetFailoverEntries(), Times.Once());

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public void IsFailoverModeEnabled_MoreThan100FailedRequests_IsFailoverModeEnabledIsFalse_ReturnFalse()
        {
            //Arrange
            var failoverEntries = new List<FailoverEntry>()
            {
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
                new FailoverEntry() { DateTime = DateTime.Now.AddMinutes(10) },
            };

            _failoverRepository.Setup(x => x.GetFailoverEntries())
                .Returns(failoverEntries);

            ConfigurationManager.AppSettings["IsFailoverModeEnabled"] = "false";

            //Act
            var result = _failoverLogicService.IsFailoverModeEnabled();

            //Assert
            _failoverRepository.Verify(x => x.GetFailoverEntries(), Times.Once());

            Assert.IsType<bool>(result);
            Assert.False(result);
        }
    }
}