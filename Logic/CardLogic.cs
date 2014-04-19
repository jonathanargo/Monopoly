using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CardLogic
    {
        private Player[] Players;
        private GameState mGame { get; set; }
        private MoneyLogic mMoneyLogic;
        private GameLogic mGameLogic;

        public CardLogic(ref Monopoly monopoly)
        {
            this.Monopoly = monopoly;
            this.IsInitialized = false;
        }//CardLogic

        //PROPERTIES
        public GameState Game { get { return mGame; } set { mGame = value; } }
        public MoneyLogic MoneyLogic { get { return mMoneyLogic; } private set { mMoneyLogic = value; } }
        public GameLogic GameLogic { get { return mGameLogic; } private set { mGameLogic = value; } }
        private Monopoly Monopoly { get; set; }
        private UI UI { get; set; }
        public bool IsInitialized { get; private set; }

        //INITIALIZATION
        public void Initialize()
            //called by Monopoly, used to make sure all logic objects
            //are created, since both CardLogic and GameLogic need
            //references to each other
        {
            this.Game = this.Monopoly.ActiveGame;
            this.Players = this.Monopoly.ActiveGame.Players;
            this.GameLogic = this.Monopoly.GameLogic;
            this.MoneyLogic = this.Monopoly.MoneyLogic;
            this.UI = this.Monopoly.UI;
            this.IsInitialized = true;
        }//Initialize()

        //METHODS
        public void HandleCard(Card card, int playerID)
        //Contains cases for handling all cards
        {
            
            UI.CardDrawn(card);

            switch (card.CardID)
            {
                case 0://Advance to Go
                    GameLogic.AdvancePlayerToPosition(playerID, 1);
                    break;
                case 1://Collect 75$
                    MoneyLogic.CollectFromBank(playerID, 75);
                    break;
                case 2://Pay $50
                    MoneyLogic.CollectFromBank(playerID, -50);
                    break;
                case 3://Get out of jail free
                    Players[playerID].JailFreeCards++;
                    break;
                case 4://Go to jail
                    GameLogic.SendToJail(playerID);
                    break;
                case 5: //collect 10 from each player
                    MoneyLogic.CollectFromOtherPlayers(playerID, 10);
                    break;
                case 6://colect $50 from each player
                    MoneyLogic.CollectFromOtherPlayers(playerID, 50);
                    break;
                case 7://collect $20
                    MoneyLogic.CollectFromBank(playerID, 20);
                    break;
                case 8://collect 100
                    MoneyLogic.CollectFromBank(playerID, 100);
                    break;
                case 9: //pay 100
                    MoneyLogic.CollectFromBank(playerID, -100);
                    break;
                case 10://pay 50
                    MoneyLogic.CollectFromBank(playerID, -50);
                    break;
                case 11://collect 25
                    MoneyLogic.CollectFromBank(playerID, 25);
                    break;
                case 12://Street repairs, see method
                    Repairs(playerID, 40, 115);
                    break;
                case 13://collect 10
                    MoneyLogic.CollectFromBank(playerID, 10);
                    break;
                case 14://collect 100
                    MoneyLogic.CollectFromBank(playerID, 100);
                    break;
                case 15://collect 50
                    MoneyLogic.CollectFromBank(playerID, 50);
                    break;
                case 16://Collect 100;
                    MoneyLogic.CollectFromBank(playerID, 100);
                    break;
                case 17://Advance To Go
                    GameLogic.AdvancePlayerToPosition(playerID, 1);
                    break;
                case 18: //Advance To Illinois
                    GameLogic.AdvancePlayerToPosition(playerID, 25);
                    break;
                case 19://Advance To Utility (13 and 29), pay 10x dice roll
                    AdvanceToUtility(playerID);
                    break;
                case 20: //Advance to nearest railroad, pay double
                    this.AdvanceToRailroad(playerID);
                    break;
                case 21: //Advance To St Charles Place (12)
                    GameLogic.AdvancePlayerToPosition(playerID, 12);
                    break;
                case 22: //collect 50
                    MoneyLogic.CollectFromBank(playerID, 50);
                    break;
                case 23://Get out of Jail Free
                    Players[playerID].JailFreeCards++;
                    break;
                case 24://Go back three spaces
                    GameLogic.AdvancePlayer(playerID, -3);
                    break;
                case 25: //GoToJail
                    GameLogic.SendToJail(playerID);
                    break;
                case 26: //General repairs, see method
                    Repairs(playerID, 25, 100);
                    break;
                case 27: //Pay 15
                    MoneyLogic.CollectFromBank(playerID, 15);
                    break;
                case 28: //go to reading railroad
                    GameLogic.AdvancePlayerToPosition(playerID, 6);
                    break;
                case 29://Go to boardwalk
                    GameLogic.AdvancePlayerToPosition(playerID, 40);
                    break;
                case 30: //pay each player 50
                    MoneyLogic.CollectFromOtherPlayers(playerID, -50);
                    break;
                case 31://collect 150
                    MoneyLogic.CollectFromBank(playerID, 150);
                    break;
                case 32: //collect 100
                    MoneyLogic.CollectFromBank(playerID, 100);
                    break;
            }//switch
        }//HandleCard() TODO

        private void Repairs(int playerID, int perHouse, int perHotel)
        {
            //Player pays 40 per house and 115 per hotel
            int numHouses = 0;
            int numHotels = 0;
            int costToPlayer = 0;

            foreach (Tiles.BoardSpace b in Game.Board.BoardSpaces)
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
            MoneyLogic.ChangeMoney(playerID, costToPlayer);
        }//StreetRepairs

        public void AdvanceToUtility(int playerID)
        {
            int currentPos = Players[playerID].Position;
            int utilPos;

            if ((currentPos < 13) || (currentPos >= 29)) { utilPos = 13; }
            else { utilPos = 29; }//ifelse
            GameLogic.AdvanceToPosCustom(playerID, utilPos);
            GameLogic.LandBuyable(true);
            
        }//AdvanceToUtility()

        public void AdvanceToRailroad(int playerID)
        {
            int currentPos = Players[playerID].Position;
            int rrPos;
            
            //Railroad positions are at 6, 16, 26, 36
            if ((currentPos >= 36) || (currentPos < 6)) { rrPos = 6; }
            else if (currentPos < 16) { rrPos = 16; }
            else if (currentPos < 26) { rrPos = 26; }
            else { rrPos = 36; } 

            GameLogic.AdvanceToPosCustom(playerID, rrPos);
            GameLogic.LandBuyable(true);
        }//AdvanceToUtility()

    }//CardLogic

}
