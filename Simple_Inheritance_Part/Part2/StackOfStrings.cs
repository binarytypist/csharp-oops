// =======================
// STACK OF STRINGS CLASS
// Demonstrates encapsulation + collection wrapping
// =======================

using System.Collections.Generic;
using System.Linq;

public class StackOfStrings : List<string>
{
    // Internal storage (separate from base List<string>)
    private List<string> data;

    // Constructor initializes internal list
    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    // Push item onto stack (add to end)
    public void Push(string item)
    {
        this.data.Add(item);
    }

    // Remove and return last item (LIFO behavior)
    public string Pop()
    {
        var item = this.data.Last();
        this.data.Remove(item);
        return item;
    }

    // Return last item without removing it
    public string Peek()
    {
        var item = this.data.Last();
        return item;
    }

    // Check if stack is empty
    public bool IsEmpty()
    {
        return this.data.Count <= 0;
    }
}