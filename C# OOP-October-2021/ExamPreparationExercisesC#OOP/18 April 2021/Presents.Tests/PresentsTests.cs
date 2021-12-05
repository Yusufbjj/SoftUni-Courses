using System;
using System.Collections.Generic;

namespace Presents.Tests
{
    using NUnit.Framework;
    

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void Ctor_Bag()
        {
            Bag bag = new Bag();
            Assert.AreEqual(bag.GetPresents().Count,0);
        }

        [Test]
        public void Ctor_Present()
        {
            string name = "pepi";
            double magic = 3;
            Present present = new Present(name, magic);
            Assert.AreEqual(present.Name, name);
            Assert.AreEqual(present.Magic, magic);
        }

        [Test]
        public void Create_ThrowArgumentNullException()
        {
            Present present = new Present("name", 2);
            Bag bag = new Bag();

            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void Create_ThrowInvalidOperationException()
        {
            Present present = new Present("name", 2);
            Bag bag = new Bag();
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void Create_Succefull()
        {
            Present present = new Present("name", 2);
            Bag bag = new Bag();
            Assert.That(bag.Create(present), Is.EqualTo($"Successfully added present {present.Name}."));
        }

        [Test]
        public void Remove_Succesull()
        {
            Present present = new Present("name", 2);
            Bag bag = new Bag();
            bag.Create(present);
            
            Assert.That(bag.Remove(present), Is.EqualTo(true));
        }

        [Test]
        public void GetPresentWithLeastMagic_Succesfull()
        {
            Present present = new Present("name", 2);
            Present present2 = new Present("name2", 5);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);

            Assert.That(bag.GetPresentWithLeastMagic(), Is.EqualTo(present));

        }

        [Test]
        public void GetPresent_Success()
        {
            Present present = new Present("name", 2);
            Present present2 = new Present("name2", 5);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);
            Assert.That(bag.GetPresent(present.Name), Is.EqualTo(present));
        }

        [Test]
        public void GetPresents()
        {
            Present present = new Present("name", 2);
            Present present2 = new Present("name", 5);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);
            List<Present> expectedPresents = new List<Present>() { present, present2 };
            Assert.That(bag.GetPresents(), Is.EqualTo(expectedPresents.AsReadOnly()));
        }

        [Test]
        public void Remove_Succesfull()
        {
            Present present = new Present("name", 2);
            Present present2 = new Present("name", 5);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Remove(present);

            Assert.AreEqual(bag.GetPresents().Count,0);

        }
    }
}
