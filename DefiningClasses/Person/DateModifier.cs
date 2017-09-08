using System;

public class DateModifier
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class is responsible for calculating the difference
     * between two dates in DAYS.
     *
     * It demonstrates:
     * - Encapsulation (data + behavior in one class)
     * - Single Responsibility Principle (only handles date logic)
     */

    /*
     * PROPERTY:
     * ---------
     * Stores the result of date difference in days.
     */
    public int DateDifferenceDays { get; set; }

    /*
     * METHOD:
     * -------
     * Takes two string dates, converts them to DateTime,
     * and calculates the absolute difference in days.
     *
     * This is a BEHAVIOR method (not just data).
     */
    public void FindDifference(string dateOne, string dateTwo)
    {
        try
        {
            /*
             * PARSING STRINGS → DATE OBJECTS
             * This converts input into real DateTime objects.
             */
            DateTime date1 = DateTime.Parse(dateOne);
            DateTime date2 = DateTime.Parse(dateTwo);

            /*
             * DATE SUBTRACTION LOGIC:
             * -----------------------
             * Subtracting DateTime gives TimeSpan
             * TotalDays gives difference in days
             */
            var result = Math.Abs((date1 - date2).TotalDays);

            /*
             * STORE RESULT:
             * -------------
             * Convert to int and store in property
             */
            this.DateDifferenceDays = (int)result;
        }
        catch (Exception e)
        {
            /*
             * ERROR HANDLING:
             * ---------------
             * If invalid date format is given,
             * exception is printed and re-thrown.
             */
            Console.WriteLine(e.Message);
            throw;
        }
    }
}