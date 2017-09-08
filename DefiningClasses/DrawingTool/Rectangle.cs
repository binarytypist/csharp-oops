using System;

namespace DrawingTool
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * Rectangle is a SPECIAL type of Square (in this exercise design).
     *
     * It inherits from Square and extends it by adding:
     * - width (X)
     *
     * This demonstrates INHERITANCE + EXTENSION of behavior.
     */

    public class Rectangle : Square
    {
        /*
         * PRIVATE FIELD (ENCAPSULATION):
         * ------------------------------
         * This stores the width of the rectangle.
         * It is hidden from outside access.
         */
        private int x;

        /*
         * CONSTRUCTOR (INHERITANCE + CONSTRUCTOR CHAINING):
         * --------------------------------------------------
         * We receive:
         * - x (width)
         * - y (height)
         *
         * ": base(y)" means:
         * → call Square constructor first
         * → initialize height in parent class
         */
        public Rectangle(int x, int y) : base(y)
        {
            // assign rectangle-specific width
            this.X = x;
        }

        /*
         * PROPERTY (ENCAPSULATION):
         * -------------------------
         * Controlled access to private field x.
         */
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        /*
         * OVERRIDING METHOD (POLYMORPHISM):
         * ---------------------------------
         * This replaces the Draw() method from Square.
         *
         * At runtime, correct Draw() is chosen automatically.
         */
        public override void Draw()
        {
            /*
             * TOP BORDER OF RECTANGLE
             * Example: |-----|
             */
            Console.WriteLine("|" + new string('-', this.X) + "|");

            /*
             * MIDDLE PART (EMPTY SPACE)
             * Example:
             * |     |
             * |     |
             *
             * this.Y comes from Square (height)
             */
            for (int i = 1; i < this.Y - 1; i++)
            {
                Console.WriteLine("|" + new string(' ', this.X) + "|");
            }

            /*
             * BOTTOM BORDER (only if height > 1)
             */
            if (this.Y > 1)
            {
                Console.WriteLine("|" + new string('-', this.X) + "|");
            }
        }
    }
}