using HyperStoreEntities.Management.Commands;
using HyperStoreEntities.MarketEntities;
using System.Collections;
using System.Diagnostics;

namespace FirstLanguageSampleMexico.MarkerEntities;

public class HyperStore : IEnumerable<Product>
{
    List<IMarketCommand> _commands;

    public string Type { get; set; }

    public string Name { get; private set; }

    public HyperStore(string name)
    {
        _commands = new List<IMarketCommand>();
        Name = name;
    }

    List<Transport> _transport;
    public List<Transport> Transport
    {
        get
        {
            return _transport;
        }
        set 
        {           
            _transport = value;
        }
    }

    List<MarketEmployee> _employees;
    public List<MarketEmployee> Employees
    {
        get
        {
            return _employees;
        }
        set
        {
            _employees = value;
        }
    }


    public void PrepareForOpen()
    {
        // Can be changed for any purposes
        _commands.Add(new LoadStorageCommand());
    //    _commands.Add(new CapitalizeProductCommand(new Product("Milk", 15f)));
    //    _commands.Add(new OrganizeSalesCommand(30));
        _commands.Add(new UpdateStorageCommand());
    }

    public void Open() 
    {   
        _commands.ForEach(x => x.Execute());     
        _commands.Clear();
    }

    public void PrepareForClose() 
    {
       // _commands.Add(new OrganizeSalesCommand(100f/70f));
       // _commands.Add(new UpdateStorageCommand());
    }

    public void Close()
    {
        _commands.ForEach(x => x.Execute());
        _commands.Clear();
    }

    public void SellProduct(string productName, MarketClient client) 
    {
        _commands.Add(new SellProductCommand(MarketProducts.GetProducts().Where(x => x.Name == productName).First(), client));        
    }

    public void ProcessPurchases() 
    {
        int numberBefore = MarketProducts.GetProducts().Count();

        Stopwatch sw = new Stopwatch();
        sw.Start();
        
        var tasks = _commands.Select(x => Task.Run(() => x.Execute())).ToArray();

        // some activity


        Task.WaitAll(tasks);

        //_commands.Clear();
        sw.Stop();
        int numberAfter = MarketProducts.GetProducts().Count();

        long time = sw.ElapsedMilliseconds;
    }

    public void DismissPurchases()
    {
        _commands.Where(x => x is SellProductCommand command ).ToList().ForEach(x => x.Undo());        
    }


    public void ReturnProduct(Product product) 
    {
        MarketProducts.GetProducts().Add(product);
    }

    
    public IEnumerator<Product> GetEnumerator()
    {
        return MarketProducts.GetProducts().OrderBy(x => x.Price).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
