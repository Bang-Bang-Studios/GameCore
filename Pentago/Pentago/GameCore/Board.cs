using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Pentago.GameCore
{
    class Board
    {
        public const int BOARDSIZE = 36;
        public const int BOARWIDTH = 6;
        public int[] board = new int[BOARDSIZE];
        

        public Board()
        {
            for (int i = 0; i < BOARDSIZE; i++) 
            {
                this.board[i] = 0;
            }
        }

        public int GetPlayer(short row, short col)
        {
            return board[BOARWIDTH * row + col]; 
        }

        public int[] GetBoard()
        {
            return board;
        }

        public short PiecesOnBoard()
        {
            short count = 0;
            for (int i = 0; i < BOARDSIZE; i++)
            {
                if (board[i] == 0)
                    count++;
            }
            return count;
        }

        public void ClearBoard()
        {
            for (int i = 0; i < BOARDSIZE; i++)
            {
                this.board[i] = 0;
            }
        }

        public void UpdateBoard(short row, short col, int player)
        {
            this.board[BOARWIDTH * row + col] = player;
        }

        public void RotateQuad1ClockWise() 
        {
            int placeHolder = board[0];

            board[0] = board[12];
            board[12] = board[14];
            board[14] = board[2];
            board[2] = placeHolder;

            placeHolder = board[6];
            board[6] = board[13];
            board[13] = board[8];
            board[8] = board[1];
            board[1] = placeHolder;
        }

        public void RotateQuad1CounterClockWise()
        {
            int placeHolder = board[0];

            board[0] = board[2];
            board[2] = board[14];
            board[14] = board[12];
            board[12] = placeHolder;

            placeHolder = board[6];
            board[6] = board[1];
            board[1] = board[8];
            board[8] = board[13];
            board[13] = placeHolder;
        }

        public void RotateQuad2ClockWise()
        {

            int placeHolder = board[3];

            board[3] = board[15];
            board[15] = board[17];
            board[17] = board[5];
            board[5] = placeHolder;

            placeHolder = board[4];
            board[4] = board[9];
            board[9] = board[16];
            board[16] = board[11];
            board[11] = placeHolder;
        }

        public void RotateQuad2CounterClockWise()
        {
            int placeholder = board[3];

            board[3] = board[5];
            board[5] = board[17];
            board[17] = board[15];
            board[15] = placeholder;

            placeholder = board[4];
            board[4] = board[11];
            board[11] = board[16];
            board[16] = board[9];
            board[9] = placeholder;
        }
    }
}
