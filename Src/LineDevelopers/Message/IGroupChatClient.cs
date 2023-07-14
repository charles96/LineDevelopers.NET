namespace Line.Message
{
    public interface IGroupChatClient
    {
        public Task<GroupChatSummary> GetSummaryAsync(string groupId);
        public Task<int> GetNumberOfUsersAsync(string groupId);
        public Task<GroupChatMemberUserIDs> GetMemberUserIdsAsync(string groupId);
        public Task<GroupChatMemberUserIDs> GetMemberUserIdsAsync(string groupId, string start);
        public Task<GroupChatMemberProfile> GetChatMemberProfileAsync(string groupId, string userId);
        public Task LeaveAsync(string groupId);
    }
}
