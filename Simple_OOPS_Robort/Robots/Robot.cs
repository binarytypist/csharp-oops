namespace Robots
{
    using System;

    /// <summary>
    /// Represents a Robot with a name and battery system.
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// Constructor initializes Robot with name and maximum battery.
        /// Battery starts fully charged.
        /// </summary>
        public Robot(string name, int maximumBattery)
        {
            this.Name = name;

            // Maximum battery capacity (cannot be changed after creation)
            this.MaximumBattery = maximumBattery;

            // Current battery starts at full capacity
            this.Battery = maximumBattery;
        }

        /// <summary>
        /// Name of the robot (can be changed because setter is public)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Current battery level of the robot
        /// Can decrease during usage or increase during charging
        /// </summary>
        public int Battery { get; set; }

        /// <summary>
        /// Maximum battery capacity (read-only after constructor)
        /// </summary>
        public int MaximumBattery { get; }
    }
}