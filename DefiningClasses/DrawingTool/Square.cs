using System;

namespace DrawingTool
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a SQUARE shape.
     *
     * It is also the BASE CLASS for Rectangle.
     *
     * It defines:
     * - height (Y)
     * - default drawing behavior
     */

    public class Square
    {
        /*
         * PRIVATE FIELD (ENCAPSULATION):
         * ------------------------------
         * Stores the height of the square.
         * Hidden from outside access.
         */
        private int y;

        /*
         * CONSTRUCTOR:
         * ------------
         * Initializes Square object with height.
         */
        public Square(int y)
        {
            this.Y = y;
        }

        /*
         * PROPERTY (ENCAPSULATION):
         * -------------------------
         * Controlled access to private field y.
         */
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /*
         * VIRTUAL METHOD (IMPORTANT OOP CONCEPT)
         * --------------------------------------
         * This method defines HOW a Square is drawn.
         *
         * WHY "virtual" is needed:
         * ------------------------
         * Because we EXPECT child classes (like Rectangle)
         * to CHANGE this behavior.
         *
         * So we allow overriding in derived classes.
         *
         * Without "virtual":
         * → Rectangle cannot modify Draw()
         *
         * With "virtual":
         * → Rectangle can override Draw()
         * → This enables POLYMORPHISM
         */
        public virtual void Draw()
        {
            /*
             * TOP BORDER OF SQUARE
             */
            Console.WriteLine("|" + new string('-', y) + "|");

            /*
             * MIDDLE PART (EMPTY SPACE)
             * Draw height - 2 rows
             */
            for (int i = 1; i < y - 1; i++)
            {
                Console.WriteLine("|" + new string(' ', y) + "|");
            }

            /*
             * BOTTOM BORDER
             * Only if height > 1
             */
            if (y > 1)
            {
                Console.WriteLine("|" + new string('-', y) + "|");
            }
        }
    }
}

// The Square class defines default drawing behavior and uses a virtual method to allow derived
// classes like Rectangle to override it and implement polymorphism at runtime.