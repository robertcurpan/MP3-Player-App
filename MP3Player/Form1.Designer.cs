namespace MP3Player
{
    partial class Mp3Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.PictureBox songLogo;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mp3Form));
            System.Windows.Forms.PictureBox minLogo;
            System.Windows.Forms.PictureBox maxLogo;
            this.groupBoxControlPanel = new System.Windows.Forms.GroupBox();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.progressBarSong = new MP3Player.NewProgressBar();
            this.songDisplay = new System.Windows.Forms.Panel();
            this.songTime = new System.Windows.Forms.Label();
            this.songType = new System.Windows.Forms.Label();
            this.songState = new System.Windows.Forms.Label();
            this.songPassedTime = new System.Windows.Forms.Label();
            this.songTitle = new System.Windows.Forms.Label();
            this.playButton = new MP3Player.RoundButton();
            this.pauseButton = new MP3Player.RoundButton();
            this.previousSongButton = new MP3Player.RoundButton();
            this.nextSongButton = new MP3Player.RoundButton();
            this.stopButton = new MP3Player.RoundButton();
            this.groupBoxPlaylists = new System.Windows.Forms.GroupBox();
            this.buttonRemovePlaylist = new System.Windows.Forms.Button();
            this.buttonAddPlaylist = new System.Windows.Forms.Button();
            this.listBoxPlaylists = new System.Windows.Forms.ListBox();
            this.groupBoxSongs = new System.Windows.Forms.GroupBox();
            this.roundButtonAddSongToPlaylist = new MP3Player.RoundButton();
            this.listBoxSongs = new System.Windows.Forms.ListBox();
            this.roundButtonAddSong = new MP3Player.RoundButton();
            this.shuffleButton = new MP3Player.RoundButton();
            this.roundButtonRemoveSong = new MP3Player.RoundButton();
            this.timerSong = new System.Windows.Forms.Timer(this.components);
            this.helpButton = new MP3Player.RoundButton();
            this.infoButton = new MP3Player.RoundButton();
            this.powerOffButton = new MP3Player.RoundButton();
            songLogo = new System.Windows.Forms.PictureBox();
            minLogo = new System.Windows.Forms.PictureBox();
            maxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(songLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(minLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(maxLogo)).BeginInit();
            this.groupBoxControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.songDisplay.SuspendLayout();
            this.groupBoxPlaylists.SuspendLayout();
            this.groupBoxSongs.SuspendLayout();
            this.SuspendLayout();
            // 
            // songLogo
            // 
            songLogo.Image = ((System.Drawing.Image)(resources.GetObject("songLogo.Image")));
            songLogo.Location = new System.Drawing.Point(13, 7);
            songLogo.Name = "songLogo";
            songLogo.Size = new System.Drawing.Size(58, 63);
            songLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            songLogo.TabIndex = 1;
            songLogo.TabStop = false;
            // 
            // minLogo
            // 
            minLogo.Image = ((System.Drawing.Image)(resources.GetObject("minLogo.Image")));
            minLogo.Location = new System.Drawing.Point(420, 177);
            minLogo.Name = "minLogo";
            minLogo.Size = new System.Drawing.Size(37, 31);
            minLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            minLogo.TabIndex = 22;
            minLogo.TabStop = false;
            // 
            // maxLogo
            // 
            maxLogo.Image = ((System.Drawing.Image)(resources.GetObject("maxLogo.Image")));
            maxLogo.Location = new System.Drawing.Point(420, 21);
            maxLogo.Name = "maxLogo";
            maxLogo.Size = new System.Drawing.Size(37, 31);
            maxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            maxLogo.TabIndex = 23;
            maxLogo.TabStop = false;
            // 
            // groupBoxControlPanel
            // 
            this.groupBoxControlPanel.Controls.Add(maxLogo);
            this.groupBoxControlPanel.Controls.Add(minLogo);
            this.groupBoxControlPanel.Controls.Add(this.volumeBar);
            this.groupBoxControlPanel.Controls.Add(this.shuffleButton);
            this.groupBoxControlPanel.Controls.Add(this.progressBarSong);
            this.groupBoxControlPanel.Controls.Add(this.songDisplay);
            this.groupBoxControlPanel.Controls.Add(this.playButton);
            this.groupBoxControlPanel.Controls.Add(this.pauseButton);
            this.groupBoxControlPanel.Controls.Add(this.previousSongButton);
            this.groupBoxControlPanel.Controls.Add(this.nextSongButton);
            this.groupBoxControlPanel.Controls.Add(this.stopButton);
            this.groupBoxControlPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxControlPanel.Location = new System.Drawing.Point(12, 34);
            this.groupBoxControlPanel.Name = "groupBoxControlPanel";
            this.groupBoxControlPanel.Size = new System.Drawing.Size(479, 223);
            this.groupBoxControlPanel.TabIndex = 0;
            this.groupBoxControlPanel.TabStop = false;
            this.groupBoxControlPanel.Text = "Control Panel";
            // 
            // volumeBar
            // 
            this.volumeBar.Location = new System.Drawing.Point(401, 21);
            this.volumeBar.Maximum = 100;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumeBar.Size = new System.Drawing.Size(56, 187);
            this.volumeBar.TabIndex = 18;
            this.volumeBar.TickFrequency = 100;
            this.volumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeBar.Value = 50;
            this.volumeBar.Scroll += new System.EventHandler(this.volumeBar_Scroll);
            // 
            // progressBarSong
            // 
            this.progressBarSong.Location = new System.Drawing.Point(16, 120);
            this.progressBarSong.Name = "progressBarSong";
            this.progressBarSong.Size = new System.Drawing.Size(374, 10);
            this.progressBarSong.TabIndex = 20;
            // 
            // songDisplay
            // 
            this.songDisplay.BackColor = System.Drawing.Color.Black;
            this.songDisplay.Controls.Add(this.songTime);
            this.songDisplay.Controls.Add(this.songType);
            this.songDisplay.Controls.Add(this.songState);
            this.songDisplay.Controls.Add(this.songPassedTime);
            this.songDisplay.Controls.Add(songLogo);
            this.songDisplay.Controls.Add(this.songTitle);
            this.songDisplay.Location = new System.Drawing.Point(16, 22);
            this.songDisplay.Name = "songDisplay";
            this.songDisplay.Size = new System.Drawing.Size(374, 73);
            this.songDisplay.TabIndex = 19;
            // 
            // songTime
            // 
            this.songTime.AutoSize = true;
            this.songTime.Location = new System.Drawing.Point(307, 53);
            this.songTime.Name = "songTime";
            this.songTime.Size = new System.Drawing.Size(38, 16);
            this.songTime.TabIndex = 6;
            this.songTime.Text = "00:00";
            // 
            // songType
            // 
            this.songType.AutoSize = true;
            this.songType.Location = new System.Drawing.Point(158, 55);
            this.songType.Name = "songType";
            this.songType.Size = new System.Drawing.Size(34, 16);
            this.songType.TabIndex = 5;
            this.songType.Text = "MP3";
            // 
            // songState
            // 
            this.songState.AutoSize = true;
            this.songState.Location = new System.Drawing.Point(87, 53);
            this.songState.Name = "songState";
            this.songState.Size = new System.Drawing.Size(52, 16);
            this.songState.TabIndex = 4;
            this.songState.Text = "Starting";
            // 
            // songPassedTime
            // 
            this.songPassedTime.AutoSize = true;
            this.songPassedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songPassedTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(206)))), ((int)(((byte)(250)))));
            this.songPassedTime.Location = new System.Drawing.Point(306, 21);
            this.songPassedTime.Name = "songPassedTime";
            this.songPassedTime.Size = new System.Drawing.Size(55, 22);
            this.songPassedTime.TabIndex = 2;
            this.songPassedTime.Text = "00:00";
            // 
            // songTitle
            // 
            this.songTitle.AutoSize = true;
            this.songTitle.Font = new System.Drawing.Font("Microsoft Uighur", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songTitle.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.songTitle.Location = new System.Drawing.Point(77, 7);
            this.songTitle.Name = "songTitle";
            this.songTitle.Size = new System.Drawing.Size(136, 53);
            this.songTitle.TabIndex = 0;
            this.songTitle.Text = "Welcome!";
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.playButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playButton.BackgroundImage")));
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playButton.FlatAppearance.BorderSize = 0;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.playButton.Location = new System.Drawing.Point(172, 145);
            this.playButton.Margin = new System.Windows.Forms.Padding(0);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(64, 64);
            this.playButton.TabIndex = 10;
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.pauseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pauseButton.BackgroundImage")));
            this.pauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pauseButton.FlatAppearance.BorderSize = 0;
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pauseButton.Location = new System.Drawing.Point(119, 159);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(0);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(36, 36);
            this.pauseButton.TabIndex = 14;
            this.pauseButton.UseVisualStyleBackColor = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // previousSongButton
            // 
            this.previousSongButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.previousSongButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("previousSongButton.BackgroundImage")));
            this.previousSongButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.previousSongButton.FlatAppearance.BorderSize = 0;
            this.previousSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousSongButton.Location = new System.Drawing.Point(68, 159);
            this.previousSongButton.Margin = new System.Windows.Forms.Padding(0);
            this.previousSongButton.Name = "previousSongButton";
            this.previousSongButton.Size = new System.Drawing.Size(36, 36);
            this.previousSongButton.TabIndex = 13;
            this.previousSongButton.UseVisualStyleBackColor = false;
            this.previousSongButton.Click += new System.EventHandler(this.previousSongButton_Click);
            // 
            // nextSongButton
            // 
            this.nextSongButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.nextSongButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nextSongButton.BackgroundImage")));
            this.nextSongButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nextSongButton.FlatAppearance.BorderSize = 0;
            this.nextSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextSongButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nextSongButton.Location = new System.Drawing.Point(305, 159);
            this.nextSongButton.Margin = new System.Windows.Forms.Padding(0);
            this.nextSongButton.Name = "nextSongButton";
            this.nextSongButton.Size = new System.Drawing.Size(36, 36);
            this.nextSongButton.TabIndex = 12;
            this.nextSongButton.UseVisualStyleBackColor = false;
            this.nextSongButton.Click += new System.EventHandler(this.nextSongButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.stopButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stopButton.BackgroundImage")));
            this.stopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stopButton.FlatAppearance.BorderSize = 0;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Location = new System.Drawing.Point(254, 159);
            this.stopButton.Margin = new System.Windows.Forms.Padding(0);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(36, 36);
            this.stopButton.TabIndex = 11;
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // groupBoxPlaylists
            // 
            this.groupBoxPlaylists.Controls.Add(this.buttonRemovePlaylist);
            this.groupBoxPlaylists.Controls.Add(this.buttonAddPlaylist);
            this.groupBoxPlaylists.Controls.Add(this.listBoxPlaylists);
            this.groupBoxPlaylists.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxPlaylists.Location = new System.Drawing.Point(12, 284);
            this.groupBoxPlaylists.Name = "groupBoxPlaylists";
            this.groupBoxPlaylists.Size = new System.Drawing.Size(479, 219);
            this.groupBoxPlaylists.TabIndex = 1;
            this.groupBoxPlaylists.TabStop = false;
            this.groupBoxPlaylists.Text = "Playlists";
            // 
            // buttonRemovePlaylist
            // 
            this.buttonRemovePlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.buttonRemovePlaylist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRemovePlaylist.BackgroundImage")));
            this.buttonRemovePlaylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRemovePlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemovePlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(206)))), ((int)(((byte)(250)))));
            this.buttonRemovePlaylist.Location = new System.Drawing.Point(421, 164);
            this.buttonRemovePlaylist.Name = "buttonRemovePlaylist";
            this.buttonRemovePlaylist.Size = new System.Drawing.Size(36, 36);
            this.buttonRemovePlaylist.TabIndex = 2;
            this.buttonRemovePlaylist.UseVisualStyleBackColor = false;
            this.buttonRemovePlaylist.Click += new System.EventHandler(this.buttonRemovePlaylist_Click);
            // 
            // buttonAddPlaylist
            // 
            this.buttonAddPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.buttonAddPlaylist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAddPlaylist.BackgroundImage")));
            this.buttonAddPlaylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(206)))), ((int)(((byte)(250)))));
            this.buttonAddPlaylist.Location = new System.Drawing.Point(421, 112);
            this.buttonAddPlaylist.Margin = new System.Windows.Forms.Padding(1);
            this.buttonAddPlaylist.Name = "buttonAddPlaylist";
            this.buttonAddPlaylist.Size = new System.Drawing.Size(36, 36);
            this.buttonAddPlaylist.TabIndex = 1;
            this.buttonAddPlaylist.UseVisualStyleBackColor = false;
            this.buttonAddPlaylist.Click += new System.EventHandler(this.buttonAddPlaylist_Click);
            // 
            // listBoxPlaylists
            // 
            this.listBoxPlaylists.BackColor = System.Drawing.Color.Black;
            this.listBoxPlaylists.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxPlaylists.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPlaylists.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(206)))), ((int)(((byte)(250)))));
            this.listBoxPlaylists.FormattingEnabled = true;
            this.listBoxPlaylists.ItemHeight = 20;
            this.listBoxPlaylists.Location = new System.Drawing.Point(16, 30);
            this.listBoxPlaylists.Name = "listBoxPlaylists";
            this.listBoxPlaylists.Size = new System.Drawing.Size(374, 180);
            this.listBoxPlaylists.TabIndex = 0;
            this.listBoxPlaylists.SelectedIndexChanged += new System.EventHandler(this.listBoxPlaylists_SelectedIndexChanged);
            // 
            // groupBoxSongs
            // 
            this.groupBoxSongs.Controls.Add(this.roundButtonAddSongToPlaylist);
            this.groupBoxSongs.Controls.Add(this.listBoxSongs);
            this.groupBoxSongs.Controls.Add(this.roundButtonAddSong);
            this.groupBoxSongs.Controls.Add(this.roundButtonRemoveSong);
            this.groupBoxSongs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBoxSongs.Location = new System.Drawing.Point(518, 34);
            this.groupBoxSongs.Name = "groupBoxSongs";
            this.groupBoxSongs.Size = new System.Drawing.Size(377, 469);
            this.groupBoxSongs.TabIndex = 2;
            this.groupBoxSongs.TabStop = false;
            this.groupBoxSongs.Text = "Songs";
            // 
            // roundButtonAddSongToPlaylist
            // 
            this.roundButtonAddSongToPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.roundButtonAddSongToPlaylist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("roundButtonAddSongToPlaylist.BackgroundImage")));
            this.roundButtonAddSongToPlaylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundButtonAddSongToPlaylist.Enabled = false;
            this.roundButtonAddSongToPlaylist.FlatAppearance.BorderSize = 0;
            this.roundButtonAddSongToPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButtonAddSongToPlaylist.Location = new System.Drawing.Point(224, 418);
            this.roundButtonAddSongToPlaylist.Margin = new System.Windows.Forms.Padding(0);
            this.roundButtonAddSongToPlaylist.Name = "roundButtonAddSongToPlaylist";
            this.roundButtonAddSongToPlaylist.Size = new System.Drawing.Size(32, 32);
            this.roundButtonAddSongToPlaylist.TabIndex = 11;
            this.roundButtonAddSongToPlaylist.UseVisualStyleBackColor = false;
            this.roundButtonAddSongToPlaylist.Click += new System.EventHandler(this.roundButtonAddSongToPlaylist_Click);
            // 
            // listBoxSongs
            // 
            this.listBoxSongs.BackColor = System.Drawing.Color.Black;
            this.listBoxSongs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSongs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(206)))), ((int)(((byte)(250)))));
            this.listBoxSongs.FormattingEnabled = true;
            this.listBoxSongs.ItemHeight = 20;
            this.listBoxSongs.Location = new System.Drawing.Point(19, 30);
            this.listBoxSongs.Name = "listBoxSongs";
            this.listBoxSongs.Size = new System.Drawing.Size(341, 380);
            this.listBoxSongs.TabIndex = 10;
            this.listBoxSongs.SelectedIndexChanged += new System.EventHandler(this.listBoxSongs_SelectedIndexChanged);
            // 
            // roundButtonAddSong
            // 
            this.roundButtonAddSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.roundButtonAddSong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("roundButtonAddSong.BackgroundImage")));
            this.roundButtonAddSong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundButtonAddSong.FlatAppearance.BorderSize = 0;
            this.roundButtonAddSong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButtonAddSong.Location = new System.Drawing.Point(137, 418);
            this.roundButtonAddSong.Margin = new System.Windows.Forms.Padding(0);
            this.roundButtonAddSong.Name = "roundButtonAddSong";
            this.roundButtonAddSong.Size = new System.Drawing.Size(32, 32);
            this.roundButtonAddSong.TabIndex = 9;
            this.roundButtonAddSong.UseVisualStyleBackColor = false;
            this.roundButtonAddSong.Click += new System.EventHandler(this.roundButtonAddSong_Click);
            // 
            // shuffleButton
            // 
            this.shuffleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.shuffleButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("shuffleButton.BackgroundImage")));
            this.shuffleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.shuffleButton.FlatAppearance.BorderSize = 0;
            this.shuffleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shuffleButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shuffleButton.Location = new System.Drawing.Point(358, 161);
            this.shuffleButton.Margin = new System.Windows.Forms.Padding(0);
            this.shuffleButton.Name = "shuffleButton";
            this.shuffleButton.Size = new System.Drawing.Size(32, 32);
            this.shuffleButton.TabIndex = 21;
            this.shuffleButton.UseVisualStyleBackColor = false;
            this.shuffleButton.Click += new System.EventHandler(this.shuffleButton_Click);
            // 
            // roundButtonRemoveSong
            // 
            this.roundButtonRemoveSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.roundButtonRemoveSong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("roundButtonRemoveSong.BackgroundImage")));
            this.roundButtonRemoveSong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundButtonRemoveSong.FlatAppearance.BorderSize = 0;
            this.roundButtonRemoveSong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButtonRemoveSong.Location = new System.Drawing.Point(181, 418);
            this.roundButtonRemoveSong.Margin = new System.Windows.Forms.Padding(0);
            this.roundButtonRemoveSong.Name = "roundButtonRemoveSong";
            this.roundButtonRemoveSong.Size = new System.Drawing.Size(32, 32);
            this.roundButtonRemoveSong.TabIndex = 8;
            this.roundButtonRemoveSong.UseVisualStyleBackColor = false;
            this.roundButtonRemoveSong.Click += new System.EventHandler(this.roundButtonRemoveSong_Click);
            // 
            // timerSong
            // 
            this.timerSong.Interval = 10;
            this.timerSong.Tick += new System.EventHandler(this.timerSong_Tick);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.helpButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("helpButton.BackgroundImage")));
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.helpButton.FlatAppearance.BorderSize = 0;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.helpButton.Location = new System.Drawing.Point(918, 198);
            this.helpButton.Margin = new System.Windows.Forms.Padding(0);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(46, 46);
            this.helpButton.TabIndex = 21;
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.infoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("infoButton.BackgroundImage")));
            this.infoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.infoButton.FlatAppearance.BorderSize = 0;
            this.infoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.infoButton.Location = new System.Drawing.Point(918, 136);
            this.infoButton.Margin = new System.Windows.Forms.Padding(0);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(46, 46);
            this.infoButton.TabIndex = 20;
            this.infoButton.UseVisualStyleBackColor = false;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // powerOffButton
            // 
            this.powerOffButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.powerOffButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("powerOffButton.BackgroundImage")));
            this.powerOffButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.powerOffButton.FlatAppearance.BorderSize = 0;
            this.powerOffButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.powerOffButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.powerOffButton.Location = new System.Drawing.Point(909, 52);
            this.powerOffButton.Margin = new System.Windows.Forms.Padding(0);
            this.powerOffButton.Name = "powerOffButton";
            this.powerOffButton.Size = new System.Drawing.Size(64, 64);
            this.powerOffButton.TabIndex = 19;
            this.powerOffButton.UseVisualStyleBackColor = false;
            this.powerOffButton.Click += new System.EventHandler(this.powerOffButton_Click);
            // 
            // Mp3Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(982, 523);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.powerOffButton);
            this.Controls.Add(this.groupBoxSongs);
            this.Controls.Add(this.groupBoxPlaylists);
            this.Controls.Add(this.groupBoxControlPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name = "Mp3Form";
            this.Text = "MP3 Player";
            this.Load += new System.EventHandler(this.mp3Form_Load);
            ((System.ComponentModel.ISupportInitialize)(songLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(minLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(maxLogo)).EndInit();
            this.groupBoxControlPanel.ResumeLayout(false);
            this.groupBoxControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.songDisplay.ResumeLayout(false);
            this.songDisplay.PerformLayout();
            this.groupBoxPlaylists.ResumeLayout(false);
            this.groupBoxSongs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxControlPanel;
        private System.Windows.Forms.GroupBox groupBoxPlaylists;
        private System.Windows.Forms.GroupBox groupBoxSongs;
        private System.Windows.Forms.Button buttonRemovePlaylist;
        private System.Windows.Forms.Button buttonAddPlaylist;
        private System.Windows.Forms.ListBox listBoxPlaylists;
        private System.Windows.Forms.ListBox listBoxSongs;
        private RoundButton roundButtonAddSong;
        private RoundButton roundButtonRemoveSong;
        private RoundButton playButton;
        private RoundButton pauseButton;
        private RoundButton previousSongButton;
        private RoundButton nextSongButton;
        private RoundButton stopButton;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Timer timerSong;
        private System.Windows.Forms.Panel songDisplay;
        private System.Windows.Forms.Label songTitle;
        private System.Windows.Forms.Label songPassedTime;
        private NewProgressBar progressBarSong;
        private System.Windows.Forms.Label songState;
        private System.Windows.Forms.Label songType;
        private RoundButton roundButtonAddSongToPlaylist;
        private RoundButton powerOffButton;
        private System.Windows.Forms.Label songTime;
        private RoundButton shuffleButton;
        private RoundButton infoButton;
        private RoundButton helpButton;
    }
}

