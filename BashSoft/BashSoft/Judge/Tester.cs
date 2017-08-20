using BashSoft.Exceptions;
using System;
using System.IO;

namespace BashSoft
{
    // This class is responsible for comparing two files
    // It simulates a "test engine" that checks expected vs actual output
    public class Tester
    {
        // Main method: compares two files line by line
        public void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");

            try
            {
                // Build path where mismatches will be saved (if any)
                string mismatchPath = GetMismatchPath(expectedOutputPath);

                // Read both files into memory
                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatch;

                // Compare both files line by line and collect differences
                string[] mismatches =
                    GetLinesWithPossibleMismatches(
                        actualOutputLines,
                        expectedOutputLines,
                        out hasMismatch
                    );

                // Print results and optionally write mismatch file
                PrintOutput(mismatches, hasMismatch, mismatchPath);

                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (IOException)
            {
                // Any file error (missing file, locked file, invalid path)
                throw new InvalidPathException();
            }
        }

        // Handles printing results and saving mismatch file if needed
        private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
        {
            if (hasMismatch)
            {
                // Print all mismatched lines to console
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }

                // Save mismatches into a file for later inspection
                File.WriteAllLines(mismatchPath, mismatches);

                return;
            }
            else
            {
                // If no differences found → files are identical
                OutputWriter.WriteMessageOnNewLine(
                    "Files are identical. There are no mismatches."
                );
            }
        }

        // Core comparison logic: compares files line-by-line
        private string[] GetLinesWithPossibleMismatches(
            string[] actualOutputLines,
            string[] expectedOutputLines,
            out bool hasMismatch)
        {
            hasMismatch = false;

            string output = string.Empty;

            // Store results (either match or mismatch messages)
            string[] mismatches = new string[actualOutputLines.Length];

            OutputWriter.WriteMessageOnNewLine("Comparing files...");

            int minOutputlines = actualOutputLines.Length;

            // If file sizes differ → mark mismatch and compare only up to smallest size
            if (actualOutputLines.Length != expectedOutputLines.Length)
            {
                hasMismatch = true;
                minOutputlines = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);

                OutputWriter.DisplayException(
                    ExceptionMessages.ComparisonOfFilesWithDifferentSizes
                );
            }

            // Compare line by line
            for (int index = 0; index < minOutputlines; index++)
            {
                string actualLine = actualOutputLines[index];
                string expectedLine = expectedOutputLines[index];

                // If lines differ → record mismatch
                if (!actualLine.Equals(expectedLine))
                {
                    output =
                        $"Mismatch at line {index} -- expected: \"{expectedLine}\", actual: \"{actualLine}\"";

                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    // If equal → store line as-is
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[index] = output;
            }

            return mismatches;
        }

        // Builds path for mismatch output file
        private string GetMismatchPath(string expectedOutputPath)
        {
            // Find last folder separator
            int indexOf = expectedOutputPath.LastIndexOf('\\');

            // Extract folder path
            string directoryPath = expectedOutputPath.Substring(0, indexOf);

            // Create fixed file name for mismatch report
            string finalPath = directoryPath + @"\Mismatches.txt";

            return finalPath;
        }
    }
}