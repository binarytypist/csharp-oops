namespace Robots
{
    /// <summary>
    /// Entry point of the application.
    /// Used to test Robot and RobotManager functionality.
    /// </summary>
    class StartUp
    {
        static void Main()
        {
            // ================================
            // CREATE ROBOT MANAGER
            // ================================
            RobotManager manager = new RobotManager(2);

            // ================================
            // CREATE ROBOTS
            // ================================
            Robot r1 = new Robot("Alpha", 100);
            Robot r2 = new Robot("Beta", 80);

            // ================================
            // ADD ROBOTS TO MANAGER
            // ================================
            manager.Add(r1);
            manager.Add(r2);

            // ================================
            // WORK ACTION (reduces battery)
            // ================================
            manager.Work("Alpha", "Welding", 30);

            // ================================
            // CHARGE ROBOT BACK TO FULL
            // ================================
            manager.Charge("Alpha");

            // ================================
            // REMOVE ROBOT
            // ================================
            manager.Remove("Beta");

            // ================================
            // OUTPUT CURRENT COUNT
            // ================================
            System.Console.WriteLine($"Robots in system: {manager.Count}");
        }
    }
}