using System;
using NUnit.Framework;



namespace Tests
{
    public class ExtendedDatabaseTests
    {

        private ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            extendedDatabase = new ExtendedDatabase();
        }

        [Test]
        public void Ctor_AddInitialPeoplesToTheDb()
        {
            var people = new Person[5];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name:{i}");
            }

            extendedDatabase = new ExtendedDatabase(people);

            Assert.That(extendedDatabase.Count, Is.EqualTo(people.Length));

            foreach (Person person in people)
            {
                Person dbPerson = extendedDatabase.FindById(person.Id);

                Assert.That(person, Is.EqualTo(dbPerson));
            }
        }

        [Test]
        public void Ctor_ThrowsExceptionCapacityIsExceeded()
        {
            var people = new Person[17];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Pesho{i}");
            }

            Assert.Throws<ArgumentException>(() => extendedDatabase = new ExtendedDatabase(people));

        }

        [Test]
        public void Add_ThrowsExceptionWhenCountIsExceeded()
        {
            var n = 16;

            for (int i = 0; i < n; i++)
            {
                extendedDatabase.Add(new Person(i, $"Name{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(16, "blabla")));

        }

        [Test]
        public void Add_ThrowsExceptionWhenUsernameIsExisting()
        {
            var name = "Pesho";
            extendedDatabase.Add(new Person(1, name));

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(16, name)));

        }

        [Test]
        public void Add_ThrowsExceptionWhenIdIsExisting()
        {
            var id = 1;
            extendedDatabase.Add(new Person(id, "dsadas"));

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(id, "name")));

        }

        [Test]
        public void Add_IncrementCountWhenAllIsValid()
        {
            var expectedCount = 2;

            extendedDatabase.Add(new Person(1, "Pepi"));
            extendedDatabase.Add(new Person(2, "Ceci"));

            Assert.That(extendedDatabase.Count, Is.EqualTo(expectedCount));

        }

        [Test]
        public void Remove_ThrowsExceptionWhenDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Remove());

        }

        [Test]
        public void Remove_RemoveElementFromDb()
        {

            var n = 3;

            for (int i = 0; i < n; i++)
            {
                extendedDatabase.Add(new Person(i, $"Fresh{i}"));
            }
            extendedDatabase.Remove();

            Assert.That(extendedDatabase.Count, Is.EqualTo(n - 1));

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindById(n - 1));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ThrowsExceptionWhenUsernameIsInvalid(string username)
        {
            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(username));

        }

        [Test]
        public void FindByUsername_ThrowsExceptionWhenUsernameIsNotExisting()
        {

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindByUsername("fsdfdsfs"));
        }

        [Test]
        public void FindByUsername_ReturnsTheCorrectResult()
        {
            var person = new Person(1, "Pesho");
            extendedDatabase.Add(person);
            var dbPerson = extendedDatabase.FindByUsername(person.UserName);

            Assert.That(person, Is.EqualTo(dbPerson));
        }

        [Test]
        public void FindById_ThrowsExceptionForInvalidId()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindById(123));
        }


        [Test]
        [TestCase(-1)]
        [TestCase(-21)]
        public void FindById_ThrowsExceptionWhenIdIsNegativeValue(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindById(id));
        }

        [Test]
        public void FindById_ReturnTheCorrectResult()
        {
            var person = new Person(1, "Pesho");
            extendedDatabase.Add(person);

            var dbPerson = extendedDatabase.FindById(person.Id);

            Assert.That(person, Is.EqualTo(dbPerson));
        }





    }
}