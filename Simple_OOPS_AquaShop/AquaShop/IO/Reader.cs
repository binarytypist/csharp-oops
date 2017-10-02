namespace AquaShop.IO
{
    using System;
    using AquaShop.IO.Contracts;

    /// <summary>
    /// Responsible for reading input from the console.
    /// This class abstracts the input source, allowing easier testing
    /// and better separation of concerns (Dependency Inversion Principle).
    /// </summary>
    public class Reader : IReader
    {
        /// <summary>
        /// Reads a line of input from the standard input stream.
        /// </summary>
        /// <returns>
        /// The input string from the console, or an empty string if no input is provided.
        /// </returns>
        public string ReadLine()
        {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}