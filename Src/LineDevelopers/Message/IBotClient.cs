using System.Net.Http.Headers;

namespace Line.Message
{
    public interface IBotClient
    {
        /// <summary>
        /// Gets a bot's basic information.
        /// </summary>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public Task<BotInformation> GetBotInformationAsync(Action<HttpResponseHeaders>? getResponseHeaders = null);
    }
}
