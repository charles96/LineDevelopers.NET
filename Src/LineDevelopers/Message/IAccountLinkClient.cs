namespace Line.Message
{
    public interface IAccountLinkClient
    {
        public Task<string> IssueLinkTokenAsync(string userId);
    }
}
