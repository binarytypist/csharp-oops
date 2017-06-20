using System;

namespace BashSoft.Exceptions
{
    // The exception that is thrown when a course is not found in the repository.
    //  
    public class CourseNotFoundException : Exception
    {
        // The message that is displayed when a course is not found in the repository.
        private const string NotEnrolledInCourse = "Student must be enrolled in a course before you set his mark.";

        // Initializes a new instance of the CourseNotFoundException class with a default message.
        public CourseNotFoundException() : base(NotEnrolledInCourse)
        {
            // The default message is passed to the base class constructor
        }

        // Initializes a new instance of the CourseNotFoundException class with a specified message.
        public CourseNotFoundException(string message) : base(message)
        {
            // The message is passed to the base class constructor, which is the Exception class.
        }
    }
}