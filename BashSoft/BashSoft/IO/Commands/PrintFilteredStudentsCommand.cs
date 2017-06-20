using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    // The "printFilteredStudents" command is used to print a filtered list of students from a course.
    // The command expects the following format: "printFilteredStudents {courseName} {filter} take {quantity}"/
    // The command is implemented in the PrintFilteredStudentsCommand class, which inherits from the Command class.
    // The Execute method checks if the command data has exactly five elements (the command name, course name, filter, "take", and quantity). If it does, it retrieves the course name, filter, take command, and take quantity from the command data and calls the TryParseParametersForFilterAndTake method to validate and execute the command. If the command data does not have exactly five elements,
    // an InvalidCommandException is thrown with the original input as the message.

    public class PrintFilteredStudentsCommand : Command
    {
        // Constructor for the PrintFilteredStudentsCommand class. It takes the command input, command data, a Tester instance,
        // a StudentsRepository instance, and an IOManager instance as parameters. The constructor calls the base class constructor
        // to initialize the command with the provided parameters.
        //  Parameters:
        //  - input: The raw command input from the user.
        //  - data: An array of strings containing the command name and its arguments.
        //  - repository: An instance of the StudentsRepository class, used for managing student data.
        //  - judge: An instance of the Tester class, used for testing purposes.
        //  - inputOutputManager: An instance of the IOManager class, used for managing input and output operations.
        //  The constructor initializes the command with the provided parameters by calling the base class constructor, which sets up the necessary properties
        //  and dependencies for the command to function properly.
        public PrintFilteredStudentsCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
            // The constructor does not contain any additional logic beyond calling the base class constructor to initialize the command.
            //  No additional initialization logic is needed for the PrintFilteredStudentsCommand, as it relies on the base class to set
            //  up the necessary properties and dependencies.
        }

        public override void Execute()
        {
            // The Execute method is responsible for executing the command logic. It first checks if the command data has exactly five elements (the command name, course name, filter, "take", and quantity). If it does, it retrieves the course name, filter, take command, and take quantity from the command data and calls the TryParseParametersForFilterAndTake method to validate and execute the command.
            // If the command data does not have exactly five elements, an InvalidCommandException is thrown with the original input as the message. 
            // The Execute method ensures that the command is executed only if the correct number of arguments is provided, and it delegates the
            // validation and execution of the command to the TryParseParametersForFilterAndTake method.
            // Check if the command data has exactly five elements (the command name, course name, filter, "take", and quantity).
            //  If it does, retrieve the course name, filter, take command, and take quantity from the command data and call the
           
            if (this.Data.Length == 5)
            {
                string courseName = this.Data[1];
                string filter = this.Data[2].ToLower();
                string takeCommand = this.Data[3].ToLower();
                string takeQuantity = this.Data[4].ToLower();

                // Call the TryParseParametersForFilterAndTake method to validate and execute the command with the retrieved parameters.
                // The TryParseParametersForFilterAndTake method will check if the take command is "take" and if the take quantity is
                // either "all" or a valid integer. If the parameters are valid, it will call the appropriate method in the repository
                // to filter and take the students based on the provided course name, filter, and quantity.      

                TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                // If the command data does not have exactly five elements, throw an InvalidCommandException with the original
                // input as the message. This indicates that the command was not provided with the correct number of arguments and cannot be executed.
                // The InvalidCommandException will be caught by the command interpreter, which will display an appropriate error message to the user.
                // Throw an InvalidCommandException with the original input as the message to indicate that the command is invalid due to incorrect number of arguments.

                throw new InvalidCommandException(this.Input);
            }
        }


        //  The TryParseParametersForFilterAndTake method is responsible for validating the parameters for the "take" command and executing
        //  the appropriate method in the repository to filter and take the students based on the provided course name, filter, and quantity.
        //  Parameters:
        //  - takeCommand: The command that indicates the action to take (expected to be  take").    
        //  - takeQuantity: The quantity of students to take (expected to be "all" or a valid integer).
        //  - courseName: The name of the course for which to filter and take students
        //  - filter: The filter to apply when taking students (e.g., "excellent", "average", "poor").
        // The method first checks if the take command is "take". If it is, it then checks if the take quantity is "all".
        // If the take quantity is "all", it calls the FilterAndTake method in the repository with the course name and
        // filter to take all students that match the filter. If the take quantity is not "all", it attempts to parse
        // it as an integer. If the parsing is successful, it calls the FilterAndTake method in the repository with the
        // course name, filter, and the number of students to take.
        // If the parsing fails or if the take command is not "take", it displays an exception message indicating that the take quantity parameter is invalid.      

        private void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.Repository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.Repository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {

                // Display an exception message indicating that the take quantity parameter is invalid, as the take command is not "take".
                // The InvalidTakeQuantityParameter message will inform the user that the expected format for the take command is not met,
                // and it will guide them to provide the correct parameters for the command to work properly.
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }
    }
}