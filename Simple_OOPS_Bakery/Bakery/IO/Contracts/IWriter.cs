namespace Bakery.IO.Contracts
{
    public interface IWriter
    {
        // Any class that implements me MUST be able to print text.
        void Write(string message);


        //Any class that implements me MUST be able to print text.
        void WriteLine(string message);
    }
}
