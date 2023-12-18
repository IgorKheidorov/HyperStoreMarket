using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.Logger;
using HyperStoreEntities.MarketEntities;
namespace HyperStoreEntities.Management.Commands;

internal class SellProductCommand : IMarketCommand
{
    Product _product;
    MarketClient _client;
    public bool IsSuccesfull {get; set;}

    public SellProductCommand(Product product, MarketClient client)
    {  
        _product = product;
        _client = client;
        IsSuccesfull = true;
    }
    
    public void Execute()
    {
        _client.MakePurchase(_product);
        
        MarketProducts.GetProducts().Remove(_product);
        FileLogger.GetLogger().LogMessage($"{_product.ToString()} is sold!");

        Thread.Sleep(3000);
    }

    public void Undo() 
    {
        MarketProducts.GetProducts().Add(_product);
      //  _client.Refund(_product.Price);
    
    }
}
