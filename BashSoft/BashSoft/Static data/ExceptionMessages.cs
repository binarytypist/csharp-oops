namespace BashSoft
{
    public static class ExceptionMessages
    {
        // A sample placeholder message, likely used for testing or demonstration
        public const string ExampleExceptionMessage = "Example message!";

        // Thrown when data is loaded more than once without reset/unload
        public const string DataAlreadyInitialisedException = "Data is already initialized!";

        // Thrown when user tries to operate before loading any data
        public const string DataNotInitializedExceptionMessage =
            "The data structure must be initialised first in order to make any operations with it.";

        // Thrown when a requested course does not exist in repository/database
        public const string InexistingCourseInDataBase =
            "The course you are trying to get does not exist in the data base!";

        // Thrown when a student username is not found in repository/database
        public const string InexistingStudentInDataBase =
            "The user name for the student you are trying to get does not exist!";

        // (Commented out) Previously used for invalid file/folder path handling
        // public const string InvalidPath = "The folder/file you are trying to access at the current address, does not exist.";

        // Thrown when trying to access restricted files/folders without permission
        public const string UnauthorizedAccessExceptionMessage =
            "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        // Used when comparing two files that have different sizes/content mismatch
        public const string ComparisonOfFilesWithDifferentSizes =
            "Files not of equal size, certain mismatch.";

        // Thrown when trying to navigate above root directory (like cd .. too far)
        public const string UnableToGoHigherInPartitionHierarchy =
            "You cannot go higher!";

        // Thrown when input cannot be parsed into a valid number (e.g. ls depth)
        public const string UnableToParseNumber =
            "The sequence you've written is not a valid number.";

        // Thrown when user provides invalid filter type (must be excellent/average/poor)
        public const string InvalidStudentFilter =
            "The given filter is not one of the following: excellent/average/poor";

        // Thrown when sorting direction is invalid (must be ascending/descending)
        public const string InvalidComparisonQuery =
            "The comparison query you want, does not exist in the context of the current program!";

        // Thrown when "take X" command has invalid format or non-numeric value
        public const string InvalidTakeQuantityParameter =
            "The take command expected does not match the format wanted!";

        // (Commented out) Previously used for duplicate student-course enrollment
        // public const string StudentAlreadyEntrolledInGivenCourse = "The {0} already exists in {1}.";

        // (Commented out) Previously used when student wasn't enrolled in course
        // public const string NotEnrolledInCourse = "Student must be enrolled in a course before you set his mark.";

        // Thrown when number of exam scores exceeds allowed limit
        public const string InvalidNumberOfScores =
            "The number of scores for the given course is greater than the possible.";

        // Thrown when score is outside valid range (0–100)
        public const string InvalidScore =
            "The number for the score you've entered is not in the range of 0 - 100";

        // (Commented out) Previously used for null/empty validation
        // public const string NullOrEmptyValue = "The value of the variable CANNOT be null or empty!";
    }
}