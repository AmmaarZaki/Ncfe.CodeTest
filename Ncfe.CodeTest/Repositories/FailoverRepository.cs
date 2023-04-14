using Ncfe.CodeTest.Interfaces;
using System.Collections.Generic;

namespace Ncfe.CodeTest
{
    public class FailoverRepository : IFailoverRepository
    {
        public List<FailoverEntry> GetFailoverEntries()
        {
            // return all from fail entries from database
            return new List<FailoverEntry>();
        }
    }
}
