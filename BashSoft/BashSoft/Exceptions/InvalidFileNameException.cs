using System;

namespace BashSoft.Exceptions
{
    // The exception that is thrown when an invalid name is given for a file or folder.
    // For example, when we try to create a file with a name that contains symbols that are not allowed to be used in names of files and folders.
    // The message that is displayed when an invalid name is given for a file or folder is "The given name contains symbols that are not allowed to be used in names of files and folders."

    public class InvalidFileNameException : Exception
    {
        // The message template for the exception. It is used when an invalid name is given for a file or folder.
        // The message is passed to the base class constructor, which is the Exception class and used in the IOManager class
        // when an invalid name is given for a file or folder.
        // For example, if we try to create a file with the name "invalid*name.txt", the message will be "The given name contains symbols
        // that are not allowed to be used in names of files and folders."
        private const string ForbiddenSymbolsContainedInName = "The given name contains symbols that are not allowed to be used in names of files and folders.";

        // Initializes a new instance of the InvalidFileNameException class with a default message.
        // The default message is passed to the base class constructor when an invalid name is given for a file or folder.
        public InvalidFileNameException() : base(ForbiddenSymbolsContainedInName)
        {
            // The default message is passed to the base class constructor
            // when an invalid name is given for a file or folder.
        }

        public InvalidFileNameException(string message) : base(message)
        {
            // The message is passed to the base class constructor, which is the Exception class.
            // The message parameter is the message that is displayed when an invalid name is given for a file or folder,
           // which is passed to the constructor when
        }
    }
}