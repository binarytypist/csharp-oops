using System;

class Startup
{
    private static void Main(string[] args)
    {
        // Base type reference pointing to derived class object
        Animal cat = new Cat("Pesho", "Whiskas");
        Animal dog = new Dog("Gosho", "Meat");

        // Runtime polymorphism:
        // correct overridden method is called depending on object type
        Console.WriteLine(cat.ExplainMyself());
        Console.WriteLine(dog.ExplainMyself());
    }
}