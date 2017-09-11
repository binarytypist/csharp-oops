using System;
using System.Linq;
using System.Reflection;

namespace ClassBox
{
    class ClassBox
    {
        private static void Main(string[] args)
        {
            // Reflection: Getting the Box type at runtime
            Type boxType = typeof(Box);

            // Reflection: Fetching all private instance fields of Box
            // This is used to inspect the internal structure of the class at runtime
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            // Prints how many private fields exist in Box (length, width, height)
            Console.WriteLine($"Private fields count: {fields.Count()}");

            // Dummy input data instead of Console.ReadLine()
            double length = 5.0;
            double width = 3.0;
            double height = 2.0;

            try
            {
                Box box = new Box(length, width, height);

                box.PrintSurfaceArea();
                box.PrintLateralSurfaceArea();
                box.PrintVolume();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}