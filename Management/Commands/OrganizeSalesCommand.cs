using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.Logger;
using HyperStoreEntities.MarketEntities;

namespace HyperStoreEntities.Management.Commands;

internal class OrganizeSalesCommand : IMarketCommand
{
    float _salesProcentage;

    public OrganizeSalesCommand(float salesProcentage)
    {
       _salesProcentage = 1 - salesProcentage / 100f;
    }

    public void Execute()
    {
        MarketProducts.GetProducts().ForEach(x => x.Price *= _salesProcentage);
        FileLogger.GetLogger().LogMessage($"Sales orginized!");
    }

    public void Undo() 
    {
        MarketProducts.GetProducts().ForEach(x => x.Price /= (100 - _salesProcentage) * 100 );
    }
}
