namespace StrategyPattern
{
    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying {amount:C} using Credit Card.");
        }
    }
}
