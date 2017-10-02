namespace AquaShop.IO
{
    using System;
    using AquaShop.IO.Contracts;

    /// <summary>
    /// Handles all output operations to the console.
    /// This class abstracts the output mechanism, allowing
    /// easier testing and replacement (e.g., file writer, logger).
    /// </summary>
    public class Writer : IWriter
    {
        /// <summary>
        /// Writes text to the standard output without a newline.
        /// </summary>
        /// <param name="message">The message to be written.</param>
        public void Write(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// Writes text to the standard output followed by a newline.
        /// </summary>
        /// <param name="message">The message to be written.</param>
        public void WriteLine(string message)
        {
            Console.WriteLine(message ?? string.Empty);
        }
    }
}