namespace BankSafe
{
    /// <summary>
    /// Represents an item stored in the bank vault
    /// </summary>
    public class Item
    {
        private string owner;
        private string itemId;

        public Item(string owner, string itemId)
        {
            this.Owner = owner;
            this.ItemId = itemId;
        }

        /// <summary>
        /// Owner of the item (person who owns it)
        /// </summary>
        public string Owner
        {
            get => this.owner;
            private set => this.owner = value;
        }

        /// <summary>
        /// Unique identifier of the item
        /// </summary>
        public string ItemId
        {
            get => this.itemId;
            private set => this.itemId = value;
        }
    }
}