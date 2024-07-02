namespace StrategyPattern
{
    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying {amount:C} using PayPal.");
        }
    }

    public class EFTPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying {amount:C} using EFT.");
        }
    }
}
