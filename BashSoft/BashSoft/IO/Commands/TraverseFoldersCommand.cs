using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    // This class represents a SINGLE command in the Command Pattern
    // Responsibility: traverse (list) folders in the current directory
    //
    // OOP Concept Used:
    // 👉 Command Pattern
    // Each command is a separate class with its own Execute() logic
    public class TraverseFoldersCommand : Command
    {
        // Constructor passes shared system dependencies to base Command class:
        // - input (raw user command)
        // - data (parsed command arguments)
        // - judge (tester system)
        // - repository (student/course database)
        // - inputOutputManager (file system manager)
        public TraverseFoldersCommand(
            string input,
            string[] data,
            Tester judge,
            StudentsRepository repository,
            IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        // Core logic of the command
        public override void Execute()
        {
            // Case 1: command is just "ls"
            // Example: ls
            if (this.Data.Length == 1)
            {
                // depth = 0 means: show only current folder level
                this.InputOutputManager.TraverseDirectory(0);
            }

            // Case 2: command is "ls 3"
            // Example: ls 3 → show directory tree up to depth 3
            else if (this.Data.Length == 2)
            {
                int depth;

                // Try to convert user input into number (safe parsing)
                bool hasParsed = int.TryParse(this.Data[1], out depth);

                if (hasParsed)
                {
                    // Valid depth → traverse directory structure
                    this.InputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    // Invalid number input → show error message
                    OutputWriter.DisplayException(
                        ExceptionMessages.UnableToParseNumber
                    );
                }
            }

            // Case 3: invalid command format
            else
            {
                // Command structure is not valid → throw custom exception
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}