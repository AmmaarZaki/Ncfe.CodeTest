using Moq;
using Ncfe.CodeTest;
using Ncfe.CodeTest.Interfaces;

namespace Ncfe.Test
{
    public class LearnerServiceTests
    {
        private readonly Mock<IFailoverLogicService> _failoverLogicService;
        private readonly Mock<ILearnerDataAccess> _learnerDataAccess;
        private readonly Mock<IArchivedDataService> _archivedDataService;
        private readonly Mock<IFailoverLearnerDataAccess> _failoverLearnerDataAccess;


        private readonly LearnerService _learnerService;

        public LearnerServiceTests()
        {
            _failoverLogicService = new Mock<IFailoverLogicService>();
            _learnerDataAccess = new Mock<ILearnerDataAccess>();
            _archivedDataService = new Mock<IArchivedDataService>();
            _failoverLearnerDataAccess = new Mock<IFailoverLearnerDataAccess>();

            _learnerService = new LearnerService(
                _failoverLogicService.Object,
                _learnerDataAccess.Object,
                _archivedDataService.Object,
                _failoverLearnerDataAccess.Object);
        }

        [Fact]
        public void GetLearner_ReturnsLearner_From_LearnerDataAccess_WhenNotInFailoverMode_And_NotArchived()
        {
            //Arrange
            var learnerId = 1;
            var learnerResponse = new LearnerResponse() 
            { 
                IsArchived = false,
                Learner = new Learner()
                {
                    Id = learnerId,
                    Name = "test",
                }
            };

            _failoverLogicService.Setup(x => x.IsFailoverModeEnabled())
                .Returns(false);
            _learnerDataAccess.Setup(x => x.LoadLearner(It.IsAny<int>()))
                .Returns(learnerResponse);

            //Act
            var learner = _learnerService.GetLearner(learnerId);

            //Assert
            _failoverLogicService.Verify(x => x.IsFailoverModeEnabled(), Times.Once());
            _learnerDataAccess.Verify(x => x.LoadLearner(It.IsAny<int>()), Times.Once());
            _archivedDataService.Verify(x => x.GetArchivedLearner(It.IsAny<int>()), Times.Never());
            _failoverLearnerDataAccess.Verify(x => x.GetLearnerById(It.IsAny<int>()), Times.Never());

            Assert.IsType<Learner>(learner);
            Assert.Equal(learnerId, learner.Id);
            Assert.Equal("test", learner.Name);
        }

        [Fact]
        public void GetLearner_ReturnsLearner_From_LearnerDataAccess_WhenNotInFailoverMode_And_Archived()
        {
            //Arrange
            var learnerId = 1;
            var learnerResponse = new LearnerResponse()
            {
                IsArchived = true,
                Learner = new Learner()
                {
                    Id = learnerId,
                    Name = "test",
                }
            };

            _failoverLogicService.Setup(x => x.IsFailoverModeEnabled())
                .Returns(false);
            _learnerDataAccess.Setup(x => x.LoadLearner(It.IsAny<int>()))
                .Returns(learnerResponse);
            _archivedDataService.Setup(x => x.GetArchivedLearner(It.IsAny<int>()))
                .Returns(learnerResponse.Learner);

            //Act
            var learner = _learnerService.GetLearner(learnerId);

            //Assert
            _failoverLogicService.Verify(x => x.IsFailoverModeEnabled(), Times.Once());
            _learnerDataAccess.Verify(x => x.LoadLearner(It.IsAny<int>()), Times.Once());
            _archivedDataService.Verify(x => x.GetArchivedLearner(It.IsAny<int>()), Times.Once());
            _failoverLearnerDataAccess.Verify(x => x.GetLearnerById(It.IsAny<int>()), Times.Never());

            Assert.IsType<Learner>(learner);
            Assert.Equal(learnerId, learner.Id);
            Assert.Equal("test", learner.Name);
        }

        [Fact]
        public void GetLearner_ReturnsLearner_From_FailoverLearnerDataAccess_WhenInFailoverMode_And_NotArchived()
        {
            //Arrange
            var learnerId = 1;
            var learnerResponse = new LearnerResponse()
            {
                IsArchived = false,
                Learner = new Learner()
                {
                    Id = learnerId,
                    Name = "test",
                }
            };

            _failoverLogicService.Setup(x => x.IsFailoverModeEnabled())
                .Returns(true);
            _failoverLearnerDataAccess.Setup(x => x.GetLearnerById(It.IsAny<int>()))
                .Returns(learnerResponse);

            //Act
            var learner = _learnerService.GetLearner(learnerId);

            //Assert
            _failoverLogicService.Verify(x => x.IsFailoverModeEnabled(), Times.Once());
            _failoverLearnerDataAccess.Verify(x => x.GetLearnerById(It.IsAny<int>()), Times.Once());
            _archivedDataService.Verify(x => x.GetArchivedLearner(It.IsAny<int>()), Times.Never());
            _learnerDataAccess.Verify(x => x.LoadLearner(It.IsAny<int>()), Times.Never());

            Assert.IsType<Learner>(learner);
            Assert.Equal(learnerId, learner.Id);
            Assert.Equal("test", learner.Name);
        }

        [Fact]
        public void GetLearner_ReturnsLearner_From_FailoverLearnerDataAccess_WhenInFailoverMode_And_Archived()
        {
            //Arrange
            var learnerId = 1;
            var learnerResponse = new LearnerResponse()
            {
                IsArchived = true,
                Learner = new Learner()
                {
                    Id = learnerId,
                    Name = "test",
                }
            };

            _failoverLogicService.Setup(x => x.IsFailoverModeEnabled())
                .Returns(true);
            _failoverLearnerDataAccess.Setup(x => x.GetLearnerById(It.IsAny<int>()))
                .Returns(learnerResponse);
            _archivedDataService.Setup(x => x.GetArchivedLearner(It.IsAny<int>()))
                .Returns(learnerResponse.Learner);

            //Act
            var learner = _learnerService.GetLearner(learnerId);

            //Assert
            _failoverLogicService.Verify(x => x.IsFailoverModeEnabled(), Times.Once());
            _failoverLearnerDataAccess.Verify(x => x.GetLearnerById(It.IsAny<int>()), Times.Once());
            _archivedDataService.Verify(x => x.GetArchivedLearner(It.IsAny<int>()), Times.Once());
            _learnerDataAccess.Verify(x => x.LoadLearner(It.IsAny<int>()), Times.Never());

            Assert.IsType<Learner>(learner);
            Assert.Equal(learnerId, learner.Id);
            Assert.Equal("test", learner.Name);
        }
    }
}
