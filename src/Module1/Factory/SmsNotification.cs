namespace FactoryPattern
{
    public class SmsNotification : INotification
    {
        public void Send()
        {
            Console.WriteLine("Sending SMS notification...");
        }
    }
}
