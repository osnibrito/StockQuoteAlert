using System.Data;

namespace stock_quote_alert;
using System;

public class Input
{
        public string Stock {get ; set;}
        public decimal PriceSell {get ; set;}
        public decimal PriceBuy {get ; set;}
    

    
    public Input(string[] args){
        switch (args.Length)
        {
            case > 3:
                throw new Exception($"Too much arguments. Expect 3 (stock, priceSell, priceBuy) got {args.Length}");
            case < 3:
                throw new Exception($"Missing arguments. Expect 3 (stock, priceSell, priceBuy) got {args.Length}");
        }
        
        if (decimal.TryParse(args[1], out var priceSell) & decimal.TryParse(args[2], out var priceBuy))
        {
            this.Stock = args[0];
            this.PriceSell = priceSell;
            this.PriceBuy = priceBuy;
        }
        else
        {
            throw new Exception(
                "Error parsing datatype, Expect (stock<string>, priceSell<decimal>, priceBuy<decimal>)");
        }
    }
          
   
}