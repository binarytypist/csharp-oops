namespace Bakery.Models.BakedFoods.Contracts
{
    // Any class that implements me MUST have a name, portion size, and price.
    // used to represent a baked food item in the bakery menu.  
    // Every baked food must have a Name, Portion, and Price.
   
    public interface IBakedFood
    {
        string Name { get; }

        int Portion { get; }

        decimal Price { get; }
    }
}
