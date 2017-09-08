using System;
using System.Collections.Generic;
using System.Linq;

class RectangleIntersection
{
    private static void Main(string[] args)
    {
        /*
         * PURPOSE OF THIS PROGRAM:
         * ------------------------
         * This program checks whether two rectangles intersect.
         *
         * OOP CONCEPTS USED:
         * - Object creation (Rectangle instances)
         * - Encapsulation (Rectangle holds its own data)
         * - Object interaction (rect1 compares with rect2)
         * - Collection usage (List of rectangles)
         */

        /*
         * DUMMY DATA (replacing Console.ReadLine)
         * ----------------------------------------
         * n = number of rectangles
         * m = number of intersection checks
         */
        int n = 3;
        int m = 2;

        /*
         * STEP 1: CREATE RECTANGLES (SIMULATED INPUT)
         */
        List<Rectangle> rectangles = new List<Rectangle>
        {
            new Rectangle("A", 4, 5, 0, 0),
            new Rectangle("B", 3, 4, 2, 2),
            new Rectangle("C", 5, 3, -1, -1)
        };

        /*
         * STEP 2: PAIRS TO CHECK INTERSECTION
         * (Instead of reading from console)
         */
        List<(string, string)> checks = new List<(string, string)>
        {
            ("A", "B"),
            ("A", "C")
        };

        /*
         * STEP 3: PROCESS INTERSECTION CHECKS
         * -----------------------------------
         * This demonstrates object interaction + method calls
         */
        for (int j = 0; j < m; j++)
        {
            var ids = checks[j];

            // find rectangles by ID (LINQ search)
            var rect1 = rectangles.First(x => x.ID == ids.Item1);
            var rect2 = rectangles.First(x => x.ID == ids.Item2);

            // OOP: object calling method on another object
            bool result = rect1.IntersectsWith(rect2);

            Console.WriteLine(result ? "true" : "false");
        }
    }
}