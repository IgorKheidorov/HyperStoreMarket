using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.Logger;
using HyperStoreEntities.MarketEntities;

namespace HyperStoreEntities.Management.Commands;

internal class OrganizeSalesCommand : IMarketCommand, IMarketCommandAsync
{
    float _salesProcentage;

    public OrganizeSalesCommand(float salesProcentage)
    {
        _salesProcentage = 1 - salesProcentage / 100f;
    }

    public void Execute()
    {
        MarketProducts.GetInstance().Products.ForEach(x => x.Price *= _salesProcentage);
        FileLogger.GetLogger().LogMessage($"Sales orginized!");
    }

    public async Task ExecuteAsync()
    {
        MarketProducts.GetInstance().Products.ForEach(x => x.Price *= _salesProcentage);
        await FileLogger.GetLogger().LogMessageAsync($"Sales orginized!");
    }


}