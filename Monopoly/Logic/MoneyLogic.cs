using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class MoneyLogic
    {
        private GameState mGame;
        public MoneyLogic(ref GameState game)
        {
            this.Game = game;
        }//GameLogic

        public GameState Game { get { return mGame; } private set { mGame = value; } }
    }
}
