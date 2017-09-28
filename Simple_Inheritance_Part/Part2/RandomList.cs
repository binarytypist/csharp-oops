using System;
using System.Collections;

// =======================
// RANDOMLIST CLASS
// Demonstrates inheritance from ArrayList
// =======================

public class RandomList : ArrayList
{
    // Returns a random string from the list
    public string RandomString()
    {
        // Random number generator
        Random rnd = new Random();

        // Pick a random index from list
        // NOTE: Count - 1 means last index is excluded (small logic issue, but unchanged)
        int index = rnd.Next(0, this.Count - 1);

        // Return element at random index (cast to string)
        return (string)this[index];
    }
}