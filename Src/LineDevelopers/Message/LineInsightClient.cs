using System.Text.Json;

namespace Line.Message
{
    public class LineInsightClient : LineHttpClient, IInsightClient
    {
        public LineInsightClient(string channelAccessToken, double timeout = 100d)
            : base(channelAccessToken, timeout)
        { }

        internal LineInsightClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        /// <summary>
        /// Returns the number of messages sent from LINE Official Account on a specified day.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<MessageDeliveriesCount> GetNumberOfMessageDeliveriesAsync(DateOnly date)
            => await base.GetAsync<MessageDeliveriesCount>($"v2/bot/insight/message/delivery?date={date.ToString("yyyyMMdd")}").ConfigureAwait(false);

        /// <summary>
        /// Returns the number of users who have added the LINE Official Account on or before a specified date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<FollowersCount> GetNumberOfFollowersAsync(DateOnly date)
            => await base.GetAsync<FollowersCount>($"v2/bot/insight/followers?date={date.ToString("yyyyMMdd")}").ConfigureAwait(false);

        /// <summary>
        /// Retrieves the demographic attributes for a LINE Official Account's friends. 
        /// You can only retrieve information about friends for LINE Official Accounts created by users in Japan (JP), Thailand (TH), Taiwan (TW) and Indonesia (ID).
        /// </summary>
        /// <returns></returns>
        public async Task<FriendDemographics> GetFriendsDemographicsAsync()
            => await base.GetAsync<FriendDemographics>("v2/bot/insight/demographic").ConfigureAwait(false);

        /// <summary>
        /// Returns statistics about how users interact with narrowcast messages or broadcast messages sent from your LINE Official Account.
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public async Task<UserInteractionStatistics> GetUserInteractionStatisticsAsync(string requestId)
            => await base.GetAsync<UserInteractionStatistics>($"v2/bot/insight/message/event?requestId={requestId}").ConfigureAwait(false);

        /// <summary>
        /// You can check the per-unit statistics of how users interact with push messages and multicast messages sent from your LINE Official Account.
        /// </summary>
        /// <param name="customAggregationUnit">
        /// Name of aggregation unit specified when sending the message. Case-sensitive. For example, Promotion_a and Promotion_A are regarded as different unit names.
        /// </param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task<StatisticsPerUnit> GetStatisticsPerUnitAsync(string customAggregationUnit, DateOnly from, DateOnly to)
            => await base.GetAsync<StatisticsPerUnit>($"v2/bot/insight/message/event/aggregation?customAggregationUnit={customAggregationUnit}&from={from.ToString("yyyyMMdd")}&to={to.ToString("yyyyMMdd")}").ConfigureAwait(false);
    }
}
