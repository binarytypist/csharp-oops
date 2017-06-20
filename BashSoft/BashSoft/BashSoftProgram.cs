namespace BashSoft
{
    // Entry point of the application (console program starts here)
    class BashSoftProgram
    {
        private static void Main(string[] args)
        {
            // Create Tester (Judge component)
            // Responsible for comparing files and validating outputs
            Tester tester = new Tester();

            // Create IOManager
            // Responsible for handling file system operations (directories, navigation, etc.)
            IOManager ioManager = new IOManager();

            // Create StudentsRepository (Data Layer)
            // Stores and manages students and courses
            // It uses:
            // - RepositorySorter (sorting logic)
            // - RepositoryFilter (filtering logic)
            StudentsRepository repo = new StudentsRepository(
                new RepositorySorter(),
                new RepositoryFilter());

            // Create CommandInterpreter (CORE dispatcher in Command Pattern)
            // It receives user input and decides which Command class to execute
            CommandInterpreter currentInterpreter = new CommandInterpreter(
                tester,
                repo,
                ioManager);

            // Create InputReader (handles input loop)
            // Reads commands from user and sends them to interpreter
            InputReader reader = new InputReader(currentInterpreter);

            // Start the application loop
            // This continuously reads commands until "quit" is entered
            reader.StartReadingCommands();
        }
    }
}