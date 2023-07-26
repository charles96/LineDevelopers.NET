using System.Text.Json;
using Line;
using Line.Message;
using Line.Webhook;
using Microsoft.AspNetCore.Mvc;

namespace LineDevelopers.Webhook.Tests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LineController : LineControllerBase
    {
        LineMessagingClient _lineMessagingClient;

        public LineController() 
        {
            var json = System.IO.File.ReadAllText(@"c:\temp\test.json");
            var config = JsonSerializer.Deserialize<TestConfig>(json);

            _lineMessagingClient = new LineMessagingClient(config.ChannelAccessToken);

        }

        private async Task SomeOtherMethod(string aaa, string bbb, Action<string>? someResult = null)
        {
            await Task.Delay(1);

            if (someResult != null) someResult("heloo");
        }

        [HttpPost("callback")]
        public override async Task<IActionResult> CallBackAsync([FromBody] WebhookBody request)
            => await base.CallBackAsync(request).ConfigureAwait(false);

        protected override async Task OnAccountLinkEventAsync(AccountLinkEventObject accountLinkEventObject)
        {
            var messages = SourceMessage("OnAccountLinkEventAsync", accountLinkEventObject);
            await SendReply(accountLinkEventObject.ReplyToken, messages);
        }

        protected override async Task OnBeaconEventAsync(BeaconEventObject beaconEventObject)
        {
            var messages = SourceMessage("OnBeaconEventAsync", beaconEventObject);
            await SendReply(beaconEventObject.ReplyToken, messages);
        }

        protected override async Task OnFollowEventAsync(FollowEventObject followEventObject)
        {
            var messages = SourceMessage("OnFollowEventAsync", followEventObject);
            await SendReply(followEventObject.ReplyToken, messages);
        }

        protected override async Task OnJoinEventAsync(JoinEventObject joinEventObject)
        {
            var messages = SourceMessage("OnJoinEventAsync", joinEventObject);
            await SendReply(joinEventObject.ReplyToken, messages);
        }

        protected override async Task OnLeaveEventAsync(LeaveEventObject leaveEventObject)
        {
            List<IMessage> messages = new List<IMessage>();
            messages.Add(new TextMessage($"OnLeaveEventAsync"));
        }

        protected override async Task OnMemberJoinEventAsync(MemberJoinEventObject memberJoinEventObject)
        {
            var messages = SourceMessage("OnMemberJoinEventAsync", memberJoinEventObject);
            await SendReply(memberJoinEventObject.ReplyToken, messages);
        }

        protected override async Task OnMemberLeaveEventAsync(MemberLeaveEventObject memberLeaveEventObject)
        {
            var messages = SourceMessage("OnMemberLeaveEventAsync", memberLeaveEventObject);
//            await _lineMessagingClient.Message.SendReplyMessageAsync(memberLeaveEventObject.ReplyToken, messages);

        }

        protected override async Task OnMessageEventAsync(MessageEventObject messageEventObject)
        {
            string key = "";

            await SomeOtherMethod("ddd", "ddd");


            await SomeOtherMethod("ddd", "ddd", (o) => {
                key = o;
            });

            var aaa = key;


            IMessage message;

            switch (messageEventObject.Message)
            {
                case TextObject:
                    var text = (TextObject)messageEventObject.Message;
                    message = new TextMessage(text.Text);
                    break;
                case StickerObject:
                    var sticker = (StickerObject)messageEventObject.Message;
                    message = new StickerMessage(sticker.PackageId, sticker.StickerId);
                    break;
                default:
                    message = new TextMessage("unknown message");
                    break;
            }

            await _lineMessagingClient.Message.SendReplyMessageAsync(messageEventObject.ReplyToken, message);


            //var messages = SourceMessage("OnMessageEventAsync", messageEventObject);
            //await SendReply(messageEventObject.ReplyToken, 
            //    new List<IMessage>() { FlexMessageMock.HotelSearch() });

            //switch (messageEventObject.Message)
            //{
            //    case StickerObject:

            //        var sticker = (StickerObject)messageEventObject.Message;

            //        #region arrange
            //        var stickerMessage = new StickerMessage()
            //        {
            //            PackageId = sticker.PackageId,
            //            StickerId = sticker.StickerId
            //        };
            //        #endregion

            //        await _lineMessagingClient.Message.SendPushMessageAsync(messageEventObject.Source.UserId, stickerMessage);

            //        break;
            //    case TextObject:
            //        break;
            //    default:
            //        break;
            //}
        }

        protected override async Task OnPostBackEventAsync(PostBackEventObject postBackEventObject)
        {
            var messages = SourceMessage("OnPostBackEventAsync", postBackEventObject);
            messages.Add(new TextMessage($"OnPostBackEventAsync>Data :{postBackEventObject.PostBack?.Data}"));

            if (postBackEventObject.PostBack.Params != null)
            {
                messages.Add(new TextMessage($"OnPostBackEventAsync>PostBack>DateTime :{postBackEventObject.PostBack?.Params?.DateTime}"));
            }
            else
            {
                messages.Add(new TextMessage($"OnPostBackEventAsync>PostBack : null"));
            }

            await SendReply(postBackEventObject.ReplyToken, messages);
        }

        protected override Task OnThingsEventAsync(ThingsEventObject thingsEventObject)
        {
            throw new NotImplementedException();
        }

        protected override async Task OnUnFollowEventAsync(UnFollowEventObject unFollowEventObject)
        {   
            var user = (UserSource)unFollowEventObject.Source;
            var userId = user.UserId;
        }

        protected override Task OnUnSendEventAsync(UnSendEventObject unSendEventObject)
        {
            throw new NotImplementedException();
        }

        protected override async Task OnVideoViewingCompleteEventAsync(VideoViewingCompleteEventObject videoViewingCompleteEventObject)
        {
            var messages = SourceMessage("OnVideoViewingCompleteEventAsync", videoViewingCompleteEventObject);
            await SendReply(videoViewingCompleteEventObject.ReplyToken, messages);
        }

        private async Task SendReply(string replyToken, IList<IMessage> messages) 
        {
            try
            {
                await _lineMessagingClient.Message.SendReplyMessageAsync(replyToken, messages);
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

        private List<IMessage> SourceMessage(string methodName, IWebhookEventObject webhookEvent)
        {
            List<IMessage> messages = new List<IMessage>();
            messages.Add(new TextMessage(methodName));

            switch (webhookEvent.Source)
            {
                case UserSource:
                    var user = (UserSource)webhookEvent.Source;
                    messages.Add(new TextMessage($"UserSource>User ID : {user.UserId}"));
                    break;
                case GroupChatSource:
                    var group = (GroupChatSource)webhookEvent.Source;
                    messages.Add(new TextMessage($"GroupChatSource>Group Chat ID = {group.GroupId}\r\nUser ID  = {group.UserId}"));
                    break;
                case MultiPersonChatSource:
                    var multi = (MultiPersonChatSource)webhookEvent.Source;
                    messages.Add(new TextMessage($"MultiPersonChatSource>Room ID : {multi.RoomId}"));
                    break;
            }

            messages[messages.Count - 1].QuickReply = new QuickReply()
            {
                Items = new List<QuickReplyButtonObject>()
                {
                    new QuickReplyButtonObject()
                    {
                        Action = new PostBackAction()
                        {
                            Label = "pb action label",
                            Data = "pb data"
                        }
                    },
                    new QuickReplyButtonObject()
                    {
                        Action = new MessageAction()
                        {
                            Label = "msg action label",
                            Text = "msg action text"
                        }
                    },
                    new QuickReplyButtonObject()
                    {
                        Action = new MessageAction()
                        {
                            Label = "AccountLink",
                            Text = "My Account Link Test"
                        }
                    },
                    new QuickReplyButtonObject()
                    {
                        Action = new UriAction()
                        { 
                            Uri = "https://developers.line.biz/",
                            Label = "url action label"
                        }
                    }
                }
            };

            return messages;
        }
    }
}
