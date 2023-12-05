using System.Runtime.InteropServices;
using System.Text.Json.Nodes;
using Microsoft.VisualBasic.CompilerServices;

namespace stock_quote_alert.Classes;

public class Api
{
    private string _token;
    static HttpClient _client;
    private decimal _stockPrice;
    
    public Api(string token)
    {
        _client = new HttpClient();
        _token = token;
    }

    private string MakePath(string stock)
    {
        return $"https://brapi.dev/api/quote/{stock}?token={_token}";
    }

    public async Task<decimal> GetPriceStock(string stock)
    {
        //var content = null;
//        string? contentData = null;
        var response = await _client.GetAsync(MakePath(stock));
        if (!response.IsSuccessStatusCode) throw new Exception("Falha na requisição da API");
        var price = -1.0M;
        
        try
        {
            var contentData = await response.Content.ReadAsStringAsync();
            var content = JsonNode.Parse(contentData)!["results"]![0]!;
            price = content["regularMarketPrice"]!.GetValue<decimal>();
        }
        catch (Exception e)
        {
            Console.WriteLine("Falha ao fazer o parser do JSON oferecido pela API");
            Console.WriteLine(e.Message);
        }

        return price;
    }
}