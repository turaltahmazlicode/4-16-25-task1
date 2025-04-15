using System.Diagnostics;
using System.Net;

namespace ConsoleApp;

internal class Program
{
    static readonly HttpClient client = new HttpClient();

    static async Task Main()
    {
        List<string> urls = new List<string>
        {
            "https://www.google.com/",
            "https://www.youtube.com/",
            "https://www.facebook.com/",
            "https://www.tiktok.com/",
            "https://www.instagram.com/",
            "https://www.github.com/"
        };
        Stopwatch stopwatch = new Stopwatch();
        foreach (var url in urls)
        {
            stopwatch.Start();
            HttpStatusCode code = await GetData(url);
            stopwatch.Stop();
            if (code is HttpStatusCode.OK)
                Console.WriteLine($"The URL ({url}) responded in {(stopwatch.ElapsedMilliseconds / 1000d).ToString("0.00")} seconds.");
            stopwatch.Restart();
        }
    }

    static async Task<HttpStatusCode> GetData(string url)
    {
        using HttpResponseMessage response = await client.GetAsync(url);
        return response.StatusCode;
    }
}
