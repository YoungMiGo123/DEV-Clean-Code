namespace StrategyPattern
{
    public enum PaymentStrategyType
    {
        EFT,
        CreditCard,
        PayPal
    }
    public class PaymentStrategyFactory
    {
        public static IPaymentStrategy GetPaymentStrategy(PaymentStrategyType type)
        {
            return type switch
            {
                PaymentStrategyType.EFT => new CreditCardPayment(),
                PaymentStrategyType.CreditCard => new PayPalPayment(),
                PaymentStrategyType.PayPal => new EFTPayment(),
                _ => throw new NotImplementedException()
            };
        }
    }
    public class StrategyRunner
    {
        public static void Run()
        {
            SetupSortStrategy();
            SetupPaymentStrategy();
        }

        private static void SetupPaymentStrategy()
        {
            var paymentContext = new PaymentContext();

            var strategy = PaymentStrategyFactory.GetPaymentStrategy(PaymentStrategyType.CreditCard);

            paymentContext.SetPaymentStrategy(strategy);
            paymentContext.Pay(100.00m);


            strategy = PaymentStrategyFactory.GetPaymentStrategy(PaymentStrategyType.PayPal);
            paymentContext.SetPaymentStrategy(strategy);
            paymentContext.Pay(200.00m);

            strategy = PaymentStrategyFactory.GetPaymentStrategy(PaymentStrategyType.EFT);

            paymentContext.SetPaymentStrategy(strategy);
            paymentContext.Pay(300.00m);
        }

        private static void SetupSortStrategy()
        {
            var numbers = new List<int> { 5, 3, 8, 4, 2 };

            var context = new SortContext();

            Console.WriteLine("Original list:");
            numbers.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();

            context.SetSortStrategy(new BubbleSortStrategy());
            context.Sort(numbers);
            Console.WriteLine("Bubble sorted list:");
            numbers.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();

            numbers = [5, 3, 8, 4, 2];
            context.SetSortStrategy(new QuickSortStrategy());
            context.Sort(numbers);
            Console.WriteLine("Quick sorted list:");
            numbers.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();


            numbers = [5, 3, 8, 4, 2];
            context.SetSortStrategy(new OrderBySortStrategy());
            context.Sort(numbers);
            Console.WriteLine("Order by sorted list:");
            numbers.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();
        }
    }
}
