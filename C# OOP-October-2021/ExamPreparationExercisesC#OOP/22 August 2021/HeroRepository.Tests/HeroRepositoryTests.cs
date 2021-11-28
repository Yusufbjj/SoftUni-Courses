using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void Create_SuccesfullyAddedHero()
    {
        Hero test = new Hero("name", 1);

        HeroRepository heroRepository = new HeroRepository();

        string message = heroRepository.Create(test);

        Assert.AreEqual(message, $"Successfully added hero {test.Name} with level {test.Level}");
    }

    [Test]
    public void Create_ThrowExceptionWhenHeroIsNull()
    {
        Hero test = null;

        HeroRepository heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>((() => heroRepository.Create(test)));
    }

    [Test]
    public void Create_ThrowExceptionWhenHeroAlreadyExists()
    {
        Hero test = new Hero("name", 1);

        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(test);


        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(test));
    }

    [Test]
    public void Remove_ThrowsArgumentNullException()
    {
        Hero test = new Hero(null, 1);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(test);

        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(test.Name));
    }

    [Test]
    public void Remove_SuccessfullyRemoved()
    {
        Hero test = new Hero("name", 1);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(test);
        bool removed = heroRepository.Remove(test.Name);

        Assert.AreEqual(removed, true);
    }

    [Test]
    public void GetHeroWithHighestLevel_ReturnsHero()
    {
        Hero test = new Hero("name", 1);
        Hero test2 = new Hero("name2", 2);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(test);
        heroRepository.Create(test2);

        Assert.That(() => heroRepository.GetHeroWithHighestLevel() == test2);

    }

    [Test]
    public void GetHero_ReturnsHero()
    {
        Hero test = new Hero("name", 1);
        Hero test2 = new Hero("name2", 2);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(test);
        heroRepository.Create(test2);

        Assert.That(() => heroRepository.GetHero(test.Name) == test);

    }

    [Test]
    public void Heroes_ReturnsAllHeroesAsReadOnly()
    {
        Hero test = new Hero("name", 1);
        Hero test2 = new Hero("name2", 2);
        HeroRepository heroRepository = new HeroRepository();

        IReadOnlyCollection<Hero> heroes = new List<Hero>() { test, test2 };

        heroRepository.Create(test);
        heroRepository.Create(test2);

        Assert.AreEqual(heroRepository.Heroes, heroes);

    }
}