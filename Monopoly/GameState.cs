using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    public class GameState
        //contains the majority of the game logic, as well as the game elements
        //creates the board, deck, and players
    {
        private Board mBoard;
        private int mTurnCount;
        private Player[] mPlayers;
        private Player mActivePlayer;
        private Deck[] mDecks;
        private Random mRand;

        public GameState()
        {
            this.Board = new Board();
            this.Players = new Player[2];
            this.Decks = new Deck[2];

            TurnCount = 1;
            ActivePlayer = Players[1];

            Players[0] = new Player(0);
            Players[1] = new Player(1);

            Decks[0] = new Deck(1, DeckType.CommunityChest);
            Decks[1] = new Deck(2, DeckType.Chance);

        }//Game()       


        //PROPERTIES

        public Deck[] Decks { get { return mDecks; } set { mDecks = value; } }
        public Player[] Players { get { return mPlayers; } private set { mPlayers = value; } }
        public Board Board { get { return mBoard; } private set { mBoard = value; } }
        public Player ActivePlayer { get { return mActivePlayer; } set { mActivePlayer = value; } }        
        public int TurnCount { get { return mTurnCount; } set { mTurnCount = value; } }

        //METHODS


        //GAME FLOW

        public void Land(int playerID)
        {
            //logic for what happens when player lands on a space
        }//Land() //TODO

        public void PassGo(int playerID)
        {
            Players[playerID].Money += 200;
        }//PassGo()

        public void StartGame()
        {
            int[] Roll = new int[2];
            int[] RollResult = new int[2];
            mRand = new Random();

            foreach (Deck d in Decks)
            {
                d.ShuffleDeck(); //initalized cards in each deck
            }//foreach

            foreach (Player p in Players)
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
                ActivePlayer = Players[0];
            }
            else
            {
                ActivePlayer = Players[1];
            }

            System.Windows.Forms.MessageBox.Show("Player 1 rolled " + RollResult[0] + " and Player 2 rolled " + RollResult[1] + ", so Player " + (int)ActivePlayer.ID + " goes first.");

        }//StartGame()

        public void ChangeActivePlayer()
        {
            int intActiveID = ActivePlayer.ID;
            intActiveID++;
            if (intActiveID > (Players.Count() - 1))
            {
                intActiveID = 0;
            }//if
            ActivePlayer = Players[intActiveID];
        }//ChangeActivePlayer()

        public void AdvancePlayer(int playerID, int numberOfSpaces)
        {
            int finalPosition = Players[playerID].Position + numberOfSpaces;

            //check for >40
            if (finalPosition > 40)
            {
                finalPosition -= 40;
                //Player has passed Go, so award $200
                PassGo(playerID);
            }
            else if (finalPosition <= 0) //to handle the -3 spaces card
            {
                finalPosition += 40;
            }

            Players[playerID].Position = finalPosition;
            Land(playerID);
        }//AdvancePlayer()

        public void AdvancePlayerToPosition(int playerID, int position)
        //used for handling some cards
        {
            int currentPos = Players[playerID].Position;

            //if player will need to pass Go
            if (Players[playerID].Position > position) { PassGo(playerID); }//if

            Players[playerID].Position = position;
            Land(playerID);

        }//AdvancePlayerToPosition()

        public void AdvanceToPositionCustomPay(int playerID, int position)
        //used for handling the "advance to railroad" and 
        //"advance to utility" cards, since they manually 
        //pay the owner a certain amount
        {
            int currentPos = Players[playerID].Position;

            //if player will need to pass Go
            if (Players[playerID].Position > position) { PassGo(playerID); }//if

            Players[playerID].Position = position;
        }//AdvancePlayerToPositionCustomPay()

        public void SendToJail(int playerID)
        {
            Players[playerID].Position = 11; //don't advancePlayer, don't pass go!
            Players[playerID].IsJailed = true;
        }//SendToJail



        //CARD LOGIC

        public void HandleCard(Card card, int playerID)
            //Contains cases for handling all cards
        {
            switch (card.CardID)
            {
                case 0://Advance to Go
                    Players[playerID].Position = 1;
                    break;
                case 1://Collect 75$
                    CollectFromBank(playerID, 75);
                    break;
                case 2://Pay $50
                    CollectFromBank(playerID, -50); //need to check for bankruptcy
                    break;
                case 3://Get out of jail free
                    Players[playerID].JailFreeCards++;
                    break;
                case 4://Go to jail
                    Players[playerID].IsJailed = true;
                    Players[playerID].Position = 11;
                    break;
                case 5: //collect 10 from each player
                    CollectFromOtherPlayers(playerID, 10);
                    break;
                case 6://colect $50 from each player
                    CollectFromOtherPlayers(playerID, 50);
                    break;
                case 7://collect $20
                    CollectFromBank(playerID, 20);
                    break;
                case 8://collect 100
                    CollectFromBank(playerID, 100);
                    break;
                case 9: //pay 100
                    CollectFromBank(playerID, -100);
                    break;
                case 10://pay 50
                    CollectFromBank(playerID, -50);
                    break;
                case 11://collect 25
                    CollectFromBank(playerID, 25);
                    break;
                case 12://Street repairs, see method
                    Repairs(playerID, 40, 115);
                    break;
                case 13://collect 10
                    CollectFromBank(playerID, 10);
                    break;
                case 14://collect 100
                    CollectFromBank(playerID, 100);
                    break;
                case 15://collect 50
                    CollectFromBank(playerID, 50);
                    break;
                case 16://Collect 100;
                    CollectFromBank(playerID, 100);
                    break;
                case 17://Advance To Go
                    this.AdvancePlayerToPosition(playerID, 1);
                    break;
                case 18: //Advance To Illinois
                    this.AdvancePlayerToPosition(playerID, 25);
                    break;
                case 19://Advance To Utility (13 and 29), pay 10x dice roll
                    AdvanceToUtility(playerID);
                    break;
                case 20: //Advance to nearest railroad, pay double
                    AdvanceToRailroad(playerID);
                    break;
                case 21: //Advance To St Charles Place (12)
                    this.AdvancePlayerToPosition(playerID, 12);
                    break;
                case 22: //collect 50
                    CollectFromBank(playerID, 50);
                    break;
                case 23://Get out of Jail Free
                    Players[playerID].JailFreeCards++;
                    break;
                case 24://Go back three spaces
                    this.AdvancePlayer(playerID, -3);
                    break;
                case 25: //GoToJail
                    this.SendToJail(playerID);
                    break;
                case 26: //General repairs, see method
                    Repairs(playerID, 25, 100);
                    break;
                case 27: //Pay 15
                    CollectFromBank(playerID, 15);
                    break;
                case 28: //go to reading railroad
                    this.AdvancePlayerToPosition(playerID, 6);
                    break;
                case 29://Go to boardwalk
                    this.AdvancePlayerToPosition(playerID, 40);
                    break;
                case 30: //pay each player 50
                    CollectFromOtherPlayers(playerID, -50);
                    break;
                case 31://collect 150
                    CollectFromBank(playerID, 150);
                    break;
                case 32: //collect 100
                    CollectFromBank(playerID, 100);
                    break;
            }//switch
        }//HandleCard() TODO

        private void Repairs(int playerID, int perHouse, int perHotel)
        {
            //Player pays 40 per house and 115 per hotel
            int numHouses = 0;
            int numHotels = 0;
            int costToPlayer = 0;

            foreach (Tiles.BoardSpace b in this.Board.BoardSpaces)
            {
                if (b is Tiles.Property)
                {
                    Tiles.Property prop = (Tiles.Property)b;
                    //if it's owned by our player and it has an improvement...
                    if ((prop.OwnerID == Players[playerID].ID) && ((int)prop.ImprovementLevel > 0))
                    {
                        //if the improvement is a hotel
                        if ((int)prop.ImprovementLevel == 5)
                        {
                            numHotels++;
                        }
                        else
                        {
                            numHouses++;
                        }//ifelse
                    }//ifelse
                }//if
            }//foreach

            costToPlayer = -1 * ((numHouses * perHouse) + (numHotels * perHotel));
            CollectFromBank(playerID, costToPlayer);
        }//StreetRepairs

        public void AdvanceToUtility(int playerID)
        {
            int currentPos = Players[playerID].Position;
            int utilPos;

            if ((currentPos < 13) || (currentPos >= 29)) { utilPos = 13; }
            else { utilPos = 29; }//ifelse

            AdvanceToPositionCustomPay(playerID, utilPos);



        }//AdvanceToUtility() TODO

        public void AdvanceToRailroad(int playerID)
        {
            //TODO
        }//AdvanceToRailroad //TODO



        //MONEY LOGIC

        public void PayPlayer(int payerID, int recieverID, int amount)
        {
            ChangeMoney(payerID, -1 * amount);
            ChangeMoney(recieverID, amount);
        }//PayPlayer

        public void ChangeMoney(int playerID, int amount)
        {
            Players[playerID].Money += amount;
            CheckForBankrupt(playerID);
        }//ChangeMoney()

        public void CheckForBankrupt(int playerID)
        {
            //check to see if player has < 0 money. If so, mortgage properties
        }//CheckForBankrupt() //TODO

        private void CollectFromBank(int playerID, int amount)
        {
            Players[playerID].Money += amount;
        }//CollectFromBank

        private void CollectFromOtherPlayers(int playerID, int amount)
        //used for a few cards that have the player 
        //collecting money from all other players
        {
            foreach (Player p in Players)
            {
                if (p.ID != Players[playerID].ID)
                {
                    p.Money -= amount;
                    Players[playerID].Money += amount;
                }//if

            }//foreach
        }//CollectFromPlayers


        //TILE LOGIC

        public void GrantProperty(int propID, int playerID)
        {
            if (Board.BoardSpaces[propID] is Tiles.Property)
            {
                Tiles.Property propSpace = (Tiles.Property)Board.BoardSpaces[propID];
                propSpace.OwnerID = playerID;
                Board.BoardSpaces[propID] = propSpace;
            }
            else if (Board.BoardSpaces[propID] is Tiles.Railroad)
            {
                Tiles.Railroad rrSpace = (Tiles.Railroad)Board.BoardSpaces[propID];
                rrSpace.OwnerID = playerID;
                Board.BoardSpaces[propID] = rrSpace;
                Players[playerID].Railroads++;
            }
            else if (Board.BoardSpaces[propID] is Tiles.Utility)
            {
                Tiles.Utility utilSpace = (Tiles.Utility)Board.BoardSpaces[propID];
                utilSpace.OwnerID = playerID;
                Board.BoardSpaces[propID] = utilSpace;
                Players[playerID].Utilities++;
            }
            else
            {
                MessageBox.Show("ERROR in GrantPropert(): Property type doesn't support owners");
            }// if
        }//GrantProperty()

    }//class Game

}//Monopoly
