namespace Bakery.Models.Tables
{

    // The OutsideTable class represents a specific type of table in the bakery, which is located outside the establishment.
    // It inherits from the Table class, which provides the common properties and validation logic for all tables.
    // The OutsideTable class has a constant field InitialPricePerPerson, which defines the price per person for outside tables (3.50).

    public class OutsideTable : Table
    {

        // The constructor of the OutsideTable class takes two parameters: tableNumber and capacity, which are passed to the base constructor
        // of the Table class along with the InitialPricePerPerson to initialize the properties of the outside table.
        // The tableNumber parameter represents the unique number assigned to the outside table,
        // and the capacity parameter represents the maximum number of people that can be seated at the outside table.
        private const decimal InitialPricePerPerson = 3.50m;

        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }
    }
}