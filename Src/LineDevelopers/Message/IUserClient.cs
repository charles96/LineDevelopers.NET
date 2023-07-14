namespace Line.Message
{
    public interface IUserClient
    {
        public Task<UserProfile> GetUserProfileAsync(string userId);
        public Task<Followers> GetFollowersAsync();
    }
}
