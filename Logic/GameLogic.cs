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
        public GameLogic(Monopoly monopoly)
        {
            this.MonopolyRef = monopoly;
            this.IsInitialized = false;
        }//GameLogic

        public bool IsInitialized { get; private set; }
        private Monopoly MonopolyRef { get; set; }
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
            this.Game = this.MonopolyRef.ActiveGame;
            this.Players = this.MonopolyRef.ActiveGame.Players;
            this.MoneyLogic = this.MonopolyRef.MoneyLogic;
            this.CardLogic = this.MonopolyRef.CardLogic;
            this.UI = this.MonopolyRef.UI;
            this.IsInitialized = true;
        }//Initialize()

        public void Turn(int roll)
        {
            bool rollWasDouble = Game.Doubles[Game.ActivePlayerID].LastRollWasDouble;

            if (Game.Players[Game.ActivePlayerID].IsJailed)
            {
                UI.UIDebug("Roll()- player is in jail");
                
                if (rollWasDouble)
                {
                    UI.UIDebug("Player " + Game.GetActivePlayer().GameID + " is released from jail, since he rolled a double");
                    ReleaseFromJail(Game.ActivePlayerID);
                    AdvancePlayer(Game.ActivePlayerID, roll);
                }//if
                else 
                {
                    //Player remains in jail, does he want to use a GOOJ card? TODO buggy
                    UI.UIDebug("Player remains in jail, since he didn't roll a double");
                    if ((Game.GetActivePlayer().JailFreeCards > 0) && (UI.JailCardDialog()))
                    {
                        UI.UIDebug("Player used a GOOJ card to leave jail");
                        Game.GetActivePlayer().JailFreeCards--;
                        ReleaseFromJail(Game.ActivePlayerID);
                        Turn(roll);
                    }
                    else
                    {
                        UI.Display("You remain in jail.");
                    }
                }//else
            }
            else if (Game.Doubles[Game.ActivePlayerID].LastThreeWereDoubles()) //if player rolled his third double
            {
                UI.UIDebug("Player " + Game.GetActivePlayer().GameID + " was sent to jail because he rolled 3 doubles");
                SendToJail(Game.ActivePlayerID);
            }
            else //player is unjailed and didn't roll his third double
            {
                AdvancePlayer(Game.ActivePlayerID, roll);
            }//else

            if (!rollWasDouble || Game.GetActivePlayer().IsJailed)
            {
                //Only go to next player if the player didn't roll doubles, unless
                //the player got sent to jail for rolling doubles.
                ChangeActivePlayer();
            }//if

            UI.UpdateStats();
            UI.PromptTurn();
            MonopolyRef.EnableRollButton();
        }//Turn()

        public void AdvancePlayer(int playerID, int numberOfSpaces)
        {
            UI.UIDebug(String.Format("Advancing player {0} by {1} spaces", playerID + 1, numberOfSpaces));
            int finalPosition = Game.Players[playerID].Position + numberOfSpaces;
            int firstPosition = Game.Players[playerID].Position;
            Tiles.BoardSpace startSpace = Game.Board.BoardSpaces[firstPosition];

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
                finalPosition = 41 + numberOfSpaces;
            }
            //set endSpace after the finalspace has been determined
            Tiles.BoardSpace endSpace = Game.Board.BoardSpaces[finalPosition];

            Game.Players[playerID].Position = finalPosition;
            UI.UIDebug(String.Format("Player {0} was moved {1} spaces from {2}({3}) to {4}({5})", playerID + 1, 
                numberOfSpaces, firstPosition, startSpace.Name, finalPosition, endSpace.Name));
            Land(Game.Board.BoardSpaces[Game.Players[Game.ActivePlayerID].Position].SpaceType);
        }//AdvancePlayer()

        public void Land(String spaceType)
        {
            UI.UpdateStats();
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
        }//Land()

        public void StartGame()
        {
            UI.UIDebug("Game is starting...");
            foreach (Deck d in Game.Decks)
            {
                d.ShuffleDeck(); //initalized cards in each deck
            }//foreach

            foreach (Player p in Game.Players)
            {
                p.Money = 1500;
                p.Position = 1;
            }//foreach
            UI.UpdateStats();
            UI.DisplayNoCaption("Each player will roll to see who goes first. Player 1, you start.");
            UI.ActivePlayerChanged();
            MonopolyRef.DisableStartButton();
            MonopolyRef.EnableRollButton();
        }

        public void ChangeActivePlayer()
        {
            int intActiveID = Game.ActivePlayerID;
            intActiveID++;
            if (intActiveID > (Game.Players.Count() - 1))
            {
                intActiveID = 0;
            }//if
            Game.ActivePlayerID = Game.Players[intActiveID].ID;
            UI.ActivePlayerChanged();
        }//ChangeActivePlayer()

        public void Roll() //called every time the roll button is pressed
        {
            MonopolyRef.DisableRollButton();
            UI.UIDebug("Begin Roll()");

            if (Game.IsStarted)
            {
                int roll = RollDice();
                Turn(roll);
            }//if
            else
            {
                UI.UIDebug("Roll-off commencing");
                RollOff();
            }//else
        }//Roll()

        public void RollOff()
            //called by Roll() when roll-off hasn't been completed
        {
            int roll = RollDiceStart();
            if (Game.StartingRolls[0] == 0) //Player 1 hasn't rolled to see who goes first
            {                
                Game.StartingRolls[0] = roll;                
                UI.DisplayNoCaption("Player 1 has rolled a " + roll);
                UI.DisplayNoCaption("Player 2, now you roll.");
                ChangeActivePlayer();
                MonopolyRef.EnableRollButton();
            }
            else if (Game.StartingRolls[1] == 0) //Player 1 has already rolled
            {
                Game.StartingRolls[1] = roll;
                UI.DisplayNoCaption("Player 2 has rolled a " + roll);

                if (Game.StartingRolls[0] == Game.StartingRolls[1])
                {
                    //reset the roll-off to the start
                    Game.StartingRolls[0] = 0;
                    Game.StartingRolls[1] = 0;
                    UI.DisplayNoCaption("Both players have rolled a " + roll + ", so they'll both roll again");
                    ChangeActivePlayer();
                    MonopolyRef.EnableRollButton();
                }
                else //not the same roll
                {
                    int firstTurnPlayer = 0;
                    if (Game.StartingRolls[1] > Game.StartingRolls[0]) { firstTurnPlayer = 1; }
                    Game.ActivePlayerID = firstTurnPlayer;
                    UI.ActivePlayerChanged();
                    UI.DisplayNoCaption(String.Format("Player 1 rolled a {0} and Player 2 rolled a {1}, so Player {2} will go first!",
                        Game.StartingRolls[0], Game.StartingRolls[1], Game.ActivePlayerID + 1));
                    Game.IsStarted = true;
                    UI.UIDebug("Game was started, roll off is complete.");
                    MonopolyRef.EnableRollButton();
                    UI.PromptTurn();
                }//else
            }//else if
        }//RollOff()

        public int RollDice()
        {
            Random rand = new Random();
            bool rolledDoubles = false;
            int roll1, roll2, rollSum;
            
            roll1 = rand.Next(1, 7);
            roll2 = rand.Next(1, 8);
            rollSum = roll1 + roll2;
            UI.UIDebug(String.Format("A {0} and a {1} were rolled", roll1, roll2));

            UI.Display(String.Format("You have rolled a {0} and a {1} ({2})", roll1, roll2, rollSum));

            if (roll1 == roll2)
            {
                rolledDoubles = true;
            }//if

            Game.Doubles[Game.ActivePlayerID].NextDouble(rolledDoubles);
            UI.UIDebug("Enqueued " + rolledDoubles + " in the doubles queue for player " + Game.GetActivePlayer().GameID);
            Game.LastRoll = rollSum;

            return rollSum;
        }//RollDice()

        public int RollDiceStart()
        {
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

            //Change the active player if this player didn't roll a double, 
            //or if he landed in jail (probably for rolling 3 doubles)
            if ((!Game.Doubles[Game.ActivePlayerID].LastRollWasDouble) || (Game.GetActivePlayer().IsJailed))
            {
                ChangeActivePlayer();
            }//if

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

            //Change the active player if this player didn't roll a double, 
            //or if he landed in jail (probably for rolling 3 doubles)
            if ((!Game.Doubles[Game.ActivePlayerID].LastRollWasDouble) || (Game.GetActivePlayer().IsJailed))
            {
                ChangeActivePlayer();
            }//if

        }//AdvancePlayerToPositionCustomPay()

        public void PassGo(int playerID)
        {
            UI.PassGo();
            MoneyLogic.ChangeMoney(playerID, 200);
        }//PassGo()

        public void SendToJail(int playerID)
        {
            Game.Players[playerID].Position = 11; //don't advancePlayer, don't pass go!
            Game.Players[playerID].IsJailed = true;
            //TODO: UI popup
        }//SendToJail

        public void ReleaseFromJail(int playerID)
        {
            Game.Players[playerID].IsJailed = false;
            UI.UIDebug(String.Format("Player {0} was released from jail", playerID + 1));
            //TODO: UI Popup
        }//SendToJail

        public void LandBuyable(bool fromCard)
        {
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

        public int TestMethod()
        {
            return MonopolyRef.TestState;
        }

    }//GameLogic
}
