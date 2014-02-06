using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Pentago.GameCore
{
    class GameBrain
    {
        private Board board = null;
        private Player player1 = null;
        private Player player2 = null;

        public GameBrain(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            board = new Board();
        }

        public bool PlacePiece(short row, short col)
        {
            int player;
            if (player1.ActivePlayer)
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
                    if (rotateClockWise)
                        board.RotateQuad3ClockWise();
                    else
                        board.RotateQuad3CounterClockWise();
                    break;
                case 4:
                    if (rotateClockWise)
                        board.RotateQuad4ClockWise();
                    else
                        board.RotateQuad4CounterClockWise();
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
            return player1.ActivePlayer;
        }

        public void ChangeTurn()
        {
            if (player1.ActivePlayer)
            {
                player1.ActivePlayer = false;
                player2.ActivePlayer = true;
            }
            else
            {
                player1.ActivePlayer = true;
                player2.ActivePlayer = false;
            }
        }

        public int[] GetBoard
        {
            get { return board.GetBoard; }
        }
    }
}
