using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaylistDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistDLL.Tests
{
    [TestClass()]
    public class ConcretePlaylistTests
    {
        [TestMethod()]
        public void ConcretePlaylistTest_WithoutName()
        {
            ConcretePlaylist playlist = new ConcretePlaylist();

            Assert.AreEqual("Noname", playlist.PlaylistName);
            Assert.AreEqual(0, playlist.Songs.Length);
        }

        [TestMethod()]
        public void ConcretePlaylistTest_WithName()
        {
            ConcretePlaylist playlist = new ConcretePlaylist("BestPlaylistEver");

            Assert.AreEqual("BestPlaylistEver", playlist.PlaylistName);
            Assert.AreEqual(0, playlist.Songs.Length);
        }

        [TestMethod()]
        public void PlaylistSongPathTest()
        {
            ConcretePlaylist playlist = new ConcretePlaylist();
            string songName = "test";
            string songPath = "TestResources/test_sample.mp3";
            string songName1 = "test1";
            string songPath1 = "TestResources/test_sample1.mp3";
            playlist.AddSong(songName1, songPath1);
            playlist.AddSong(songName, songPath);

            Assert.AreEqual(songPath, playlist.PlaylistSongPath(songName));
        }

        [TestMethod()]
        public void AddSongTest()
        {
            ConcretePlaylist playlist = new ConcretePlaylist();
            string songName = "test";
            string songPath = "TestResources/test_sample.mp3";
            playlist.AddSong(songName, songPath);
            string songName1 = "test1";
            string songPath1 = "TestResources/test_sample1.mp3";
            playlist.AddSong(songName1, songPath1);

            Assert.AreEqual(2, playlist.Songs.Length);
            Assert.AreEqual($"{songName}///{songPath}", playlist.SongsWithPaths[0]);
            Assert.AreEqual($"{songName1}///{songPath1}", playlist.SongsWithPaths[1]);
        }

        [TestMethod()]
        public void AddSongTest_UpdateSongPath()
        {
            ConcretePlaylist playlist = new ConcretePlaylist();
            string songName = "test";
            string songPath = "TestResources/test_sample.mp3";
            playlist.AddSong(songName, songPath);
            string songPath1 = "TestResources/test_sample1.mp3";
            playlist.AddSong(songName, songPath1);

            Assert.AreEqual(1, playlist.Songs.Length);
            Assert.AreEqual($"{songName}///{songPath1}", playlist.SongsWithPaths[0]);
        }

        [TestMethod()]
        public void RemoveSongTest_NoSong()
        {
            string songName = "test";
            try
            {
                ConcretePlaylist playlist = new ConcretePlaylist();
                string songName1 = "test1";
                string songPath1 = "TestResources/test_sample1.mp3";
                playlist.AddSong(songName1, songPath1);
                playlist.RemoveSong(songName);
            }
            catch (Exception ex)
            {
                string msg = "The song that you want to remove - " + songName + " - does not exist in the song dictionary.";
                Assert.AreEqual(msg, ex.Message);
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveSongTest_WrongSong()
        {
            string songName = "test";
            try
            {
                ConcretePlaylist playlist = new ConcretePlaylist();
                playlist.RemoveSong(songName);
            }
            catch (Exception ex)
            {
                string msg = "The song that you want to remove - " + songName + " - does not exist in the song dictionary.";
                Assert.AreEqual(msg, ex.Message);
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveSongTest_OneSong()
        {
            ConcretePlaylist playlist = new ConcretePlaylist();
            string songName = "test";
            string songPath = "TestResources/test_sample.mp3";
            playlist.AddSong(songName, songPath);
            playlist.RemoveSong(songName);
            Assert.AreEqual(0, playlist.Songs.Length);
        }

            [TestMethod()]
        public void RemoveSongTest_MultipleSongs()
        {
            ConcretePlaylist playlist = new ConcretePlaylist();
            string songName = "test";
            string songPath = "TestResources/test_sample.mp3";
            playlist.AddSong(songName, songPath);
            string songName1 = "test1";
            string songPath1 = "TestResources/test_sample1.mp3";
            playlist.AddSong(songName1, songPath1);

            playlist.RemoveSong(songName);
            Assert.AreEqual(1, playlist.Songs.Length);
            Assert.AreEqual(songName1, playlist.Songs[0]);

            playlist.RemoveSong(songName1);
            Assert.AreEqual(0, playlist.Songs.Length);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            ConcretePlaylist playlist = new ConcretePlaylist();
            string songName = "test";
            string songPath = "TestResources/test_sample.mp3";
            playlist.AddSong(songName, songPath);
            string songName1 = "test1";
            string songPath1 = "TestResources/test_sample1.mp3";
            playlist.AddSong(songName1, songPath1);

            playlist.Update(songName);
            Assert.AreEqual(1, playlist.Songs.Length);
            Assert.AreEqual(songName1, playlist.Songs[0]);

            playlist.Update(songName1);
            Assert.AreEqual(0, playlist.Songs.Length);
        }
    }
}