using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Extensions.Logging;
using Skylift.Core.Extensions;
using Skylift.Core.Helpers;
using Skylift.Core.Interfaces.Repositories;
using Skylift.Core.Utilities;

namespace Skylift.Core.Interactors
{
    /// <summary>
    /// Save Delivery Info Interactor
    /// </summary>
    public class SaveLogInfoInteractor
    {
        #region Configuration fields

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        #endregion

        #region Repository fields

        /// <summary>
        /// The vehicle buy repository/
        /// </summary>
        private readonly ILogRepository logRepository;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveDeliveryInfoInteractor"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public SaveLogInfoInteractor(ILogRepository repository, ILogger logger)
        {
            this.logRepository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Executes the specified buyer identifier.
        /// </summary>
        /// <param name="request">The save delivery info request.</param>
        /// <returns>id</returns>
        public SaveLogInfoResponse Execute(SaveLogInfoRequest request)
        {
            SaveLogInfoResponse response = new SaveLogInfoResponse();
            try
            {
                if (request != null)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        Result<int> result = new Result<int>();
                            result = this.logRepository.InsertLogInfo(request.DeviceCode,request.CardNumber,request.UserId);

                        if (result.IsSuccess)
                        {
                            if (result.Data > 0)
                            {
                                this.SendEmail();
                                response.id = result.Data;
                            }

                            scope.Complete();
                        }
                        else
                        {
                            using (TransactionScope logScope = new TransactionScope(TransactionScopeOption.Suppress))
                            {
                                response.Message = result.Message;
                                this.logger.LogError(AssemblyHelper.GetMethodFullName(this.GetType().FullName) + ": " +
                                     response.Message + ": " + result.ErrorException);
                            }
                        }

                        response.IsSuccess = result.IsSuccess;
                    }
                }
            }
            catch (ThreadAbortException ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }



        private Result<List<string>> SendEmail()
        {
            Result<List<string>> documentResult = new Result<List<string>>();
            var genarateDocResponse = EmailHelper.sendAsync();

            return documentResult;
        }
    }
}
