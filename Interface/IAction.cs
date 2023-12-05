using System.Net.Mail;
using StockQuoteAlert.Classes;

namespace StockQuoteAlert.Interface;

internal interface IAction
{
    MailMessage MakeMessage(Config.EmailData from, Config.EmailData to, string stock, decimal price);
}