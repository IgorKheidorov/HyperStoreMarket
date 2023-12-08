namespace FirstLanguageSampleMexico.PaymentEntities;

/// <summary>
/// THis clas is a basis for allpayment cards
/// </summary>
internal abstract class PaymentCard : IPayment /* sign the contract*/
{
    public string CardHolder { get; private set; }

    private int _cardNumber;
    public int CardNumber
    {
        get
        {
            return _cardNumber;
        }
        private set
        {
            _cardNumber = value < 0 ? int.MinValue : value;
        }
    }

    public float Balance { get; protected set; }

    public int ID => CardNumber;

    public PaymentCard(int number, string name, float balance)
    {
        CardNumber = number;
        CardHolder = name;
        Balance = balance;
    }

    public PaymentCard(int number, string name)
    {
        CardNumber = number;
        CardHolder = name;
        Balance = 0;
    }

    /// <summary>
    /// Method to make the payment
    /// </summary>
    /// <param name="amount"> amount of money  to be transfered in USD</param>
    /// <returns>operation succeess </returns>
    public abstract bool MakePayment(float amount);

    public override string ToString()
    {
        return $"Card number: {CardNumber}, Name: {CardHolder}, Balance: {Balance}";
    }

    public abstract object Clone();


}
