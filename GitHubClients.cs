using System.Net.Http;
using System.Text.Json;

public class GitHubClients
{
    private readonly HttpClient _client;

    public GitHubClients()
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.UserAgent.ParseAdd("GitHubActivityApp");
    }

    public async Task<List<GitHubEvent>> GetUserEvents(string username)
    {
        var url = $"https://api.github.com/users/{username}/events";
        var response = await _client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("GitHub API vernul oshibku.");
        }

        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var events = JsonSerializer.Deserialize<List<GitHubEvent>>(json, options);

        return events ?? new List<GitHubEvent>();
    }
}