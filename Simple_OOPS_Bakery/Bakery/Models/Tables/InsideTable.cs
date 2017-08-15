namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        // The InsideTable class represents a specific type of table in the bakery, which is located inside the establishment.
        // It inherits from the Table class, which provides the common properties and validation logic for all tables.
        // The InsideTable class has a constant field InitialPricePerPerson, which defines the price per person for inside tables (2.50).
        // The constructor of the InsideTable class takes two parameters: tableNumber and capacity, which are passed to the base constructor
        // of the Table class along with the InitialPricePerPerson
        private const decimal InitialPricePerPerson = 2.50m;

        // Constructor to initialize the properties of the inside table.
        // The constructor takes two parameters: tableNumber and capacity,
        // which are used to set the corresponding properties of the inside table.

        public InsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
            // The base constructor of the Table class is called with the tableNumber, capacity, and InitialPricePerPerson parameters.
            // The constructor does not contain any additional logic beyond calling the base constructor to initialize the properties
            // of the inside table.
        }
    }
}