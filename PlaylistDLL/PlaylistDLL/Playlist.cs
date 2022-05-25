/****************************************************************************************
 *                                                                                      *
 *  File:        Playlist.cs                                                            *
 *  Copyright:   (c) 2022, Curpan Robert, Istrate Sebastian, Toma Catalin               *
 *  E-mail:      robert-gabriel.curpan@student.tuiasi.ro                                *
 *  Website:     https://github.com/Tudisie/MP3-Player                                  *
 *  Description: Abstract Class used to do operations on a dictionary that models a     *
 *               a collection of songs within a playlist.                               *
 *                                                                                      *
 ***************************************************************************************/

using System.Collections.Generic;

namespace PlaylistDLL
{
    /// <summary>
    /// Subscriber abstract class (part of the Observer design pattern) - defines the methods that will be implemented in the concrete playlist class.
    /// </summary>
    public abstract class Playlist
    {
        // Numele playlistului
        protected string _playlistName;

        // Fiecare playlist are o lista de melodii (nume, path)
        protected Dictionary<string, string> _songList;

        /// <summary>
        /// Abstract Property that retrieves the name of all the songs in the current playlist.
        /// </summary>
        public abstract string[] Songs
        {
            get;
        }

        /// <summary>
        /// Abstract Property that retrieves the name + path of all the songs in the current playlist.
        /// </summary>
        public abstract string[] SongsWithPaths
        {
            get;
        }

        /// <summary>
        /// Abstract property that retrieves the current playlist's name.
        /// </summary>
        public abstract string PlaylistName
        {
            get;
        }

        /// <summary>
        /// Will retrieve the path of the specified song (by name).
        /// </summary>
        /// <param name="name">The name of the song that we want to get the path of.</param>
        /// <returns>The path of the song mentioned by name as parameter.</returns>
        public abstract string PlaylistSongPath(string name);

        /// <summary>
        /// Adds a (name, path) pair to the song dictionary.
        /// </summary>
        /// <param name="name">The name of the song that will be added.</param>
        /// <param name="path">The path of the song that will be added.</param>
        public abstract void AddSong(string name, string path);
        
        /// <summary>
        /// Removes a song from the song dictionary.
        /// </summary>
        /// <param name="name">The name of the song that we want to remove.</param>
        public abstract void RemoveSong(string name);

        /// <summary>
        /// The Update method (part of Observer design pattern) that is executed by each subscriber when they are notified. If a song is removed from the default playlist (or from the computer), through the Observer pattern it will be deleted from the other playlists too.
        /// </summary>
        /// <param name="songName">The name of the song that will be deleted from the current playlist if it exists.</param>
        public abstract void Update(string songName);
    }
}
