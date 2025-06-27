public class GitHubEvent
{
    public string Type { get; set; }
    public Repo Repo { get; set; }

    public string ToDisplayString()
    {
        return Type switch
        {
            "PushEvent" => $"Pushed to {Repo?.Name}",
            "IssuesEvent" => $"Interacted with an issue in {Repo?.Name}",
            "WatchEvent" => $"Starred {Repo?.Name}",
            "ForkEvent" => $"Forked {Repo?.Name}",
            _ => $"{Type} in {Repo?.Name}"
        };
    }
}

public class Repo
{
    public string Name { get; set; }
}