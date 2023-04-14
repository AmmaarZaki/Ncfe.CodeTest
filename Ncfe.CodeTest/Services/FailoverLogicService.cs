using Ncfe.CodeTest.Interfaces;
using System;
using System.Configuration;

namespace Ncfe.CodeTest.Services
{
    public class FailoverLogicService : IFailoverLogicService
    {
        private readonly IFailoverRepository _failoverRepository;

        public FailoverLogicService(IFailoverRepository failoverRepository)
        {
            _failoverRepository = failoverRepository;
        }

        public bool IsFailoverModeEnabled()
        {
            var failedRequests = 0;
            var failedoverEntries = _failoverRepository.GetFailoverEntries();

            foreach (var failedoverEntry in failedoverEntries)
            {
                if (failedoverEntry.DateTime > DateTime.Now.AddMinutes(-10))
                {
                    failedRequests++;
                }
            }

            return
                failedRequests > 100 &&
                (ConfigurationManager.AppSettings["IsFailoverModeEnabled"] == "true" || 
                ConfigurationManager.AppSettings["IsFailoverModeEnabled"] == "True");
        }
    }
}
