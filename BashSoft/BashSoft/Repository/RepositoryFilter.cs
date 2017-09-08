using System;
using System.Collections.Generic;

namespace BashSoft
{
    public class RepositoryFilter
    {
        // Filters students based on performance category and prints limited results
        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake)
        {
            // Excellent students (grade >= 5)
            if (wantedFilter == "excellent")
            {
                FilterAndTake(studentsWithMarks, x => x >= 5, studentsToTake);
            }
            // Average students (3.5 <= grade < 5)
            else if (wantedFilter == "average")
            {
                FilterAndTake(studentsWithMarks, x => x < 5 && x >= 3.5, studentsToTake);
            }
            // Poor students (grade < 3.5)
            else if (wantedFilter == "poor")
            {
                FilterAndTake(studentsWithMarks, x => x < 3.5, studentsToTake);
            }
            else
            {
                // Invalid filter type
                throw new ArgumentException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        // Core filtering logic using Predicate (lambda condition)
        private void FilterAndTake(
            Dictionary<string, double> studentsWithMarks,
            Predicate<double> givenFilter,
            int studentsToTake)
        {
            int counterForPrinted = 0;

            foreach (var studentMark in studentsWithMarks)
            {
                // Stop if required number of students is printed
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                // Apply filter condition (lambda)
                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(studentMark);
                    counterForPrinted++;
                }
            }
        }
    }
}