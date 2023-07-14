using Line.Webhook;
using Microsoft.AspNetCore.Mvc;

namespace LineDevelopers.Webhook.Sample
{
    public abstract class LineControllerBase : ControllerBase
    {
        public virtual async Task<IActionResult> CallBackAsync([FromBody] WebhookBody request)
        {
            try
            {
                foreach (var currentEvent in request.Events)
                {
                    switch (currentEvent)
                    {
                        case MessageEventObject:
                            await OnMessageEventAsync((MessageEventObject)currentEvent).ConfigureAwait(false);
                            break;
                        case UnSendEventObject:
                            await OnUnSendEventAsync((UnSendEventObject)currentEvent).ConfigureAwait(false);
                            break;
                        case FollowEventObject:
                            await OnFollowEventAsync((FollowEventObject)currentEvent).ConfigureAwait(false);
                            break;
                        case UnFollowEventObject:
                            await OnUnFollowEventAsync((UnFollowEventObject)currentEvent).ConfigureAwait(false);
                            break;
                        case JoinEventObject:
                            await OnJoinEventAsync((JoinEventObject)currentEvent).ConfigureAwait(false);
                            break;
                        case LeaveEventObject:
                            await OnLeaveEventAsync((LeaveEventObject)currentEvent).ConfigureAwait(false);
                            break;
                        case MemberJoinEventObject:
                            await OnMemberJoinEventAsync((MemberJoinEventObject)currentEvent).ConfigureAwait(false);
                            break;
                        case MemberLeaveEventObject:
                            await OnMemberLeaveEventAsync((MemberLeaveEventObject)currentEvent).ConfigureAwait(false);
                            break;
                        case PostBackEventObject:
                            await OnPostBackEventAsync((PostBackEventObject)currentEvent).ConfigureAwait(false);
                            break;
                        case VideoViewingCompleteEventObject:
                            await OnVideoViewingCompleteEventAsync((VideoViewingCompleteEventObject)currentEvent).ConfigureAwait(false);
                            break;
                        case BeaconEventObject:
                            await OnBeaconEventAsync((BeaconEventObject)currentEvent).ConfigureAwait(false);
                            break;
                        case AccountLinkEventObject:
                            await OnAccountLinkEventAsync((AccountLinkEventObject)currentEvent).ConfigureAwait(false);
                            break;
                        case ThingsEventObject:
                            await OnThingsEventAsync((ThingsEventObject)currentEvent).ConfigureAwait(false);
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }

                return Ok();
            }
            catch (NotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected abstract Task OnMessageEventAsync(MessageEventObject messageEventObject);
        protected abstract Task OnUnSendEventAsync(UnSendEventObject unSendEventObject);
        protected abstract Task OnFollowEventAsync(FollowEventObject followEventObject);
        protected abstract Task OnUnFollowEventAsync(UnFollowEventObject unFollowEventObject);
        protected abstract Task OnJoinEventAsync(JoinEventObject joinEventObject);
        protected abstract Task OnLeaveEventAsync(LeaveEventObject leaveEventObject);
        protected abstract Task OnMemberJoinEventAsync(MemberJoinEventObject memberJoinEventObject);
        protected abstract Task OnMemberLeaveEventAsync(MemberLeaveEventObject memberLeaveEventObject);
        protected abstract Task OnPostBackEventAsync(PostBackEventObject postBackEventObject);
        protected abstract Task OnVideoViewingCompleteEventAsync(VideoViewingCompleteEventObject videoViewingCompleteEventObject);
        protected abstract Task OnBeaconEventAsync(BeaconEventObject beaconEventObject);
        protected abstract Task OnAccountLinkEventAsync(AccountLinkEventObject accountLinkEventObject);
        protected abstract Task OnThingsEventAsync(ThingsEventObject thingsEventObject);
    }
}
