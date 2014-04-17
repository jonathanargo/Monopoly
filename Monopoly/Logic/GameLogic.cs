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


        public void Turn()
        {            
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
            

        }//Turn() TODO

        public void AdvancePlayer(int playerID, int numberOfSpaces)
        {
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
            UI.LandMessage();
            switch (spaceType)
            {
                case "Property":
                    LandProperty();
                    break;
                case "Railroad":
                    LandRailroad();
                    break;
                case "Utility":
                    LandUtility(Game.LastRoll);
                    break;
                case "Luxury Tax":
                    LandLuxTax();
                    break;
                case "Income Tax":
                    LandIncTax();
                    break;
                case "Community Chest":
                    LandComChest();
                    break;
                case "Chance":
                    LandChance();
                    break;
                case "Go To Jail":
                    SendToJail(Game.ActivePlayerID);
                    break;
                case "Free Parking": case "Jail": case "Go":
                    UI.NoAction(spaceType);
                    break;
                default:
                    UI.Error("Land() unable to determine space type.");
                    break;
            }//switch            
            
        }//Land() //TODO

        public void StartGame()
        {
            int[] Roll = new int[2];
            int[] RollResult = new int[2];
            Random mRand = new Random();

            foreach (Deck d in Game.Decks)
            {
                d.ShuffleDeck(); //initalized cards in each deck
            }//foreach

            foreach (Player p in Game.Players)
            {
                p.Money = 1500;
                p.Position = 1;
            }//foreach

            RollResult[0] = 0;
            RollResult[1] = 0;

            while (RollResult[0] == RollResult[1]) //reroll if both players get same result
            {
                for (int i = 0; i <= 1; i++)
                {
                    Roll[0] = mRand.Next(1, 7);
                    Roll[1] = mRand.Next(1, 7);
                    RollResult[i] = Roll.Sum();
                }//for
            }//while

            if (RollResult[0] > RollResult[1])
            {
                Game.ActivePlayerID = 0;
            }
            else
            {
                Game.ActivePlayerID = 1;
            }

            System.Windows.Forms.MessageBox.Show("Player 1 rolled " + RollResult[0] + " and Player 2 rolled " + RollResult[1] + ", so Player " + Game.ActivePlayerID + " goes first.");

        }//StartGame()

        public void ChangeActivePlayer()
        {
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
            Random rand = new Random();
            bool rolledDoubles = false;
            int roll1, roll2, rollSum;
            
            roll1 = rand.Next(1, 7);
            roll2 = rand.Next(1, 8);
            rollSum = roll1 + roll2;

            UI.Display(String.Format("You have rolled a {0} and a {1} ({2})", roll1, roll2, rollSum), String.Format("Player {0}: Dice Roll", Game.ActivePlayerID + 1));

            if (roll1 == roll2)
            {
                rolledDoubles = true;
            }//if

            Game.Doubles[Game.ActivePlayerID].NextDouble(rolledDoubles);
            Game.LastRoll = rollSum;

            return rollSum;
            //Roll dice
        }//RollDice() TODO

        public void AdvancePlayerToPosition(int playerID, int position)
        //used for handling some cards
        {
            int currentPos = Game.Players[playerID].Position;

            //if player will need to pass Go
            if (Game.Players[playerID].Position > position) { PassGo(playerID); }//if

            Game.Players[playerID].Position = position;
            Land(Game.Board.BoardSpaces[position].SpaceType);

        }//AdvancePlayerToPosition()

        public void AdvanceToPositionCustomPay(int playerID, int position)
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
            Game.Players[playerID].Position = 11; //don't advancePlayer, don't pass go!
            Game.Players[playerID].IsJailed = true;
        }//SendToJail

        public void ReleaseFromJail(int playerID)
        {
            Game.Players[playerID].IsJailed = false;
        }//SendToJail
        /*
        LandProperty();
                    LandRailroad();
                    LandUtility();
                    LandLuxTax();
                    LandIncTax();
                    LandComChest();*/

        private void LandProperty()
        {
            try
            {
                int spaceIndex = Game.Players[Game.ActivePlayerID].Position;
                Tiles.Property prop = (Tiles.Property)Game.Board.BoardSpaces[spaceIndex];

                if (prop.OwnerID == -1) 
                    //interpreted as no owner
                {
                    bool wantsToBuy = UI.BuyPropDialogue();
                    if (wantsToBuy && CanBuyProp())
                    {                       
                        MoneyLogic.BuyProp(prop.Position, Game.ActivePlayerID);
                        String message = String.Format("You have bought {0}!", prop.Name);
                        String caption = String.Format("You bought a property!");
                        UI.Display(message, caption);
                    }
                    else if (wantsToBuy && !CanBuyProp())
                    {
                        UI.Display("You do not have enough money to buy this property.", "Can't afford property");
                    }//else
                    else
                    //He doesn't want to buy it
                    {
                        UI.Display("You don't buy the property.", String.Format("Player {0}: Not buying it", Game.ActivePlayerID + 1));
                    }
                }//if
                else if (prop.OwnerID != Game.ActivePlayerID)
                    //You must pay rent
                {
                    int rent = prop.CurrentRent();
                    UI.UIPayPlayer(prop);
                    MoneyLogic.PayPlayer(Game.ActivePlayerID, prop.OwnerID, rent);
                }//else if
                else
                //You own the property
                {
                    String message = "You own this property.";
                    String caption = String.Format("Player {0}: Your Property", Game.ActivePlayerID + 1);
                    UI.Display(message, caption);
                }//else if
            }
            catch (InvalidCastException ex)
            {
                UI.Error("Invalid cast in GameLogic.LandProperty()", ex);
            }
            catch (Exception ex)
            {
                UI.UnknownException(ex, "GameLogic.LandProperty()");
            }
            
        }//TODO

        private void LandRailroad()
        {
            int spaceIndex = Game.Board.BoardSpaces[Game.Players[Game.ActivePlayerID].ID].Position;
            try
            {
                Tiles.Railroad thisRR = (Tiles.Railroad)Game.Board.BoardSpaces[spaceIndex];

                if (thisRR.OwnerID == -1)
                {
                    bool wantsToBuy = UI.BuyPropDialogue();
                    if ((wantsToBuy && CanBuyProp()))
                    {
                        MoneyLogic.BuyRailroad(thisRR.Position, Game.ActivePlayerID);
                    }
                    else if ((wantsToBuy) && (!CanBuyProp()))
                    {
                        UI.CantAfford();
                    }
                    else
                    //He doesn't want to buy it
                    {
                        UI.Display("You don't buy the railroad", String.Format("Player {0}: Not buying it", Game.ActivePlayerID + 1));
                    }
                }
                else if (thisRR.OwnerID != Game.ActivePlayerID)
                //Must pay railroad owner
                {
                    Player owner = Game.Players[thisRR.OwnerID];
                    int ownerRRs = owner.Railroads;
                    int fare = (thisRR.BaseFare * ownerRRs);
                    UI.UIPayPlayer(thisRR, fare);
                    MoneyLogic.PayPlayer(Game.ActivePlayerID, thisRR.OwnerID, fare);
                }//else if
                else
                //This railroad belongs to the player!
                {
                    String message = "You own this railroad. No action required.";
                    String caption = String.Format("Player {0}: Your railroad", Game.ActivePlayerID + 1);
                    UI.Display(message, caption);
                }//else
            }
            catch (InvalidCastException ex)
            {
                UI.Error("Invalid cast in GameLogic.LandRailroad()", ex);
            }
            catch (Exception ex)
            {
                UI.UnknownException(ex, "GameLogic.LandRailroad()");
            }
        }//TODO

        private void LandUtility(int roll)
        {
            int spaceIndex = Game.Board.BoardSpaces[Game.Players[Game.ActivePlayerID].ID].Position;
            Tiles.Utility thisUtil;
            try
            {
                thisUtil = (Tiles.Utility)Game.Board.BoardSpaces[spaceIndex];
                if (thisUtil.OwnerID == -1)
                {
                    bool wantsToBuy = UI.BuyPropDialogue();
                    if ((wantsToBuy && CanBuyProp()))
                    {
                        MoneyLogic.BuyRailroad(thisUtil.Position, Game.ActivePlayerID);
                    }
                    else if ((wantsToBuy) && (!CanBuyProp()))
                    {
                        UI.CantAfford();
                    }
                    else
                    //He doesn't want to buy it
                    {
                        UI.Display("You don't buy the ultility.", String.Format("Player {0}: Not buying it", Game.ActivePlayerID + 1));
                    }
                }
                else if (thisUtil.OwnerID != Game.ActivePlayerID)
                //Must pay utility owner
                {
                    Player owner = Game.Players[thisUtil.OwnerID];
                    int ownerRRs = owner.Railroads;
                    int utilsOwned = Game.Players[thisUtil.OwnerID].Utilities;
                    int bill = thisUtil.GetBill(roll, utilsOwned);
                    UI.UIPayPlayer(thisUtil, bill);
                    MoneyLogic.PayPlayer(Game.ActivePlayerID, thisUtil.OwnerID, bill);
                }//else if
                else
                //This utility belongs to the player!
                {
                    String message = "You own this utility. No action required.";
                    String caption = String.Format("Player {0}: Your utility", Game.ActivePlayerID + 1);
                    UI.Display(message, caption);
                }//else
            }//LandUtility(roll)
            catch (InvalidCastException ex)
            {
                UI.Error("Invalid cast in GameLogic.LandUtility()", ex);
            }
            catch (Exception ex)
            {
                UI.UnknownException(ex, "GameLogic.LandUtility()");
            }
        }//LandUtility()

        private void LandLuxTax()
        {
            Player thisPlayer = Game.Players[Game.ActivePlayerID];
            MoneyLogic.ChangeMoney(thisPlayer.ID, -75);
            UI.Display("You must pay the bank 75$!", UI.MakeCaption(thisPlayer.GameID, "Pay Luxury Tax"));
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
        }//TODO

        private void LandComChest()
        {
        }//TODO

        private void LandChance()
        {
        }//TODO

        public bool CanBuyProp()
            //For buying property when it's landed on
        {
            Player thisPlayer = Game.Players[Game.ActivePlayerID];
            Tiles.Property thisProp = (Tiles.Property)Game.Board.BoardSpaces[thisPlayer.Position];            
            
            if((thisProp.OwnerID == -1) && (thisPlayer.Money >= thisProp.Cost)) //interpreted as no owner
            {
                return true;
            }           

            return false;
        }//CanBuyProp()

        public bool CanBuyProp(int buyerID, int cost)
            //for buying properties from other players
        {
            Player buyer = Game.Players[buyerID];
            Tiles.Property thisProp = (Tiles.Property)Game.Board.BoardSpaces[buyer.Position];
            if (buyer.Money >= cost)
            {
                return true;
            }
            return false;
        }//CanBuyProp(buyerID)

    }//GameLogic
}
