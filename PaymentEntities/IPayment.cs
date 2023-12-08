namespace FirstLanguageSampleMexico.PaymentEntities;

internal interface IPayment : ICloneable
{
    /// <summary>
    /// Method to make the payment
    /// </summary>
    /// <param name="amount"> amount of money  to be transfered in USD</param>
    /// <returns>operation succeess </returns>
    bool MakePayment(float amount);
    float Balance { get; }
    int ID { get; }


}