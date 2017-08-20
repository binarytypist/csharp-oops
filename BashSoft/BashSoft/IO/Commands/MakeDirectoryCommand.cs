using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    // The MakeDirectoryCommand class is responsible for creating a new directory in the current folder.
    // It inherits from the Command class and implements the Execute method to perform the directory creation operation.
    // If the command is not provided with the correct number of arguments, it throws an InvalidCommandException.
    public class MakeDirectoryCommand : Command
    {
        // Constructor for the MakeDirectoryCommand class, which initializes the command with the input, data, judge, repository, and inputOutputManager.
        public MakeDirectoryCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
            // The constructor simply calls the base class constructor to initialize the command with the provided parameters.
            // No additional initialization logic is needed for the MakeDirectoryCommand, as it relies on the base class 
            // to set up the necessary properties and dependencies.
            // The constructor does not contain any additional logic and simply calls the base constructor to initialize the
            // command with the provided parameters.
        }

        // The Execute method of the MakeDirectoryCommand class checks if the command data has exactly two elements (the command name and
        // the folder name). If it does, it retrieves the folder name
        // from the data array and calls the CreateDirectoryInCurrentFolder method of the inputOutputManager to create the directory.
        // If it does not, it throws an InvalidCommandException with the original input as the message.
        // The Execute method is responsible for performing the actual operation of creating a directory
        // based on the command input. It validates the input and ensures that the correct number of arguments
        // is provided before attempting to create the directory.
        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string folderName = this.Data[1];
                this.InputOutputManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}