using System.Text.Json;
using Line;
using Line.Liff;

var json = File.ReadAllText(@"c:\temp\test.json");
var config = JsonSerializer.Deserialize<TestConfig>(json);


try
{
    using (var client = new LineLiffClient("access token"))
    {
        var liffs = await client.GetAllLiffAppsAsync();

        foreach (var liff in liffs)
        {
            await client.DeleteLiffAppsFromChannelAsync(liff.LiffId);
        }
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
