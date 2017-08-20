using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{

    // The DropDatabaseCommand class is responsible for handling the "dropdb" command, 
    // which is used to drop the current database in the BashSoft application. The class inherits from the Command class and overrides the
    // Execute method to implement the specific behavior of the "dropdb" command.
    public class DropDatabaseCommand : Command
    {
        // The constructor of the DropDatabaseCommand class initializes
        // the command with the given input, data, tester, repository, and IO manager. It calls the base class constructor
        //  to initialize the command with the provided parameters. The constructor does not contain any additional logic 
        // and simply calls the base constructor to initialize the command with the provided parameters.
        public DropDatabaseCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
            // No additional initialization logic is needed for the DropDatabaseCommand, as it relies on the base class constructor
            // to set up the necessary properties and dependencies.
        }

        // The Execute method of the DropDatabaseCommand class checks if the command data has exactly one element (the command name). If it does, it calls the UnloadData method of the repository to drop the current database and prints a confirmation message.
        // If it does not, it throws an InvalidCommandException with the original input as the message.
        public override void Execute()
        {
            // Check if the command data has exactly one element (the command name)
            // If it does not, throw an InvalidCommandException with the original input as the message
            // If it does, call the UnloadData method of the repository to drop the current database and print a confirmation message
            if (this.Data.Length != 1)
            {
                // If the command data does not have exactly one element, throw an InvalidCommandException with the original input as the message   
                throw new InvalidCommandException(this.Input);
            }

            // If the command data has exactly one element, call the UnloadData method of the repository to drop the
            // current database and print a confirmation message

            this.Repository.UnloadData();

            // After successfully dropping the database, print a confirmation message to the user
            // The message "Database dropped!" is displayed to inform the user that the database has been successfully dropped
            // This message serves as feedback to the user, confirming that the "dropdb" command has been executed successfully and the database has been dropped.
            // The OutputWriter.WriteMessageOnNewLine method is used to print the message on a new line in the console, ensuring that it is clearly visible to the user.
            // The OutputWriter class is responsible for handling output operations in the BashSoft application. It provides methods for writing messages to the console, including the WriteMessageOnNewLine method, which writes a message on a new line.
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}