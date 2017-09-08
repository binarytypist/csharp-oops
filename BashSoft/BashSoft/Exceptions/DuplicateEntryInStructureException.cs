using System;

namespace BashSoft.Exceptions
{

    //  This exception is thrown when we try to add an entry in a structure that already contains it. For example,
    //  when we try to enroll a student in a course, but the student is already enrolled in it.
    public class DuplicateEntryInStructureException : Exception
    {
        // The message template for the exception. It takes two parameters: the entry that is duplicated and the structure where it is duplicated.
        private const string DuplicateEntry = "The {0} already exists in {1}.";

        // Initializes a new instance of the DuplicateEntryInStructureException class with a default message.
        public DuplicateEntryInStructureException(string message) : base(message)
        {
            // The message is passed to the base class constructor, which is the Exception class.
        }

        // Initializes a new instance of the DuplicateEntryInStructureException class with a specified entry and structure.
        public DuplicateEntryInStructureException(string entry, string structure) : base(string.Format(DuplicateEntry, entry, structure))
        {
            // The message is formatted using the entry and structure parameters and passed to the base class constructor

        }
    }
}