namespace FactoryPattern
{
    public static class DocumentFactory
    {
        public static IDocument CreateDocument(DocumentType type)
        {
            return type switch
            {
                DocumentType.Word => new WordDocument(),
                DocumentType.Pdf => new PdfDocument(),
                _ => throw new ArgumentException("Invalid document type"),
            };
        }
    }
}
