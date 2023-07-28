using System.Net.Http.Headers;
using System.Text.Json;
using Line;
using Line.Login;
using Line.Message;

var json = File.ReadAllText(@"c:\temp\test.json");
var config = JsonSerializer.Deserialize<TestConfig>(json);


using (var client = new LineMessagingClient(config.ChannelAccessToken))
{
    string requestId = String.Empty;

    var messages = new List<IMessage>()
    {
        new TextMessage("first"),
        new StickerMessage("6632","11825375")
        { 
            QuickReply = new QuickReply()
            {
                    Items = new List<QuickReplyButtonObject>()
                    {
                        new QuickReplyButtonObject()
                        {
                            Action = new UriAction()
                            {
                                Label = "test label",
                                Uri = "http://lunasoft.co.kr"
                            }
                        }
                    }
            }
        }
    };

    await client.Message.SendBroadcastMessageAsync(messages,
            getResponseHeaders: async (o) =>
            {
                IEnumerable<string> xLineRequestId;

                if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                {
                    requestId = xLineRequestId.First();

                    Console.WriteLine(requestId);
                }
            });

    try
    {
        await Task.Delay(60000);

        var result = await client.Insight.GetUserInteractionStatisticsAsync(requestId);

        Console.WriteLine(result.Overview.RequestId);

    }
    catch (LineException ex)
    {
        Console.WriteLine(ex.Message);
    }
}



//using (var test = new LineMessagingClient(config.ChannelAccessToken))
//{
//    await test.Message.SendPushMessageAsync("", new TextMessage("fdasfds"),
//        getResponseHeaders: (o) =>
//        {
//            IEnumerable<string> xLineRequestId;
//            IEnumerable<string> xLineAcceptedRequestId;

//            if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
//            {
//                Console.WriteLine(xLineRequestId.First());
//            }

//            if (o.TryGetValues("X-Line-Accepted-Request-Id", out xLineAcceptedRequestId))
//            {
//                Console.WriteLine(xLineAcceptedRequestId.First());
//            }
//        });
//}




//using (LineLoginClient client = new LineLoginClient())
//{
//    var issued = await client.OAuth2dot1.IssueAccessTokenAsync("code", "redirectUrl", "clientId", "secret");
//    var profile = await client.GetUserProfileAsync(issued.AccessToken);
//}


//using (var client2 = new LineMessagingClient(config.ChannelAccessToken))
//{
//    try
//    {

//        var result = await client2.Bot.GetBotInformationAsync();

//        Console.WriteLine(result.PremiumId);
//        Console.WriteLine(result.PictureUrl);
//        Console.WriteLine($"User ID : {result.UserId}");
//        Console.WriteLine($"ChatMode : {result.ChatMode}");
//        Console.WriteLine($"MarkAsReadMode : {result.MarkAsReadMode}");

//    }
//    catch (LineCredentialException ex)
//    {
//        Console.WriteLine($"error : {ex.Message}");
//        Console.WriteLine($"error_description : {ex.Detail}");
//    }
//}




//var main = new Main();
//main.Sub.Method();
//main.Dispose();

//var sub = new Sub();
//sub.Method();
//sub.Dispose();





//public abstract class LineHttpClient : IDisposable
//{
//    public void Dispose()
//    { 
//    }
//}

//public class Main : LineHttpClient
//{
//    public Main() { }

//    public ISub Sub { get; set; } = new Sub();
//}

//public class Sub : LineHttpClient, ISub
//{
//    public string Method()
//    {
//        Console.WriteLine("hello");
//        return "";
//    }
//}

//public interface ISub
//{
//    public string Method();
//}



//var json = File.ReadAllText(@"c:\temp\test.json");
//var config = JsonSerializer.Deserialize<TestConfig>(json);

//    try
//    {
//        using (var client = new LineMessageClient(config.ChannelAccessToken))
//        {
//            await client.SendPushMessageAsync("userId", new TextMessage("hello world"));
//        }
//    }
//    catch (LineException ex)
//    {
//        Console.WriteLine(ex.Message);

//        foreach (var detail in ex.Details ?? Enumerable.Empty<Detail>())
//        {
//            Console.WriteLine(detail.Message);
//            Console.WriteLine(detail.Property);
//        }
//    }


internal class TestConfig
{
    public string ChannelAccessToken { get; set; }
    public string UserID { get; set; }
    public string ChannelId { get; set; }
    public string ChannelSecret { get; set; }
}
