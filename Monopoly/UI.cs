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

        public UI()
        {
            //Nothing required, just for showing errors and messages
        }

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

        public void NoAction(String spaceType)
        {
            MessageBox.Show(String.Format("You have laneded on {0}. Enjoy your stay!", spaceType), String.Format("Player {0}: {1}", Game.ActivePlayerID + 1, spaceType));
        }//NoAction

        public void Error(String message)
        {
            message = "ERROR: " + message;
            MessageBox.Show(Monopoly.ActiveForm, message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }//Error

        public void Error(String message, Exception ex)
        {
            message = "ERROR: " + message;
            MessageBox.Show(Monopoly.ActiveForm, message,  ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }//Error

    }//UI
}
