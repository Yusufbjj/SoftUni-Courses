// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 

using System.Linq;



namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        [Test]
        public void AddPerformer_ThrowArgumentNullException()
        {
            Stage stage = new Stage();

            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
        }

        [Test]
        public void AddPerformer_ArgumentExceptionWhenPerformerAgeIsLessThan18()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("name", "surname", 17);

            Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
        }

        [Test]
        public void AddPerformer_IsAdded()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("name", "surname", 20);
            int expectedPerformers = 1;
            stage.AddPerformer(performer);
            Assert.AreEqual(expectedPerformers, stage.Performers.Count);
        }

        [Test]
        public void AddSong_ThrowsArgumentNullException()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("name", "surname", 20);
            Assert.Throws<ArgumentNullException>(() => stage.AddSong((null)));
        }

        [Test]
        public void AddSong_ThrowsArgumentException()
        {
            Stage stage = new Stage();
            Song song = new Song("name", new TimeSpan(0, 0, 40));

            Assert.Throws<ArgumentException>(() => stage.AddSong(song));
        }

        [Test]
        public void AddSongToPerformer_SongNameCantBeNull()
        {
            Stage stage = new Stage();
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "Pesho"));
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("song", null));
        }

        [Test]
        public void AddSongToPerformerSongAdded()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("pepi", "surname", 20);
            Song song = new Song("kamanitePadat", new TimeSpan(0, 2, 40));

            stage.AddPerformer(performer);

            stage.AddSong(song);

            stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.That(performer.SongList.Count == 1);
            Assert.That(performer.SongList.FirstOrDefault().Equals(song));
        }

        [Test]
        public void Play_ReturnsPerformersCountAndSongsCount()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("pepi", "surname", 20);
            Song song = new Song("kamanitePadat", new TimeSpan(0, 2, 40));

            stage.AddPerformer(performer);

            stage.AddSong(song);

            stage.AddSongToPerformer(song.Name, performer.FullName);

            var expectedResult = $"{stage.Performers.Count} performers played 1 songs";

            var result = stage.Play();

            Assert.AreEqual(expectedResult,result);
        }

        [Test]
        public void GetPerformer_ThrowsArgumentExceptionWhenPerformerDoesNotExist()
        {
            Stage stage = new Stage();

            Performer performer = new Performer("pepi", "surname", 20);
            
            stage.AddPerformer(performer);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("alabala", performer.FullName));

        }
        [Test]
        public void GetPerformer_PerformerNotExist()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("pepi", "surname", 20);
            Song song = new Song("kamanitePadat", new TimeSpan(0, 2, 40));

            stage.AddPerformer(performer);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name, "pepi"));

        }

    }
}