namespace Line.Message
{
    public interface IMultiPersonChatClient
    {
        public Task<int> GetNumberOfUsersAsync(string roomId);
        public Task<MultiPersonChatMemberUserIds> GetMemberUserIdsAsync(string roomId);
        public Task<MultiPersonChatMemberUserIds> GetMemberUserIdsAsync(string roomId, string next);
        public Task<MultiPersonChatMemberProfile> GetMemberProfileAsync(string roomId, string userId);
        public Task LeaveAsync(string roomId);
    }
}
