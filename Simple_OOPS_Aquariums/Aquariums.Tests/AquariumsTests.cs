using NUnit.Framework;
using System;

namespace Aquariums.Tests
{
    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void Setup()
        {
            fish = new Fish("Nemo");
            aquarium = new Aquarium("Ocean", 3);
            aquarium.Add(fish);
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(fish);
            Assert.IsNotNull(aquarium);
        }

        [Test]
        public void VerifyFishProperties()
        {
            Assert.AreEqual("Nemo", fish.Name);
            Assert.IsTrue(fish.Available);
        }

        [Test]
        public void VerifyNameProperty()
        {
            Assert.AreEqual("Ocean", aquarium.Name);
        }

        [Test]
        public void NamePropertyThrowsExceptionIfNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Aquarium(null, 1));

            Assert.Throws<ArgumentNullException>(
                () => new Aquarium(string.Empty, 1));
        }

        [Test]
        public void VerifyCapacityProperty()
        {
            Assert.AreEqual(3, aquarium.Capacity);
        }

        [Test]
        public void CapacityPropertyThrowsExceptionIfValueIsNegative()
        {
            Assert.Throws<ArgumentException>(
                () => new Aquarium("Ocean", -1));
        }

        [Test]
        public void VerifyAquariumCollection()
        {
            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void VerifyAddMethod()
        {
            aquarium.Add(new Fish("Dory"));

            Assert.AreEqual(2, aquarium.Count);
        }

        [Test]
        public void AddMethodThrowsExceptionWhenAquariumIsFull()
        {
            aquarium.Add(new Fish("Dory"));
            aquarium.Add(new Fish("Goldie"));

            Assert.Throws<InvalidOperationException>(
                () => aquarium.Add(new Fish("Sharky")));
        }

        [Test]
        public void VerifyRemoveFishMethod()
        {
            aquarium.RemoveFish("Nemo");

            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void RemoveFishMethodThrowsExceptionWhenFishDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => aquarium.RemoveFish("Unknown"));
        }

        [Test]
        public void VerifySellFishMethod()
        {
            Fish soldFish = aquarium.SellFish("Nemo");

            Assert.AreEqual(fish, soldFish);
            Assert.IsFalse(soldFish.Available);
        }

        [Test]
        public void SellFishMethodThrowsExceptionWhenFishDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => aquarium.SellFish("Unknown"));
        }

        [Test]
        public void VerifyReportMethod()
        {
            string expected =
                $"Fish available at {aquarium.Name}: {fish.Name}";

            Assert.AreEqual(expected, aquarium.Report());
        }
    }
}