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
using Pentago.GameCore;

namespace Pentago
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private GameBrain gameBrain = null;

        private const int BOARDSIZE = 36;
        private const int MAXCOLUMNS = 6;
        private const int MAXROWS = 6;

        private bool userMadeRotation = true;

        private Player player1 = null;
        private Player player2 = null;

        public Game()
        {
            InitializeComponent();
            PaintBoard();
            //to initialize player, a switch case could be used
            //according to the options the user selected on previous
            //page
            player1 = new Player("player1", true, Brushes.Green);
            player2 = new Player("player2", false, Brushes.Blue);
            gameBrain = new GameBrain(player1, player2);
        }

        public void PaintBoard()
        {
            Board.Rows = MAXROWS;
            Board.Columns = MAXCOLUMNS;
            for (int i = 0; i < BOARDSIZE; i++)
            {
                Rectangle rect = new Rectangle();
                rect.Fill = Brushes.White;
                rect.Stroke = Brushes.Black;
                Board.Children.Add(rect);
            }
        }

        private void Board_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (userMadeRotation)
            {
                userMadeRotation = false;
                int rectSize = (int)Board.Width / MAXCOLUMNS;

                Point mousePosition = e.GetPosition(Board);
                short row = (short)(mousePosition.Y / rectSize);
                short col = (short)(mousePosition.X / rectSize);

                if (gameBrain.PlacePiece(row, col))
                {
                    Rectangle rec = (Rectangle)Board.Children[MAXCOLUMNS * row + col];
                    if (gameBrain.isPlayer1Turn())
                        rec.Fill = player1.Fill;
                    else
                        rec.Fill = player2.Fill;
                    gameBrain.ChangeTurn();
                    
                }
                MakeRotationsVisible();
            }
        }

        private void RePaintBoard()
        {
            int[] tempBoard = gameBrain.GetBoard;
            for (int i = 0; i < BOARDSIZE; i++)
            {
                Rectangle rec = (Rectangle)Board.Children[i];
                
                if (tempBoard[i] == 1)
                    rec.Fill = player1.Fill;
                else if (tempBoard[i] == 2)
                    rec.Fill = player2.Fill;
                else
                    rec.Fill = Brushes.White;
            }
        }

        private void MakeRotationsVisible() 
        {
            btnClockWise1.Visibility = Visibility.Visible;
            btnCounterClockWise1.Visibility = Visibility.Visible;
            btnClockWise2.Visibility = Visibility.Visible;
            btnCounterClockWise2.Visibility = Visibility.Visible;
            btnClockWise3.Visibility = Visibility.Visible;
            btnCounterClockWise3.Visibility = Visibility.Visible;
            btnClockWise4.Visibility = Visibility.Visible;
            btnCounterClockWise4.Visibility = Visibility.Visible;
        }

        private void MakeRotationsHidden()
        {
            btnClockWise1.Visibility = Visibility.Hidden;
            btnCounterClockWise1.Visibility = Visibility.Hidden;
            btnClockWise2.Visibility = Visibility.Hidden;
            btnCounterClockWise2.Visibility = Visibility.Hidden;
            btnClockWise3.Visibility = Visibility.Hidden;
            btnCounterClockWise3.Visibility = Visibility.Hidden;
            btnClockWise4.Visibility = Visibility.Hidden;
            btnCounterClockWise4.Visibility = Visibility.Hidden;
        }

        private void btnCounterClockWise2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gameBrain.RotateBoard(false, 2);
            RePaintBoard();
            userMadeRotation = true;
            MakeRotationsHidden();
        }

        private void btnClockWise1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gameBrain.RotateBoard(true, 1);
            RePaintBoard();
            userMadeRotation = true;
            MakeRotationsHidden();
        }

        private void btnCounterClockWise1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gameBrain.RotateBoard(false, 1);
            RePaintBoard();
            userMadeRotation = true;
            MakeRotationsHidden();
        }

        private void btnClockWise2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gameBrain.RotateBoard(true, 2);
            RePaintBoard();
            userMadeRotation = true;
            MakeRotationsHidden();
        }

        private void btnClockWise3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gameBrain.RotateBoard(true, 3);
            RePaintBoard();
            userMadeRotation = true;
            MakeRotationsHidden();
        }

        private void btnCounterClockWise3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gameBrain.RotateBoard(false, 3);
            RePaintBoard();
            userMadeRotation = true;
            MakeRotationsHidden();
        }

        private void btnClockWise4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gameBrain.RotateBoard(true, 4);
            RePaintBoard();
            userMadeRotation = true;
            MakeRotationsHidden();
        }

        private void btnCounterClockWise4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gameBrain.RotateBoard(false, 4);
            RePaintBoard();
            userMadeRotation = true;
            MakeRotationsHidden();
        }
    }
}
