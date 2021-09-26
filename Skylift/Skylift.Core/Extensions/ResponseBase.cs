namespace Skylift.Core.Extensions
{
    /// <summary>
    /// Response Base
    /// </summary>
    public abstract class ResponseBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the message code.
        /// </summary>
        /// <value>
        /// The message code.
        /// </value>
        public string MessageCode { get; set; }
    }
}
