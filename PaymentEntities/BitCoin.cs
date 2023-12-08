namespace FirstLanguageSampleMexico.PaymentEntities;

internal class BitCoin : IPayment
{
    public float Balance => 50f;

    public int ID => 10;

    public object Clone()
    {
        return new BitCoin();
    }

    public bool MakePayment(float amount)
    {
        return false;
    }

    public int CompareTo(object? obj)
    {
        if (obj is IPayment)
        {
            return Balance.CompareTo((obj as IPayment)?.Balance);
        }

        throw new Exception();
    }

}
