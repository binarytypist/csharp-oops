using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    // This class represents a concrete COMMAND in the Command Pattern (OOP design pattern)
    // Each command in the system is encapsulated as an object with a single responsibility:
    // to execute a specific action based on user input.
    public class ShowCourseCommand : Command
    {
        // Constructor passes shared dependencies to the base Command class:
        // - input: raw command string from user
        // - data: parsed command arguments
        // - judge: tester logic (comparison of files etc.)
        // - repository: data layer (students & courses storage)
        // - inputOutputManager: handles IO operations (console/file system)
        public ShowCourseCommand(
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
            // This method is the core of the command.
            // It decides what operation to perform based on arguments.

            // CASE 1: "show {courseName}"
            // Show all students in a given course (bulk query operation)
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];

                // Delegation principle: command does NOT handle data directly,
                // it delegates responsibility to the Repository (separation of concerns).
                this.Repository.GetAllStudentsFromCourse(courseName);
            }
            // CASE 2: "show {courseName} {username}"
            // Show a specific student's score in a specific course
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string userName = this.Data[2];

                // Again delegation: Repository handles lookup + logic
                this.Repository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                // If input does not match expected structure, throw exception
                // This enforces command validation and protects system integrity
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}