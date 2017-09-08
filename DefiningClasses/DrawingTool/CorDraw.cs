namespace DrawingTool
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a "Drawing Controller" (CorDraw).
     *
     * Its job is NOT to draw shapes itself,
     * but to HOLD a shape object (Square) and manage it.
     *
     * This demonstrates a key OOP idea:
     * → Composition (HAS-A relationship)
     */

    public class CorDraw
    {
        /*
         * PRIVATE FIELD:
         * --------------
         * This stores the Square object internally.
         *
         * It is hidden from outside classes to protect data.
         * (Encapsulation principle)
         */
        private Square figure;

        /*
         * CONSTRUCTOR:
         * ------------
         * This initializes the CorDraw object.
         *
         * It requires a Square object to be passed in.
         *
         * This means:
         * → CorDraw cannot exist without a Figure (Square)
         */
        public CorDraw(Square figure)
        {
            this.Figure = figure;
        }

        /*
         * PROPERTY:
         * ---------
         * This provides controlled access to the private field "figure".
         *
         * Instead of exposing the field directly,
         * we use a property (Encapsulation).
         */
        public Square Figure
        {
            get { return figure; }
            set { figure = value; }
        }
    }
}