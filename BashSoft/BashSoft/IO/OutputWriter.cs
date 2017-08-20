using System;
using System.Collections.Generic;

namespace BashSoft
{
    // This class is responsible ONLY for printing output to the console
    // It acts like a "central output system" for the whole application
    // Instead of using Console.WriteLine everywhere, everything goes through here
    public static class OutputWriter
    {
        // Prints text WITHOUT moving to a new line
        // Used when you want to continue printing on the same line
        public static void WriteMessage(string message)
        {
            Console.Write(message);
        }

        // Prints text and moves to a new line
        // This is the most commonly used output method in the project
        public static void WriteMessageOnNewLine(string message)
        {
            Console.WriteLine(message);
        }

        // Prints an empty line (just spacing in console output)
        // Used to improve readability of command output
        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }

        // Prints an error message in RED color
        // This is used for exceptions and warnings (important UX improvement)
        public static void DisplayException(string message)
        {
            // Save current console color so we can restore it later
            ConsoleColor currentColor = Console.ForegroundColor;

            // Change text color to red to highlight errors
            Console.ForegroundColor = ConsoleColor.Red;

            // Print error message
            Console.WriteLine(message);

            // Restore original console color (important to avoid affecting other outputs)
            Console.ForegroundColor = currentColor;
        }

        // Prints a student record in format: "username - mark"
        // Used by filtering/sorting features in RepositoryFilter and RepositorySorter
        public static void PrintStudent(KeyValuePair<string, double> student)
        {
            OutputWriter.WriteMessageOnNewLine($"{student.Key} - {student.Value}");
        }
    }
}