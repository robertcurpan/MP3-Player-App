/********************************************************************************
 *                                                                              *
 *  File:        ConcretePlaylist.cs                                            *
 *  Copyright:   (c) 2022, Curpan Robert, Istrate Sebastian, Toma Catalin       *
 *  E-mail:      robert-gabriel.curpan@student.tuiasi.ro                        *
 *  Website:     https://github.com/Tudisie/MP3-Player                          *
 *  Description: Class used to do operations on a dictionary that models a      *
 *               a collection of songs within a playlist.                       *
 *                                                                              *
 *******************************************************************************/



using System;
using System.Collections.Generic;

namespace PlaylistDLL
{
    /// <summary>
    /// Concrete Subscriber class (part of the Observer design pattern) - contains methods that manage the songs in a playlist.
    /// </summary>
    public class ConcretePlaylist : Playlist
    {
        /// <summary>
        /// Constructs the dictionary that saves the song name and song path.
        /// </summary>
        public ConcretePlaylist()
        {
            _playlistName = "Noname";
            _songList = new Dictionary<string, string>();
        }

        /// <summary>
        /// Constructs the dictionary that saves the song name and song path. It also gives a name to the playlist.
        /// </summary>
        /// <param name="playlistName">The name of the playlist.</param>
        public ConcretePlaylist(string playlistName)
        {
            _playlistName = playlistName;
            _songList = new Dictionary<string, string>();
        }

        /// <summary>
        /// Retrieves the name of all the songs in the current playlist.
        /// </summary>
        public override string[] Songs
        {
            get
            {
                string[] songs = new string[_songList.Count];
                int i = 0;
                foreach (KeyValuePair<string, string> elem in _songList)
                {
                    songs[i++] = elem.Key;
                }

                return songs;
            }
        }

        /// <summary>
        /// Retrieves the name + path of all the songs in the current playlist.
        /// </summary>
        public override string[] SongsWithPaths
        {
            get
            {
                string[] songs = new string[_songList.Count];
                int i = 0;
                foreach (KeyValuePair<string, string> elem in _songList)
                {
                    songs[i++] = elem.Key + "///" + elem.Value;
                }

                return songs;
            }
        }

        /// <summary>
        /// Retrieves the current playlist's name.
        /// </summary>
        public override string PlaylistName
        {
            get { return _playlistName; }
        }

        /// <summary>
        /// Will retrieve the path of the specified song (by name).
        /// </summary>
        /// <param name="name">The name of the song that we want to get the path of.</param>
        /// <returns>The path of the song mentioned by name as parameter.</returns>
        public override string PlaylistSongPath(string name)
        {
            if (_songList.ContainsKey(name) == false)
                throw new Exception("The song that you are trying to retrieve a path for does not exist in the song dictionary.");

            return _songList[name];
        }

        /// <summary>
        /// Adds a (name, path) pair to the song dictionary.
        /// </summary>
        /// <param name="name">The name of the song that will be added.</param>
        /// <param name="path">The path of the song that will be added.</param>
        public override void AddSong(string name, string path)
        {
            _songList[name] = path;
        }

        /// <summary>
        /// Removes a song from the song dictionary.
        /// </summary>
        /// <param name="name">The name of the song that we want to remove.</param>
        public override void RemoveSong(string name)
        {
            if (_songList.ContainsKey(name) == false)
                throw new Exception("The song that you want to remove - " + name + " - does not exist in the song dictionary.");

            _songList.Remove(name);
        }

        /// <summary>
        /// The Update method (part of Observer design pattern) that is executed by each subscriber when they are notified. If a song is removed from the default playlist (or from the computer), through the Observer pattern it will be deleted from the other playlists too.
        /// </summary>
        /// <param name="songName">The name of the song that will be deleted from the current playlist if it exists.</param>
        public override void Update(string songName)
        {
            if (_songList.ContainsKey(songName))
                RemoveSong(songName);
        }

    }
}
