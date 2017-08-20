// Base class representing a general Animal
// Demonstrates ENCAPSULATION + INHERITANCE + POLYMORPHISM
public class Animal
{
    private string name;              // private field (encapsulation)
    private string favouriteFood;     // private field (encapsulation)

    // Constructor used to initialize Animal object
    public Animal(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }

    // Property for Name (controls access to private field)
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    // Property for FavouriteFood (encapsulation)
    public string FavouriteFood
    {
        get { return this.favouriteFood; }
        set { this.favouriteFood = value; }
    }

    // Virtual method → allows child classes to override behavior
    public virtual string ExplainMyself()
    {
        return $"I am {this.Name} and my favourite food is {this.FavouriteFood}";
    }
}