using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CardLogic
    {
        private Player[] Players;
        private GameState mGame { get; set; }

        public CardLogic(ref GameState game)
        {
            this.Game = game;
            this.Players = game.Players;
        }//CardLogic

        //PROPERTIES
        public GameState Game { get { return mGame; } set { mGame = value; } } 

        //METHODS
        

    }//CardLogic
}
