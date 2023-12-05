using System.Net.Mail;
using stock_quote_alert.Classes;

namespace stock_quote_alert.Interface;

internal interface IAction
{
    MailMessage MakeMessage(Config.EmailData from, Config.EmailData to, string stock, decimal price);
}
internal class Buy : IAction
{
    public MailMessage MakeMessage(Config.EmailData from, Config.EmailData to, string stock, decimal price)
    {
        return new MailMessage(from.Address, to.Address)
        {
            IsBodyHtml = false,
            Body = $"The value of the stock {stock} is lower than the given reference value {price}\r\n"+
            "We suggest you make a buy now!",
            Subject = $"Hello {to.Username}! "+
            $"is a good time to buy the stock {stock}"
        };
    }
}

internal class Sell : IAction
{
    public MailMessage MakeMessage(Config.EmailData from, Config.EmailData to, string stock, decimal price)
    {
        return new MailMessage(from.Address, to.Address)
        {
            IsBodyHtml = false,
            Body = $"The value of the stock {stock} is greater than the given reference value {price}\r\n"+
                   "We suggest you make a sell now!",
            Subject = $"Hello {to.Username}! "+
                      $"is a good time to sell the stock {stock}"
        };
    }
}

