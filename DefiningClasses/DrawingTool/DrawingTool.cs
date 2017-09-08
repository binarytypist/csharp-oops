namespace DrawingTool
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This is the MAIN entry point of the program.
     *
     * It acts like a CONTROLLER that:
     * - decides what shape to create
     * - builds the correct object (Square or Rectangle)
     * - passes it to CorDraw
     * - triggers drawing behavior
     */

    class DrawingTool
    {
        private static void Main(string[] args)
        {
            /*
             * STEP 1: DUMMY INPUT DATA (instead of Console.ReadLine)
             * -------------------------------------------------------
             * We simulate user input here.
             *
             * Change values here to test different scenarios.
             */

            var shape = "Rectangle"; // try "Square" or "Rectangle"

            // variables for dimensions
            var y = 0;
            var x = 0;

            /*
             * POLYMORPHISM BASE TYPE:
             * ------------------------
             * We use a base reference type (Square)
             *
             * This allows us to store BOTH Square and Rectangle objects
             * in the same variable.
             */
            Square sq = null;

            /*
             * STEP 2: OBJECT CREATION (runtime decision)
             * ------------------------------------------
             * The program decides which object to create
             * based on the value of "shape"
             */
            if (shape == "Square")
            {
                /*
                 * Square needs only one value
                 */
                y = 5; // dummy value instead of Console.ReadLine()

                // create Square object
                sq = new Square(y);
            }
            else
            {
                /*
                 * Rectangle needs two values
                 */
                y = 10; // height
                x = 20; // width

                // create Rectangle object
                sq = new Rectangle(y, x);
            }

            /*
             * STEP 3: COMPOSITION
             * --------------------
             * CorDraw "HAS A" shape object
             *
             * We pass the created shape into CorDraw
             */
            CorDraw cd = new CorDraw(sq);

            /*
             * STEP 4: ABSTRACTION + POLYMORPHISM
             * -----------------------------------
             * We do NOT care whether it's Square or Rectangle.
             *
             * We just call Draw()
             * and correct implementation runs automatically.
             */
            cd.Figure.Draw();
        }
    }
}