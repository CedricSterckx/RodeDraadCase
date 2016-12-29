using Media.Controller.Ex01;
using Media.DataModel;
using Media.Player;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Media.Player;

namespace Media.WPF.Ex01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private AudioPlayer audioPlayer;
        private AudioPlaylist audioPlaylist;

        private MovieController movieController;
        private MusicController musicController;

        private MediaController activeController;


        public MainWindow()
        {
            InitializeComponent();

            audioPlayer = new AudioPlayer();
            audioPlaylist = new AudioPlaylist();

            movieController = new MovieController();
            musicController = new MusicController(audioPlayer, audioPlaylist);

            musicListBox.ItemsSource = musicController.List;
            movieListBox.ItemsSource = movieController.List;


            musicController.Player.IsStarted += Player_IsStarted;
            musicController.Player.IsFinished += Player_IsFinished;




        }

        private void Player_IsFinished()
        {
            //Doen wss bij databinding
        }

        private void Player_IsStarted()
        {
            //Doen wss bij databinding
        }

        private void btnPlayMusic_Click(object sender, RoutedEventArgs e)
        {
            musicController.PlayFromPlaylist();
        }

        private void btnPauseMusic_Click(object sender, RoutedEventArgs e)
        {
            musicController.Pause();
        }

        private void btnStopMusic_Click(object sender, RoutedEventArgs e)
        {
            musicController.StopPlaying();
        }



        private void Window_Closed(object sender, EventArgs e)
        {
            musicController.Dispose();
            movieController.Dispose();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (musicTabItem.IsSelected)
            {
                activeController = musicController;
                musicListBox.Items.Refresh();
                musicListBox.ItemsSource = activeController.List;
                //waarom wordt activeController geen musicController
                if (activeController.HasSongsInPlaylist)
                {
                    btnPlayMusic.IsEnabled = false;
                    btnStopMusic.IsEnabled = false;
                    btnNextMusic.IsEnabled = false;
                    btnPauseMusic.IsEnabled = false;        
                } else
                {
                    btnPlayMusic.IsEnabled = true;
                    btnStopMusic.IsEnabled = true;
                    btnNextMusic.IsEnabled = true;
                    btnPauseMusic.IsEnabled = true;
                }


            }
            else if (moviesTabItem.IsSelected)
            {
                activeController = movieController;
                //hier moet nog code komen
                movieListBox.Items.Refresh();
                
                movieListBox.ItemsSource = activeController.List;

                //Hier geen buttons disablen ? Hoe kijken of er movie in buffer/playlist staat

            }
            //hier moet nog code komen

           
        }
    }
}
