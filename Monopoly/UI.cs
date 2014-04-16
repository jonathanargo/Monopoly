using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    public class UI
    {
        private GameState mGame;
        private bool mHasRef;

        public UI()
        {
            mHasRef = false;
            //Nothing required, just for showing errors and messages
        }

        public UI(ref GameState game)
        {
            this.Game = game;
            mHasRef = true;
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
            message = "ERROR: " + message + Environment.NewLine + Environment.NewLine + ex.Message;
            MessageBox.Show(Monopoly.ActiveForm, message,  ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }//Error

        public void UnknownException(Exception ex)
        {
            Error("Unknown Excpetion: " + ex.Message);
        }//UnknownException(Exception)

        public void UnknownException(Exception ex, String location)
        {
            String message = String.Format("Unknown error in {0}: {1}", location, ex.Message);
            Error(message);
        }//UnknownException(Exception, location)

        public void LandMessage()
        {
            Player thisPlayer = Game.Players[Game.ActivePlayerID];
            Tiles.BoardSpace thisTile = Game.Board.BoardSpaces[thisPlayer.Position];
            String message = String.Format("You have landed on {0}", thisTile.Name);
            String caption = String.Format("Player {0}: Landed on {1}", thisPlayer.ID + 1, thisTile.Name);
            Display(message, caption);
        }//LandMessage()

        public void CantAfford()
        {
            Player thisPlayer = Game.Players[Game.ActivePlayerID];
            Tiles.BoardSpace thisTile = Game.Board.BoardSpaces[thisPlayer.Position];
            Display("You can't afford to buy this property!", String.Format("Player {0}: Can't afford property", Game.ActivePlayerID + 1));
        }//CantAfford()

        public void PayPlayer(Tiles.Property prop)
        {
            if (mHasRef == true)
            {
                    int rent = prop.CurrentRent();
                    String message = String.Format("You pay player {0} ${1} for landing on {2}.", prop.OwnerID + 1, rent, prop.Name);
                    String caption = String.Format("Player {0}: Pay Rent", Game.ActivePlayerID + 1);
                    Display(message, caption);                                
            }//if
            else
            {
                Error("PayPlayer(Tiles.Property) can't be called by an instance of UI that wasn't passed a game!");
            }//else
        }//PlayPlayer(Tiles.Property)

        public void PayPlayer(Tiles.Railroad thisRR, int fare)
        {
            if (mHasRef == true)
            {
                String message = String.Format("You pay player {0} ${1} for landing on {2}.", thisRR.OwnerID + 1, fare, thisRR.Name);
                String caption = String.Format("Player {0}: Pay Railroad Fare", Game.ActivePlayerID + 1);
                Display(message, caption);
            }//if
            else
            {
                Error("PayPlayer(Tiles.Utility) can't be called by an instance of UI that wasn't passed a game!");
            }//else
        }//PlayPlayer(Tiles.Railroad)

        public void PayPlayer(Tiles.Utility thisUtil, int bill)
        {
            if (mHasRef == true)
            {
                String message = String.Format("You pay player {0} ${1} for landing on {2}.", thisUtil.OwnerID + 1, bill, thisUtil.Name);
                String caption = String.Format("Player {0}: Pay Utility Bill", Game.ActivePlayerID + 1);
                Display(message, caption);
            }//if
            else
            {
                Error("PayPlayer(Tiles.Utility) can't be called by an instance of UI that wasn't passed a game!");
            }//else
        }//PlayPlayer(Tiles.Railroad)
    }//UI
}
