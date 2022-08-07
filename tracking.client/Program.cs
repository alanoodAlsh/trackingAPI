
using System.Net.Http.Headers;
using System.Net.Http.Json;
using tracking.client;

HttpClient client=new();
client.BaseAddress=new Uri("https://localhost:7250");
client.DefaultRequestHeaders.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = await client.GetAsync("api/Issue");
response.EnsureSuccessStatusCode();
if (response.IsSuccessStatusCode)
{
    var issues=await response.Content.ReadFromJsonAsync<IEnumerable<issueDto>>();
    foreach (var issue in issues)
    {
        Console.WriteLine(issue.title);
    }

}
else
{
    Console.WriteLine("no result");
}

Console.ReadLine();