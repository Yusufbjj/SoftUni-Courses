using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void Ctor_ThrowArgumentNullExceptionForInvalidGymName()
        {

            Assert.Throws<ArgumentNullException>(() => new Gym(null, 1));

        }

        [Test]
        public void Ctor_ThrowArgumentNullExceptionForInvalidGymCapacity()
        {

            Assert.Throws<ArgumentException>(() => new Gym("dmac", -1));

        }

        [Test]
        public void Ctor_CreatedGym()
        {

            Gym gym = new Gym("dmac", 10);

            Assert.AreEqual("dmac", gym.Name);
            Assert.AreEqual(10, gym.Capacity);

        }

        [Test]
        public void Count()
        {

            Gym gym = new Gym("dmac", 10);

            Athlete athlete = new Athlete("Yusuf");
            Athlete athlete2 = new Athlete("Arnold");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.AreEqual(gym.Count, 2);
        }

        [Test]
        public void AddAthlete_ThrowExceptionWhenGymIsFull()
        {

            Gym gym = new Gym("dmac", 1);

            Athlete athlete = new Athlete("Yusuf");
            Athlete athlete2 = new Athlete("Arnold");

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete2));
        }

        [Test]
        public void AddAthlete_AddedSuccesfully()
        {

            Gym gym = new Gym("dmac", 1);

            Athlete athlete = new Athlete("Yusuf");

            gym.AddAthlete(athlete);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void RemoveAthletee_ThrowExceptionWhenAthleteDoesNotExist()
        {

            Gym gym = new Gym("dmac", 1);

            Athlete athlete = new Athlete("Yusuf");

            Athlete athlete2 = new Athlete("Arnold");

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Arnold"));
        }

        [Test]
        public void RemoveAthletee_RemovedSuccessfully()
        {

            Gym gym = new Gym("dmac", 1);

            Athlete athlete = new Athlete("Yusuf");


            gym.AddAthlete(athlete);

            gym.RemoveAthlete(athlete.FullName);

            Assert.AreEqual(gym.Count, 0);
        }

        [Test]
        public void InjureAthlete_ThrowsExceptionWhenAthleteDoesNotExist()
        {

            Gym gym = new Gym("dmac", 1);

            Athlete athlete = new Athlete("Yusuf");

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete(athlete.FullName));
        }

        [Test]
        public void InjureAthlete_InjuredSuccessfully()
        {

            Gym gym = new Gym("dmac", 1);

            Athlete athlete = new Athlete("Yusuf");

            gym.AddAthlete(athlete);

            Assert.That(athlete, Is.EqualTo(gym.InjureAthlete(athlete.FullName)));
        }

        [Test]
        public void Report()
        {

            Gym gym = new Gym("dmac", 2);

            Athlete athlete = new Athlete("Yusuf");
            Athlete athlete2 = new Athlete("Arnold");

            List<string> athleteNames = new List<string>();

            athleteNames.Add(athlete.FullName);

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            gym.InjureAthlete(athlete2.FullName);

            var reportMessage = $"Active athletes at {gym.Name}: {athlete.FullName}";

            Assert.AreEqual(reportMessage, gym.Report());
        }


    }
}
