using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.Factory;

namespace FirstLanguageSampleMexico;

internal class Program
{
    static void Main(string[] args)
    {
        var store = HyperStoreBuilder.BuildHyperStore("Happy hours", "Food");

        store.PrepareForOpen(); // Create commands
        store.Open(); // execute

        MarketClient client = new MarketClient("John");
        store.SellProduct("Pizza", client);
        store.SellProduct("Bread", client);
        store.SellProduct("Pizza", client);
        store.SellProduct("Pizza", client);
        store.SellProduct("Bread", client);
        store.SellProduct("Pizza", client);


        store.ProcessPurchases(); // execute

    //    store.DismissPurchases();

      //  store.PrepareForClose();
        //store.Close();
       
    }
 
}
