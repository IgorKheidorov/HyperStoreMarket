using FirstLanguageSampleMexico.MarkerEntities;
using System.Dynamic;

namespace HyperStoreEntities.MarketEntities;

internal class MarketProducts
{
    static List<Product>? _products;
    MarketProducts() { }

    public static List<Product> GetProducts() 
    {
        if (_products == null)
        {
            _products = new List<Product>();
        }

        return _products;
    }

}
