﻿using StockQuoteAlert.Classes;

namespace StockQuoteAlert;

internal static class Program{
    private static async Task Main(string[] args)
    {
        var inputArgs = new Input(args);
        var configs = Config.GetSetup("./appsettings.json");
        
        var api = new Api(configs.ApiToken);
        while (true)
        {
            var actualPrice = await api.GetPriceStock(inputArgs.Stock);

            if (actualPrice >= inputArgs.PriceSell)
            {
                Console.WriteLine($"Sending emails to sell {inputArgs.Stock}");
                var emailManager = new EmailManager(new SellAction(), configs);
                await emailManager.SendEmail(inputArgs, inputArgs.PriceSell);
            }
            else if (actualPrice <= inputArgs.PriceBuy)
            {
                Console.WriteLine($"Sending emails to buy {inputArgs.Stock}");
                var emailManager = new EmailManager(new BuyAction(), configs);
                await emailManager.SendEmail(inputArgs, inputArgs.PriceBuy);
            }
            await Task.Delay(configs.ApiTimer);
        }
        // ReSharper disable once FunctionNeverReturns
    }

}