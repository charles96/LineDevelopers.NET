using System.Text.Json.Serialization;

namespace Line.Webhook
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(MessageEventObject), "message")]
    [JsonDerivedType(typeof(UnSendEventObject), "unsend")]
    [JsonDerivedType(typeof(FollowEventObject), "follow")]
    [JsonDerivedType(typeof(UnFollowEventObject), "unfollow")]
    [JsonDerivedType(typeof(JoinEventObject), "join")]
    [JsonDerivedType(typeof(LeaveEventObject), "leave")]
    [JsonDerivedType(typeof(MemberJoinEventObject), "memberJoined")]
    [JsonDerivedType(typeof(MemberLeaveEventObject), "memberLeft")]
    [JsonDerivedType(typeof(PostBackEventObject), "postback")]
    [JsonDerivedType(typeof(VideoViewingCompleteEventObject), "videoPlayComplete")]
    [JsonDerivedType(typeof(BeaconEventObject), "beacon")]
    [JsonDerivedType(typeof(AccountLinkEventObject), "accountLink")]
    [JsonDerivedType(typeof(ThingsEventObject), "things")]
    public interface IWebhookEventObject
    {
        public ModeType Mode { get; set; }
     
        public long Timestamp { get; set; }

        public ISource? Source { get; set; }

        public string WebhookEventId { get; set; }

        public DeliveryContext DeliveryContext { get; set; }
    }
}
