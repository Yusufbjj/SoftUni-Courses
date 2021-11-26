using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void ConstructorInitializeCorrectly()
        {
            string name = "name";
            int capacity = 1;
            Aquarium aquarium = new Aquarium(name, capacity);

            Assert.AreEqual(aquarium.Name, name);
            Assert.AreEqual(aquarium.Capacity, capacity);

        }

        [Test]
        public void SetNameThrowExc()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 1));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(String.Empty, 1));
        }

        [Test]
        public void TestCapacitySetterForThrowingArgumentExceptionIfNegative()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("name", -1));
        }

        [Test]
        public void CountPropertyTest()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            aquarium.Add(new Fish("a"));
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void AddShouldThrowExceptionWhenAquariumCapacityIsFull()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            aquarium.Add(new Fish("a"));

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("b")));
        }

        [Test]
        public void Remove_ThrowException()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(null));
        }

        [Test]
        public void Remove_FishWhenSuccessful()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            aquarium.Add(new Fish("fish"));
            aquarium.RemoveFish("fish");
            int expectedCount = 0;


            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void SellFishThrowException()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));
        }

        [Test]
        public void SellFish()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            aquarium.Add(new Fish("fish"));

            Fish fish = aquarium.SellFish("fish");

            Assert.AreEqual(fish.Name, "fish");
        }

        [Test]
        public void Report()
        {
            Aquarium aquarium = new Aquarium("a", 1);
            aquarium.Add(new Fish("fish"));

            string expectedMessage = $"Fish available at a: fish";
            Assert.AreEqual(expectedMessage,aquarium.Report());

        }
    }
}
