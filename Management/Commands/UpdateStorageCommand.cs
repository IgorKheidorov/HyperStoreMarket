using HyperStoreEntities.DAL.Repositories;
using HyperStoreEntities.Logger;
using HyperStoreEntities.MarketEntities;

namespace HyperStoreEntities.Management.Commands
{
    internal class UpdateStorageCommand : IMarketCommand, IMarketCommandAsync
    {
        public UpdateStorageCommand() {}

        public void Execute()
        {            
            RepositoryBuilder.GetWriter().SaveProducts(MarketProducts.GetInstance().Products);
            FileLogger.GetLogger().LogMessage($"Products repository is updated!");
        }

        public async Task ExecuteAsync()
        {
            RepositoryBuilder.GetWriter().SaveProducts(MarketProducts.GetInstance().Products);
            await FileLogger.GetLogger().LogMessageAsync($"Products repository is updated!");
            await FileLogger.GetLogger().LogMessageAsync($"{MarketProducts.GetInstance().Products.Count} remains!");
        }
      
    }
}
