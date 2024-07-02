namespace FactoryPattern
{
    public class WordDocument : IDocument
    {
        public void Print()
        {
            Console.WriteLine("Printing Word document...");
        }
    }
}
