using BashSoft.Exceptions;
using System.Diagnostics;

namespace BashSoft.IO.Commands
{
    // The OpenFileCommand class is a concrete implementation of the Command class that represents the "open" command
    // in the BashSoft application. This command is responsible for opening a file specified by the user. The Execute
    // method checks if the command has the correct number of arguments (2), and if so, it retrieves the file name
    // from the command data and uses the Process.
    // Start method to open the file. If the command does not have the correct number of arguments,
    // an InvalidCommandException is thrown.

    // The OpenFileCommand class is located in the BashSoft.IO.Commands namespace and is part of the BashSoft project.
    // It relies on the System.Diagnostics namespace to use the Process class for opening files.
    // The OpenFileCommand class inherits from the Command class, which provides the basic structure and functionality for executing commands in the BashSoft application. The OpenFileCommand class overrides
    // the Execute method to implement the specific behavior of opening a file based on the command input.

    public class OpenFileCommand : Command
    {
        // Constructor for the OpenFileCommand class that initializes the command with the input, data, judge, repository, and inputOutputManager.
        // The constructor simply calls the base class constructor to initialize the command with the provided parameters.
        // No additional initialization logic is needed for the OpenFileCommand, as it relies on the base class to set up the necessary properties and dependencies.
        // The constructor does not contain any additional logic and simply calls the base constructor to initialize the command with the provided parameters.
        // Parameters:
        //  - input: The raw command input from the user.
        //  - data: An array of strings containing the command name and its arguments.
        //  - judge: An instance of the Tester class, used for testing purposes.
        //  - repository: An instance of the StudentsRepository class, used for managing student data.
        //  - inputOutputManager: An instance of the IOManager class, used for managing input and output operations.
        //  The constructor initializes the command with the provided parameters by calling the base class constructor,
        //  which sets up the necessary properties and dependencies for the command to function properly.

        public OpenFileCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
            // No additional initialization logic is needed for the OpenFileCommand,
            // as it relies on the base class to set up the necessary properties and dependencies.
        }

        //  Executes the "open" command. It checks if the command data has exactly two elements (the command name and the file name). If it does, it retrieves the file name from the command data and uses the Process.
        //  Start method to open the file. If the command data does not have exactly two elements,
        //  it throws an InvalidCommandException with the original input as the message.
        public override void Execute()
        {

            // Check if the command data has exactly two elements (the command name and the file name)
            // If it does, retrieve the file name from the command data and use the Process.Start method to open the file
            // If the command data does not have exactly two elements, throw an InvalidCommandException with the original input as the message
            // The command data is expected to have the format: ["open", "fileName"]
            // If the command data does not match this format, it is considered invalid and an exception is thrown
            // The Process.Start method is used to open the file specified by the file name. The file path is constructed by combining the current path from the
            // SessionsData class with the file name provided in the command data.
            if (this.Data.Length == 2)
            {
                // Retrieve the file name from the command data 
                // The file name is expected to be the second element in the command data array (index 1)
                string fileName = this.Data[1];
                
                
                // Construct the file path by combining the current path from the SessionsData class with the file name
                // Use the Process.Start method to open the file specified by the file name
                // The file path is constructed by concatenating the current path from the SessionsData class with a backslash and the file name
                // Example: If the current path is "C:\Users\Username\Documents" and the file name is "file.txt", the file path will be "C:\Users\Username\Documents\file.txt"
                // The Process.Start method will attempt to open the file using the default application associated with the file type on the user's system
                Process.Start(SessionsData.currentPath + "\\" + fileName);
            }
            else
            {
                // If the command data does not have exactly two elements, throw an InvalidCommandException with the original input as the message
                // The InvalidCommandException is thrown to indicate that the command input is invalid due to an incorrect number of arguments or
                // an incorrect format. The original input is passed to the exception constructor to provide context about the invalid command that was attempted, allowing for better error handling and debugging.  
                // The original input is passed to the exception constructor to provide context about the invalid command that was attempted
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}