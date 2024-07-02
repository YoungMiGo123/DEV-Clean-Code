namespace FactoryPattern
{
    public class EmailNotification : INotification
    {
        public void Send()
        {
            Console.WriteLine("Sending email notification...");
        }
    }
}
