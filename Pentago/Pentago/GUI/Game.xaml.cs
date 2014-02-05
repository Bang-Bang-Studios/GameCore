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
        GameBrain gameBrain = null;

        const int BOARDSIZE = 36;
        const int MAXCOLUMNS = 6;
        const int MAXROWS = 6;
        bool userMadeRotation = true;

        public Game()
        {
            InitializeComponent();
            PaintBoard();
            gameBrain = new GameBrain();

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
                        rec.Fill = Brushes.Green;
                    else
                        rec.Fill = Brushes.Blue;
                    gameBrain.ChangeTurn();
                }

                MakeRotationsVisible();
            }

        }

        private void RePaintBoard()
        {
            int[] tempBoard = gameBrain.GetBoard();
            for (int i = 0; i < BOARDSIZE; i++)
            {
                Rectangle rec = (Rectangle)Board.Children[i];
                
                if (tempBoard[i] == 1)
                    rec.Fill = Brushes.Green;
                else if (tempBoard[i] == 2)
                    rec.Fill = Brushes.Blue;
                else
                    rec.Fill = Brushes.White;
            }
        }

        private void MakeRotationsVisible() 
        {
            btnRight1.Visibility = Visibility.Visible;
            btnLeft1.Visibility = Visibility.Visible;
            btnLeft2.Visibility = Visibility.Visible;
            btnRight2.Visibility = Visibility.Visible;
        }

        private void MakeRotationsHidden()
        {
            btnRight1.Visibility = Visibility.Hidden;
            btnLeft1.Visibility = Visibility.Hidden;
            btnLeft2.Visibility = Visibility.Hidden;
            btnRight2.Visibility = Visibility.Hidden;
        }

        private void btnLeft2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gameBrain.RotateBoard(false, 2);
            RePaintBoard();
            userMadeRotation = true;
            MakeRotationsHidden();
        }

        private void btnRight1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gameBrain.RotateBoard(true, 1);
            RePaintBoard();
            userMadeRotation = true;
            MakeRotationsHidden();
        }

        private void btnLeft1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gameBrain.RotateBoard(false, 1);
            RePaintBoard();
            userMadeRotation = true;
            MakeRotationsHidden();
        }

        private void btnRight2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gameBrain.RotateBoard(true, 2);
            RePaintBoard();
            userMadeRotation = true;
            MakeRotationsHidden();
        }
    }
}
