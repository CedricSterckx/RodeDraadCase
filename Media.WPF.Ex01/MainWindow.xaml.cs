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

        private Song currentSong;

        private MainWindow window;



        public MainWindow()
        {
            InitializeComponent();

            audioPlayer = new AudioPlayer();
            audioPlaylist = new AudioPlaylist();

            movieController = new MovieController();
            musicController = new MusicController(audioPlayer, audioPlaylist);

            currentSong = new Song();

            musicController.Player.IsStarted += audioPlaylist.AddMedia(currentSong); //opdracht waar we code al an krijgen
            musicController.Player.IsFinished += audioPlaylist.RemoveMedia(currentSong);

            window = new MainWindow(); //om dispose method in te steken bij close event

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
    }
}
