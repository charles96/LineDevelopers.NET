namespace Line.Message
{
    public interface IInsightClient
    {
        public Task<MessageDeliveriesCount> GetNumberOfMessageDeliveriesAsync(DateOnly date);
        public Task<FollowersCount> GetNumberOfFollowersAsync(DateOnly date);
        public Task<FriendDemographics> GetFriendsDemographicsAsync();
        public Task<UserInteractionStatistics> GetUserInteractionStatisticsAsync(string requestId);
        public Task<StatisticsPerUnit> GetStatisticsPerUnitAsync(string customAggregationUnit, DateOnly from, DateOnly to);
    }
}
