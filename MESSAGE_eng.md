# how to create / send a message

# message types & quick reply
LINE message API has been offered variant message types and you can develop it through LineDevelopers.NET.  
please refer to my wiki.
* [Wiki](https://github.com/charles96/LineDevelopers.NET/wiki)

# test codes
  * [test codes to send a message of each types](https://github.com/charles96/LineDevelopers.Net/blob/master/Src/LineDevelopers.Tests/LineMessageClientTest.cs)
  * [flex message simulator example](https://github.com/charles96/LineDevelopers.NET/wiki/flex-message-simulator-example)

# send message sample
* example to send a simple text message with a 'X-Line-Retry-Key' header via SendBroadcastMessageAsync method
    ```csharp
    using Line;
    using Line.Message;

    using (var client = new LineMessagingClient("your access token"))
    {
        try
        {
            await client.Message.SendBroadcastMessageAsync(new TextMessage("hello world"), xLineRetryKey: Guid.NewGuid().ToString());
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
* send multiple message types all at once via SendBroadcastMessageAsync 
    ```csharp
    var messages = new List<IMessage>()
    {
        new TextMessage()
        {
            Text = "hello world!"
        },
        new StickerMessage()
        {
            PackageId = "6632",
            StickerId = "11825375"
        },
        new LocationMessage()
        {
            Title = "location title",
            Address = "location address",
            Longitude = 127.0374m,
            Latitude = 37.5444m
        },
        new TemplateMessage()
        {
            AltText = "alt text",
            Template = new ButtonTemplate()
            {
                Title = "button template title",
                Text = "button template text",
                Actions = new List<IAction>()
                {
                    new PostBackAction()
                    {
                        Label = "pb action label",
                        Text = "pb text",
                        Data = "pb data"
                    }
                }
            }
        },
        new TextMessage()
        {
            Text = "text with quick",
            QuickReply = new QuickReply()
            {
                Items = new List<QuickReplyButtonObject>()
                {
                    new QuickReplyButtonObject()
                    {
                        Action = new UriAction()
                        {
                            Uri = "https://developers.line.biz/",
                            Label = "uri label"
                        }
                    }
                }
            }
        }
    };
    
    await client.Message.SendBroadcastMessageAsync(messages);
    ```
# methods for send message
```csharp
Task SendReplyMessageAsync(string replyToken, IMessage message, bool? notificationDisabled = null);
Task SendReplyMessageAsync(string replyToken, IList<IMessage> messages, bool? notificationDisabled = null);
Task SendPushMessageAsync(string to, IList<IMessage> messages, bool? notificationDisabled = null, string? xLineRetryKey = null);
Task SendPushMessageAsync(string to, IMessage message, bool? notificationDisabled = null, string? xLineRetryKey = null);
Task SendMulticastMessageAsync(IList<string> to, IList<IMessage> messages, bool? notificationDisabled = null, IList<string>? customAggregationUnits = null, string? xLineRetryKey = null);
Task SendMulticastMessageAsync(IList<string> to, IMessage message, bool? notificationDisabled = null, IList<string>? customAggregationUnits = null, string? xLineRetryKey = null);
Task SendNarrowcastMessageAsync(IList<IMessage> messages, IRecipientObject? recipient = null, NarrowcastMessageFilter? filter = null, NarrowcastLimit? limit = null, bool? notificationDisabled = null, string? xLineRetryKey = null);
Task SendNarrowcastMessageAsync(IMessage message, IRecipientObject? recipient = null, NarrowcastMessageFilter? filter = null, NarrowcastLimit? limit = null, bool? notificationDisabled = null, string? xLineRetryKey = null);
Task SendBroadcastMessageAsync(IList<IMessage> messages, bool? notificationDisabled = null, string? xLineRetryKey = null);
Task SendBroadcastMessageAsync(IMessage message, bool? notificationDisabled = null, string? xLineRetryKey = null);
```
# how to make a message via each type
LINE has varient messge types so, you can refer to the below sample cases.
all the message types can include [quick reply buttons](https://developers.line.biz/en/docs/messaging-api/using-quick-reply/) and it's an optional.

## 1. [Text message](https://developers.line.biz/en/reference/messaging-api/#text-message)
![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/text%20message.JPEG?raw=true)
```csharp
var message = new TextMessage()
{
    Text = "hello world"
};
```
## 2. [Sticker message](https://developers.line.biz/en/reference/messaging-api/#sticker-message)
![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/sticker%20message.JPEG?raw=true)
* [List of available stickers](https://developers.line.biz/en/docs/messaging-api/sticker-list/)

```csharp
var message = new StickerMessage()
{ 
    PackageId = "6632",
    StickerId = "11825375"
};
```
## 3. [Image message](https://developers.line.biz/en/reference/messaging-api/#image-message)
![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/image%20message.JPEG?raw=true)
```csharp
var message = new ImageMessage()
{
    OriginalContentUrl = "your image url",
    PreviewImageUrl = "preview image url"
};
```
## 4. [Video message](https://developers.line.biz/en/reference/messaging-api/#video-message)
```csharp
var message = new VideoMessage()
{
    OriginalContentUrl = "your mp4 video url",
    PreviewImageUrl = "your preview url",
    TrackingId = "trackingid"
};
```
## 5. [Audio message](https://developers.line.biz/en/reference/messaging-api/#audio-message)
```csharp
var message = new AudioMessage()
{
    OriginalContentUrl = "your m4a audio url",
    Duration = 100
};
```
## 6. [Location message](https://developers.line.biz/en/reference/messaging-api/#location-message)
![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/location%20message.JPEG?raw=true)
```csharp
var message = new LocationMessage()
{        
    Title = "location title",
    Address = "location address",
    Longitude = 127.0374m,
    Latitude = 37.5444m
};
```
## 7. [Imagemap Message](https://developers.line.biz/en/reference/messaging-api/#imagemap-message) 
```csharp
var message = new ImageMapMessage()
{
    BaseUrl = "https://example.com/bot/images/rm001",
    AltText = "This is an imagemap",
    BaseSize = new ImageMapBaseSize()
    { 
        Width = 1040,
        Height = 1040
    },
    Video = new ImageMapVideo()
    { 
        OriginalContentUrl = "https://example.com/video.mp4",
        PreviewImageUrl = "https://example.com/video_preview.jpg",
        Area = new ImageMapArea()
        {
            X = 0,
            Y = 0,
            Width = 1040,
            Height = 585
        },
        ExternalLink = new ImageMapExternalLink()
        { 
            LinkUri = "https://example.com/see_more.html",
            Label = "See More"
        }
    },
    Actions = new List<IImageMapAction>()
    { 
        new ImageMapUriAction()
        {
            LinkUri =  "https://example.com/",
            Area = new ImageMapArea()
            { 
                X = 0,
                Y = 586,
                Width = 520,
                Height = 454
            }
        },
        new ImageMapMessageAction()
        { 
            Text = "Hello",
            Area = new ImageMapArea()
            { 
                X = 520,
                Y = 586,
                Width = 520,
                Height = 454
            }
        }
    }
};
```
## 8. [Template Message](https://developers.line.biz/en/reference/messaging-api/#template-messages)
### 8-1. [Buttons Template](https://developers.line.biz/en/reference/messaging-api/#buttons)
![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/button%20template%20message.jpg?raw=true)
```csharp
var message = new TemplateMessage()
{
    AltText = "alt text",
    Template = new ButtonTemplate()
    {
        Title = "button template title",
        Text = "button template text",
        Actions = new List<IAction>()
        {
            new PostBackAction()
            {
                Label = "pb action",
                Text = "pb text",
                Data = "pb data"
             }
        }
    }
};
```
### 8-2. [Confirm Template](https://developers.line.biz/en/reference/messaging-api/#confirm)
![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/confirm%20template%20message.png?raw=true)
```csharp
var message = new TemplateMessage()
{
    AltText = "this is a confirm template",
    Template = new ConfirmTemplate()
    {
        Text = "Are you sure?",
        Actions = new List<IAction>()
        {
            new MessageAction()
            {
                Label = "Yes",
                Text = "yes"
            },
            new MessageAction()
            {
                Label = "No",
                Text = "no"
            }
        }
    }
};
```
### 8-3. [Carousel Template](https://developers.line.biz/en/reference/messaging-api/#carousel)
![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/carousel%20template%20message.JPEG?raw=true)

```csharp
var message = new TemplateMessage()
{
    AltText = "alt text",
    Template = new CarouselTemplate()
    {
        Columns = new List<CarouselColumnObject>()
        {
            new CarouselColumnObject()
            {
                ThumbnailImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/47/VU-Banana-1000x1000.png",
                ImageBackgroundColor = "#FFFFFF",
                Title = "carousel title 1",
                Text = "carousel text 1",
                Actions = new List<IAction>()
                {
                    new PostBackAction()
                    {
                        Label = "pb action",
                        Text = "pb text",
                        Data = "pb data"
                    }
                }
            },
            new CarouselColumnObject()
            {
                ThumbnailImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/47/VU-Banana-1000x1000.png",
                Title = "carousel title 2",
                Text = "carousel text 2",
                Actions = new List<IAction>()
                {
                    new PostBackAction()
                    {
                        Label = "pb action",
                        Text = "pb text",
                        Data = "pb data"
                    }
                }
            }
        }
    }
};
```
### 8-4. [Image Carousel Template](https://developers.line.biz/en/reference/messaging-api/#image-carousel)
![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/image%20carousel%20template%20message.JPEG?raw=true)
```csharp
var message = new TemplateMessage()
{
    AltText = "alt text",
    Template = new ImageCarouselTemplate()
    {
        Columns = new List<ImageCarouselColumnObject>()
        {
            new ImageCarouselColumnObject()
            {
                ImageUrl = "https://imageurl",
                Action = new PostBackAction()
                {
                    Label = "pb action 1",
                    Text = "pb text 1",
                    Data = "pb data 1"
                }
            },
            new ImageCarouselColumnObject()
            {
                ImageUrl = "https://imageurl",
                Action = new PostBackAction()
                {
                    Label = "pb action 2",
                    Text = "pb text 2",
                    Data = "pb data 2"
                }
            }
        }
    }
};
```
## 9. [Flex Message](https://developers.line.biz/en/reference/messaging-api/#flex-message)
![image](https://github.com/charles96/LineDevelopers.Net/blob/master/Assets/flex%20message.JPEG?raw=true)
```csharp
var message = new FlexMessage()
{
    AltText = "flex message test",
    Contents = new Bubble()
    {
        Hero = new ImageComponent()
        {
            Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/01_1_cafe.png",
            Size = SizeType.Full,
            AspectRatio = "20:13",
            AspectMode = AspectModeType.Cover,
            Action = new UriAction()
            {
                Uri = "http://linecorp.com/"
            }
        },
        Body = new BoxComponent()
        {
            Layout = BoxLayoutType.Vertical,
            Contents =
            {
                new TextComponent()
                {
                    Text = "Brown Cafe",
                    Weight = WeightType.Bold,
                    Size = SizeType.Xl
                },
                new BoxComponent()
                {
                    Layout = BoxLayoutType.Baseline,
                    Margin = MarginType.Md,
                    Contents =
                    {
                        new IconComponent()
                        {
                            Size = SizeType.Sm,
                            Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                        },
                        new IconComponent()
                        {
                            Size = SizeType.Sm,
                            Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                        },
                        new IconComponent()
                        {
                            Size = SizeType.Sm,
                            Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                        },
                        new IconComponent()
                        {
                            Size = SizeType.Sm,
                            Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                        },
                        new IconComponent()
                        {
                            Size = SizeType.Sm,
                            Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gray_star_28.png"
                        },
                        new TextComponent()
                        {
                            Text = "4.0",
                            Size = SizeType.Sm,
                            Color = "#999999",
                            Margin = MarginType.Md,
                            Flex = 0
                        }
                    }
                },
                new BoxComponent()
                {
                    Layout = BoxLayoutType.Vertical,
                    Margin = MarginType.Lg,
                    Spacing = SpacingType.Sm,
                    Contents =
                    {
                        new BoxComponent()
                        {
                            Layout = BoxLayoutType.Baseline,
                            Spacing = SpacingType.Sm,
                            Contents =
                            {
                                new TextComponent()
                                {
                                    Text = "Place",
                                    Color = "#aaaaaa",
                                    Size = SizeType.Sm,
                                    Flex = 1
                                },
                                new TextComponent()
                                {
                                    Text = "Miraina Tower, 4-1-6 Shinjuku, Tokyo",
                                    Wrap = true,
                                    Color = "#666666",
                                    Size = SizeType.Sm,
                                    Flex = 5
                                }
                            }
                        }
                    }
                },
                new BoxComponent()
                {
                    Layout = BoxLayoutType.Baseline,
                    Spacing = SpacingType.Sm,
                    Contents =
                    {
                        new TextComponent()
                        {
                            Text = "Time",
                            Color = "#aaaaaa",
                            Size = SizeType.Sm,
                            Flex= 1
                        },
                        new TextComponent()
                        {
                            Text =  "10:00 - 23:00",
                            Wrap = true,
                            Color = "#666666",
                            Size = SizeType.Sm,
                            Flex = 5
                        }
                    }
                }
            }
        },
        Footer = new BoxComponent()
        {
            Layout = BoxLayoutType.Vertical,
            Spacing = SpacingType.Sm,
            Contents =
            {
                new ButtonComponent()
                {
                    Style = ButtonStyleType.Link,
                    Height = "sm",
                    Action = new UriAction()
                    {
                        Label = "CALL",
                        Uri = "https://linecorp.com"
                    }
                },
                new ButtonComponent()
                {
                    Style = ButtonStyleType.Link,
                    Height = "sm",
                    Action = new UriAction()
                    {
                        Label = "WEBSITE",
                        Uri = "https://linecorp.com"
                    }
                },
                new BoxComponent()
                {
                    Layout = BoxLayoutType.Vertical,
                    Margin = MarginType.Sm
                }
            },
            Flex = 0
        },
    },
};
```
