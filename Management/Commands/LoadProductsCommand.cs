using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.DAL.Repositories;
using HyperStoreEntities.Logger;
using HyperStoreEntities.MarketEntities;

namespace HyperStoreEntities.Management.Commands;

internal class LoadStorageCommand : IMarketCommand
{
   public LoadStorageCommand() { }
   
   public void Execute()
   {
     MarketProducts.GetProducts().AddRange(RepositoryBuilder.GetReader().GetProducts());
     FileLogger.GetLogger().LogMessage($"Products are loaded !");
   }
}
