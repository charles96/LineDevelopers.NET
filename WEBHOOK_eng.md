# webhook api quick start
This is a simple test through WebHook. if you'd like to webhook test quickly using LINE Developers.NET, 
please following below description step by step.
# quick start
## 1. [LINE Developers](https://developers.line.biz/console/) 
* Messaging API → issue and copy to Channel access token (long-lived)

## 2. open webhook api sample project
1. download [line webhook sample](https://github.com/charles96/LineDevelopers.Net/tree/master/Src/LineDevelopers.Webhook.Sample) project 
2. Visual Studio → open line webhook sample project
3. modify to your Channel access token in LineController constructor
  * LineController.cs
  ```csharp
  public LineController()
  {
      _client = new LineMessagingClient("your channel access token"); //here
  }
  ```
4. Visual Studio → F5
5. take a note or remember of your localhost address and callback url.
  * ex) localhost : https://localhost:7250, callback url: /line/callback
  ![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/swagger.png?raw=true)

## 3. install ngrok & setting
need to follow the below process for LINE Messenger Serever call directly your local webhook address.
### 3-1. Download the ngrok what your proper PC environment
  * [ngrok download](https://ngrok.com/download)
### 3-2. ngrok 
1. run ngrok with your local host in console
    ```console
    ngrok http https://localhost:7250/
    ```
2. copy created host via ngrok
![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/ngrok_run.png?raw=true)

## 4. register Webhook url in LINE Developers 
![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/line_webhook.png?raw=true)

1. [LINE Developers Console](https://developers.line.biz/console/) → Messaging API → Webhook settings
2. Use webhhook ✔
3. Webhook URL → Edit → ngrok host + callback url → Update → Verifiy → Success

## 5. LINE Messanger
If you type some text on your channel, you'll get the message from LINE messenger which is set the webhook.
# sample source
|LINE Developers|Methods|
|---|---|
|[Message event](https://developers.line.biz/en/reference/messaging-api/#message-event)|OnMessageEventAsync|
|[Unsend event](https://developers.line.biz/en/reference/messaging-api/#unsend-event)|OnUnSendEventAsync|
|[Follow event](https://developers.line.biz/en/reference/messaging-api/#follow-event)|OnFollowEventAsync|
|[Unfollow event](https://developers.line.biz/en/reference/messaging-api/#unfollow-event)|OnUnFollowEventAsync|
|[Join event](https://developers.line.biz/en/reference/messaging-api/#join-event)|OnJoinEventAsync|
|[Leave event](https://developers.line.biz/en/reference/messaging-api/#leave-event)|OnLeaveEventAsync|
|[Member join event](https://developers.line.biz/en/reference/messaging-api/#member-joined-event)|OnMemberJoinEventAsync|
|[Member leave event](https://developers.line.biz/en/reference/messaging-api/#member-left-event)|OnMemberLeaveEventAsync|
|[Postback event](https://developers.line.biz/en/reference/messaging-api/#postback-event)|OnPostBackEventAsync|
|[Video viewing complete event](https://developers.line.biz/en/reference/messaging-api/#video-viewing-complete)|OnVideoViewingCompleteEventAsync|
|[Beacon event](https://developers.line.biz/en/reference/messaging-api/#beacon-event)|OnBeaconEventAsync|
|[Account link event](https://developers.line.biz/en/reference/messaging-api/#account-link-event)|OnAccountLinkEventAsync|
|[Device link event](https://developers.line.biz/en/reference/messaging-api/#device-link-event)|OnThingsEventAsync|
|[Device unlink event](https://developers.line.biz/en/reference/messaging-api/#device-unlink-event)|OnThingsEventAsync|
|[LINE Things scenario execution event](https://developers.line.biz/en/reference/messaging-api/#scenario-result-event)|OnThingsEventAsync|

# example
## ping pong message
This is a sample of message property handling of [Message event](https://developers.line.biz/en/reference/messaging-api/#message-event), 
it will response as a user input a text or sticker.
```csharp
protected override async Task OnMessageEventAsync(MessageEventObject messageEventObject)
{
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
}
```
## a sample of source property handling

* [Source user](https://developers.line.biz/en/reference/messaging-api/#source-user)
* [Source group chat](https://developers.line.biz/en/reference/messaging-api/#source-group)
* [Source multi-person chat](https://developers.line.biz/en/reference/messaging-api/#source-room)

```csharp
protected override async Task OnMessageEventAsync(MessageEventObject messageEventObject)
{
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
}
```
