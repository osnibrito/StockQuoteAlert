using System.Net.Mail;
using System.Net;
using StockQuoteAlert.Interface;

namespace StockQuoteAlert.Classes;

internal class Email
{
    private readonly SmtpClient? _client;
    private readonly IAction _action;
    private readonly Config.EmailData _sender;
    private readonly IList<Config.EmailData> _receivers;

    public Email(IAction action, Config.Setup setup)
    {
        _action = action;
        _sender = setup.Sender;
        _receivers = setup.Users!;
        
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
    
    public void SendEmail(Input input, decimal referenceValue)
    {
        try
        {
            foreach (var receiver in _receivers)
            {
                var msg = _action.MakeMessage(_sender, receiver, input.Stock, referenceValue);
                _client!.Send(msg);
                Console.WriteLine($"Email sent to {receiver.Address}");
            }
        }
        catch (Exception err)
        {
            Console.WriteLine("Failed to send emails");
            Console.WriteLine(err);
        }
        _client!.Dispose();
    }
}