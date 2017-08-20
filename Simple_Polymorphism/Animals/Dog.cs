// Dog inherits from Animal
// Demonstrates polymorphic behavior
public class Dog : Animal
{
    public Dog(string name, string favouriteFood)
        : base(name, favouriteFood)
    {
    }

    // Custom behavior for Dog
    public override string ExplainMyself()
    {
        return base.ExplainMyself() + "\nDJAAF";
    }
}