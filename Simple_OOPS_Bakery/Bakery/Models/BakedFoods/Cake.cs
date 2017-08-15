namespace Bakery.Models.BakedFoods
{
    // The Cake class represents a specific type of baked food item in the bakery menu.
    // It inherits from the BakedFood class, which provides the common properties and validation logic for all baked food items.
    // The Cake class has a constant field InitialCakePortion, which defines the default portion size for cake items (245 grams).
    // The constructor of the Cake class takes two parameters: name and price, which are passed to the base constructor of the BakedFood class along with the InitialCakePortion
    // to initialize the properties of the cake item.
    // The Cake class does not contain any additional logic beyond calling the base constructor to initialize the properties of the cake item.
    // The name parameter represents the name of the cake item, and the price parameter represents the price of the cake item.
    // The portion size for cake items is fixed at 245 grams, as defined by the InitialCakePortion constant, and is not passed as a parameter to the constructor
    // since it is the same for all cake items.
    // The validation for the name and price properties is handled in the base BakedFood class, so there is no need for additional validation logic in the Cake class constructor
    // The Cake class is a concrete implementation of the BakedFood class, representing a specific type of baked food item in the bakery menu. It provides a constructor to initialize the properties
    // of the cake item and relies on the base class for validation and common functionality.
    public class Cake : BakedFood
    {
        // The InitialCakePortion constant defines the default portion size for cake items in the bakery menu.
        // It is set to 245 grams, which is a common portion size for cake.
        // The portion size for cake items is fixed at 245 grams, as defined by the InitialCakePortion constant,
        // and is not passed as a parameter to the constructor since it is the same for all cake items.
        private const int InitialCakePortion = 245;


        // Constructor to initialize the properties of the cake item.
        // The constructor takes two parameters: name and price, which are used to set the corresponding properties of the cake item.
        // The constructor calls the base constructor of the BakedFood class, passing the name, InitialCakePortion, and price to initialize the properties of the cake item.
        // The constructor is public, allowing it to be called from outside the class to create instances of cake items for the bakery menu.
        public Cake(string name, decimal price) : base(name, InitialCakePortion, price)
        {
            // The constructor does not contain any additional logic beyond calling the base constructor to initialize the properties of the cake item.
        }
    }
}