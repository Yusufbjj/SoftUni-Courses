using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("yusuf", "1");
        }

        [Test]
        public void AddItem_ThrowArgumentException()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("yusuf", "1");

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("C5", item));
        }

        [Test]
        public void AddItem_ThrowArgumentExceptionCellTaken()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("yusuf", "1");
            Item item2 = new Item("yusuf", "2");

            bankVault.AddItem("C4", item);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("C4", item2));

        }

        [Test]
        public void AddItem_ThrowInvalidOperationExceptionItemAlreadyInCell()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("yusuf", "1");
            Item item2 = new Item("yusuf2", "1");

            bankVault.AddItem("C4", item);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("C3", item2));

        }

        [Test]
        public void AddItem_Added()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("yusuf", "1");
            Item item2 = new Item("yusuf2", "2");

            var result = bankVault.AddItem("C4", item);
            Assert.That(result, Is.EqualTo($"Item:{item.ItemId} saved successfully!"));

        }

        [Test]
        public void RemoveItem_CellDoesNotExist()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("yusuf", "1");
            Item item2 = new Item("yusuf2", "2");

            var result = bankVault.AddItem("C4", item);
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("C5", item));

        }

        [Test]
        public void RemoveItem_ItemDoesNotExist()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("yusuf", "1");
            Item item2 = new Item("yusuf2", "2");

            var result = bankVault.AddItem("C4", item);
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("C4", item2));

        }

        [Test]
        public void RemoveItem_Removed()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("yusuf", "1");
            Item item2 = new Item("yusuf2", "2");

            var addItem = bankVault.AddItem("C4", item);
            var removeItem = bankVault.RemoveItem("C4", item);
            Assert.That(removeItem, Is.EqualTo($"Remove item:{item.ItemId} successfully!"));

        }

    }
}