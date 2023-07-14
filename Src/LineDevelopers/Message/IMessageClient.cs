namespace Line.Message
{
    public interface IMessageClient
    {
        public Task SendReplyMessageAsync(string replyToken, IMessage message, bool? notificationDisabled = null);
        public Task SendReplyMessageAsync(string replyToken, IList<IMessage> messages, bool? notificationDisabled = null);
        public Task SendPushMessageAsync(string to, IList<IMessage> messages, bool? notificationDisabled = null, string? xLineRetryKey = null);
        public Task SendPushMessageAsync(string to, IMessage message, bool? notificationDisabled = null, string? xLineRetryKey = null);
        public Task SendMulticastMessageAsync(IList<string> to, IList<IMessage> messages, bool? notificationDisabled = null, IList<string>? customAggregationUnits = null, string? xLineRetryKey = null);
        public Task SendMulticastMessageAsync(IList<string> to, IMessage message, bool? notificationDisabled = null, IList<string>? customAggregationUnits = null, string? xLineRetryKey = null);
        public Task SendNarrowcastMessageAsync(IList<IMessage> messages, IRecipientObject? recipient = null, NarrowcastMessageFilter? filter = null, NarrowcastLimit? limit = null, bool? notificationDisabled = null, string? xLineRetryKey = null);
        public Task SendNarrowcastMessageAsync(IMessage message, IRecipientObject? recipient = null, NarrowcastMessageFilter? filter = null, NarrowcastLimit? limit = null, bool? notificationDisabled = null, string? xLineRetryKey = null);
        public Task SendBroadcastMessageAsync(IList<IMessage> messages, bool? notificationDisabled = null, string? xLineRetryKey = null);
        public Task SendBroadcastMessageAsync(IMessage message, bool? notificationDisabled = null, string? xLineRetryKey = null);
        public Task<NarrowcastMessageStatus> GetNarrowcastMessageStatusAsync(string requestId);
        public Task<TargetLimitForSendingMessagesThisMonth> GetTheTargetLimitForSendingMessagesThisMonthAsync();
        public Task<int> GetNumberOfMessagesSentThisMonthAsync();
        public Task<NumberOfSentMessages> GetNumberOfSentMessagesAsync(SendType sendType, DateOnly date);
        public Task ValidateMessageObjectsOfMessageAsync(SendType sendType, IList<IMessage> messages);
        public Task ValidateMessageObjectsOfMessageAsync(SendType sendType, IMessage message);
        public Task<int> GetNumberOfUnitsUsedThisMonthAsync();
        public Task<NameListOfUnitsUsedThisMonth> GetNameListOfUnitsUsedThisMonthAsync(int limit = 100);
        public Task<NameListOfUnitsUsedThisMonth> GetNameListOfUnitsUsedThisMonthAsync(int limit, string start);
    }
}
