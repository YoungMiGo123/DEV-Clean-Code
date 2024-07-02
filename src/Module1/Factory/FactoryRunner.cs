namespace FactoryPattern
{
    public class FactoryRunner
    {
        public static void Run()
        {
            SetupDocumentFactory();
            SetupNotificationFactory();
        }

        private static void SetupDocumentFactory()
        {
            IDocument wordDoc = DocumentFactory.CreateDocument(DocumentType.Word);
            wordDoc.Print();

            IDocument pdfDoc = DocumentFactory.CreateDocument(DocumentType.Pdf);
            pdfDoc.Print();
        }

        private static void SetupNotificationFactory()
        {
            INotification emailNotification = NotificationFactory.CreateNotification(NotificationType.Email);
            emailNotification.Send();

            INotification smsNotification = NotificationFactory.CreateNotification(NotificationType.Sms);
            smsNotification.Send();
        }
    }
}
