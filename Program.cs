using System;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Enter: <GitHub username> ");
            return;
        }

        string username = args[0];
        var client = new GitHubClients();

        try
        {
            var events = await client.GetUserEvents(username);
            if (events.Count == 0)
            {
                Console.WriteLine("Activity ga dostup yoq ");
                return;
            }
            foreach (var e in events)
            {
                Console.WriteLine(e.ToDisplayString());
            }
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("Oshibka siti ili nepravilni username!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Proizoshlo oshibka: {ex.Message}");
        }
    }
}