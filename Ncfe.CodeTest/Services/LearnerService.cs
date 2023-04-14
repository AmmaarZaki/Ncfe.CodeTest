using Ncfe.CodeTest.Interfaces;

namespace Ncfe.CodeTest
{
    public class LearnerService
    {
        private readonly IFailoverLogicService _failoverService;
        private readonly ILearnerDataAccess _learnerDataAccess;
        private readonly IArchivedDataService _archivedDataService;
        private readonly IFailoverLearnerDataAccess _failoverLearnerDataAccess;

        public LearnerService(
            IFailoverLogicService failoverLogicService,
            ILearnerDataAccess learnerDataAccess,
            IArchivedDataService archivedDataService,
            IFailoverLearnerDataAccess failoverLearnerDataAccess)
        {
            _failoverService = failoverLogicService;
            _learnerDataAccess = learnerDataAccess;
            _archivedDataService = archivedDataService;
            _failoverLearnerDataAccess = failoverLearnerDataAccess;
        }

        public Learner GetLearner(int learnerId)
        {
            LearnerResponse learnerResponse;

            if (_failoverService.IsFailoverModeEnabled())
            {
                learnerResponse = _failoverLearnerDataAccess.GetLearnerById(learnerId);
            }

            else
            {
                learnerResponse = _learnerDataAccess.LoadLearner(learnerId);
            }

            if (learnerResponse.IsArchived)
            {
                return _archivedDataService.GetArchivedLearner(learnerId);
            }

            else
            {
                return learnerResponse.Learner;
            }
        }
    }
}
