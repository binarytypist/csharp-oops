using AquaShop.Core;
using AquaShop.Core.Contracts;
using AquaShop.IO;
using AquaShop.IO.Contracts;

/// <summary>
/// Entry point of the application.
/// Responsible ONLY for composing the system (Dependency Injection).
/// 
/// It wires together all layers:
/// - IO layer (input/output)
/// - Core layer (business logic)
/// </summary>
public class StartUp
{
    public static void Main()
    {
        // Responsible for output operations (printing results)
        IWriter writer = new Writer();

        // Main business logic controller
        IController controller = new Controller();

        // Provides input data (dummy/test input instead of console)
        IInputProvider inputProvider = new DummyInputProvider();

        // Engine coordinates input → processing → output
        IEngine engine = new Engine(writer, controller, inputProvider);

        engine.Run();
    }
}