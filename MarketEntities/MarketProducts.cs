using FirstLanguageSampleMexico.MarkerEntities;
using System.Collections;

namespace HyperStoreEntities.MarketEntities;

internal class MarketProducts
{
    List<Product>? _products = new List<Product>();
    static MarketProducts _marketProducts;
    MarketProducts() { }

    public List<Product> Products { get => _products; }
    private readonly object _locker = new object();

    public static MarketProducts GetInstance()
    {
        if (_marketProducts == null)
        {
            _marketProducts = new MarketProducts();
        }

        return _marketProducts;
    }

    public void AddProduct(Product product)
    {
        lock (_locker)
        {
            _products?.Add(product);
        }
    }

    public void RemoveProduct(Product product)
    { 
        lock(_locker)
        {
            _products?.Remove(product);
        }    
    }

    
}



