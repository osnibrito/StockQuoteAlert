using System.Net.Mail;
using System.Net;
using stock_quote_alert.Interface;

namespace stock_quote_alert.Classes;

internal class Email
{
    private readonly SmtpClient? _client;
    private readonly IAction _action;
    public class EmailContent
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public Email(IAction action, Config.Setup setup)
    {
        _action = action;
        
        try
        {
            _client = new SmtpClient(setup.Host, setup.Port)
            {
                Credentials = new NetworkCredential(setup.Username, setup.Password),
                EnableSsl = true
            };

        }
        catch(Exception err)
        {
            Console.WriteLine("Failed to connect with SMTP client");
            Console.WriteLine(err);
        }
    }
    
    public void SendEmail(Config.Setup config, Input input, decimal referenceValue)
    {
        
        try
        {
            Console.WriteLine(config.Users!);
            foreach (var user in config.Users!)
            {
                var msg = _action.MakeMessage(config.Sender, user, input.Stock, referenceValue);
                _client!.Send(msg);
                Console.WriteLine($"Email sent to {user.Address}");
            }
        }
        catch (Exception err)
        {
            Console.WriteLine("Failed to send emails");
            Console.WriteLine(err);

        }

    }
}