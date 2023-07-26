using System.Net.Http.Headers;

namespace Line.Message
{
    public interface IAccountLinkClient
    {
        /// <summary>
        /// Issues a link token used for the account link feature.
        /// </summary>
        /// <param name="userId">User ID for the LINE account to be linked.</param>
        /// <param name="getResponseHeaders">Response headers</param>
        /// <returns></returns>
        public Task<string> IssueLinkTokenAsync(string userId, Action<HttpResponseHeaders>? getResponseHeaders = null);
    }
}
