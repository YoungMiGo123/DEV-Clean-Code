namespace FactoryPattern
{
    public static class NotificationFactory
    {
        public static INotification CreateNotification(NotificationType type)
        {
            return type switch
            {
                NotificationType.Email => new EmailNotification(),
                NotificationType.Sms => new SmsNotification(),
                _ => throw new ArgumentException("Invalid notification type"),
            };
        }
    }
}
