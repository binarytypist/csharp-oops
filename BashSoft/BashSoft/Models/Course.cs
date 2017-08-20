using BashSoft.Exceptions;
using System.Collections.Generic;

namespace BashSoft.Models
{
    public class Course
    {
        // Maximum possible score per exam task
        public const int MaxScoreOnExamTasks = 100;

        // Number of tasks in the exam
        public const int NumberOfTasksOnExam = 5;

        // Course name field
        private string name;

        // Stores students enrolled in this course (key = username)
        private Dictionary<string, Student> studentsByName;

        public Course(string name)
        {
            // Initialize course name
            this.Name = name;

            // Initialize student collection
            this.studentsByName = new Dictionary<string, Student>();
        }

        public string Name
        {
            get => this.name;

            set
            {
                // Validate course name is not empty or null
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        // Read-only access to enrolled students
        public IReadOnlyDictionary<string, Student> StudentsByName
        {
            get => this.studentsByName;
        }

        // Enroll a student into the course
        public void EntrollStudent(Student student)
        {
            // Prevent duplicate enrollment
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(
                    student.UserName,
                    this.Name
                );
            }

            // Add student to course
            this.studentsByName.Add(student.UserName, student);
        }
    }
}