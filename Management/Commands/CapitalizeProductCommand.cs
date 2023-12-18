using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.Logger;
using HyperStoreEntities.MarketEntities;

namespace HyperStoreEntities.Management.Commands
{
    internal class CapitalizeProductCommand : IMarketCommand
    {   
        Product _product;

        public CapitalizeProductCommand(Product product)
        {
            _product = product;
        }

        public void Execute()
        {
            MarketProducts.GetProducts().Add(_product);
            FileLogger.GetLogger().LogMessage($"{_product.ToString()} is capitalized!");
        }
    }
}
