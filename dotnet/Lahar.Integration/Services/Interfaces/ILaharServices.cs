using System;
using Lahar.Api.Integration.Data;
using Lahar.Api.Integration.Helpers;

namespace Lahar.Api.Integration.Services.Interfaces
{
    public interface ILaharServices
    {

        /// <summary>
        /// Save or update the Lead in the contact base Lahar
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool SaveLead(Lead obj);

        /// <summary>
        /// Update stage of Lead in the contact base Lahar
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool UpdateStageLead(Lead obj);

    }
}
