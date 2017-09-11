using System;

namespace ClassBox
{
    public class Box
    {
        // Encapsulation: fields are kept private to protect internal state
        private double length;
        private double width;
        private double height;

        // Constructor ensures object is created in a valid state
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        // Property used to validate and control access to length
        private double Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        // Property used to validate and control access to width
        private double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        // Property used to validate and control access to height
        private double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        // Calculates total surface area of the box
        public void PrintSurfaceArea()
        {
            double area =
                2 * this.length * this.width +
                2 * this.length * this.height +
                2 * this.width * this.height;

            Console.WriteLine($"Surface Area - {area:F2}");
        }

        // Calculates lateral surface area of the box
        public void PrintLateralSurfaceArea()
        {
            double area =
                2 * this.length * this.height +
                2 * this.width * this.height;

            Console.WriteLine($"Lateral Surface Area - {area:F2}");
        }

        // Calculates volume of the box
        public void PrintVolume()
        {
            double volume = this.length * this.width * this.height;

            Console.WriteLine($"Volume - {volume:F2}");
        }
    }
}