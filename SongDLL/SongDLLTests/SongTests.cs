using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongDLL.Tests
{
    [TestClass()]
    public class SongTests
    {
        [TestMethod()]
        public void PlayTest_PlayTwice()
        {
            try
            {
                Song song = new Song();
                song.SongPath = "test_sample.mp3";
                song.Play();
                song.Play();
            }
            catch (Exception e)
            {
                String msg = "The song thread already exists. This might mean that a song is already playing. This should be handled in the calling application";
                Assert.AreEqual(msg, e.Message);
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void PauseSongTest_NoThread()
        {
            try
            {
                Song song = new Song();
                song.PauseSong();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Can not kill the song thread because it is null!", e.Message);
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void PauseSongTest_PauseTwice()
        {
            try
            {
                Song song = new Song();
                song.SongPath = "TestResources/test_sample.mp3";
                song.Play();
                song.PauseSong();
                song.PauseSong();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Can not kill the song thread because it is null!", e.Message);
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void StopSongTest_NoThread()
        {
            try
            {
                Song song = new Song();
                song.StopSong();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Can not kill the song thread because it is null!", e.Message);
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void StopSongTest_StopTwice()
        {
            try
            {
                Song song = new Song();
                song.SongPath = "TestResources/test_sample.mp3";
                song.Play();
                song.StopSong();
                song.StopSong();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Can not kill the song thread because it is null!", e.Message);
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void WplayerTest()
        {
            try
            {
                Song song = new Song();
                if (song.Wplayer == null)
                {
                    Assert.Fail();
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void StopSongTest_StopThenPause()
        {
            try
            {
                Song song = new Song();
                song.SongPath = "TestResources/test_sample.mp3";
                song.Play();
                song.StopSong();
                song.PauseSong();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Can not kill the song thread because it is null!", e.Message);
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void PauseSongTest_PauseThenStop()
        {
            try
            {
                Song song = new Song();
                song.SongPath = "TestResources/test_sample.mp3";
                song.Play();
                song.PauseSong();
                song.StopSong();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Can not kill the song thread because it is null!", e.Message);
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void PlaySongTest_PlayPauseResume()
        {
            try
            {
                Song song = new Song();
                song.SongPath = "TestResources/test_sample.mp3";
                song.Play();
                song.PauseSong();
                song.Play();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void PlaySong_NoSongPath()
        {
            try
            {
                Song song = new Song();
                song.Play();
            }
            catch (Exception e)
            {
                Assert.AreEqual("No path for song", e.Message);
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void WPlayerURLTest()
        {
            try
            {
                Song song = new Song();
                song.SongPath = "TestResources/test_sample.mp3";
                song.Play();
                song.StopSong();
                //Trebuie luat in calcul faptul ca primesc calea absoluta
                string url = song.Wplayer.URL;
                string[] urlParts = url.Split('\\');
                string relativeURL = $"{urlParts[urlParts.Length - 2]}/{urlParts[urlParts.Length - 1]}";
                Assert.AreEqual("TestResources/test_sample.mp3", relativeURL);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void WPlayerURLTest_Reasign()
        {
            try
            {
                Song song = new Song();
                song.SongPath = "TestResources/test_sample.mp3";
                song.Play();
                song.StopSong();
                song.SongPath = "TestResources/test_sample1.mp3";
                song.Play();
                song.StopSong();

                string url = song.Wplayer.URL;
                string[] urlParts = url.Split('\\');
                string relativeURL = $"{urlParts[urlParts.Length - 2]}/{urlParts[urlParts.Length - 1]}";
                Assert.AreEqual("TestResources/test_sample1.mp3", relativeURL);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}