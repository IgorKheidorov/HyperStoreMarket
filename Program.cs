using FirstLanguageSampleMexico.MarkerEntities;
using HyperStoreEntities.DAL.Interfaces;
using HyperStoreEntities.DAL.Repositories.XML;
using System.Data;

namespace FirstLanguageSampleMexico;

internal class Program
{
    static void Main(string[] args)
    {
        var store = new HyperStore("ProStore");

        IRepositoryRead reader = new XMLReader();
        store.Products = reader.GetProducts();

        IRepositoryWrite writer = new XMLWriter();
        writer.SaveProducts(store.Products);

        writer = new XMLCompressedWriter();
        writer.SaveProducts(store.Products);
        reader = new XMLCompressedReader();
        store.Products = reader.GetProducts();

        writer.SaveProducts(store.Products);
        store.Products = reader.GetProducts();
      
        var client = new MarketClient("Jonny");
        client.InitializePaymentMeans();
        
        client.Purchase += store.SellProduct;

        var productToBuy = store.Where(x => x.Name == "Bread").First();

        try
        {
            client.MakePurchase(productToBuy);

        }
        catch
        {
            store.ReturnProduct(productToBuy);
        }

                  
       
    }
 
}
