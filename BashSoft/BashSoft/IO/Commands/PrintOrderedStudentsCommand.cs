using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    /// <summary>
    /// This command is part of the Command Pattern architecture.
    /// Responsibility: Print students from a course ordered by a given filter and quantity.
    /// It does NOT process data itself — it delegates work to the Repository layer.
    /// </summary>
    public class PrintOrderedStudentsCommand : Command
    {
        // Constructor uses constructor chaining to pass dependencies to the base Command class.
        // This avoids duplication and follows DRY + Dependency Injection principles.
        public PrintOrderedStudentsCommand(
            string input,
            string[] data,
            Tester judge,
            StudentsRepository repository,
            IOManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
            // intentionally empty because base class handles initialization
        }

        public override void Execute()
        {
            // Validate command structure: expected format has 5 parts
            // Example:
            // order {courseName} ascending/descending take all/5/10
            if (this.Data.Length == 5)
            {
                // Extract command arguments from input
                string courseName = this.Data[1];     // course to operate on
                string filter = this.Data[2].ToLower(); // ascending or descending
                string takeCommand = this.Data[3].ToLower(); // must be "take"
                string takeQuantity = this.Data[4].ToLower(); // "all" or number

                // Delegate parsing logic to a helper method for cleaner code (SRP principle)
                TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                // If command format is incorrect, throw exception to maintain system integrity
                throw new InvalidCommandException(this.Input);
            }
        }

        /// <summary>
        /// Handles parsing and validation of "take" command parameters.
        /// This method decides how many students should be printed.
        /// </summary>
        private void TryParseParametersForOrderAndTake(
            string takeCommand,
            string takeQuantity,
            string courseName,
            string filter)
        {
            // First validate that command starts with "take"
            if (takeCommand == "take")
            {
                // CASE 1: take all students
                if (takeQuantity == "all")
                {
                    // Delegation: Repository handles sorting + printing logic
                    this.Repository.OrderAndTake(courseName, filter);
                }
                else
                {
                    // CASE 2: take a specific number of students
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                    if (hasParsed)
                    {
                        // Valid number → pass to repository
                        this.Repository.OrderAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        // Invalid number format → show user-friendly error
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                // If command does not start with "take", it's invalid input
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }
    }
}