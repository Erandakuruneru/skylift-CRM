using System;
using Skylift.Core.DomainModels;
using Skylift.Core.Extensions;

namespace Skylift.Core.Interfaces.Repositories
{
    /// <summary>
    /// Delivery repository
    /// </summary>
    public interface ILogRepository
    {
        /// <summary>Inserts the log information.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Result<int> InsertLogInfo(string deviceCode, string cardNumber, int userId);
    }
}

