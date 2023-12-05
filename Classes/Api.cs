using System.Text.Json.Nodes;

namespace StockQuoteAlert.Classes;

public class Api
{
    private readonly string _token;
    private static HttpClient? _client;
    
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
        var response = await _client!.GetAsync(MakePath(stock));
        if (!response.IsSuccessStatusCode) throw new Exception("Falha na requisição da API");
        decimal price;        
        try
        {
            var contentData = await response.Content.ReadAsStringAsync();
            var content = JsonNode.Parse(contentData)!["results"]![0]!;
            price = content["regularMarketPrice"]!.GetValue<decimal>();
        }
        catch (Exception e)
        {
            throw new Exception("Falha ao fazer o parser do JSON oferecido pela API");
        }
        return price;
    }
}