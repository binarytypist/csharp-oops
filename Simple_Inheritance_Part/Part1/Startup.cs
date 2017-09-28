// =======================
// STARTUP (ENTRY POINT)
// Demonstrates OOP inheritance in action
// =======================
class Startup
{
    private static void Main(string[] args)
    {
        // Dog object created
        // Dog inherits from Animal, so it can use Eat()
        Dog dog = new Dog();

        // Method from base class (Animal)
        dog.Eat();

        // Method from derived class (Dog)
        dog.Bark();

        // Cat object created
        // Cat also inherits from Animal
        Cat cat = new Cat();

        // Inherited method from Animal
        cat.Eat();

        // Cat-specific method
        cat.Meow();
    }
}