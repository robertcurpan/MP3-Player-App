/********************************************************************************
 *                                                                              *
 *  File:        Song.cs                                                        *
 *  Copyright:   (c) 2022, Curpan Robert, Istrate Sebastian, Toma Catalin       *
 *  E-mail:      robert-gabriel.curpan@student.tuiasi.ro                        *
 *  Website:     https://github.com/Tudisie/MP3-Player                          *
 *  Description: Class used to play mp3 files as songs in a MP3 player app      *
 *               This class implements operations like: Start, Stop, Pause etc  *
 *                                                                              *
 *******************************************************************************/


using System;
using System.Threading;
using WMPLib;

namespace SongDLL
{
    /// <summary>
    /// This class is responsible for playing, stopping and pausing a song. It has all the logic that controls the Windows Media Player object.
    /// </summary>
    public class Song
    {
        private WindowsMediaPlayer _wplayer = new WindowsMediaPlayer();
        private Thread _songThread;
        private bool _isPaused = false;
        private string _songPath;
        private string _songName;

        /// <summary>
        /// Starts a song that is stopped or paused in a new thread.
        /// </summary>
        public void Play()
        {
            // Cu aceasta functie pornim melodia pt prima oara sau dupa oprire
            if (_songPath == null)
                throw new Exception("No path for song");
            if (_songThread != null)
                throw new Exception("The song thread already exists. This might mean that a song is already playing. This should be handled in the calling application");
            else
            {
                if (_isPaused == false) // melodia e oprita
                {
                    _songThread = new Thread(PlaySong);
                    _songThread.Start();
                }
                else // melodia e in pauza
                {
                    _isPaused = false;
            
                    _songThread = new Thread(ResumeSong);
                    _songThread.Start();
                }
            }

        }

        /// <summary>
        /// Plays a new song (the new song is loaded through its path into the WMP object's URL attribute)
        /// </summary>
        private void PlaySong()
        {
            //_wplayer = new WindowsMediaPlayer();
            _wplayer.URL = _songPath;
            _wplayer.controls.play();
        }

        /// <summary>
        /// Pauses a song that is currently playing and kills the thread that it was playing in. The thread will be constructed again when the song will be resumed.
        /// </summary>
        public void PauseSong()
        {
            if (_wplayer == null)
                throw new Exception("The windows media player object was not created!");
            else
            {
                _wplayer.controls.pause();

                if (_songThread == null)
                    throw new Exception("Can not kill the song thread because it is null!");
                 
                // Un nou thread va fi pornit cu functia de ResumeSong() atunci cand se apasa pe Play, asa ca putem sa terminam acest thread (cat melodia e in pauza).
                _songThread.Abort();
                _songThread = null;
    
                _isPaused = true;
            }
        }

        /// <summary>
        /// Resumes playing a song.
        /// </summary>
        private void ResumeSong()
        {
            if (_wplayer == null)
                throw new Exception("The windows media player object was not created!");
            else
            {
                _wplayer.controls.play();
            }
        }

        /// <summary>
        /// Stops a song that is currently playing. It also kills the thread that the song was playing in.
        /// </summary>
        public void StopSong()
        {
            if (_wplayer == null)
                throw new Exception("The windows media player object was not created!");
            else
            {
                _wplayer.controls.stop();

                if (_songThread == null)
                    throw new Exception("Can not kill the song thread because it is null!");

                _songThread.Abort();
                _songThread = null;

                _isPaused = false; // posibil redundant
            }
        }

        /// <summary>
        /// This function returns current time of the song as a string with the format HH:MM:SS.
        /// </summary>
        /// <returns>The actual duration of the selected song.</returns>
        public string GetSongDurationString()
        {
            return _wplayer.currentMedia.durationString;
        }

        /// <summary>
        /// This function returns duration of a song in seconds.
        /// </summary>
        /// <returns>The actual duration of the selected song.</returns>
        public double GetSongDurationDouble()
        {
            return _wplayer.currentMedia.duration;
        }

        /// <summary>
        /// Property that sets/retrieves the path of a song.
        /// </summary>
        public string SongPath
        {
            get { return _songPath; }
            set { _songPath = value; }
        }

        /// <summary>
        /// Property that sets/retrieves the name of a song.
        /// </summary>
        public string SongName
        {
            get { return _songName; }
            set { _songName = value; }
        }

        /// <summary>
        /// Property that sets/retrieves the elapsed time of a song.
        /// </summary>
        public double PassedTime
        {
            get { return _wplayer.controls.currentPosition; }
            set { _wplayer.controls.currentPosition = value; }
        }

        /// <summary>
        /// Property that retrieves the Windows Media Player object.
        /// </summary>
        public WindowsMediaPlayer Wplayer
        {
            get { return _wplayer; }
        }
    }
}
