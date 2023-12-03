using stock_quote_alert.Classes;
using stock_quote_alert.Interface;

namespace stock_quote_alert;

internal static class Program{
    private static void Main(string[] args)
    {
        var inputArgs = new Input(args);
        var configs = Config.GetSetup("./appsettings.json");
        
        var emailManager = new Email(new Buy(), configs);
        emailManager.SendEmail(configs, inputArgs, inputArgs.PriceBuy);
    }

}