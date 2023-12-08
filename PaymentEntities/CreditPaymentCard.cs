namespace FirstLanguageSampleMexico.PaymentEntities;

internal class CreditPaymentCard : PaymentCard
{
    public float OverDraft { get; private set; }

    public CreditPaymentCard(int number, string name, float balance) : base(number, name, balance)
    {
        OverDraft = 100;
    }

    public CreditPaymentCard(int number, string name) : base(number, name)
    {

        OverDraft = 100;

    }

    public override bool MakePayment(float amount)
    {
        if (amount < Balance + OverDraft)
        {
            Balance -= amount;

            if (Balance < 0)
            {
                OverDraft += Balance;
                Balance = 0;
            }

            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return base.ToString() + $" Overdraft: {OverDraft}";
    }

    public override object Clone()
    {
        return new CreditPaymentCard(CardNumber, CardHolder, Balance);
    }

}
