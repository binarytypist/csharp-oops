using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    // This class is a concrete implementation of the COMMAND pattern.
    // Responsibility: Load student/course data from a file into the system.
    // It encapsulates one action: "read database".
    public class ReadDatabaseCommand : Command
    {
        // Constructor injects shared dependencies from the base Command class.
        // This follows Dependency Injection (OOP principle) so the command
        // does not create or manage dependencies itself.
        public ReadDatabaseCommand(
            string input,
            string[] data,
            Tester judge,
            StudentsRepository repository,
            IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            // This command expects exactly one argument: file name
            // Example: "readDb students.txt"

            if (this.Data.Length == 2)
            {
                string fileName = this.Data[1];

                // Delegation: repository handles ALL data loading logic
                // Command only triggers the action (Single Responsibility Principle)
                this.Repository.LoadData(fileName);
            }
            else
            {
                // If command format is invalid, throw exception
                // This ensures strict command validation in the system
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
}