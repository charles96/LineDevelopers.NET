[![dotnet version](https://img.shields.io/badge/.NET-7.x-blue)](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-7)

# LINE Developers.Net
이 라이브러리는 [LINE Developers](https://developers.line.biz/en/docs/)의 API를 C# 라이브러리로 개발한 것이며, LINE Developers와 관련없는 비공식 라이브러리 임을 밝힙니다.
한국에서는 지원하지 않거나 유료 기반의 기능들은 테스트를 완료하지 못했습니다. 참고하시기 바라며 LINE Messenger 기반 메시지 발송 또는 챗봇을 개발하시는 분들께 도움이 되길 바랍니다.

# 1. 사용 가이드 문서
1. Nuget을 통한 설치
* [![Nuget](https://img.shields.io/nuget/v/LineDevelopers.svg)](https://www.nuget.org/packages/LineDevelopers)
    ```powershell
    Install-Package LineDevelopers 
    ```
2. [메시지 생성 및 발송 가이드](https://github.com/charles96/LineDevelopers.Net/blob/master/MESSAGE_kor.md)
3. [webhook quick start](https://github.com/charles96/LineDevelopers.Net/blob/master/WEBHOOK_kor.md)

# 2. 라이브러리 소개

## 2-1. LineChannelAccessTokenClient class
* [Channel access token](https://developers.line.biz/en/reference/messaging-api/#channel-access-token)

```csharp
using Line;

using (var client = new LineChannelAccessTokenClient())
{
    try
    {
        var result = await client.IssueShortLivedChannelAccessTokenAsync("client id", "secret");

        await client.VerifyShortLonglivedChannelAccessTokenAsync(result.AccessToken);
    }
    catch (LineCredentialException ex)
    {
        Console.WriteLine($"error : {ex.Message}");
        Console.WriteLine($"error_description : {ex.Detail}");
    }
}
```

|LINE Developers|Methods|Tested|
|---|---|---|
|[Issue channel access token v2.1](https://developers.line.biz/en/reference/messaging-api/#issue-channel-access-token-v2-1)|IssueChannelAccessTokenAsync|✔|
|[Verify the validity of the channel access token v2.1](https://developers.line.biz/en/reference/messaging-api/#verfiy-channel-access-token-v2-1)|VerifyChannelAccessTokenAsync|✔|
|[Get all valid channel access token key IDs v2.1](https://developers.line.biz/en/reference/messaging-api/#get-all-valid-channel-access-token-key-ids-v2-1)|GetAllValidChannelAccessTokenKeyIDsAsync|❌|
|[Revoke channel access token v2.1](https://developers.line.biz/en/reference/messaging-api/#revoke-channel-access-token-v2-1)|RevokeChannelAccessTokenAsync|❌|
|[Issue short-lived channel access token](https://developers.line.biz/en/reference/messaging-api/#issue-shortlived-channel-access-token)|IssueShortLivedChannelAccessTokenAsync|✔|
|[Verify the validity of short-lived and long-lived channel access tokens](https://developers.line.biz/en/reference/messaging-api/#verfiy-channel-access-token)|VerifyShortLonglivedChannelAccessTokenAsync|✔|
|[Revoke short-lived or long-lived channel access token](https://developers.line.biz/en/reference/messaging-api/#revoke-longlived-or-shortlived-channel-access-token)|RevokeShortLongLivedChannelAccessTokenAsync|✔|

## 2-2. LineMessagingClient class
각 기능 별로 개별 class들이 아래와 같이 존재합니다. 하지만 LineMessagingClient를 통해 
아래의 모든 기능들을 사용 할 수 있으며 LineMessagingClient를 통해 구현하는 것을 권장합니다.

* 예시)
    ```csharp
    using Line.Message;

    using (var client = new LineMessagingClient("your access token"))
    {
        await client.Message.SendBroadcastMessageAsync(new TextMessage("hello world"));
        await client.Message.SendReplyMessageAsync("reply token", new TextMessage("hello world"));
        await client.Insight.GetNumberOfMessageDeliveriesAsync(new DateOnly(2022, 10, 31));
        await client.RichMenu.DownloadRichMenuImageAsync("test richmenu id", @"c:\temp\test.jpg");
    }
    ```
### 2-2-1. LineMessageClient class
* [Message](https://developers.line.biz/en/reference/messaging-api/#messages)

|LINE Developers|Methods|Tested|
|---|---|---|
|[Send reply message](https://developers.line.biz/en/reference/messaging-api/#send-reply-message)|SendReplyMessageAsync|✔|
|[Send push message](https://developers.line.biz/en/reference/messaging-api/#send-push-message)|SendPushMessageAsync|✔|
|[Send multicast message](https://developers.line.biz/en/reference/messaging-api/#send-multicast-message)|SendMulticastMessageAsync|✔|
|[Send narrowcast message](https://developers.line.biz/en/reference/messaging-api/#send-narrowcast-message)|SendNarrowcastMessageAsync|❌|
|[Send broadcast message](https://developers.line.biz/en/reference/messaging-api/#send-broadcast-message)|SendBroadcastMessageAsync|✔|
|[Get the target limit for sending messages this month](https://developers.line.biz/en/reference/messaging-api/#get-quota)|GetTheTargetLimitForSendingMessagesThisMonthAsync|✔|
|[Get number of messages sent this month](https://developers.line.biz/en/reference/messaging-api/#get-consumption)|GetNumberOfMessagesSentThisMonthAsync|✔|
|[Get number of sent reply messages](https://developers.line.biz/en/reference/messaging-api/#get-number-of-reply-messages)|GetNumberOfSentMessagesAsync|✔|
|[Get number of sent push messages](https://developers.line.biz/en/reference/messaging-api/#get-number-of-push-messages)|GetNumberOfSentMessagesAsync|✔|
|[Get number of sent multicast messages](https://developers.line.biz/en/reference/messaging-api/#get-number-of-multicast-messages)|GetNumberOfSentMessagesAsync|✔|
|[Get number of sent broadcast messages](https://developers.line.biz/en/reference/messaging-api/#get-number-of-broadcast-messages)|GetNumberOfSentMessagesAsync|✔|
|[Validate message objects of a reply message](https://developers.line.biz/en/reference/messaging-api/#validate-message-objects-of-reply-message)|ValidateMessageObjectsOfMessageAsync|✔|
|[Validate message objects of a push message](https://developers.line.biz/en/reference/messaging-api/#validate-message-objects-of-push-message)|ValidateMessageObjectsOfMessageAsync|✔|
|[Validate message objects of a multicast message](https://developers.line.biz/en/reference/messaging-api/#validate-message-objects-of-multicast-message)|ValidateMessageObjectsOfMessageAsync|✔|
|[Validate message objects of a narrowcast message](https://developers.line.biz/en/reference/messaging-api/#validate-message-objects-of-narrowcast-message)|ValidateMessageObjectsOfMessageAsync|❌|
|[Validate message objects of a broadcast message](https://developers.line.biz/en/reference/messaging-api/#validate-message-objects-of-broadcast-message)|ValidateMessageObjectsOfMessageAsync|✔|
|[Get number of units used this month](https://developers.line.biz/en/reference/messaging-api/#get-number-of-units-used-this-month)|GetNumberOfUnitsUsedThisMonthAsync|✔|
|[Get name list of units used this month](https://developers.line.biz/en/reference/messaging-api/#get-name-list-of-units-used-this-month)|GetNameListOfUnitsUsedThisMonthAsync|✔|

### 2-2-2. LineInsightClient class
* [Insight](https://developers.line.biz/en/reference/messaging-api/#get-insight)

|LINE Developers|Methods|Tested|
|---|---|---|
|[Get number of message deliveries](https://developers.line.biz/en/reference/messaging-api/#get-number-of-delivery-messages)|GetNumberOfMessageDeliveriesAsync|✔|
|[Get number of followers](https://developers.line.biz/en/reference/messaging-api/#get-number-of-followers)|GetNumberOfFollowersAsync|✔|
|[Get friend demographics](https://developers.line.biz/en/reference/messaging-api/#get-demographic)|GetFriendsDemographicsAsync|✔|
|[Get user interaction statistics](https://developers.line.biz/en/reference/messaging-api/#get-message-event)|GetUserInteractionStatisticsAsync|✔|
|[Get statistics per unit](https://developers.line.biz/en/reference/messaging-api/#get-statistics-per-unit)|GetStatisticsPerUnitAsync|✔|

### 2-2-3. LineRichMenuClient class
* [Rich menu](https://developers.line.biz/en/reference/messaging-api/#rich-menu)

|LINE Developers|Methods|Tested|
|---|---|---|
|[Create rich menu](https://developers.line.biz/en/reference/messaging-api/#create-rich-menu)|CreateRichMenuAsync|✔|
|[Validate rich menu object](https://developers.line.biz/en/reference/messaging-api/#validate-rich-menu-object)|ValidateRichMenuAsync|✔|
|[Upload rich menu image](https://developers.line.biz/en/reference/messaging-api/#upload-rich-menu-image)|UploadRichMenuImageAsync|✔|
|[Download rich menu image](https://developers.line.biz/en/reference/messaging-api/#download-rich-menu-image)|DownloadRichMenuImageAsync|✔|
|[Get rich menu list](https://developers.line.biz/en/reference/messaging-api/#get-rich-menu-list)|GetRichMenuListAsync|✔|
|[Get rich menu](https://developers.line.biz/en/reference/messaging-api/#get-rich-menu)|GetRichMenuAsync|✔|
|[Delete rich menu](https://developers.line.biz/en/reference/messaging-api/#delete-rich-menu)|DeleteRichMenuAsync|✔|
|[Set default rich menu](https://developers.line.biz/en/reference/messaging-api/#set-default-rich-menu)|SetDefaultRichMenuAsync|✔|
|[Get default rich menu ID](https://developers.line.biz/en/reference/messaging-api/#get-default-rich-menu-id)|GetDefaultRichMenuIdAsync|✔|
|[Cancel default rich menu](https://developers.line.biz/en/reference/messaging-api/#cancel-default-rich-menu)|CancelDefaultRichMenuAsync|✔|
|[Create rich menu alias](https://developers.line.biz/en/reference/messaging-api/#create-rich-menu-alias)|CreateRichMenuAliasAsync|✔|
|[Delete rich menu alias](https://developers.line.biz/en/reference/messaging-api/#delete-rich-menu-alias)|DeleteRichMenuAliasAsync|✔|
|[Update rich menu alias](https://developers.line.biz/en/reference/messaging-api/#update-rich-menu-alias)|UpdateRichMenuAliasAsync|✔|
|[Get rich menu alias information](https://developers.line.biz/en/reference/messaging-api/#get-rich-menu-alias-by-id)|GetRichMenuAliasInformationAsync|✔|
|[Get list of rich menu alias](https://developers.line.biz/en/reference/messaging-api/#get-rich-menu-alias-list)|GetListOfRichMenuAliasAsync|✔|
|[Link rich menu to user](https://developers.line.biz/en/reference/messaging-api/#link-rich-menu-to-user)|LinkRichMenuToUserAsync|✔|
|[Link rich menu to multiple users](https://developers.line.biz/en/reference/messaging-api/#link-rich-menu-to-users)|LinkRichMenuToMultipleUsersAsync|✔|
|[Get rich menu ID of user](https://developers.line.biz/en/reference/messaging-api/#get-rich-menu-id-of-user)|GetRichMenuIdOfUserAsync|✔|
|[Unlink rich menu from user](https://developers.line.biz/en/reference/messaging-api/#unlink-rich-menu-from-user)|UnlinkRichMenuFromUserAsync|✔|
|[Unlink rich menus from multiple users](https://developers.line.biz/en/reference/messaging-api/#unlink-rich-menu-from-users)|UnlinkRichMenusFromMultipleUsersAsync|✔|
|[Replace or unlink the linked rich menus in batches](https://developers.line.biz/en/reference/messaging-api/#batch-control-rich-menus-of-users)|ReplaceOrUnlinkTheLinkedRichMenusInBatchesAsync|✔|
|[Get the status of rich menu batch control](https://developers.line.biz/en/reference/messaging-api/#get-batch-control-rich-menus-progress-status)|GetStatusOfRichMenuBatchControlAsync|❌|
|[Validate a request of rich menu batch control](https://developers.line.biz/en/reference/messaging-api/#validate-batch-control-rich-menus-request)|ValidateRequestOfRichMenuBatchControlAsync|✔|

### 2-2-4. LineGroupChatClient class
* [GroupChat](https://developers.line.biz/en/reference/messaging-api/#group)

|LINE Developers|Methods|Tested|
|---|---|---|
|[Get group chat summary](https://developers.line.biz/en/reference/messaging-api/#get-group-summary)|GetSummaryAsync|✔|
|[Get number of users in a group chat](https://developers.line.biz/en/reference/messaging-api/#get-members-group-count)|GetNumberOfUsersAsync|✔|
|[Get group chat member user IDs](https://developers.line.biz/en/reference/messaging-api/#get-group-member-user-ids)|GetMemberUserIdsAsync|✔|
|[Get group chat member profile](https://developers.line.biz/en/reference/messaging-api/#get-group-member-profile)|GetChatMemberProfileAsync|✔|
|[Leave group chat](https://developers.line.biz/en/reference/messaging-api/#leave-group)|LeaveAsync|✔|

### 2-2-5. LineMultiPersonChatClient class
* [MultiPersonChat](https://developers.line.biz/en/reference/messaging-api/#chat-room)

|LINE Developers|Methods|Tested|
|---|---|---|
|[Get number of users in a multi-person chat](https://developers.line.biz/en/reference/messaging-api/#get-members-room-count)|GetNumberOfUsersAsync|❌|
|[Get multi-person chat member user IDs](https://developers.line.biz/en/reference/messaging-api/#get-room-member-user-ids)|GetMemberUserIdsAsync|❌|
|[Get multi-person chat member profile](https://developers.line.biz/en/reference/messaging-api/#get-room-member-profile)|GetMemberProfileAsync|❌|
|[Leave multi-person chat](https://developers.line.biz/en/reference/messaging-api/#leave-room)|LeaveAsync|❌|

### 2-2-6. LineUserClient class
* [Users](https://developers.line.biz/en/reference/messaging-api/#users)

|LINE Developers|Methods|Tested|
|---|---|---|
|[Get profile](https://developers.line.biz/en/reference/messaging-api/#get-profile)|GetUserProfileAsync|✔|
|[Get a list of users who added your LINE Official Account as a friend](https://developers.line.biz/en/reference/messaging-api/#get-follower-ids)|GetFollowersAsync|❌|

## 2-2-7. LineAccountLinkClient class
* [Account link](https://developers.line.biz/en/reference/messaging-api/#account-link)

|LINE Developers|Methods|Tested|
|---|---|---|
|[Issue link token](https://developers.line.biz/en/reference/messaging-api/#issue-link-token)|IssueLinkTokenAsync|✔|

## 2-2-8. LineWebhookSettingClient class
* [Webhook settings](https://developers.line.biz/en/reference/messaging-api/#webhook-settings)

|LINE Developers|Methods|Tested|
|---|---|---|
|[Set webhook endpoint URL](https://developers.line.biz/en/reference/messaging-api/#set-webhook-endpoint-url)|SetEndpointUrlAsync|✔|
|[Get webhook endpoint information](https://developers.line.biz/en/reference/messaging-api/#get-webhook-endpoint-information)|GetEndpointInformationAsync|✔|
|[Test webhook endpoint](https://developers.line.biz/en/reference/messaging-api/#test-webhook-endpoint)|TestEndpointAsync|✔|

## 2-2-9. LineBotClient class
* [Bot](https://developers.line.biz/en/reference/messaging-api/#bot)

|LINE Developers|Methods|Tested|
|---|---|---|
|[Get bot info](https://developers.line.biz/en/reference/messaging-api/#get-bot-info)|GetBotInformationAsync|✔|

## 2-3 LineLiffClient class
* [LIFF Server API](https://developers.line.biz/en/reference/liff-server/)

```csharp
using Line;
using Line.Liff;

using (var client = new LineLiffClient("access token"))
{
    try
    {
        var liffs = await client.GetAllLiffAppsAsync();

        foreach (var liff in liffs)
        {
            await client.DeleteLiffAppsFromChannelAsync(liff.LiffId);
        }
    }
    catch (LineException ex)
    {
        Console.WriteLine(ex.Message);

        foreach (var detail in ex.Details ?? Enumerable.Empty<Detail>())
        {
            Console.WriteLine(detail.Message);
            Console.WriteLine(detail.Property);
        }
    }
}
```

|LINE Developers|Methods|Tested|
|---|---|---|
|[Adding the LIFF app to a channel](https://developers.line.biz/en/reference/liff-server/#add-liff-app)|AddLiffAppToChannelAsync|✔|
|[Update LIFF app settings](https://developers.line.biz/en/reference/liff-server/#update-liff-app)|UpdateLiffAppSettingAsync|✔|
|[Get all LIFF apps](https://developers.line.biz/en/reference/liff-server/#get-all-liff-apps)|GetAllLiffAppsAsync|✔|
|[Delete LIFF app from a channel](https://developers.line.biz/en/reference/liff-server/#delete-liff-app)|DeleteLiffAppsFromChannelAsync|✔|

# 3. 참고 문서
* [Messaging API reference](https://developers.line.biz/en/reference/messaging-api/)
* [How to serialize properties of derived classes with System.Text.Json](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/polymorphism?pivots=dotnet-7-0) 
* [System.Text.Json:How to specify a custom name for an enum value](https://itecnote.com/tecnote/c-system-text-json-how-to-specify-a-custom-name-for-an-enum-value/) 