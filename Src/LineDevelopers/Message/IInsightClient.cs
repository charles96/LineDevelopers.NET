using System.Net.Http.Headers;

namespace Line.Message
{
    public interface IInsightClient
    {
        /// <summary>
        /// Returns the number of messages sent from LINE Official Account on the date specified in date.
        /// </summary>
        /// <param name="date">Date for which to retrieve number of sent messages.</param>
        /// <returns></returns>
        public Task<MessageDeliveriesCount> GetNumberOfMessageDeliveriesAsync(DateOnly date, Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Returns the number of users who have added the LINE Official Account on or before a specified date.
        /// </summary>
        /// <param name="date">Date for which to retrieve the number of followers.</param>
        /// <returns></returns>
        public Task<FollowersCount> GetNumberOfFollowersAsync(DateOnly date, Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Retrieves the demographic attributes for a LINE Official Account's friends. You can only retrieve information about friends for LINE Official Accounts created by users in Japan (JP), Thailand (TH), Taiwan (TW) and Indonesia (ID).
        /// </summary>
        /// <returns></returns>
        public Task<FriendDemographics> GetFriendsDemographicsAsync(Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// Returns statistics about how users interact with narrowcast messages or broadcast messages sent from your LINE Official Account.
        /// </summary>
        /// <param name="requestId">Request ID of a narrowcast message or broadcast message. Each Messaging API request has a request ID. Find it in the response headers.</param>
        /// <returns></returns>
        public Task<UserInteractionStatistics> GetUserInteractionStatisticsAsync(string requestId, Action<HttpResponseHeaders>? getResponseHeaders = null);

        /// <summary>
        /// You can check the per-unit statistics of how users interact with push messages and multicast messages sent from your LINE Official Account.
        /// </summary>
        /// <param name="customAggregationUnit">Name of aggregation unit specified when sending the message. Case-sensitive. For example, Promotion_a and Promotion_A are regarded as different unit names.</param>
        /// <param name="from">Start date of aggregation period.</param>
        /// <param name="to">End date of aggregation period.</param>
        /// <returns></returns>
        public Task<StatisticsPerUnit> GetStatisticsPerUnitAsync(string customAggregationUnit, DateOnly from, DateOnly to, Action<HttpResponseHeaders>? getResponseHeaders = null);
    }
}
