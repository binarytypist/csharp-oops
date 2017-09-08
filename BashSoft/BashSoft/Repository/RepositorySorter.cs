using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public class RepositorySorter
    {
        // Sorts students by mark and prints limited results
        public void OrderAndTake(Dictionary<string, double> studentsWithMarks, string comparison, int studentsToTake)
        {
            // Normalize input to avoid case issues
            comparison = comparison.ToLower();

            // Sort ascending (low → high marks)
            if (comparison == "ascending")
            {
                PrintStudents(
                    studentsWithMarks
                        .OrderBy(x => x.Value)
                        .Take(studentsToTake)
                        .ToDictionary(pair => pair.Key, pair => pair.Value)
                );
            }
            // Sort descending (high → low marks)
            else if (comparison == "descending")
            {
                PrintStudents(
                    studentsWithMarks
                        .OrderByDescending(x => x.Value)
                        .Take(studentsToTake)
                        .ToDictionary(pair => pair.Key, pair => pair.Value)
                );
            }
            else
            {
                // Invalid sorting option
                throw new ArgumentException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        // Prints sorted students to console
        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (KeyValuePair<string, double> keyValuePair in studentsSorted)
            {
                OutputWriter.PrintStudent(keyValuePair);
            }
        }
    }
}