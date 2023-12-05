using System.Net.Mail;
using StockQuoteAlert.Interface;

namespace StockQuoteAlert.Classes;

internal class BuyAction : IAction
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