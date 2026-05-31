namespace Robots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Manages a collection of Robot objects.
    /// Responsible for adding, removing, working, and charging robots.
    /// </summary>
    public class RobotManager
    {
        // Internal storage for robots
        private List<Robot> robots;

        // Maximum allowed robots in the manager
        private int capacity;

        public RobotManager(int capacity)
        {
            this.robots = new List<Robot>();

            // Set capacity with validation
            this.Capacity = capacity;
        }

        /// <summary>
        /// Maximum number of robots allowed
        /// </summary>
        public int Capacity
        {
            get => this.capacity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid capacity!");
                }

                this.capacity = value;
            }
        }

        /// <summary>
        /// Current number of robots in manager
        /// </summary>
        public int Count => this.robots.Count;

        /// <summary>
        /// Adds a robot to the manager
        /// </summary>
        public void Add(Robot robot)
        {
            // Check duplicate name
            if (this.robots.Any(r => r.Name == robot.Name))
            {
                throw new InvalidOperationException(
                    $"There is already a robot with name {robot.Name}!");
            }

            // Check capacity limit
            if (this.robots.Count == this.capacity)
            {
                throw new InvalidOperationException("Not enough capacity!");
            }

            // Add robot
            this.robots.Add(robot);
        }

        /// <summary>
        /// Removes a robot by name
        /// </summary>
        public void Remove(string name)
        {
            Robot robotToRemove = this.robots.FirstOrDefault(r => r.Name == name);

            if (robotToRemove == null)
            {
                throw new InvalidOperationException(
                    $"Robot with the name {name} doesn't exist!");
            }

            this.robots.Remove(robotToRemove);
        }

        /// <summary>
        /// Makes a robot perform work which reduces battery
        /// </summary>
        public void Work(string robotName, string job, int batteryUsage)
        {
            Robot robot = this.robots.FirstOrDefault(r => r.Name == robotName);

            // Check if robot exists
            if (robot == null)
            {
                throw new InvalidOperationException(
                    $"Robot with the name {robotName} doesn't exist!");
            }

            // Check battery availability
            if (robot.Battery < batteryUsage)
            {
                throw new InvalidOperationException(
                    $"{robot.Name} doesn't have enough battery!");
            }

            // Reduce battery after work
            robot.Battery -= batteryUsage;
        }

        /// <summary>
        /// Charges robot back to full battery
        /// </summary>
        public void Charge(string robotName)
        {
            Robot robot = this.robots.FirstOrDefault(r => r.Name == robotName);

            if (robot == null)
            {
                throw new InvalidOperationException(
                    $"Robot with the name {robotName} doesn't exist!");
            }

            // Restore full battery
            robot.Battery = robot.MaximumBattery;
        }
    }
}