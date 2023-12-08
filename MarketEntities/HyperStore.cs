using System.Collections;

namespace FirstLanguageSampleMexico.MarkerEntities;

public class HyperStore: IEnumerable<Product>
{
    List<Product> _products;
    public string Name { get; private set; }
    public List<Product> Products 
    {
        get => _products;
        set => _products = value;
    }

    public HyperStore(string name) 
    {
         _products = new List<Product>();
        Name = name;           
    }

 
    public bool SellProduct(string productName, MarketClient client) 
    {
        for (int i = 0; i < _products.Count; i++)
        {
            if (_products[i].Name == productName)
            {
                _products.Remove(_products[i]);
                return true;
            }

        }

        return false;
    }

    public void ReturnProduct(Product product) 
    {
        _products.Add(product);
    }

    
    public IEnumerator<Product> GetEnumerator()
    {
        return _products.OrderBy(x => x.Price).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
