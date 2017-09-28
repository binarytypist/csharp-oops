using System;

class Startup
{
    private static void Main(string[] args)
    {
        // -----------------------
        // TEST RANDOM LIST
        // -----------------------
        RandomList list = new RandomList();

        list.Add("Apple");
        list.Add("Banana");
        list.Add("Cherry");
        list.Add("Orange");

        Console.WriteLine("Random item: " + list.RandomString());

        // -----------------------
        // TEST STACK
        // -----------------------
        StackOfStrings stack = new StackOfStrings();

        stack.Push("A");
        stack.Push("B");
        stack.Push("C");

        Console.WriteLine("Peek: " + stack.Peek());
        Console.WriteLine("Pop: " + stack.Pop());
        Console.WriteLine("Peek after pop: " + stack.Peek());
        Console.WriteLine("Is empty? " + stack.IsEmpty());
    }
}