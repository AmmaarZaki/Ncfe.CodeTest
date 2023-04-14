using Ncfe.CodeTest.Interfaces;

namespace Ncfe.CodeTest
{
    public class FailoverLearnerDataAccess : IFailoverLearnerDataAccess
    {
        public static LearnerResponse GetLearnerById(int id)
        {
            // retrieve learner from database
            return new LearnerResponse();
        }

        LearnerResponse IFailoverLearnerDataAccess.GetLearnerById(int id) 
        {
            return new LearnerResponse(); 
        }
    }
}
