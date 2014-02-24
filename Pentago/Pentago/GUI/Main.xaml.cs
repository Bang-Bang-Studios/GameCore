using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pentago.GUI;
using Pentago.GameCore;
using Pentago.AI;

namespace Pentago
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnQuickMatch_Click(object sender, RoutedEventArgs e)
        {
            //Human vs Human
            //Idieally all this options will be set from GUI and then extracted
            //and passed to the gameOptions constructor
            string player1Name = "Diego Castillo";
            bool isPlayer1Active = true;
            ImageBrush player1Image = new ImageBrush();
            player1Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/GUI/images/dragon1.jpg", UriKind.Absolute));
            Player player1 = new Player(player1Name, isPlayer1Active, player1Image);


            string player2Name = "Antonio Banderas";
            ImageBrush player2Image = new ImageBrush();
            player2Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/GUI/images/dragon2.jpg", UriKind.Absolute));
            Player player2 = new Player(player2Name, !isPlayer1Active, player2Image);

            GameOptions gameOptions = new GameOptions(GameOptions.TypeOfGame.QuickMatch, player1, player2);
            Window gameWindow = new Game(gameOptions);
            App.Current.MainWindow = gameWindow;
            gameWindow.Show();
        }
        
        private void btnQuickMatchAI_Click(object sender, RoutedEventArgs e)
        {
            //Human vs AI
            //Idieally all this options will be set from GUI and then extracted
            //and passed to the gameOptions constructor 
            string player1Name = "Diego Castillo";
            bool isPlayer1Active = true;
            ImageBrush player1Image = new ImageBrush();
            player1Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/GUI/images/dragon1.jpg", UriKind.Absolute));
            Player player1 = new Player(player1Name, isPlayer1Active, player1Image);

            string computerPlayerName = "Miley Twerk";
            ImageBrush computerPlayerImage = new ImageBrush();
            computerPlayerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/GUI/images/dragon2.jpg", UriKind.Absolute));
            computerAI.Difficulty difficulty = computerAI.Difficulty.Hard;
            computerAI computerPlayer = new computerAI(computerPlayerName, !isPlayer1Active, computerPlayerImage, difficulty);

            GameOptions gameOptions = new GameOptions(GameOptions.TypeOfGame.AI, player1, computerPlayer);
            Window gameWindow = new Game(gameOptions);
            App.Current.MainWindow = gameWindow;
            this.Hide();
            gameWindow.Show();
             
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
