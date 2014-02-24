using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Pentago.AI;

namespace Pentago.GUI
{
    public class GameOptions
    {
        public enum TypeOfGame { QuickMatch, Campaign, Network, AI };
        public TypeOfGame _TypeOfGame;

        //Human vs Human
        public string _Player1Name;
        public string _Player2Name;
        public ImageBrush _Player1Image;
        public ImageBrush _Player2Image;
        public GameOptions(TypeOfGame typeOfGame, string player1Name, ImageBrush player1Image, string player2Name, ImageBrush player2Image)
        {
            this._TypeOfGame = typeOfGame;
            this._Player1Name = player1Name;
            this._Player1Image = player1Image;
            this._Player2Name = player2Name;
            this._Player2Image = player2Image;
        }

        //Human vs AI
        public computerAI.Difficulty _Difficulty;
        public string _ComputerName;
        public ImageBrush _CopmuterImage;
        public GameOptions(TypeOfGame typeOfGame, string player1Name, ImageBrush player1Image, string computerName, ImageBrush computerImage, computerAI.Difficulty difficulty)
        {
            this._TypeOfGame = typeOfGame;
            this._Player1Name = player1Name;
            this._Player1Image = player1Image;
            this._ComputerName = computerName;
            this._CopmuterImage = computerImage;
            this._Difficulty = difficulty;
        }
         
    }
}
