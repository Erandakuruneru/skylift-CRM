using Skylift.Core.Extensions;

namespace Skylift.Core.Interactors
{
    /// <summary>
    /// Save Delivery Info Response
    /// </summary>
    /// <seealso cref="SveaHusbilar.Core.Extensions.ResponseBase" />
    public class SaveLogInfoResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the buyer identifier.
        /// </summary>
        /// <value>
        /// The buyer identifier.
        /// </value>
        public int id { get; set; }
    }
}

