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

        public UI()
        {
            this.HasRef = false;
            //Nothing required, just for showing errors and messages
        }

        public UI(ref GameState game)
        {
            this.Game = game;
            this.HasRef = true;
        }

        public GameState Game { get { return mGame; } private set { mGame = value; } }
        public bool HasRef { get; set; }

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

        public void UIRefError(String functionName)
        {
            Error("Can't call " + functionName + " from an instance of UI that doesn't have a reference to the gamestate!");
        }//UIRefError

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

        public void UIPayPlayer(Tiles.Property prop)
        {
            if (HasRef)
            {
                    int rent = prop.CurrentRent();
                    String message = String.Format("You pay player {0} ${1} for landing on {2}.", prop.OwnerID + 1, rent, prop.Name);
                    String caption = String.Format("Player {0}: Pay Rent", Game.ActivePlayerID + 1);
                    Display(message, caption);                                
            }//if
            else
            {
                UIRefError("UIPayPlayer()");
            }//else
        }//PlayPlayer(Tiles.Property)

        public void UIPayPlayer(Tiles.Railroad thisRR, int fare)
        {
            if (HasRef)
            {
                String message = String.Format("You pay player {0} ${1} for landing on {2}.", thisRR.OwnerID + 1, fare, thisRR.Name);
                String caption = String.Format("Player {0}: Pay Railroad Fare", Game.ActivePlayerID + 1);
                Display(message, caption);
            }//if
            else
            {
                UIRefError("UIPayPlayer()");
            }//else
        }//PlayPlayer(Tiles.Railroad)

        public void UIPayPlayer(Tiles.Utility thisUtil, int bill)
        {
            if (HasRef)
            {
                String message = String.Format("You pay player {0} ${1} for landing on {2}.", thisUtil.OwnerID + 1, bill, thisUtil.Name);
                String caption = String.Format("Player {0}: Pay Utility Bill", Game.ActivePlayerID + 1);
                Display(message, caption);
            }//if
            else
            {
                UIRefError("UIPayPlayer(Tiles.Utility)");
            }//else
        }//PlayPlayer(Tiles.Railroad)

        public String MakeCaption(int playerGameNumber, String caption)
        {
            return String.Format("Player {0}: {1}", playerGameNumber, caption);
        }//MakeCaption()

        public TaxChoice ShowTaxDialog(int playerID)
        {
            if (HasRef)
            {
                Form taxForm = new TaxDialog();
                DialogResult result = taxForm.ShowDialog();
                    //TODO- clean this up. There's almost certainly a better way of handling it.
                if (result == DialogResult.OK)
                {
                    return TaxChoice.TenPercent;
                }
                else
                {
                    return TaxChoice.TwoHundred;
                }//if-else
            }//if
            else
            {
                UIRefError("ShowTaxDialog");
                return TaxChoice.Error;
            }//else
        }//ShowTaxDialog

        public void CardMessage(String message, String deckType)
        {
            Display(message, MakeCaption(Game.ActivePlayerID + 1, "Draw " + deckType));
        }//CardMessage()

    }//UI
}
