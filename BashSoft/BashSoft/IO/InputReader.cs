using System;

namespace BashSoft
{
    public class InputReader
    {
        // Command that stops the application loop (like typing "exit" in a terminal)
        private const string endCommand = "quit";

        // This is the "brain" that understands and executes commands
        // It takes raw text like "mkdir test" and converts it into actions
        private CommandInterpreter interpreter;

        public InputReader(CommandInterpreter interpreter)
        {
            // Dependency injection:
            // We pass the interpreter from outside so InputReader doesn't create it itself
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            // Instead of real Console.ReadLine(), we are using dummy test commands
            // This simulates a user typing commands in a terminal

            string[] commands =
            {
                "mkdir test",   // create a folder named test
                "ls",           // list current directory content
                "cdRel ..",     // go one directory up
                "help",         // show available commands
                "dropdb",       // clear database (reset state)
                "show OOP",     // show course data
                "quit"          // stop program
            };

            // Loop through each simulated command
            foreach (var input in commands)
            {
                // Print fake terminal prompt + command (like real CLI)
                OutputWriter.WriteMessageOnNewLine($"{SessionsData.currentPath}> {input}");

                // Stop execution when "quit" command is reached
                if (input == endCommand)
                {
                    break;
                }

                // Send command to interpreter which decides what to execute
                interpreter.InterpredCommand(input);
            }
        }
    }
}