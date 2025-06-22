using System;

public interface IDocument
{
    void Open();
}

public class WordDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Word document opened.");
    }
}

public class PdfDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("PDF document opened.");
    }
}

public class ExcelDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Excel document opened.");
    }
}

public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

public class WordDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new WordDocument();
    }
}

public class PdfDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new PdfDocument();
    }
}

public class ExcelDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new ExcelDocument();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the type of document to open (Word, PDF, Excel):");
        string input = Console.ReadLine();

        DocumentFactory factory = null;

        switch (input.Trim().ToLower())
        {
            case "word":
                factory = new WordDocumentFactory();
                break;
            case "pdf":
                factory = new PdfDocumentFactory();
                break;
            case "excel":
                factory = new ExcelDocumentFactory();
                break;
            default:
                Console.WriteLine("Invalid document type entered.");
                return;
        }

        IDocument doc = factory.CreateDocument();
        doc.Open();
    }
}
