/********************************************************************************************
 *                                                                                          *
 *  File:        Form1.cs                                                                   *
 *  Copyright:   (c) 2022, Curpan Robert, Istrate Sebastian, Toma Catalin                   *
 *  E-mail:      robert-gabriel.curpan@student.tuiasi.ro                                    *
 *  Website:     https://github.com/Tudisie/MP3-Player                                      *
 *  Description: File that implements the functionality of a MP3 Player app User Interface  *
 *               You can add/remove a song, add/remove a playlist, put a specific song      *
 *               in a specific playlist etc.                                                *
 *                                                                                          *
 *******************************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Microsoft.VisualBasic;

using SongDLL;
using PlaylistDLL;

namespace MP3Player
{
    /// <summary>
    /// Publisher class (part of the Observer design pattern) - the changes on songs (removal, for example) happen in the UI, so this class has to be the publisher.
    /// </summary>
    public partial class Mp3Form : Form 
    {
        private Song _currentSong;
        // Subscribers
        private List<Playlist> _playlists;

        private Color _disabledColor, _enabledColor;
        private bool _firstTime = true;
        private bool _loadedAux = false;
        private int _loadingSong;
        private double _progressBarTime;

        private string _selectedSongPath;
        private string _selectedSongName;

        /// <summary>
        /// This creates the default playlist if it does not exists. Also, here, all the songs and playlists saved in the file are loaded (basically restores the last state of the mp3 player that was saved in the file by pressing the power button in the UI).
        /// </summary>
        public Mp3Form()
        {
            InitializeComponent();
            _currentSong = new Song();

            // Incarca melodiile si playlisturile existente in ultima stare a playlistului (cand au fost salvate)
            if(loadPlaylists() == false)
            {
                _playlists.Add(new ConcretePlaylist("All songs"));    // playlist default
                listBoxPlaylists.Items.Add(_playlists[0].PlaylistName);
                listBoxPlaylists.SelectedIndex = 0;
            }
            _progressBarTime = 0.0;

            _disabledColor = Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            _enabledColor = Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
        }

        /// <summary>
        /// The actual function that loads the playlists and songs which were saved in the file during the last session.
        /// </summary>
        /// <returns>Returns true if the songs and playlists were loaded succesfully, otherwise false.</returns>
        private bool loadPlaylists()
        {
            _playlists = new List<Playlist>();

            try
            {

                string[] lines = System.IO.File.ReadAllLines("Playlists.txt");

                int numberOfPlaylists = 0;
                foreach(string line in lines)
                {
                    if(line[0] == '$') //Song
                    {
                        //Format: $song_name///song_path
                        string[] subs = line.Substring(1).Split(new String[] {"///"}, StringSplitOptions.None);
                        _playlists[numberOfPlaylists - 1].AddSong(subs[0],subs[1]);
                    }
                    else //Playlist
                    {
                        ++numberOfPlaylists;
                        _playlists.Add(new ConcretePlaylist(line));
                    }
                }

                RefreshPlaylists();

                listBoxPlaylists.SelectedIndex = 0;

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Loads the form.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void mp3Form_Load(object sender, EventArgs e)
        {
            this.songTitle.Text = "Empty player";
        }

        /// <summary>
        /// (Callback function) Starts the selected song. If it doesn't exist, it is deleted from the default playlist and then the other playlists are notified (through the observer pattern).
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void startButton_Click(object sender, EventArgs e)
        {
            if (_selectedSongPath == null)
                return;
            if (this.songState.Text == "Playing")
            {
                if(_currentSong.SongName == _selectedSongName)
                {
                    //Play la melodia care e deja in curs de redare, deci nu trebuie facut nimic
                    return;
                }
                else
                {
                    //Este o melodie in curs de rulare, dar se alege alta pentru redare, deci trebuie oprita cea anterioara mai intai
                    try
                    {
                        _currentSong.StopSong();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if(this.songState.Text == "Paused")
            {
                //Playerul este pe pauza, deci trebuie reluata melodia
                if (_currentSong.SongName != _selectedSongName)
                {
                    try
                    {
                        _currentSong.Play();
                        _currentSong.StopSong();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (!File.Exists(_selectedSongPath))
            {
                MessageBox.Show("File " + _selectedSongName + " doesn't exist in local PC.");
                try
                {
                    _playlists[0].RemoveSong(_selectedSongName);
                    NotifyPlaylists(_selectedSongPath);
                }
                catch(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }

                this.songTitle.Text = "MP3 Player";
                this.songState.Text = "Stopped";
                this.timerSong.Stop();
                this.progressBarSong.Value = 0;
                this.songTime.Text = "00:00";
                this.songPassedTime.Text = "00:00";

                RefreshSongs();

                if (listBoxSongs.Items.Count > 0)
                    listBoxSongs.SelectedIndex = 0;

                return;
            }
            _currentSong.SongPath = _selectedSongPath;
            _currentSong.SongName = _selectedSongName;
            
            this.songTitle.Text = _currentSong.SongName;
            this.songState.Text = "Playing";
      

            _loadingSong = 10;
            _loadedAux = false;

            this.timerSong.Start();

            try
            {
                _currentSong.Play();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// (Callback function) Increments the progress bar based on the time elapsed and the songs' duration.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void timerSong_Tick(object sender, EventArgs e)
        {  

            if (!_loadedAux)
            {
                if (_loadingSong <= 0)
                {
                    _loadedAux = true;
                    this.songTime.Text = _currentSong.Wplayer.currentMedia.durationString;
                    _currentSong.Wplayer.settings.volume = volumeBar.Value;
                }
                _loadingSong--;
            }
            else
            {
                //this._currentSong.Update();
                _progressBarTime = this._currentSong.PassedTime;
                string mins, secs;
                if (_progressBarTime / 60 < 10)
                    mins = "0" + (int)_progressBarTime / 60;
                else
                    mins = "" + (int)_progressBarTime / 60;

                if (_progressBarTime % 60 < 10)
                    secs = "0" + (int)_progressBarTime % 60;
                else
                    secs = "" + (int)_progressBarTime % 60;

                songPassedTime.Text = mins + ":" + secs;

                try
                {
                    this.progressBarSong.Value = (int)(_progressBarTime * 100 / _currentSong.GetSongDurationDouble());
                }
                catch(Exception ex)
                {
                    this.progressBarSong.Value = 0;
                }
                this.songTime.Text = _currentSong.GetSongDurationString();
               }
            
        }

        /// <summary>
        /// (Callback function) Paused the currently playing song.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (_currentSong.SongPath == null)
                return;

            this.songState.Text = "Paused";
            this.timerSong.Stop();

            try
            {
                _currentSong.PauseSong();
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// (Callback function) Stops the currently playing song.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void stopButton_Click(object sender, EventArgs e)
        {
            if (_currentSong.SongPath == null)
                return;

            this.songTitle.Text = "MP3 Player";
            this.songState.Text = "Stopped";
            this.timerSong.Stop();
            this.progressBarSong.Value = 0;
            this.songTime.Text = "00:00";
            this.songPassedTime.Text = "00:00";
            _currentSong.PassedTime = 0;

            try
            {
                _currentSong.StopSong();
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// (Callback function) Stops the current song and plays the next song in the playlist (if it is not the last).
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void nextSongButton_Click(object sender, EventArgs e)
        {
            if (listBoxSongs.SelectedIndex < listBoxSongs.Items.Count - 1)
                listBoxSongs.SelectedIndex++;
            stopButton_Click(sender, e);
            startButton_Click(sender, e);
        }

        /// <summary>
        /// (Callback function) Stops the current song and plays the previous song in the playlist (if it is not the first).
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void previousSongButton_Click(object sender, EventArgs e)
        {
            if (listBoxSongs.SelectedIndex > 0)
                listBoxSongs.SelectedIndex--;
            stopButton_Click(sender, e);
            startButton_Click(sender, e);
        }

        /// <summary>
        /// (Callback function) Subscribe method (part of the Observer design pattern) - adds a new playlist to the MP3 Player
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void buttonAddPlaylist_Click(object sender, EventArgs e)
        {
            string newPlaylistName = Interaction.InputBox("Dati numele noului playlist:", "New playlist", "", -1, -1);

            if (newPlaylistName == "")
                return;
            
            for(int i = 0; i< _playlists.Count; i++)
                if(_playlists[i].PlaylistName == newPlaylistName)
                {
                    MessageBox.Show("Acest playlist exista deja.");
                    return;
                }

            _playlists.Add(new ConcretePlaylist(newPlaylistName));

            RefreshPlaylists();
        }

        /// <summary>
        /// (Callback function) Unsubscribe (part of the Observer design pattern) - removes a playlist from the MP3 player.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void buttonRemovePlaylist_Click(object sender, EventArgs e)
        {
            if(_playlists[listBoxPlaylists.SelectedIndex].PlaylistName != "All songs")
            {
                _playlists.RemoveAt(listBoxPlaylists.SelectedIndex);

                RefreshPlaylists();
            }
        }

        /// <summary>
        /// After a change in the structure of the playlists (one was added/removed), the playlists are refreshed so that the UI can display the new structure.
        /// </summary>
        private void RefreshPlaylists()
        {
            listBoxPlaylists.Items.Clear();
            for(int i = 0; i < _playlists.Count; i++)
                listBoxPlaylists.Items.Add(_playlists[i].PlaylistName);

            listBoxPlaylists.SelectedIndex = 0;
        }

        /// <summary>
        /// (Callback function) Plays a song at random from the current playlist.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void shuffleButton_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            listBoxSongs.SelectedIndex = r.Next(listBoxSongs.Items.Count);

            stopButton_Click(sender, e);
            startButton_Click(sender, e);
        }

        /// <summary>
        /// (Callback function) Adds a new song to the default playlist (that contains all the songs).
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void roundButtonAddSong_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Mp3 Files|*.mp3";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    char c = @"\".ToCharArray()[0];
                    string[] aux = ofd.FileName.Split(c);
                    string name = aux[aux.Length - 1];
                    string path = ofd.FileName;

                    // Cream o pereche <denumire, path> pt fiecare melodie adaugata
                    // Se adauga by default in All Songs (playlist-ul 0)
                    _playlists[0].AddSong(name, ofd.FileName);

                    // Introducem denumirea in listbox-ul din interfata
                    RefreshPlaylists();

                    // By default, the selected song is the last added one
                    _currentSong.SongPath = path;
                    _currentSong.SongName = name;

                }
            }
        }

        /// <summary>
        /// (Callback function) Removes a song from a user (custom) playlist or from the default playlist.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void roundButtonRemoveSong_Click(object sender, EventArgs e)
        {
            string songName = listBoxSongs.GetItemText(listBoxSongs.SelectedItem);

            try
            {
                _playlists[listBoxPlaylists.SelectedIndex].RemoveSong(songName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            RefreshSongs();
            if(listBoxPlaylists.SelectedIndex == 0)
            {
                // Daca am sters melodia din playlistul default (cel care contine toate melodiile), 
                // atunci melodia respectiva trebuie stearsa si din toate celelalte playlisturi
                NotifyPlaylists(songName);
            }

            if (listBoxSongs.Items.Count > 0)
                listBoxSongs.SelectedIndex = 0;
            
        }


        /// <summary>
        /// Notify Subscribers (part of the Observer design pattern) - if a song was deleted from the default playlist or a mp3 file was deleted, the other playlists are notified and they will remove that song too.
        /// </summary>
        /// <param name="songName">The name of the song that will be checked within the other playlists and, if it exists there, it will be deleted.</param>
        private void NotifyPlaylists(string songName)
        {
            if(_playlists.Count > 1)
            {
                for (int i = 0; i < _playlists.Count; i++)
                    _playlists[i].Update(songName);
            }
        }

        /// <summary>
        /// After a change in the structure of the songs (one was added/removed), they are refreshed so that the UI can display the updated version of the songs structure.
        /// </summary>
        private void RefreshSongs()
        {
            string[] songNames = _playlists[listBoxPlaylists.SelectedIndex].Songs;

            listBoxSongs.Items.Clear();
            for (int i = 0; i < songNames.Length; i++)
                listBoxSongs.Items.Add(songNames[i]);
        }

        /// <summary>
        /// (Callback function) When another song is selected from the list, the windows media player object receives its path so that it can be played when pressing the play button.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedSongName = listBoxSongs.GetItemText(listBoxSongs.SelectedItem);
            _selectedSongPath = _playlists[listBoxPlaylists.SelectedIndex].PlaylistSongPath(_selectedSongName);

            /*try
            {
                _currentSong.SongPath = _playlists[listBoxPlaylists.SelectedIndex].PlaylistSongPath(songName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            _currentSong.SongName = songName;*/

        }

        /// <summary>
        /// (Callback function) When another playlist is selected from the list, the listbox needs to display the songs from that new playlist.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void listBoxPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Afisam melodiile din playlist-ul selectat in fereastra din dreapta (cea cu melodii)

           
            RefreshSongs();
            if(listBoxSongs.Items.Count > 0)
                listBoxSongs.SelectedIndex = 0;

            if (_firstTime)
            {
                _firstTime = false;
                return;
            }

            if (listBoxPlaylists.SelectedIndex > 0 || listBoxSongs.Items.Count == 0 )
            {
                roundButtonAddSongToPlaylist.Enabled = false;
                roundButtonAddSongToPlaylist.BackColor = _disabledColor;
            }
            else
            {
                roundButtonAddSongToPlaylist.Enabled = true;
                roundButtonAddSongToPlaylist.BackColor = _enabledColor;
            }
        }

        /// <summary>
        /// (Callback function) If we press the power off button, the structure of all the songs and playlists is saved in a file. Basically, the state of the MP3 player is saved so that it can be restored in the future.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void powerOffButton_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText("Playlists.txt", "");
                for (int i = 0; i < _playlists.Count; i++)
                {
                    File.AppendAllText("Playlists.txt", _playlists[i].PlaylistName + "\n");
                    foreach (string str in _playlists[i].SongsWithPaths)
                    {
                        //melodiile vor avea $ in fata pentru a le diferentia de playlisturi
                        File.AppendAllText("Playlists.txt", "$" + str + "\n");
                    }
                }
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// (Callback function) Modifies the volume of the song.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void volumeBar_Scroll(object sender, EventArgs e)
        {
            if (songState.Text == "Playing")
                _currentSong.Wplayer.settings.volume = volumeBar.Value;
        }

        /// <summary>
        /// (Callback function) Displays the help file of the application.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void helpButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MP3 Player Help.chm");
        }

        /// <summary>
        /// (Callback function) Displays information about the application.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void infoButton_Click(object sender, EventArgs e)
        {
            string text = "MP3 Player este un program cu ajutorul caruia se poate asculta muzica." +
                "Melodiile pot fi adaugate direct in playlist-ul general \"All Songs\" " + 
                "si dupa mutate in alte playlist-uri.";
            string title = "About MP3 Player";
            MessageBox.Show(text, title);
        }

        /// <summary>
        /// (Callback function) Adds the selected song to a playlist of the user's choice.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void roundButtonAddSongToPlaylist_Click(object sender, EventArgs e)
        {
            string playlistName = Interaction.InputBox("In ce playlist introduceti melodia?", "Add song to playlist", "", -1, -1);

            if (listBoxPlaylists.SelectedIndex == 0)
            {
                if (listBoxSongs.SelectedIndex != -1)
                {
                    // Daca am selectat o melodie
                    if (playlistName != "All songs")
                    {
                        // Daca playlistul in care dorim sa adaugam melodia nu este cel default (melodiile exista deja in playlistul default, nu are rost sa adaugam aici)

                        // Cautam indexul playlistului cu numele dat
                        int playlistIndex = -1;
                        for (int i = 1; i < _playlists.Count; i++)  // nu iteram si playlistul default
                        {
                            if (_playlists[i].PlaylistName == playlistName)
                            {
                                playlistIndex = i;
                                break;
                            }
                        }

                        if (playlistIndex != -1)
                        {
                            string songName = listBoxSongs.GetItemText(listBoxSongs.SelectedItem);

                            try
                            {
                                string songPath = _playlists[0].PlaylistSongPath(songName); // luam path-ul din playlist-ul default
                                _playlists[playlistIndex].AddSong(songName, songPath);
                                RefreshPlaylists();
                                if (listBoxSongs.Items.Count > 0)
                                    listBoxSongs.SelectedIndex = 0;
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Playlistul in care doriti sa introduceti melodia nu exista!");
                        }
                    }
                }
                else
                {
                    // Nicio melodie nu este selectata
                    MessageBox.Show("Selectati o melodie din lista mai intai!");
                }
            }
            else
            {
                MessageBox.Show("Trebuie sa fiti in playlist-ul default pt a adauga melodii in alt playlist!");
            }
        }
    }
}
