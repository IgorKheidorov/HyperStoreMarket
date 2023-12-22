using HyperStoreEntities.DAL.Repositories;
using HyperStoreEntities.Logger;
using HyperStoreEntities.MarketEntities;

namespace HyperStoreEntities.Management.Commands;

internal class LoadStorageCommand : IMarketCommand, IMarketCommandAsync
{
   public LoadStorageCommand() { }
   
   public void Execute()
   {
     MarketProducts.GetInstance().Products.AddRange(RepositoryBuilder.GetReader().GetProducts());     
     FileLogger.GetLogger().LogMessage($"Products are loaded !");
   }

    public async Task ExecuteAsync()
    {
        MarketProducts.GetInstance().Products.AddRange(RepositoryBuilder.GetReader().GetProducts());
        await FileLogger.GetLogger().LogMessageAsync($"Products are loaded !");
        await FileLogger.GetLogger().LogMessageAsync($"{MarketProducts.GetInstance().Products.Count} remains!");
    }

}
