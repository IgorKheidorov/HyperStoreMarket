using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.DAL.Repositories;
using HyperStoreEntities.Logger;
using HyperStoreEntities.MarketEntities;

namespace HyperStoreEntities.Management.Commands
{
    internal class UpdateStorageCommand : IMarketCommand
    {
        public UpdateStorageCommand() {}

        public void Execute()
        {            
            RepositoryBuilder.GetWriter().SaveProducts(MarketProducts.GetProducts());
            FileLogger.GetLogger().LogMessage($"Products repository is updated!");
        }
    }
}
