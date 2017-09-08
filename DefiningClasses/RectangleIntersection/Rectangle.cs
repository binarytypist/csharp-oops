using System;
public class Rectangle
{
    /*
     * PURPOSE OF THIS CLASS:
     * ----------------------
     * This class represents a geometric Rectangle object.
     *
     * OOP CONCEPTS USED:
     * - Encapsulation (data + behavior inside one class)
     * - Object modeling (real-world shape representation)
     * - Method behavior (object can act on another object)
     */

    /*
     * CONSTRUCTOR:
     * ------------
     * Initializes a rectangle with:
     * - ID (identifier)
     * - Width & Height (size)
     * - X & Y (position in 2D space)
     */
    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.ID = id;         // unique identifier
        this.Width = width;   // rectangle width
        this.Height = height; // rectangle height
        this.X = x;           // position X (coordinate)
        this.Y = y;           // position Y (coordinate)
    }

    /*
     * PROPERTIES (ENCAPSULATION):
     * ---------------------------
     * These define the internal state of the rectangle.
     */

    public string ID { get; set; }       // rectangle identifier
    public double Width { get; set; }    // width size
    public double Height { get; set; }   // height size
    public double X { get; set; }        // X position
    public double Y { get; set; }        // Y position

    /*
     * METHOD: IntersectsWith
     * ----------------------
     * This checks if this rectangle overlaps with another rectangle.
     *
     * OOP CONCEPT:
     * - Object interaction (one object compares with another object)
     * - Behavior inside class (encapsulation of logic)
     */
    public bool IntersectsWith(Rectangle rect)
    {
        if (Math.Abs(this.X) < Math.Abs(rect.X + rect.Width))
        {
            if (Math.Abs(this.X + this.Width) >= Math.Abs(rect.X))
            {
                if (this.Y < Math.Abs((rect.Y - rect.Height)))
                {
                    if (Math.Abs(this.Y + this.Height) >= Math.Abs(rect.Y))
                    {
                        return true; // rectangles overlap
                    }
                }
            }
        }

        return false; // no intersection
    }
}

/*
 * DUMMY DATA EXAMPLE (NO READLINE)
 * ---------------------------------
 * You can test like this:
 *
 * Rectangle r1 = new Rectangle("A", 4, 5, 0, 0);
 * Rectangle r2 = new Rectangle("B", 3, 4, 2, 2);
 *
 * Console.WriteLine(r1.IntersectsWith(r2));
 *
 * This removes dependency on user input and makes testing easier.
 */