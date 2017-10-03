using System;

namespace BankSafe
{
    /// <summary>
    /// Entry point of the program.
    /// This is where execution starts.
    /// </summary>
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // This is the starting point of the application.
            // Normally we would create objects and test the system here.

            // Example (dummy usage):

            // Create items
            Item item1 = new Item("John", "ITEM123");
            Item item2 = new Item("Anna", "ITEM456");

            // Create bank vault
            BankVault vault = new BankVault();

            // Add items to vault cells
            Console.WriteLine(vault.AddItem("A1", item1));
            Console.WriteLine(vault.AddItem("B2", item2));

            // Remove item from vault
            Console.WriteLine(vault.RemoveItem("A1", item1));

            // You can also inspect vault state if needed
            // Console.WriteLine(string.Join(", ", vault.VaultCells));
        }
    }
}