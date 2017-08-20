using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    // The GetHelpCommand class is responsible for displaying a list of available commands and their descriptions to the user.
    // It inherits from the Command class and overrides the Execute method to provide the help information.
    // The GetHelpCommand class is located in the BashSoft.IO.Commands namespace and is part of the BashSoft project.   
    // The GetHelpCommand class has a constructor that takes the command input, the command data, the tester, the students repository, and
    // the IO manager as parameters. The constructor calls the base class constructor

    public class GetHelpCommand : Command
    {

        // The constructor of the GetHelpCommand class initializes the command with the provided input, data, tester, repository, and IO manager.
        // Parameters:
        // - input: The raw command input from the user.
        // - data: An array of strings containing the command name and its arguments.
        // - judge: An instance of the Tester class, used for testing purposes.
        // - repository: An instance of the StudentsRepository class, used for managing student data.
        // - inputOutputManager: An instance of the IOManager class, used for managing input
        //   and output operations.
        // The constructor calls the base class constructor
        //  to initialize the command with the provided parameters. The constructor does not contain any additional logic and simply calls the base constructor
        //  to initialize the command with the provided parameters.
        //  The base constructor is responsible for initializing the command with the provided parameters and setting up the necessary properties
        //  and dependencies for the command to function properly.
        public GetHelpCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
            // The constructor does not contain any additional logic and simply calls the base constructor
            // to initialize the command with the provided parameters. The base constructor is responsible for initializing the command with the
            // provided parameters and setting up the necessary properties
        }

        // The Execute method of the GetHelpCommand class checks if the command data has exactly one element (the command name).
        // If it does, it calls the DisplayHelp method to show the list of available commands and their descriptions.
        // If it does not, it throws an InvalidCommandException with the original input as the message.
        // The Execute method is called by the CommandInterpreter when the user enters the "help" command in
        // the console. The method is responsible for executing the "help" command and providing the user with information about the
        // available commands in the BashSoft application.
        public override void Execute()
        {
            // The Execute method checks if the command data has exactly one element (the command name).
            // If it does not, it throws an InvalidCommandException with the original input as the message.
            // If the command data has exactly one element, it calls the DisplayHelp method to show the list of available commands and their descriptions.
            if (this.Data.Length != 1)
            {
                // If the command data does not have exactly one element, it throws an InvalidCommandException with the original input as the message.
                // The InvalidCommandException is a custom exception that indicates that the command entered by the user is invalid. It takes the original
                // input as a parameter to provide more context about the error.
                throw new InvalidCommandException(this.Input);
            }

            // If the command data has exactly one element, it calls the DisplayHelp method to show the list of available
            // commands and their descriptions.
            // The DisplayHelp method is responsible for displaying a list of available commands and their descriptions to the user.
            // It uses the OutputWriter class to write messages to the console.
            // The DisplayHelp method is called when the user enters the "help" command in the console.
            // It provides the user with information about the available commands in the BashSoft application.
            this.DisplayHelp();
        }

        private void DisplayHelp()
        {
            // The DisplayHelp method uses the OutputWriter class to write messages to the console.
            // It displays a list of available commands and their descriptions to the user.
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");

            // Each command is displayed with its name and a brief description of its functionality.
            // The make directory command allows users to create a new directory at a specified path. This command is useful for organizing files
            // and directories within the file system.
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path"));

            // The traverse directory command lists directory contents at a specified depth.
            // The ls command allows users to list the contents of a directory at a specified depth. This command is useful for navigating through the
            // file system and viewing the structure of directories and files.
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth"));

            // Comparing files command compares the contents of two files and displays the differences.
            // The cmp command allows users to compare the contents of two files and display the differences between them. This command is useful for identifying
            // discrepancies or changes between two files,such as source code files, configuration files, or any other text-based files.
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));

            // Change directory using relative path.
            // The cdRel command allows users to change the current directory to a specified relative path. This command is useful for navigating through the file system using
            // relative paths, which are based on the current directory.
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdRel: relative path"));

            // Change directory using absolute path.
            // The cdAbs command allows users to change the current directory to a specified absolute path. This command is useful for navigating to a specific location
            // in the file system without needing to provide a relative path.
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdAbs: absolute path"));

            // Read student database from file.
            // The readDb command allows users to read a student database from a specified file path. This command is useful for loading student
            // data into the application for further processing and analysis.
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students database - readDb: path"));

            // Filter students by performance category.
            // The filter command allows users to filter students based on their performance category (excellent, average, or poor)
            // and the number of students to display (2, 5, or all).
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter excellent/average/poor take 2/5/all students"));

            // Order students ascending or descending.
            // The order command allows users to sort students in ascending or descending order based on their performance. The command takes two parameters: the sorting order (ascending or descending)
            // and the number of students to display (2, 5, or all).
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order take 20/10/all"));

            // Download file to current directory.
            // The download command allows users to download a file by providing the path of the file to be downloaded.
            // This command is useful for downloading files from a specified location to the current directory of the application.
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file"));

            // Async file download.
            // The downloadAsynch command allows users to download a file asynchronously by providing the path of the file to be downloaded. This command is useful for downloading files without blocking the main thread of the application,
            // allowing users to continue using the application while the file is being downloaded in the background.
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asynchronously - downloadAsynch: path"));

            // Help command itself.
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help - help"));
            // the method ends by writing a line of underscores to the console for visual separation and an empty line for spacing.
            // The line of underscores serves as a visual separator to distinguish the help information from other console output,
            // while the empty line provides spacing for better readability.

            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            //  The line of underscores serves as a visual separator to distinguish the help information from other console output,
            //  while the empty line provides spacing for better readability.
            OutputWriter.WriteEmptyLine();
        }
    }
}