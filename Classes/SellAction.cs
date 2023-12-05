using System.Net.Mail;
using StockQuoteAlert.Interface;

namespace StockQuoteAlert.Classes;

internal class SellAction : IAction
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
