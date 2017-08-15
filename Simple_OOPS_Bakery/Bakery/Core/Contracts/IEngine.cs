namespace Bakery.Core.Contracts
{
    // this interface is used to decouple the engine from the start up class, so that we can test the engine without the need of the start up class
    // this engine will be used to read the input from the console, and to write the output to the console, and to call the methods of the controller,
    // and to return the results of the methods of the controller

    public interface IEngine
    {
        void Run();
    }
}
