using System;

namespace Skylift.Core.Extensions
{
    /// <summary>
    /// Result
    /// </summary>
    /// <typeparam name="T">object</typeparam>
    public class Result<T>
        where T : new()
    {
        /// <summary>
        /// The data
        /// </summary>
        private T data = new T();

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> class.
        /// </summary>
        public Result()
        {
            this.IsSuccess = false;
            this.ErrorException = null;
            this.Message = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public Result(Exception exception)
        {
            if (exception != null)
            {
                this.IsSuccess = false;
                this.ErrorException = exception;
                this.Message = exception.Message;
            }
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public T Data
        {
            get
            {
                return this.data;
            }

            set
            {
                this.data = value;
            }
        }

        /// <summary>
        /// Gets or sets the error exception.
        /// </summary>
        /// <value>
        /// The error exception.
        /// </value>
        public Exception ErrorException { get; set; }

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
    }
}