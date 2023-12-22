using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.Factory;
using HyperStoreEntities.Logger;

namespace FirstLanguageSampleMexico;

internal class Program
{
    static void Main(string[] args)
    {
        var store = HyperStoreBuilder.BuildHyperStore("Happy hours", "Food");

        store.PrepareForOpen(); // Create commands
        store.Open(); // execute

        MarketClient client = new MarketClient("John");

        // Join is filling the shop bag
        int purchasesCount = 10;
                while (purchasesCount-- > 0) 
        {
            store.SellProduct("Milk", client);
            store.SellProduct("Water", client);
        }

        // John is on cash box
        store.ProcessPurchases(); // execute
    
        store.PrepareForClose();
        store.Close();
       
    }
 
}
