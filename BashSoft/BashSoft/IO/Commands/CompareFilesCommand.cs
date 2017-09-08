using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{

        // The "cmp" command compares the content of two files and prints the result on the console.
        // The command is executed by the CommandInterpreter class when the user enters a command in the
        // console. The command is implemented in the CompareFilesCommand class, which inherits from the Command class.
        public class CompareFilesCommand : Command
        {
            // The constructor of the CompareFilesCommand class takes the input string, the data array, the judge, the repository,
            // and the inputOutputManager as parameters and passes them to the base class constructor.
            // The constructor does not contain any additional logic and simply calls the base constructor to initialize the command with the provided parameters.

        public CompareFilesCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
              // The constructor of the CompareFilesCommand class takes the input string, the data array, the judge, the repository,
              // and the inputOutputManager as parameters and passes them to the base class constructor
        }

        // The Execute method of the CompareFilesCommand class checks if the command data has exactly three elements 
        // (the command name and the two file paths). If the data is valid, it retrieves the first and second file paths from the data array
        // and calls the CompareContent method of the judge to compare the content of the two files. If the data is invalid, it throws an InvalidCommandException
        // with the original input as the message.
        public override void Execute()
        {
            // The Execute method of the CompareFilesCommand class checks if the command data has exactly three elements    
            //  (the command name and the two file paths). If the data is valid, it retrieves the first and second file paths from the data array
            //  and calls the CompareContent method of the judge to compare the content of the two files. If the data is invalid, it throws an InvalidCommandException
            if (this.Data.Length == 3)
            {
                //  If the data is valid, it retrieves the first and second file paths from the data array
                string firstPath = this.Data[1];
                // If the data is valid, it retrieves the first and second file paths from the data array
                string secondPath = this.Data[2];

                //  and calls the CompareContent method of the judge to compare the content of the two files.
                //  If the data is invalid, it throws an InvalidCommandException
                //  with the original input as the message. and calls the CompareContent method of the judge to compare the content of the two files.
                this.Judge.CompareContent(firstPath, secondPath);
            }
            else
            {

                // If the data is invalid, it throws an InvalidCommandException with the original input as the message.
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}