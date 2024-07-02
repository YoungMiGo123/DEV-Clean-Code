namespace StrategyPattern
{
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }
}
