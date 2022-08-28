var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/spacenews", async () =>
{
    var client = new HttpClient();
    var request = new HttpRequestMessage
    {
        Method = HttpMethod.Get,
        RequestUri = new Uri("https://space-news.p.rapidapi.com/news/guardian"),
        Headers =
    {
        { "X-RapidAPI-Key", "dfdebe40d5mshc366520d6b88723p185427jsn269a01464245" },
        { "X-RapidAPI-Host", "space-news.p.rapidapi.com" },
    },
    };
    using (var response = await client.SendAsync(request))
    {
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        return body;
    }
});

app.Run();
