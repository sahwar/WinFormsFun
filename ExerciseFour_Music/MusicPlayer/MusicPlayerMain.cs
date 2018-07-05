using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class MusicPlayerMain : Form
    {
        Image playImage, pauseImage;
        string[] audioFileNames;
        string[] audioSafeFileNames;
        int currAudioId = -1;
        bool songPlaying = false;
        SoundPlayer musicPlayer = new SoundPlayer();
        
        public int CurrAudioId
        {
            get
            {
                return currAudioId;
            }
            set
            {
                if (currAudioId != value)
                {
                    if(value < 0 || value >= audioFileNames.Length)
                    {
                        SongPlaying = false;
                        currAudioId = -1;
                    }
                    else
                    {
                        currAudioId = value;
                        musicPlayer.SoundLocation = audioFileNames[currAudioId];
                    }
                    
                }
            }
        }
        public bool SongPlaying
        {
            get
            {
                return songPlaying;
            }
            set
            {
                if (songPlaying != value)
                {
                    if (value)
                    {
                        btnPlay.Image = pauseImage;
                        musicPlayer.Play();
                    }
                    else
                    {
                        btnPlay.Image = playImage;
                        musicPlayer.Stop();
                    }
                    songPlaying = value;
                }
            }
        }

        public MusicPlayerMain()
        {
            InitializeComponent();
            musicPlayer.LoadCompleted += MusicPlayer_LoadCompleted;
            musicPlayer.SoundLocationChanged += MusicPlayer_SoundLocationChanged;
        }

        private void MusicPlayer_SoundLocationChanged(object sender, EventArgs e)
        {
            try
            {
                SongPlaying = false;
                tbCurrentlyPlaying.Text = audioSafeFileNames[CurrAudioId];
                musicPlayer.LoadAsync();
                SongPlaying = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MakeDraggable(object sender, EventArgs e)
        {
            ControlExtension.Draggable((Control) sender, true);
        }

        private void MusicPlayerMain_Load(object sender, EventArgs e)
        {
            MakeDraggable(sender, e);
            playImage = btnPlay.Image;
            try
            {
                pauseImage = Image.FromFile(@"D:\Danilo\C#\WindowsForms\ExerciseFour_Music\icons\Pause Button_64px.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                pauseImage = playImage;
            }
        }

        private void OpenAudioFile(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Windows Audio File|*.wav"
            };

            ofd.Multiselect = true;

            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                audioSafeFileNames = ofd.SafeFileNames;
                audioFileNames = ofd.FileNames;
                CurrAudioId = 0;
            }
        }

        private void MusicPlayer_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            SongPlaying = true;
        }

        private void NextSong(object sender, EventArgs e)
        {
            try
            {
                if (CurrAudioId + 1 >= audioFileNames.Length)
                {
                    CurrAudioId = 0;
                }
                else
                {
                    ++CurrAudioId;
                }
            }
            catch { }
        }

        private void PreviousSong(object sender, EventArgs e)
        {
            try
            {
                if (CurrAudioId - 1 < 0)
                {
                    CurrAudioId = audioFileNames.Length - 1;
                }
                else
                {
                    --CurrAudioId;
                }
            }
            catch { }
        }

        private void PlayOrPauseSong(object sender, EventArgs e)
        {
            try
            {
                Button playButton = sender as Button;

                if(!musicPlayer.IsLoadCompleted)
                {
                    return;
                }
                
                SongPlaying = !SongPlaying;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
