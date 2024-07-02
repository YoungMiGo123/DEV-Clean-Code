namespace FactoryPattern
{
    public class PdfDocument : IDocument
    {
        public void Print()
        {
            Console.WriteLine("Printing PDF document...");
        }
    }
}
