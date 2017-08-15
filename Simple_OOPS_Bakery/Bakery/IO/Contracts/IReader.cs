namespace Bakery.IO.Contracts
{
    // Any class that implements me MUST be able to read a line of text.
    public interface IReader
    {
        string ReadLine();
    }
}
