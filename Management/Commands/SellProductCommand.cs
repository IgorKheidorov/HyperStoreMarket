using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.Logger;
using HyperStoreEntities.MarketEntities;

namespace HyperStoreEntities.Management.Commands;

internal class SellProductCommand : IMarketCommand, IMarketCommandAsync
{
    string _productName;
    MarketClient _client;
    public bool IsSuccesfull {get; set;}

    public SellProductCommand(string product, MarketClient client)
    {  
        _productName = product;
        _client = client;
        IsSuccesfull = true;
    }
    
    public void Execute()
    {
        var product = MarketProducts.GetInstance().Products.Where(x => x.Name == _productName).First();
        _client.MakePurchase(product);        
        MarketProducts.GetInstance().RemoveProduct(product);
        FileLogger.GetLogger().LogMessage($"{product.ToString()} is sold!");        
    }

    public async Task ExecuteAsync()
    {
        var product = MarketProducts.GetInstance().Products.Where(x => x.Name == _productName).First();
        MarketProducts.GetInstance().RemoveProduct(product);
        await FileLogger.GetLogger().LogMessageAsync($"{product.ToString()} is sold!");
        await FileLogger.GetLogger().LogMessageAsync($"{MarketProducts.GetInstance().Products.Count} remains!");
    }
 
}
