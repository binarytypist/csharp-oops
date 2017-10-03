using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BankSafe;

public class BankVault
{
    // Dictionary that represents the vault storage
    // Key = cell (A1, A2, etc.)
    // Value = Item stored in that cell (or null if empty)
    private readonly Dictionary<string, Item> vaultCells;

    public BankVault()
    {
        // Initialize all vault cells (fixed structure of the bank vault)
        this.vaultCells = new Dictionary<string, Item>
        {
            {"A1", null}, {"A2", null}, {"A3", null}, {"A4", null},
            {"B1", null}, {"B2", null}, {"B3", null}, {"B4", null},
            {"C1", null}, {"C2", null}, {"C3", null}, {"C4", null},
        };
    }

    // Read-only access to vault (prevents external modification)
    public IReadOnlyDictionary<string, Item> VaultCells
        => this.vaultCells.ToImmutableDictionary();

    /// <summary>
    /// Adds an item into a specific vault cell
    /// </summary>
    public string AddItem(string cell, Item item)
    {
        // 1. Check if the cell exists
        if (!this.vaultCells.ContainsKey(cell))
        {
            throw new ArgumentException("Cell doesn't exist!");
        }

        // 2. Check if the cell is already occupied
        if (this.vaultCells[cell] != null)
        {
            throw new ArgumentException("Cell is already taken!");
        }

        // 3. Check if the same item is already stored in another cell
        bool itemAlreadyStored = this.vaultCells.Values
            .Any(x => x?.ItemId == item.ItemId);

        if (itemAlreadyStored)
        {
            throw new InvalidOperationException("Item is already in cell!");
        }

        // 4. Store item in the cell
        this.vaultCells[cell] = item;

        return $"Item:{item.ItemId} saved successfully!";
    }

    /// <summary>
    /// Removes an item from a specific cell
    /// </summary>
    public string RemoveItem(string cell, Item item)
    {
        // 1. Check if cell exists
        if (!this.vaultCells.ContainsKey(cell))
        {
            throw new ArgumentException("Cell doesn't exist!");
        }

        // 2. Check if the correct item is in that cell
        if (this.vaultCells[cell] != item)
        {
            throw new ArgumentException("Item in that cell doesn't exist!");
        }

        // 3. Remove item (set cell to empty)
        this.vaultCells[cell] = null;

        return $"Remove item:{item.ItemId} successfully!";
    }
}