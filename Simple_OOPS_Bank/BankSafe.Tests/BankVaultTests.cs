using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private Item item;
        private BankVault vault;

        [SetUp]
        public void Setup()
        {
            // Arrange common objects for every test
            item = new Item("Kireto", "13");
            vault = new BankVault();

            // Put item into A1 cell
            vault.AddItem("A1", item);
        }

        [Test]
        public void VerifyConstructor()
        {
            // Checks objects are created properly
            Assert.IsNotNull(item);
            Assert.IsNotNull(vault);
        }

        [Test]
        public void VerifyItemIsStoredInCell()
        {
            // Better assertion than TryGetValue
            Assert.That(vault.VaultCells["A1"], Is.EqualTo(item));
        }

        [Test]
        public void VerifyItemProperties()
        {
            // Checks Item data correctness
            Assert.AreEqual("Kireto", item.Owner);
            Assert.AreEqual("13", item.ItemId);
        }

        [Test]
        public void VerifyReadOnlyDictionary()
        {
            // Ensures encapsulation (read-only exposure)
            Assert.IsInstanceOf<IReadOnlyDictionary<string, Item>>(vault.VaultCells);
        }

        [Test]
        public void VerifyAddItemMethod()
        {
            Item temp = new Item("Kobrata", "10");

            string expected = $"Item:{temp.ItemId} saved successfully!";

            // Act + Assert
            string result = vault.AddItem("A2", temp);

            Assert.AreEqual(expected, result);
            Assert.AreEqual(temp, vault.VaultCells["A2"]);
        }

        [Test]
        public void AddItem_ShouldThrow_WhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
                vault.AddItem("666", item));
        }

        [Test]
        public void AddItem_ShouldThrow_WhenCellIsTaken()
        {
            Assert.Throws<ArgumentException>(() =>
                vault.AddItem("A1", new Item("Jojo", "2")));
        }

        [Test]
        public void AddItem_ShouldThrow_WhenItemAlreadyExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
                vault.AddItem("A3", item));
        }

        [Test]
        public void VerifyRemoveItemMethod()
        {
            string expected = $"Remove item:{item.ItemId} successfully!";

            string result = vault.RemoveItem("A1", item);

            Assert.AreEqual(expected, result);
            Assert.IsNull(vault.VaultCells["A1"]);
        }

        [Test]
        public void RemoveItem_ShouldThrow_WhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
                vault.RemoveItem("666", item));
        }

        [Test]
        public void RemoveItem_ShouldThrow_WhenWrongItemInCell()
        {
            Item temp = new Item("Pepe", "1");
            vault.AddItem("A4", temp);

            Assert.Throws<ArgumentException>(() =>
                vault.RemoveItem("A4", item));
        }
    }
}