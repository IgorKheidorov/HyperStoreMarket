using HyperStoreEntities.Management.Commands;
using HyperStoreEntities.MarketEntities;
using System.Diagnostics;

namespace FirstLanguageSampleMexico.MarkerEntities;

public class HyperStore
{
    List<IMarketCommandAsync> _commands;

    public string Type { get; set; }

    public string Name { get; private set; }

    public HyperStore(string name)
    {
        _commands = new List<IMarketCommandAsync>();
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

        int num = 10;
        while (num-- > 0)
        {
            _commands.Add(new CapitalizeProductCommand(new Product("Milk", 1.5f)));
            _commands.Add(new CapitalizeProductCommand(new Product("Water", 3.1f)));
        }

        _commands.Add(new UpdateStorageCommand());
    }

    public void Open()
    {
        var tasks = new List<Task>();

        // Main thread

        foreach (var command in _commands)
        {
            // commands.Count() threads are added
            tasks.Add(command.ExecuteAsync());
        }

        // some activity

        Task.WaitAll(tasks.ToArray());

        var products = MarketProducts.GetInstance().Products;
        _commands.Clear();
    }

    public void PrepareForClose()
    {
        _commands.Add(new UpdateStorageCommand());
    }


    public void Close()
    {
        _commands.ForEach(x => x.ExecuteAsync());
        _commands.Clear();
    }

    public void SellProduct(string productName, MarketClient client)
    {
        _commands.Add(new SellProductCommand(productName, client));
    }

    public void ProcessPurchases()
    {
        int numberBefore = MarketProducts.GetInstance().Products.Count();

        Stopwatch sw = new Stopwatch();
        sw.Start();
        var tasks = new List<Task>();

        // Main thread

        foreach (var command in _commands)
        {
            // commands.Count() number of threads are added
            tasks.Add(command.ExecuteAsync());
        }

        // some activity

        Task.WaitAll(tasks.ToArray());

        sw.Stop();
        int numberAfter = MarketProducts.GetInstance().Products.Count();

        long time = sw.ElapsedMilliseconds;
        _commands.Clear();
    }
 
}

