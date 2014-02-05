using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Pentago.GameCore
{
    class Player
    {
        public string name;
        public bool activePlayer;
        public Brush Fill;

        public Player(string name, bool activaTurn, Brush color)
        {
            this.name = name;
            this.activePlayer = activaTurn;
            this.Fill = color;
        }
    }
}