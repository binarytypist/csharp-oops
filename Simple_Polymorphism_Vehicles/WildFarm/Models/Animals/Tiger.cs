// Tiger is a Feline predator
using Problem3_WildFarm.Models.Animals;
using System;

public class Tiger : Feline
{
    public Tiger(string animalName, string animalType, double animalWeight, string livingRegion)
        : base(animalName, animalType, animalWeight, livingRegion)
    {
    }

    // Tiger sound
    public override void MakeSound()
    {
        Console.WriteLine("ROAAR!!!");
    }
}