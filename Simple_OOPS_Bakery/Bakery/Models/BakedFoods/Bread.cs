namespace Bakery.Models.BakedFoods
{

    // The Bread class represents a specific type of baked food item in the bakery menu.   
    // It inherits from the BakedFood class, which provides the common properties and validation logic for all baked food items.
    // The Bread class has a constant field InitialBreadPortion, which defines the default portion size for bread items (200 grams).
    // The constructor of the Bread class takes two parameters: name and price, which are passed to the base constructor of the BakedFood class along with the InitialBreadPortion
    // to initialize the properties of the bread item.
    public class Bread : BakedFood
    {
        // The InitialBreadPortion constant defines the default portion size for bread items in the bakery menu.
        // It is set to 200 grams, which is a common portion size for bread.
        private const int InitialBreadPortion = 200;


        // Constructor to initialize the properties of the bread item.
        // The constructor takes two parameters: name and price, which are used to set the corresponding properties of the bread item.
        // The constructor calls the base constructor of the BakedFood class, passing the name, InitialBreadPortion, and price to initialize the properties of the bread item.
        // The constructor is public, allowing it to be called from outside the class to create instances of bread items for the bakery menu.
        // The name parameter represents the name of the bread item, and the price parameter represents the price of the bread item.
        // The portion size for bread items is fixed at 200 grams, as defined by the InitialBreadPortion constant, and is not passed as a parameter to the
        // constructor since it is the same for all bread items.
          
        public Bread(string name, decimal price) : base(name, InitialBreadPortion, price)
        {

            // The constructor does not contain any additional logic beyond calling the base constructor to initialize the properties of the bread item.
            // The validation for the name and price properties is handled in the base BakedFood class, so there is no need for additional validation logic 
            // in the Bread class constructor
        }
    }
}