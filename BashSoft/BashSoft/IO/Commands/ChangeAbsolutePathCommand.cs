using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    //  The command is executed by the CommandInterpreter class when the user enters a command in the console.
    //  The command is implemented in the ChangeAbsolutePathCommand class, which inherits from the Command class.
    //  The ChangeAbsolutePathCommand class is responsible for executing the "cdAbs" command and changing the current directory to the specified absolute path.
    //  The ChangeAbsolutePathCommand class is located in the BashSoft.IO.Commands namespace and is part of the BashSoft project.
    //  The ChangeAbsolutePathCommand class has a constructor that takes the command input, the command data, the tester, the students repository, and the IO manager as parameters.
    //  The Execute method of the ChangeAbsolutePathCommand class checks if the command data has exactly two elements (the command name and the absolute path). If it does, it calls the ChangeCurrentDirectoryAbsolute method of the IO manager to change the current directory to the specified absolute path.
    //  If it does not, it throws an InvalidCommandException with the command input as the message.
    public class ChangeAbsolutePathCommand : Command
    {

        //  Constructor for the ChangeAbsolutePathCommand class. It initializes the command with the given input, data, tester, repository, and IO manager.
        //  Parameters:
        //  - input: The raw command input from the user.
        //  - data: An array of strings containing the command name and its arguments.
        //  - judge: An instance of the Tester class, used for testing purposes.
        //  - repository: An instance of the StudentsRepository class, used for managing student data
        //  - inputOutputManager: An instance of the IOManager class, used for managing input and output operations.
        //  The constructor calls the base class constructor to initialize the command with the provided parameters.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="data"></param>
        /// <param name="judge"></param>
        /// <param name="repository"></param>
        /// <param name="inputOutputManager"></param>
        public ChangeAbsolutePathCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        // Executes the "cdAbs" command. It checks if the command data has exactly two elements (the command name and the absolute path). If it does, it changes the current directory to the specified absolute path using the IO manager.
        // If it does not, it throws an InvalidCommandException with the command input as the message.
        // The method is called by the CommandInterpreter when the user enters the "cdAbs" command in the console.
        // Example usage:
        //  - User input: "cdAbs C:\Users\JohnDoe\Documents"
        //  - The Execute method will change the current directory to "C:\Users\JohnDoe\Documents" if the command data is valid.
        //  - If the user input is invalid (e.g., "cdAbs"), the method will throw an InvalidCommandException with the message "cdAbs".
        //  Note: The actual implementation of the ChangeCurrentDirectoryAbsolute method in the IO manager is not shown here,
        // but it is responsible for changing the current directory to the specified absolute path.
        // The Execute method is overridden from the base Command class, which defines the structure for executing commands in the BashSoft application.  
        public override void Execute()
        {
            // heck if the command data has exactly two elements (the command name and the absolute path).    
            // If it does, change the current directory to the specified absolute path using the IO manager.
            // If it does not, throw an InvalidCommandException with the command input as the message.
            // The command data is expected to be in the format: ["cdAbs", "absolutePath"]
            //  Example: ["cdAbs", "C:\Users\JohnDoe\Documents"]
            // If the command data is valid, the current directory will be changed to "C:\Users\JohnDoe\Documents".
            // If the command data is invalid (e.g., ["cdAbs"]), an InvalidCommandException will be thrown with the message "cdAbs".
            if (this.Data.Length == 2)
            {
                // Get the absolute path from the command data and change the current directory using the IO manager.
                // The absolute path is expected to be the second element in the command data array (index 1).
                //  Example: If the command data is ["cdAbs", "C:\Users\JohnDoe\Documents"], the absolute path will be "C:\Users\JohnDoe\Documents".
                string absolutePath = this.Data[1];
                //  Call the ChangeCurrentDirectoryAbsolute method of the IO manager to change the current directory to the specified absolute path.
                //  The ChangeCurrentDirectoryAbsolute method is responsible for changing the current directory to the specified absolute path. The implementation of this method is not shown here,
                //  but it is expected to handle the logic for changing the directory and validating the path.
                this.InputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
            }
            else
            {
                //  If the command data does not have exactly two elements, throw an InvalidCommandException with the command input as the message.
                //  The command input is the raw string entered by the user in the console. It is expected to be in the format: "cdAbs absolutePath".
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}