namespace Bakery.Models.Drinks
{
    // The Tea class represents a specific type of drink in the bakery menu.
    // It inherits from the Drink class, which provides the common properties and validation logic for all drinks.
    // The Tea class has a constant field TeaPrice, which defines the price for tea items (2.50).
    // The constructor of the Tea class takes three parameters: name, portion, and brand, which are passed to the base constructor of the Drink class along with the TeaPrice
    // to initialize the properties of the tea item.
    // The Tea class does not contain any additional logic beyond calling the base constructor to initialize the properties of the tea item.
    // The name parameter represents the name of the tea item, the portion parameter represents the portion size of the tea item in ml, and the brand parameter represents the brand of the tea item.
    // The validation for the name, portion, and brand properties is handled in the base Drink class, so there is no need for additional validation logic in the Tea class constructor
    // The Tea class is a concrete implementation of the Drink class, representing a specific type of drink in the bakery menu. It provides a constructor to initialize the properties  

    public class Tea : Drink
    {
        
        // The TeaPrice constant defines the price for tea items in the bakery menu. It is set to 2.50, which is a common price for tea.
        private const decimal TeaPrice = 2.50m;

        // Constructor to initialize the properties of the tea item.
        // The constructor takes three parameters: name, portion, and brand, which are used to set the corresponding properties of the tea item.
        // The constructor calls the base constructor of the Drink class, passing the name, portion, TeaPrice, and brand to initialize the properties of the tea item.
        // The constructor is public, allowing it to be called from outside the class to create instances of tea items for the bakery menu.
        // The name parameter represents the name of the tea item, the portion parameter represents the portion size of the tea item in ml,
        // and the brand parameter represents the brand of the tea item.
        public Tea(string name, int portion, string brand) : base(name, portion, TeaPrice, brand)
        {
            // The constructor does not contain any additional logic beyond calling the base constructor to initialize the properties of the tea item.
            // The validation for the name, portion, and brand properties is handled in the base Drink class, so there is no need for additional
            // validation logic in the Tea class constructor
        }
    }
}