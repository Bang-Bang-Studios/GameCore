using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Pentago.GameCore
{
    class GameBrain
    {
        Board board = null;
        Player player1 = null;
        Player player2 = null;
        Player emptyPlayer = null;

        public GameBrain()
        {
            emptyPlayer = new Player("EMPTY", false, Brushes.White);
            player1 = new Player("Player1", true, Brushes.Green);
            player2 = new Player("Player2", false, Brushes.Blue);
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            board = new Board();
        }

        public bool PlacePiece(short row, short col)
        {
            int player;
            if (player1.activePlayer)
                player = 1;
            else
                player = 2;

            if (ValidateMove(row, col))
            {
                board.UpdateBoard(row, col, player);
                return true;
            }
            else
            {
                //Show the user thats a bad move
                return false;
            }
        }

        public void RotateBoard(bool rotateClockWise, short quad)
        {
            switch (quad)
            {
                case 1:
                    if (rotateClockWise)
                        board.RotateQuad1ClockWise();
                    else
                        board.RotateQuad1CounterClockWise();
                    break;
                case 2:
                    if (rotateClockWise)
                        board.RotateQuad2ClockWise();
                    else
                        board.RotateQuad2CounterClockWise();
                    break;
                case 3:

                    break;
                case 4:

                    break;
                default:
                    break;
            }
        }

        private bool ValidateMove(short row, short col)
        {
            if (board.GetPlayer(row, col) == 0)
                return true;
            return false;
        }

        private bool CheckForWinner(Board baord)
        {
            return false;
        }

        private void GameOver()
        {
 
        }

        public bool isPlayer1Turn()
        {
            return player1.activePlayer;
        }

        public void ChangeTurn()
        {
            if (player1.activePlayer)
            {
                player1.activePlayer = false;
                player2.activePlayer = true;
            }
            else
            {
                player1.activePlayer = true;
                player2.activePlayer = false;
            }
        }

        public int[] GetBoard()
        {
            return board.GetBoard();
        }
    }
}
