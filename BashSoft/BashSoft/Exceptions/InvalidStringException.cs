using System;


// The InvalidStringException is thrown when an invalid string is passed as an argument to a method or constructor.
// For example, when we try to set the name of a course to an empty string or null, this exception is thrown.
namespace BashSoft.Exceptions
{

    // The exception that is thrown when an invalid string is passed as an argument to a method or constructor.
    // For example, when we try to set the name of a course to an empty string or null, this exception is thrown.
    // The message that is displayed when an invalid string is passed as an argument to a method or constructor.
    public class InvalidStringException : Exception
    {

        // The message that is displayed when an invalid string is passed as an argument to a method or constructor.
        // This message is used in the Course class when we try to set the name of a course to an empty string or null.

        private const string NullOrEmptyValue = "The value of the variable CANNOT be null or empty!";

        // Initializes a new instance of the InvalidStringException class with a default message.
        // The default message is passed to the base class constructor
        // when an invalid string is passed as an argument to a method or constructor.
        public InvalidStringException() : base(NullOrEmptyValue)
        {
            // The default message is passed to the base class constructor
        }

        // Initializes a new instance of the InvalidStringException class with a specified message.
        // The message is passed to the base class constructor
        // when an invalid string is passed as an argument to a method or constructor.
        public InvalidStringException(string message) : base(message)
        {
            // The message is passed to the base class constructor
        }
    }
}