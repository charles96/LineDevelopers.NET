namespace Line.Message
{
    public interface IBotClient
    {
        public Task<BotInformation> GetBotInformationAsync();
    }
}
