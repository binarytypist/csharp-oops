// Cat inherits from Animal (IS-A relationship)
// Demonstrates METHOD OVERRIDING (runtime polymorphism)
public class Cat : Animal
{
    public Cat(string name, string favouriteFood)
        : base(name, favouriteFood)
    {
    }

    // Override base behavior
    public override string ExplainMyself()
    {
        return base.ExplainMyself() + "\nMEEOW";
    }
}