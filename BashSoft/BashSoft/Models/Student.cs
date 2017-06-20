using BashSoft.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft.Models
{
    public class Student
    {
        // Student username
        private string userName;

        // Courses the student is enrolled in (key = course name)
        private Dictionary<string, Course> enrolledCourses;

        // Final marks per course
        private Dictionary<string, double> marksByCourseName;

        public Student(string userName)
        {
            // Validate and set username
            this.UserName = userName;

            // Initialize collections
            this.enrolledCourses = new Dictionary<string, Course>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public string UserName
        {
            get => this.userName;

            private set
            {
                // Username cannot be null or empty
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.userName = value;
            }
        }

        // Read-only access to enrolled courses
        public IReadOnlyDictionary<string, Course> EnrolledCourses
        {
            get => this.enrolledCourses;
        }

        // Read-only access to calculated marks per course
        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get => this.marksByCourseName;
        }

        // Enroll student in a course
        public void EntrollInCourse(Course course)
        {
            // Prevent duplicate enrollment
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        // Set exam marks for a course
        public void SetMarksInCourse(string courseName, params int[] scores)
        {
            // Student must be enrolled first
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }

            // Validate number of scores
            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfScores);
            }

            // Calculate final mark and store it
            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        // Convert raw scores into final grade
        private double CalculateMark(int[] scores)
        {
            // Calculate percentage of solved exam tasks
            double percentageOfSolvedExam =
                scores.Sum() /
                (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTasks);

            // Convert percentage into grade (2.0 - 6.0 scale)
            double mark = percentageOfSolvedExam * 4 + 2;

            return mark;
        }
    }
}