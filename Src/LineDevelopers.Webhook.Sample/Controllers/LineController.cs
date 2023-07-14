using Line;
using Line.Message;
using Line.Webhook;
using Microsoft.AspNetCore.Mvc;

namespace LineDevelopers.Webhook.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LineController : LineControllerBase
    {
        readonly LineMessagingClient _client;

        public LineController()
        {
            _client = new LineMessagingClient("your channel access token");
        }

        [HttpPost("callback")]
        public override async Task<IActionResult> CallBackAsync([FromBody] WebhookBody request)
            => await base.CallBackAsync(request).ConfigureAwait(false);

        protected override Task OnAccountLinkEventAsync(AccountLinkEventObject accountLinkEventObject)
        {
            throw new NotImplementedException();
        }

        protected override Task OnBeaconEventAsync(BeaconEventObject beaconEventObject)
        {
            throw new NotImplementedException();
        }

        protected override Task OnFollowEventAsync(FollowEventObject followEventObject)
        {
            throw new NotImplementedException();
        }

        protected override Task OnJoinEventAsync(JoinEventObject joinEventObject)
        {
            throw new NotImplementedException();
        }

        protected override Task OnLeaveEventAsync(LeaveEventObject leaveEventObject)
        {
            throw new NotImplementedException();
        }

        protected override Task OnMemberJoinEventAsync(MemberJoinEventObject memberJoinEventObject)
        {
            throw new NotImplementedException();
        }

        protected override Task OnMemberLeaveEventAsync(MemberLeaveEventObject memberLeaveEventObject)
        {
            throw new NotImplementedException();
        }

        protected override async Task OnMessageEventAsync(MessageEventObject messageEventObject)
        {
            var messages = new List<IMessage>()
            {
                new TextMessage($"hello world!"),
            };

            switch (messageEventObject.Source)
            {
                case UserSource:
                    var user = (UserSource)messageEventObject.Source;
                    var userId = user.UserId;
                    break;
                case GroupChatSource:
                    var group = (GroupChatSource)messageEventObject.Source;
                    var groupID = group.GroupId;
                    var groupUserID = group.UserId;
                    break;
                case MultiPersonChatSource:
                    var multi = (MultiPersonChatSource)messageEventObject.Source;
                    var multiRoomId = multi.RoomId;
                    var multiUserId = multi.UserId;
                    break;
            }

            try
            {
                await _client.Message.SendReplyMessageAsync(messageEventObject.ReplyToken, messages);
            }
            catch (LineException ex)
            {
                var message = ex.Message;

                foreach (var detail in ex.Details ?? Enumerable.Empty<Detail>())
                {
                    var detailMessage = detail.Message;
                    var detailProperty = detail.Property;
                }
            }
        }

        protected override Task OnPostBackEventAsync(PostBackEventObject postBackEventObject)
        {
            throw new NotImplementedException();
        }

        protected override Task OnThingsEventAsync(ThingsEventObject thingsEventObject)
        {
            throw new NotImplementedException();
        }

        protected override Task OnUnFollowEventAsync(UnFollowEventObject unFollowEventObject)
        {
            throw new NotImplementedException();
        }

        protected override Task OnUnSendEventAsync(UnSendEventObject unSendEventObject)
        {
            throw new NotImplementedException();
        }

        protected override Task OnVideoViewingCompleteEventAsync(VideoViewingCompleteEventObject videoViewingCompleteEventObject)
        {
            throw new NotImplementedException();
        }
    }
}
