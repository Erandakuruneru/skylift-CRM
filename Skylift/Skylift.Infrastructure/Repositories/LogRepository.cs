using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylift.Core.DomainModels;
using Skylift.Core.Extensions;
using Skylift.Core.Interfaces.Repositories;
using Skylift.Core.Utilities;
using Skylift.Infrastructure.Helpers;

namespace Skylift.Infrastructure.Repositories
{
    /// <summary>
    /// /Delivery repository
    /// </summary>
    /// <seealso cref="SveaHusbilar.Core.Interfaces.Repositories.IDeliveryRepository" />
    public class LogRepository : ILogRepository
    {
        #region Configuration fields

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryRepository"/> class.
        /// </summary>
        /// <param name="configuration">config </param>
        /// <param name="logger">logger</param>
        public LogRepository(IConfiguration configuration, ILogger logger)
        {
            this.Configuration = configuration;
            this.logger = logger;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }


        public Result<int> InsertLogInfo(int buyerId)
        {
            Result<int> result = new Result<int>();
            result.IsSuccess = true;

            try
            {
                List<RequestParameter> parameterList = new List<RequestParameter>()
                {
                    new RequestParameter { ParameterName = "@buyer_id", ParameterValue = buyerId }
                };

                DBEngine dbEngine = new DBEngine(this.Configuration, this.logger);
                int id = dbEngine.SaveData("update_delivery_date", parameterList);

                if (!dbEngine.IsSuccess)
                {
                    result.ErrorException = dbEngine.Exception;
                    result.Message = dbEngine.Exception.Message;
                    result.IsSuccess = false;
                    this.logger.LogError(AssemblyHelper.GetMethodFullName(this.GetType().FullName) + ": " +
                     result.Message + ": " + result.ErrorException);
                }
                else
                {
                    if (id > 0)
                    {
                        result.Data = id;
                        result.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.ErrorException = ex;
                this.logger.LogError(ex, AssemblyHelper.GetMethodFullName(this.GetType().
                 FullName + ": " + "Failed when Updatating delivery details"));
            }

            return result;
        }

    }
}