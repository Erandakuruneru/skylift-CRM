using System.Net.Http;

namespace Skylift.Infrastructure.Helpers
{
    /// <summary>
    /// Response Result Message
    /// </summary>
    public static class ResponseResultMessage
    {
        /// <summary>
        /// Gets the response result message.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>System String.</returns>
        public static string GetResponseResultMessage(HttpResponseMessage response)
        {
            string responseMessage = string.Empty;
            if (response != null)
            {
                responseMessage = "StatusCode: " + response.StatusCode + ", ReasonPhrase: " + response.ReasonPhrase;
            }

            return responseMessage;
        }
    }
}
