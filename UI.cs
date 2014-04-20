using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Monopoly
{
    public class UI
    {
        public UI()
        {
            this.HasRef = false;
            //Nothing required, just for showing errors and messages
        }

        public UI(ref Monopoly monopoly)
        {
            this.MonopolyRef = monopoly;
            this.Game = MonopolyRef.ActiveGame;
            this.HasRef = true;
        }//UI

        private Monopoly MonopolyRef { get; set; }
        private GameState Game { get; set; }
        public bool HasRef { get; set; }

        public void Display(String message)
        {
            String caption = String.Empty;
            try
            {
                caption = String.Format("Player {0}: ", Game.GetActivePlayer().GameID);
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Error in Display()" + ex.Message);
            }//catch

            MonopolyRef.HandleOutput(caption + message);
            UIDebug(caption + message);
        }//DisplayMessage

        public void DisplayNoCaption(String message)
        {
            MonopolyRef.HandleOutput(message);
            UIDebug(message);
        }//DisplayNoHeader

        public void DisplayPopup(String message, String boxCaption)
        {
            Display(message);
            String caption = "Info";
            try
            {
                caption = String.Format("Player {0}: {1}", Game.GetActivePlayer().GameID, boxCaption);
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Null reference in DisplayPopup");
                ex.GetType(); //just to clear "not used" error
            }
            MessageBox.Show(message, caption);
        }//DisplayPopup

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

        public void NoAction(String spaceName)
        {
            String message = String.Format("You have laneded on {0}. Enjoy your stay!", spaceName);
            Display(message);
        }//NoAction

        public void LandMessage()
        {
            Player thisPlayer = Game.GetActivePlayer();
            Tiles.BoardSpace thisTile = Game.GetActiveTile();
            String message = String.Format("You have landed on {0}", thisTile.Name);
            Display(message);
        }//LandMessage()

        public void CantAfford()
        {
            Player thisPlayer = Game.Players[Game.ActivePlayerID];
            Tiles.BoardSpace thisTile = Game.Board.BoardSpaces[thisPlayer.Position];
            Display("You can't afford to buy this property!");
        }//CantAfford()

        public void UIPayPlayer(Tiles.Property prop)
        {
            if (HasRef)
            {
                int rent = prop.CurrentRent();
                String message = String.Format("You pay player {0} ${1} for landing on {2}.", prop.OwnerID + 1, rent, prop.Name);
                DisplayPopup(message, "Pay Opponent");
            }//if
            else
            {
                UIRefError("UIPayPlayer()");
            }//else
        }//PlayPlayer(Tiles.Property)

        public void UIPayPlayer(Tiles.Railroad thisRR, int fare, bool fromCard)
        {
            if (HasRef)
            {
                String message = String.Format("You pay player {0} ${1} for landing on {2}.", thisRR.OwnerID + 1, fare, thisRR.Name);
                if (fromCard)
                {
                    message += " You pay double, per the card.";
                }
                DisplayPopup(message, "Pay Opponent");
            }//if
            else
            {
                UIRefError("UIPayPlayer()");
            }//else
        }//PlayPlayer(Tiles.Railroad)

        public void UIPayPlayer(Tiles.Utility thisUtil, int bill, bool fromCard)
        {
            if (HasRef)
            {
                String message = String.Format("You pay player {0} ${1} for landing on {2}.", thisUtil.OwnerID + 1, bill, thisUtil.Name);
                if (fromCard)
                {
                    message += String.Format(" You pay ten times your dice roll of {0}, per the card.", bill/10);
                }//if
                DisplayPopup(message, "Pay Opponent");
            }//if
            else
            {
                UIRefError("UIPayPlayer(Tiles.Utility)");
            }//else
        }//PlayPlayer(Tiles.Railroad)

        public void BankExchange(int amount)
        {
            String message;
            if (amount <= 0)
            {
                message = String.Format("Bank collected {0} dollars from Player {1}", amount, Game.GetActivePlayer().GameID);
            } else 
            {
                message = String.Format("Bank gave {0} dollars to Player {1}", amount, Game.GetActivePlayer().GameID);
            }//if-else
            UIDebug(message);
        }//BankExchange();

        public void PromptTurn()
        {
            DisplayNoCaption(String.Format("Player {0}, it's your turn", Game.GetActivePlayer().GameID));
        }

        public void CardDrawn(Card card)
        {
            String deck;
            if (card.CardID > 16) { deck = "Chance"; }//if
            else { deck = "Community Chest"; }

            Display("You draw a " + deck + " card.");

            String cap = String.Format("Player {0}: {1}", Game.GetActivePlayer().GameID, deck);
            String msg = "You drew a card. " + Environment.NewLine + "It says: " + card.Description;
            DisplayPopup(msg, cap);
        }//CardDrawn()

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

        public void BoughtSpace(Player player, Tiles.BuyableSpace space)
        {
            String msg = String.Format("You bought {0}!", space.Name);
            Display(msg);
        }//BoughtSpace

        public void GameOver(Player winner)
        {
            String msg = String.Format("Congratulations, player {0}, you win!", winner.GameID);
            DisplayPopup(msg, "You win!!!");
        }//GameOver

        public void PassGo()
        {
            String msg = "You have passed go! Collect $200!";
            DisplayPopup(msg, "Pass Go");
        }

        public void UpdateStats()
        {
            MonopolyRef.SyncPlayerStats();
        }//UpdateStats()

        public bool JailCardDialog()
        {
            String msg = "Would you like to use your Get Out of Jail Free card?";
            String cap = String.Format("Player {0}: Use Card?", Game.GetActivePlayer().GameID);
            DialogResult result = MessageBox.Show(Monopoly.ActiveForm, msg, cap, MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    UIDebug(String.Format("UI- Player {0} used a GOOJ card", Game.GetActivePlayer().GameID));
                    return true;
                default:
                    UIDebug(String.Format("UI- Player {0} chose to not use a GOOJ card", Game.GetActivePlayer().GameID));
                    return false;
            }//switch
        }//bool

        public void Error(String message)
        {
            message = "ERROR: " + message;
            MessageBox.Show(Monopoly.ActiveForm, message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            UIDebug(message);
        }//Error

        public void Error(String message, Exception ex)
        {
            message = "ERROR: " + message + Environment.NewLine + Environment.NewLine + ex.Message;
            MessageBox.Show(Monopoly.ActiveForm, message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            UIDebug(message + " " + ex.Message);
        }//Error

        public void ErrorNoDebug(String message)
            //used for displaying errors with the error writer
        {
            message = "ERROR: " + message;
            MessageBox.Show(Monopoly.ActiveForm, message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DateTime now = DateTime.Now;
            String timestamp = String.Empty;
            timestamp += now.ToString();
            Debug.WriteLine(timestamp + ": " + message);
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

        public void UIDebug(String message)
        {
            DateTime now = DateTime.Now;
            String timestamp = String.Empty;
            timestamp += now.ToString();
            String fullMessage = timestamp + ": " + message;
            Debug.WriteLine(fullMessage);
            WriteToLog(fullMessage);
        }//UIDebug

        public void ActivePlayerChanged()
        {
            MonopolyRef.IndicateActivePlayer();
        }//ActivePlayerChange

        public void WriteToLog(String message)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("Log.txt", true))
                {
                    file.WriteLine(message);
                }//using
            }//try
            catch (Exception ex)
            {
                ErrorNoDebug(ex.Message + ": Can not Write to Log");
            }//catch
        }
    }//UI
}
