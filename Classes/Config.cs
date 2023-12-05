using System.Text.Json;

namespace StockQuoteAlert.Classes;

internal abstract class Config
{
    internal struct EmailData
    {
        public string Address { get; set; }
        public string Username { get; set; }
    }

    public class Setup
    {
        public required string Host { get; set; }
        public int Port { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required EmailData Sender { get; set; }
        public IList<EmailData>? Users { get; set; }
        public required string ApiToken { get; set; }
        public int ApiTimer { get; set; }
    }

    public static Setup GetSetup(string filename)
    {
        var text = File.ReadAllText(filename);
        var setup = JsonSerializer.Deserialize<Setup>(text);
        
        if (setup is null)
        {
            throw new Exception("Error parsing appSettings.json");
        }
        if (setup.Users is null)
        {
            throw new Exception("Error parsing USERS in appSettings.json");
        }

        return setup;
    }
}