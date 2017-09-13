using System;

namespace Person
{
    class Startup
    {
        private static void Main(string[] args)
        {
            // Dummy data instead of user input
            string name = "John";
            int age = 10;

            try
            {
                // Create Child object using predefined values
                Child child = new Child(name, age);

                // Print object using overridden ToString from Person
                Console.WriteLine(child);
            }
            catch (ArgumentException ae)
            {
                // Handle validation errors from Person/Child classes
                Console.WriteLine(ae.Message);
            }
        }
    }
}