using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylift.Core.Interactors;
using Skylift.Plumbing;

namespace Skylift.WebApi.Controllers
{
    [Route("api/cards")]
    [ApiController]
    public class CardController : Controller
    {

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryController"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="logger">The logger.</param>
        public CardController(IConfiguration config, ILogger<CardController> logger)
        {
            this.configuration = config;
            this.logger = logger;
        }

        [HttpPost("logs")]
        [ProducesResponseType(typeof(SaveLogInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SaveLogInfo(SaveLogInfoRequest request)
        {
            if (request != null)
            {
                LogContainer container = new LogContainer(this.configuration, this.logger);
                SaveLogInfoResponse response = container.SaveLogInfoInteractor.Execute(request);
                return this.Ok(response);
            }
            else
            {
                return this.BadRequest("Invalid parameter(s)");
            }
        }
        [HttpGet("test")]
        public IActionResult LoadTest()
        {
            return this.Ok("API is working fine");
        }
    }
}