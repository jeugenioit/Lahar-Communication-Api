using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahar.Api.Integration.Helpers
{
    /// <summary>
    /// Stage of Lead
    /// </summary>
    public enum eStageLead
    {
        /// <summary>
        /// Lead. (adding)
        /// </summary>
        Lead = 1,
        /// <summary>
        /// Opportunity. (Update lead)
        /// </summary>
        Opportunity = 2,
        /// <summary>
        /// Client. (Update lead)
        /// </summary>
        Client = 3
    }
}
