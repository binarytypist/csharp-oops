using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    // The "cdRel" command changes the current directory to a relative path.
    // The command is executed by the CommandInterpreter class when the user enters a command in the console.
    // The command is implemented in the ChangeRelativePathCommand class, which inherits from the Command class.
    // The ChangeRelativePathCommand class is responsible for executing the "cdRel" command and
    // changing the current directory to the specified relative path.
    // The ChangeRelativePathCommand class is located in the BashSoft.IO.Commands namespace and is part of the BashSoft project.
    public class ChangeRelativePathCommand : Command
    {
        // The constructor of the ChangeRelativePathCommand class initializes
        // the command with the given input, data, tester, repository, and IO manager.
        // Parameters:
        // - input: The raw command input from the user.
        // - data: An array of strings containing the command name and its arguments.
        // - judge: An instance of the Tester class, used for testing purposes. 
        // - repository: An instance of the StudentsRepository class, used for managing student data.
        // - inputOutputManager: An instance of the IOManager class, used for managing input
        //   and output operations.
        // The constructor calls the base class constructor
        // to initialize the command with the provided parameters.
        public ChangeRelativePathCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
            // The constructor does not contain any additional logic and simply calls the base constructor.
            // The base constructor is responsible for initializing the command with the provided parameters.
            // The parameters are stored in the base Command class and can be accessed by the Execute method when the command is executed.
        }

        //  Executes the "cdRel" command. It checks if the command data has exactly two elements (the command name and the relative path).
        //  If it does, it changes the current directory to the specified relative path using the IO manager.
        /// <summary>
        //    Executes the "cdRel" command. It checks if the command data has exactly two elements (the command name and the relative path). 
        //    If it does, it changes the current directory to the specified relative path using the IO manager. If the command data does not 
        //    have exactly two elements, 
        //    it throws an InvalidCommandException with the original input as the message.   
        /// </summary>
        /// <exception cref="InvalidCommandException"></exception>
        public override void Execute()
        {
            // The Execute method is responsible for executing the "cdRel" command. It checks if the command data has exactly two elements
            // (the command name and the relative path). If it does, it changes the current directory to the specified relative path using the
            // IO manager. If the command data does not have exactly two elements,
            // it throws an InvalidCommandException with the original input as the message.
            if (this.Data.Length == 2)
            {
                // If the command data has exactly two elements, it means that the user has provided a relative path to change to.
                // The first element of the data array is the command name ("cdRel"), and the second element is the relative path.
                // The method retrieves the relative path from the data array and calls the ChangeCurrentDirectoryRelative method of the IO manager to
                // change the current directory to the specified relative path.
                string relPath = this.Data[1];
                //  The ChangeCurrentDirectoryRelative method of the IO manager is responsible for changing the current directory
                //  to the specified relative path. It takes the relative path as a parameter and updates the current directory accordingly.
                //  If the relative path is valid, the current directory will be changed successfully. If the relative path is invalid, an
                //  exception may be thrown,
                //  which should be handled appropriately by the caller.
                this.InputOutputManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                // If the command data does not have exactly two elements, it means that the user has not provided a valid relative path to change to.
                // In this case, the method throws an InvalidCommandException with the original input as the message.
                // The InvalidCommandException is a custom exception defined in the BashSoft.Exceptions namespace.
                // It is used to indicate that a command is invalid or cannot be executed due to incorrect input.
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}