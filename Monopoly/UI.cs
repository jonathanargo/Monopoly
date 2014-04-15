using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    class UI
    {
        private GameState mGame;

        public UI(ref GameState game)
        {
            this.Game = game;
        }

        public GameState Game { get { return mGame; } private set { mGame = value; } }

        public bool BuyPropDialogue()
        {
            String tileName = Game.Board.BoardSpaces[Game.Players[Game.ActivePlayerID].Position].Name;
            DialogResult result = MessageBox.Show(Monopoly.ActiveForm, "Do you want to buy this property?" + Environment.NewLine + tileName, "Buy Property", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                return true;
            }
                return false;
        }//BuyPropDialogue

        public void Display(String message, String caption)
        {
            MessageBox.Show(message, caption);
        }//DisplayMessage
    }//UI
}
