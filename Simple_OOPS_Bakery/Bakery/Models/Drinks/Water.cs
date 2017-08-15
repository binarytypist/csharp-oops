namespace Bakery.Models.Drinks
{
    // The Water class represents a specific type of drink in the bakery menu.
    // It inherits from the Drink class, which provides the common properties and validation logic for all drinks.
    // The Water class has a constant field WaterPrice, which defines the price for water items (1.50).
    // The constructor of the Water class takes three parameters: name, portion, and brand, which are passed to the base constructor of the Drink class along with the WaterPrice
    // to initialize the properties of the water item.
    // The Water class does not contain any additional logic beyond calling the base constructor to initialize the properties of the water item.
    // The name parameter represents the name of the water item, the portion parameter represents the portion size of the water item in ml,
    // and the brand parameter represents the brand of the water item.

    // The validation for the name, portion, and brand properties is handled in the base Drink class, so there is no need for additional validation logic in the Water class constructor   
    // The Water class is a concrete implementation of the Drink class, representing a specific type of drink in the bakery menu. It provides a constructor to initialize the properties of the
    // water item and relies on the base class for validation and common functionality.

    // The Water class is a concrete implementation of the Drink class, representing a specific type of drink in the bakery menu. It provides a constructor to initialize the properties of the
    // water item and relies on the base class for validation and common functionality.
    // The Water class is a concrete implementation of the Drink class, representing a specific type of drink in the bakery menu. It provides a constructor to initialize the properties of the
    // water item and relies on the base class for validation and common functionality.
    // The Water class is a concrete implementation of the Drink class, representing a specific type of drink in the bakery menu. It provides a constructor to initialize the properties of the
    public class Water : Drink
    {

        //  The WaterPrice constant defines the price for water items in the bakery menu. It is set to 1.50, which is a common price for water.
       private const decimal WaterPrice = 1.50m;


        // Constructor to initialize the properties of the water item.
        // The constructor takes three parameters: name, portion, and brand, which are used to set the corresponding properties of the water item.
             
        public Water(string name, int portion, string brand) : base(name, portion, WaterPrice, brand)
        {

            // The constructor does not contain any additional logic beyond calling the base constructor to initialize the properties of the water item.
            // The validation for the name, portion, and brand properties is handled in the base Drink class, so there is no need for additional
            // validation logic in the Water class constructor
        }
    }
}