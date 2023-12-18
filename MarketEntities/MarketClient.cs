using FirstLanguageSampleMexico.PaymentEntities;

namespace FirstLanguageSampleMexico.MarkerEntities;

public class MarketClient : ICloneable
{
    List<IPayment> _paymentMeans = new List<IPayment>();

    public event Func<string, MarketClient, bool>? Purchase; // Contract DUTY

    public string Name { get; }

    public MarketClient(string name)
    {
        Name = name;
        InitializePaymentMeans();
    }

    public void InitializePaymentMeans()
    {
        _paymentMeans.Add(new DebetPaymentCard(1, Name, 1000f));
        _paymentMeans.Add(new CreditPaymentCard(4, Name, 1000));
        _paymentMeans.Add(new BitCoin());
    }


    private void MakePayment(float amount, Func<IPayment, float, bool> checkMean)
    {
        foreach (IPayment mean in _paymentMeans)
        {   
            if (checkMean(mean, amount))
            {   
                mean.MakePayment(amount);
                return;
            }
        }

        throw new Exception("Sorry, no money!");
    }


    public void MakePurchase(Product product) 
    {
        Purchase?.Invoke(product.Name, this); // Save it, reserved

        MakePayment(product.Price, (mean, amount) => mean.Balance > amount);
    }


    public object Clone()
    {
        var clonedClient = new MarketClient(Name);

        clonedClient._paymentMeans = new List<IPayment>();
        foreach (var item in _paymentMeans)
        {
            clonedClient._paymentMeans.Add((IPayment)item.Clone());
        }

        clonedClient.InitializePaymentMeans();

        return clonedClient;
    }
}
