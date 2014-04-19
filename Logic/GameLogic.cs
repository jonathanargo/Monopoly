using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monopoly
{
    public class GameLogic
    {
        public GameLogic(ref Monopoly monopoly)
        {
            this.Monopoly = monopoly;
            this.IsInitialized = false;
        }//GameLogic

        public bool IsInitialized { get; private set; }
        private Monopoly Monopoly { get; set; }
        private GameState Game { get; set; }
        private Player[] Players { get; set; }
        private CardLogic CardLogic { get; set; }
        private MoneyLogic MoneyLogic { get; set; }
        private UI UI { get; set;}


        //INITIALIZATION
        public void Initialize()
        //called by Monopoly, used to make sure all logic objects
        //are created, since both CardLogic and GameLogic need
        //references to each other
        {
            this.Game = this.Monopoly.ActiveGame;
            this.Players = this.Monopoly.ActiveGame.Players;
            this.MoneyLogic = this.Monopoly.MoneyLogic;
            this.CardLogic = this.Monopoly.CardLogic;
            this.UI = this.Monopoly.UI;
            this.IsInitialized = true;
        }//Initialize()

        public void GameFlow()
        {
            UI.UIDebug("GameFlow()");
            while (!Game.IsOver)
            {
                Turn();
                Game.TurnCount++;
            }
        }//GameFlow()

        public void Turn()
        {
            UI.UIDebug("Turn()");
            int roll = RollDice();
            bool rollWasDouble = Game.Doubles[Game.ActivePlayerID].LastRollWasDouble;

            if (Game.Players[Game.ActivePlayerID].IsJailed)
            {
                if (rollWasDouble)
                {
                    ReleaseFromJail(Game.ActivePlayerID);
                    AdvancePlayer(Game.ActivePlayerID, roll);
                }//if
                else 
                {
                    //Player remains in jail, does he want to use a GOOJ card? TODO
                    if ((Game.GetActivePlayer().JailFreeCards > 0) && (UI.JailCardDialog()))
                    {
                        ReleaseFromJail(Game.ActivePlayerID);
                        Turn();
                    }
                    else
                    {
                        UI.Display("You remain in jail.");
                    }
                }//else
            }
            else if (Game.Doubles[Game.ActivePlayerID].LastThreeWereDoubles()) //if player rolled his third double
            {
                SendToJail(Game.ActivePlayerID);
            }
            else //player is unjailed and didn't roll his third double
            {
                AdvancePlayer(Game.ActivePlayerID, roll);
            }//else

            if (rollWasDouble && !Game.Players[Game.ActivePlayerID].IsJailed) //if player rolled doubles, but didn't get sent to jail for it..
            {
                Turn();
            }//if

            ChangeActivePlayer(); //will fire after player didn't roll doubles, or is in jail.
            

        }//Turn()

        public void AdvancePlayer(int playerID, int numberOfSpaces)
        {
            UI.UIDebug("AdvancePlayer()");
            int finalPosition = Game.Players[playerID].Position + numberOfSpaces;

            //check for >40
            if (numberOfSpaces > 79)
            {
                UI.Error("Unable to advance the player more than 79 spaces.");
            }//if
            else if (finalPosition > 40)
            {
                finalPosition = 41 - numberOfSpaces;
                //Player has passed Go, so award $200
                PassGo(playerID);
            }
            else if (finalPosition <= 0) //to handle the -3 spaces card
            {
                Debug.WriteLine("finalPos = {0}, moving backwards by {1}", finalPosition, numberOfSpaces);
                finalPosition = 41 + numberOfSpaces;
            }


            Game.Players[playerID].Position = finalPosition;
            Land(Game.Board.BoardSpaces[Game.Players[Game.ActivePlayerID].Position].SpaceType);
        }//AdvancePlayer()

        public void Land(String spaceType)
        {
            UI.UIDebug("Land()");
            UI.LandMessage();
            switch (spaceType)
            {
                case "Property": case "Railroad" : case "Utility":
                    LandBuyable(false);
                    break;
                case "Luxury Tax":
                    LandLuxTax();
                    break;
                case "Income Tax":
                    LandIncTax();
                    break;
                case "Community Chest":
                    LandCard(0);
                    break;
                case "Chance":
                    LandCard(1);
                    break;
                case "Go To Jail":
                    SendToJail(Game.ActivePlayerID);
                    break;
                case "Free Parking": case "Jail": case "Go":
                    UI.NoAction(Game.GetActiveTile().Name);
                    break;
                default:
                    UI.Error("Land() unable to determine space type.");
                    break;
            }//switch            
            
        }//Land() //TODO

        public void StartGame()
        {
            UI.UIDebug("StartGame()");
            foreach (Deck d in Game.Decks)
            {
                d.ShuffleDeck(); //initalized cards in each deck
            }//foreach

            foreach (Player p in Game.Players)
            {
                p.Money = 1500;
                p.Position = 1;
            }//foreach

            int roll1 = RollDiceStart();
            int roll2 = RollDiceStart();

            while (roll1 == roll2) //reroll if both players get same result
            {
                for (int i = 0; i <= 1; i++)
                {
                    roll1 = RollDice();
                    roll2 = RollDice();
                }//for
            }//while

            if (roll1 > roll2)
            {
                Game.ActivePlayerID = 0;
            }
            else
            {
                Game.ActivePlayerID = 1;
            }

            System.Windows.Forms.MessageBox.Show("Player 1 rolled " + roll1 + " and Player 2 rolled " + roll2 + ", so Player " + Game.ActivePlayerID + " goes first.");
            GameFlow();
        }//StartGame()

        public void ChangeActivePlayer()
        {
            UI.UIDebug("ChangeActivePlayer()");
            int intActiveID = Game.ActivePlayerID;
            intActiveID++;
            if (intActiveID > (Game.Players.Count() - 1))
            {
                intActiveID = 0;
            }//if
            Game.ActivePlayerID = Game.Players[intActiveID].ID;
        }//ChangeActivePlayer()

        public int RollDice()
        {
            UI.UIDebug("RollDice()");
            Random rand = new Random();
            bool rolledDoubles = false;
            int roll1, roll2, rollSum;
            
            roll1 = rand.Next(1, 7);
            roll2 = rand.Next(1, 8);
            rollSum = roll1 + roll2;

            UI.Display(String.Format("You have rolled a {0} and a {1} ({2})", roll1, roll2, rollSum));

            if (roll1 == roll2)
            {
                rolledDoubles = true;
            }//if

            Game.Doubles[Game.ActivePlayerID].NextDouble(rolledDoubles);
            Game.LastRoll = rollSum;

            return rollSum;
        }//RollDice()

        public int RollDiceStart()
        {
            UI.UIDebug("RollDiceStart()");
            Random rand = new Random();
            int roll1, roll2, rollSum;

            roll1 = rand.Next(1, 7);
            roll2 = rand.Next(1, 8);
            rollSum = roll1 + roll2;

            return rollSum;
        }//RollDiceStart()

        public void AdvancePlayerToPosition(int playerID, int position)
        //used for handling some cards
        {
            int currentPos = Game.Players[playerID].Position;

            //if player will need to pass Go
            if (Game.Players[playerID].Position > position) { PassGo(playerID); }//if

            Game.Players[playerID].Position = position;
            Land(Game.Board.BoardSpaces[position].SpaceType);

        }//AdvancePlayerToPosition()

        public void AdvanceToPosCustom(int playerID, int position)
        //used for handling the "advance to railroad" and 
        //"advance to utility" cards, since they manually 
        //pay the owner a certain amount
        {
            int currentPos = Game.Players[playerID].Position;

            //if player will need to pass Go
            if (Game.Players[playerID].Position > position) { PassGo(playerID); }//if
            Game.Players[playerID].Position = position;
        }//AdvancePlayerToPositionCustomPay()

        public void PassGo(int playerID)
        {
            Game.Players[playerID].Money += 200;
        }//PassGo()

        public void SendToJail(int playerID)
        {
            UI.UIDebug("SendToJail()");
            Game.Players[playerID].Position = 11; //don't advancePlayer, don't pass go!
            Game.Players[playerID].IsJailed = true;
        }//SendToJail

        public void ReleaseFromJail(int playerID)
        {
            UI.UIDebug("ReleaseFromJail()");
            Game.Players[playerID].IsJailed = false;
        }//SendToJail

        public void LandBuyable(bool fromCard)
        {
            UI.UIDebug("LandBuyable()");
            int spaceIndex = Game.GetActivePlayer().Position;
            try
            {
                Tiles.BuyableSpace space = (Tiles.BuyableSpace)Game.GetActiveTile();

                if (space.OwnerID == -1) 
                    //no owner
                {
                    bool wantsToBuy = UI.BuyPropDialogue();

                    if (wantsToBuy && CanBuySpace(space))
                    {
                        MoneyLogic.BuySpace(space.Position, Game.GetActivePlayer().ID);
                        UI.BoughtSpace(Game.GetActivePlayer(), space);
                    }//if
                    else if (wantsToBuy && !CanBuySpace(space))
                    {
                        UI.Display("You do not have enough money to buy this property.");
                    }//else-if
                    else 
                        //doesn't want to buy
                    {
                        UI.Display("You don't buy the property.");
                    }//else
                }//if
                else if (space.OwnerID != Game.ActivePlayerID)
                    //you must pay rent
                {
                    switch (space.SpaceType){
                        case "Property":
                            OweRent((Tiles.Property)space);
                            break;
                        case "Railroad":
                            OweFare((Tiles.Railroad)space, fromCard);
                            break;
                        case "Utility":
                            OweBill((Tiles.Utility)space, fromCard);
                            break;
                    }//switch
                }//else-if
                else
                //You own the property
                {
                    String message = "You own this tile.";
                    UI.Display(message);
                }//else if
            }//try
            catch (InvalidCastException ex)
            {
                UI.Error("Invalid cast in LandBuyable()", ex);
            }//catch
        }//LandBuyable()

        private void LandLuxTax()
        {
            Player thisPlayer = Game.Players[Game.ActivePlayerID];
            MoneyLogic.ChangeMoney(thisPlayer.ID, -75);
            UI.Display("You must pay the bank 75$!");
        }//LandLuxTax()

        private void LandIncTax()
        {
            Debug.WriteLine("Player has landed on Income Tax");
            Player thisPlayer = Game.Players[Game.ActivePlayerID];
            TaxChoice choice = UI.ShowTaxDialog(thisPlayer.ID);
            if (choice == TaxChoice.TenPercent)
            {
                MoneyLogic.TaxTenPercent(thisPlayer);
            }//if
            else if (choice == TaxChoice.TwoHundred)
            {
                MoneyLogic.ChangeMoney(thisPlayer.ID, -200);
            }//else if
            else
            {
                UI.Error("Unable to determine tax type!");
            }//else
        }//LandIncTax()

        private void LandCard(int deckID)
            //Handles both Chance and Comm. Chest
        {
            UI.UIDebug("LandCard()");
            Card thisCard = Game.Decks[deckID].DrawCard();
            CardLogic.HandleCard(thisCard, Game.ActivePlayerID);
        }

        private void OweRent(Tiles.Property prop)
        {
            int rent = prop.CurrentRent();
            UI.UIPayPlayer(prop);
            MoneyLogic.PayPlayer(Game.ActivePlayerID, prop.OwnerID, rent);
        }//OweRent

        private void OweFare(Tiles.Railroad thisRR, bool fromCard)
        {
            Player owner = Game.Players[thisRR.OwnerID];
            int ownerRRs = owner.Railroads;
            int fare = (thisRR.BaseFare * ownerRRs);
            if (fromCard) { fare *= 2; } //for special Go To Nearest RR card
            UI.UIPayPlayer(thisRR, fare, fromCard);
            MoneyLogic.PayPlayer(Game.ActivePlayerID, thisRR.OwnerID, fare);
        }//OweFare

        private void OweBill(Tiles.Utility thisUtil, bool fromCard)
        {
            Player owner = Game.Players[thisUtil.OwnerID];
            int utilsOwned = Game.Players[thisUtil.OwnerID].Utilities;
            int roll = Game.LastRoll;
            if (fromCard)
            {
                utilsOwned = 2;
                Random rand = new Random();
                int roll1, roll2;
                roll1 = rand.Next(1, 7);
                roll2 = rand.Next(1, 7);
                roll = roll1 + roll2;
            }//if
            int bill = thisUtil.GetBill(roll, utilsOwned);
            UI.UIPayPlayer(thisUtil, bill, fromCard);
            MoneyLogic.PayPlayer(Game.ActivePlayerID, thisUtil.OwnerID, bill);
        }//OweBill

        public bool CanBuySpace(Tiles.BuyableSpace thisSpace)
            //For buying property when it's landed on
        {
            if ((thisSpace.OwnerID == -1) && (Game.GetActivePlayer().Money >= thisSpace.Cost))
            {
                return true;
            }
            return false;
        }//CanBuySpace(BuyableSpace)

        public bool CanAffordSpace(int buyerID, int cost)
            //for buying properties from other players
        {
            Player buyer = Game.Players[buyerID];
            Tiles.BuyableSpace thisProp = (Tiles.BuyableSpace)Game.Board.BoardSpaces[buyer.Position];
            if (buyer.Money >= cost)
            {
                return true;
            }
            return false;
        }//CanBuyProp(buyerID)

        public void EndGame(int winnerID)
        {
            Game.WinnerID = winnerID;
            Game.IsOver = true;
            //TODO: possibly disable controls?
        }

    }//GameLogic
}
