using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylift.Core.Interactors;
using Skylift.Core.Interfaces.Repositories;
using Skylift.Infrastructure.Repositories;

namespace Skylift.Plumbing
{
    /// <summary>
    /// Deliver container
    /// </summary>
    public class LogContainer
    {
        #region Configuration fields

        /// <summary>
        /// Looging information
        /// </summary>
        private readonly ILogger logger;

        #endregion

        #region Intractor fields

        private SaveLogInfoInteractor saveLogInfoInteractor;

        #endregion

        #region Repository fields

        /// <summary>
        /// The vehicle buy repository
        /// </summary>
        private ILogRepository logRepository;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryContainer"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="logger">The logger.</param>
        public LogContainer(IConfiguration configuration, ILogger logger)
        {
            this.Configuration = configuration;
            this.logger = logger;
        }

        /// <summary>
        /// Gets Configuration
        /// </summary>
        /// <value>
        /// Configuration
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets the save delivery information interactor.
        /// </summary>
        /// <value>
        /// The save delivery information interactor.
        /// </value>
        public SaveLogInfoInteractor SaveLogInfoInteractor
        {
            get
            {
                if (this.saveLogInfoInteractor == null)
                {
                    this.saveLogInfoInteractor = new SaveLogInfoInteractor(this.LogRepository, this.logger);
                }

                return this.saveLogInfoInteractor;
            }
        }


        internal ILogRepository LogRepository
        {
            get
            {
                if (this.logRepository == null)
                {
                    this.logRepository = new LogRepository(this.Configuration, this.logger);
                }

                return this.logRepository;
            }
        }
    }
}
