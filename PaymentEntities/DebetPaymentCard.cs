namespace FirstLanguageSampleMexico.PaymentEntities;

internal class DebetPaymentCard : PaymentCard
{
    public string ExpirityDate { get; private set; }
    public DebetPaymentCard(int number, string name, float balance) : base(number, name, balance)
    {
        ExpirityDate = "12/31/2023";

    }

    public DebetPaymentCard(int number, string name) : base(number, name)
    {
        ExpirityDate = "12/31/2023";

    }

    public override bool MakePayment(float amount)
    {
        if (amount < Balance)
        {
            Balance -= amount;
            return true;
        }

        return false;
    }

    public override object Clone()
    {
        return new DebetPaymentCard(CardNumber, CardHolder, Balance);
    }


}
