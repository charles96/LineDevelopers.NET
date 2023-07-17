using System.Text.Json;
using Line;
using Line.Message;

var json = File.ReadAllText(@"c:\temp\test.json");
var config = JsonSerializer.Deserialize<TestConfig>(json);





using (var client = new LineMessagingClient(config.ChannelAccessToken))
{
    try
    {

        var result = await client.Bot.GetBotInformationAsync();

        Console.WriteLine(result.PremiumId);
        Console.WriteLine(result.PictureUrl);
        Console.WriteLine($"User ID : {result.UserId}");
        Console.WriteLine($"ChatMode : {result.ChatMode}");
        Console.WriteLine($"MarkAsReadMode : {result.MarkAsReadMode}");

    }
    catch (LineCredentialException ex)
    {
        Console.WriteLine($"error : {ex.Message}");
        Console.WriteLine($"error_description : {ex.Detail}");
    }
}


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
