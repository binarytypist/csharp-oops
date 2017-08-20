using System;

namespace BashSoft.Exceptions
{

    //  <summary>
    //  The exception that is thrown when an invalid command is entered in the command interpreter.
    //  </summary>

    public class InvalidCommandException : Exception
    {
        //  The message template for the exception.
        //  It takes one parameter: the command that is invalid.
        //  This message is used in the CommandInterpreter class when an invalid command is entered.
        //  The message is passed to the base class constructor, which is the Exception class.
        private const string InvalidCommand = "The command '{0}' is invalid";


        //  Initializes a new instance of the InvalidCommandException class with a default message.
        //  The default message is passed to the base class constructor
        //  when an invalid command is entered in the command interpreter.
        //  For example, if the command "download" is entered, the message will be "The command 'download' is invalid".
        public InvalidCommandException(string message) : base(string.Format(InvalidCommand, message))
        {
            // The message is formatted using the message parameter and passed to the base class constructor
            // The message parameter is the command that is invalid, which is passed to the constructor when
            // an invalid command is entered in the command interpreter.
        }
    }
}