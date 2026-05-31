namespace CarRacing.Core.Contracts
{
    // Defines the contract for the Engine class, which is responsible for running the main application loop.
    // The Engine interacts with the Controller to execute commands and manage the flow of the application.
    // This interface allows for a clear separation of concerns, enabling the Engine to focus on application flow
    // while the Controller handles business logic and data management.
    // The Engine is the entry point of the application, and it will call the Run method to start processing commands.
    public interface IEngine
    {
        void Run();
    }
}
