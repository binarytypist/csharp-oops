using BashSoft.Exceptions;
using BashSoft.IO.Commands;
using System;

namespace BashSoft
{
    /// <summary>
    /// CommandInterpreter is responsible for parsing raw string input
    /// and converting it into executable command objects.
    ///
    /// This class follows the Command Pattern:
    /// - Input string → Command object → Execution
    /// - It decouples input parsing from business logic execution
    /// </summary>
    public class CommandInterpreter
    {
        // Handles grading and validation logic (judge system)
        private Tester judge;

        // Stores and manages student/course data
        private StudentsRepository repository;

        // Handles file system navigation and I/O operations
        private IOManager inputOutputManager;

        /// <summary>
        /// Initializes CommandInterpreter with required system dependencies.
        /// This follows Dependency Injection (DI) principle.
        /// </summary>
        public CommandInterpreter(
            Tester judge,
            StudentsRepository repository,
            IOManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        /// <summary>
        /// Main entry point for processing user commands.
        /// Splits input, resolves command type, and executes it safely.
        /// </summary>
        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];

            try
            {
                // Convert raw input into a Command object
                Command command = this.ParseCommand(input, commandName, data);

                // Execute the resolved command
                command.Execute();
            }
            catch (Exception ex)
            {
                // Centralized error handling for all commands
                OutputWriter.DisplayException(ex.Message);
            }
        }

        /// <summary>
        /// Maps command names to their corresponding Command classes.
        /// This is the core of the Command Pattern dispatcher.
        /// </summary>
        private Command ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "ls":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "cdRel":
                    return new ChangeRelativePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "cdAbs":
                    return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "readdb":
                    return new ReadDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "download":
                    // Feature not implemented yet
                    throw new InvalidCommandException(input);

                case "downloadAsynch":
                    // Feature not implemented yet
                    throw new InvalidCommandException(input);

                case "show":
                    return new ShowCourseCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                default:
                    // Unknown command handling
                    throw new InvalidCommandException(input);
            }
        }
    }
}