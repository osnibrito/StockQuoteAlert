using System.Data;

namespace stock_quote_alert;
using System;

public class Input
{
    public string Stock {get ; set;}
    public decimal PriceSell {get ; set;}
    public decimal PriceBuy {get ; set;}
    
    public Input(IReadOnlyList<string> args){
        switch (args.Count)
        {
            case > 3:
                throw new Exception($"Too much arguments. Expect 3 (stock, priceSell, priceBuy) got {args.Count}");
            case < 3:
                throw new Exception($"Missing arguments. Expect 3 (stock, priceSell, priceBuy) got {args.Count}");
        }
        
        if (decimal.TryParse(args[1], out var priceSell) & decimal.TryParse(args[2], out var priceBuy))
        {
            Stock = args[0];
            PriceSell = priceSell;
            PriceBuy = priceBuy;
        }
        else
        {
            throw new Exception(
                "Error parsing datatype, Expect (stock<string>, priceSell<decimal>, priceBuy<decimal>)");
        }

        if (priceBuy >= priceSell)
        {
            throw new Exception(
                "Price to sell must be greater than price to sell!");
        }
    }
          
   
}