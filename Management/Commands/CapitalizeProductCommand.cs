using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.Logger;
using HyperStoreEntities.MarketEntities;

namespace HyperStoreEntities.Management.Commands
{
    internal class CapitalizeProductCommand : IMarketCommand, IMarketCommandAsync
    {   
        Product _product;

        public CapitalizeProductCommand(Product product)
        {
            _product = product;
        }

        public void Execute()
        {
            MarketProducts.GetInstance().AddProduct(_product);
            FileLogger.GetLogger().LogMessage($"{_product.ToString()} is capitalized!");
        }

        public async Task ExecuteAsync()
        {
            MarketProducts.GetInstance().AddProduct(_product);
            await FileLogger.GetLogger().LogMessageAsync($"{_product.ToString()} is capitalized!");
        }

    }
}
