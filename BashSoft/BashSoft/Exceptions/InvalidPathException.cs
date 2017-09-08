using System;

// ReSharper disable once CheckNamespace
// The namespace is intentionally left as "BashSoft.Exceptions" to maintain the structure of the project and
// to ensure that the exception can be easily found and used throughout the application. This allows for better organization
// and separation of concerns, as all exceptions are grouped together in a dedicated namespace.
namespace BashSoft.Exceptions
{
    // The exception that is thrown when an invalid path is provided. This can occur when trying to access a file or directory
    // that does not exist.
    public class InvalidPathException : Exception
    {
        //  The message template for the exception. This message is used when an invalid path is provided and is passed
        //  to the base class constructor
        //  when the exception is thrown. The message informs the user that the source does not exist, which is the reason for the exception.
        private const string InvalidPath = "The source does not exist.";

        //  Initializes a new instance of the InvalidPathException class with a default message. The default message is passed to the base class constructor
        //  when an invalid path is provided. For example, if the path "C:\nonexistent" is provided, the message will be "The source does not exist."
        //  The default message is used to inform the user that the source does not exist, which is the reason for the exception.

        public InvalidPathException() : base(InvalidPath)
        {
            //  The constructor is intentionally left empty as the default message is already set in the base class constructor
        }

        // Initializes a new instance of the InvalidPathException class with a specified message. The message is passed to the base class constructor,
        // which is the Exception class. This allows for custom messages
       
        public InvalidPathException(string message) : base(message)
        {
            //  Initializes a new instance of the InvalidPathException class with a specified message.  
            // The message is passed to the base class constructor, which is the Exception class. This allows for custom messages
            // to be provided when the exception is thrown, giving more context about the error.
        }
    }
}