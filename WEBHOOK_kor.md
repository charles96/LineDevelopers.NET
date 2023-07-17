# webhook api quick start
LINE Develpers.NET library를 이용하여 간단한 webhook을 테스트 하는 방법에 대해 소개합니다.

# quick start
## 1. [LINE Developers](https://developers.line.biz/console/) 이동
* Messaging API → Channel access token (long-lived)을 발급 및 복사합니다.

## 2. open api project
1. [line webhook sample](https://github.com/charles96/LineDevelopers.Net/tree/master/Src/LineDevelopers.Webhook.Sample) project 다운로드
2. Visual Studio → open project
3. LineController.cs
  * channel access token 수정
  ```csharp
  public LineController()
  {
      _client = new LineMessagingClient("your channel access token"); //수정
  }
  ```
4. Visual Studio → F5를 통해 project 실행 
5. 아래와 같이 host 및 callback 경로를 기억한다.  
  * ex) host : https://localhost:7250, callback url: /line/callback
  ![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/swagger.png?raw=true)

## 3. ngrok 설치 및 세팅
자신의 local에 생성한 api를 LINE Messanger 서버에서 직접 호출하기 위해 아래와 같은 절차가 필요하다.
### 3-1. 자신의 pc환경에 맞는 ngrok을 다운로드
  * [ngrok download](https://ngrok.com/download)
### 3-2. ngrok 실행
1. console에서 아래와 같이 자신의 localhost주소를 넣고 실행
    ```console
    ngrok http https://localhost:7250/
    ```
2. 생성된 도메인 복사
![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/ngrok_run.png?raw=true)

## 4. LINE Developers Webhook 등록
![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/line_webhook.png?raw=true)

1. [LINE Developers Console](https://developers.line.biz/console/)> Messaging API> Webhook settings 이동
2. Use webhhook ✔
3. Webhook URL → Edit → ngrok 생성 host + callback url 입력 → Update → Verifiy → Success

## 5. LINE Messanger
해당 채널에서 메시지를 보내면 응답이 올 것 입니다.

# sample source 설명
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
[Message event](https://developers.line.biz/en/reference/messaging-api/#message-event)의 message property 핸들링 예제이며, 유저가 입력한 text메시지 또는 sticker메시지를 따라 응답합니다.

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
## Webhook의 Source 정보 획득 방법
웹훅의 source property 핸들링 예제입니다.
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
