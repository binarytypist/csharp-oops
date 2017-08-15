namespace Bakery.Models.Drinks.Contracts
{
    /// <summary>
    /// Contract that defines what every Drink must have.
    /// Any class that implements IDrink must provide these properties.
    /// </summary>
    public interface IDrink
    {
       
        string Name { get; }
        int Portion { get; }
        decimal Price { get; }
        string Brand { get; }
    }
}