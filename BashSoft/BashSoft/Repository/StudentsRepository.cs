using BashSoft.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using BashSoft.Exceptions;

namespace BashSoft
{
    public class StudentsRepository
    {
        // Flag to ensure data is loaded only once
        private bool isDataInitialized = false;

        // External services for filtering and sorting
        private RepositoryFilter filter;
        private RepositorySorter sorter;

        // Main in-memory storage
        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;

        public StudentsRepository(RepositorySorter sorter, RepositoryFilter filter)
        {
            this.filter = filter;
            this.sorter = sorter;
        }

        // Loads data from file into memory
        public void LoadData(string fileName)
        {
            if (!this.isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");

                this.students = new Dictionary<string, Student>();
                this.courses = new Dictionary<string, Course>();

                ReadData(fileName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.DataAlreadyInitialisedException);
            }
        }

        // Clears all loaded data
        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataAlreadyInitialisedException);
            }

            this.students = null;
            this.courses = null;
            isDataInitialized = false;
        }

        // Reads and parses file data into Students and Courses
        private void ReadData(string fileName)
        {
            string path = SessionsData.currentPath + "\\" + fileName;

            if (File.Exists(path))
            {
                // Pattern: courseName username scores
                string pattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
                Regex rgx = new Regex(pattern);

                string[] allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = rgx.Match(allInputLines[line]);

                        string courseName = currentMatch.Groups[1].Value;
                        string username = currentMatch.Groups[2].Value;
                        string scoresStr = currentMatch.Groups[3].Value;

                        try
                        {
                            // Convert scores string to int array
                            int[] scores = scoresStr
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                            // Validate score range
                            if (scores.Any(x => x > 100 || x < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                                continue;
                            }

                            // Validate number of scores
                            if (scores.Length > Course.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }

                            // Create student if not exists
                            if (!this.students.ContainsKey(username))
                            {
                                this.students.Add(username, new Student(username));
                            }

                            // Create course if not exists
                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new Course(courseName));
                            }

                            Course course = this.courses[courseName];
                            Student student = this.students[username];

                            // Link student and course both ways
                            student.EntrollInCourse(course);
                            student.SetMarksInCourse(courseName, scores);

                            course.EntrollStudent(student);
                        }
                        catch (FormatException fex)
                        {
                            OutputWriter.DisplayException(fex.Message + $" at line: {line}");
                        }
                    }
                }
            }
            else
            {
                throw new InvalidPathException();
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        // Checks if course exists and system is initialized
        private bool IsQueryForCoursePossible(string courseName)
        {
            if (!isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            if (!this.courses.ContainsKey(courseName))
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                return false;
            }

            return true;
        }

        // Checks if student exists in a course
        private bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) &&
                this.courses[courseName].StudentsByName.ContainsKey(studentUserName))
            {
                return true;
            }

            OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            return false;
        }

        // Prints a single student's score in a course
        public void GetStudentScoresFromCourse(string courseName, string username)
        {
            if (IsQueryForStudentPossible(courseName, username))
            {
                OutputWriter.PrintStudent(
                    new KeyValuePair<string, double>(
                        username,
                        this.courses[courseName].StudentsByName[username].MarksByCourseName[courseName]
                    )
                );
            }
        }

        // Prints all students in a course
        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");

                foreach (var studentMarksEntry in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentScoresFromCourse(courseName, studentMarksEntry.Key);
                }
            }
        }

        // Filters students by category (excellent/average/poor)
        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks =
                    this.courses[courseName].StudentsByName
                        .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        // Orders students and prints result
        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks =
                    this.courses[courseName].StudentsByName
                        .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }
    }
}