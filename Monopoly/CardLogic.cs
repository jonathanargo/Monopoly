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
        private Game Game;

        public CardLogic(ref Game game)
        {
            this.Game = game;
            this.Players = game.Players;
        }//CardLogic

        //PROPERTIES
 

        //METHODS
        
        public void HandleCard(Card card, int playerID)
        {
            switch (card.CardID)
            {
                case 0://Advance to Go
                    Players[playerID].Position = 1;
                    break;
                case 1://Collect 75$
                    ChangeMoneyBank(playerID, 75);
                    break;
                case 2://Pay $50
                    ChangeMoneyBank(playerID, -50); //need to check for bankruptcy
                    break;
                case 3://Get out of jail free
                    Players[playerID].JailFreeCards++;
                    break;
                case 4://Go to jail
                    Players[playerID].IsJailed = true;
                    Players[playerID].Position = 11;
                    break;
                case 5: //collect 10 from each player
                    ChangeMoneyPlayers(playerID, 10);
                    break;
                case 6://colect $50 from each player
                    ChangeMoneyPlayers(playerID, 50);
                    break;
                case 7://collect $20
                    ChangeMoneyBank(playerID, 20);
                    break;
                case 8://collect 100
                    ChangeMoneyBank(playerID, 100);
                    break;
                case 9: //pay 100
                    ChangeMoneyBank(playerID, -100);
                    break;
                case 10://pay 50
                    ChangeMoneyBank(playerID, -50);
                    break;
                case 11://collect 25
                    ChangeMoneyBank(playerID, 25);
                    break;
                case 12://Street repairs, see method
                    Repairs(playerID, 40, 115);
                    break;
                case 13://collect 10
                    ChangeMoneyBank(playerID, 10);
                    break;
                case 14://collect 100
                    ChangeMoneyBank(playerID, 100);
                    break;
                case 15://collect 50
                    ChangeMoneyBank(playerID, 50);
                    break;
                case 16://Collect 100;
                    ChangeMoneyBank(playerID, 100);
                    break;
                case 17://Advance To Go
                    Game.AdvancePlayerToPosition(playerID, 1);
                    break;
                case 18: //Advance To Illinois
                    Game.AdvancePlayerToPosition(playerID, 25);
                    break;
                case 19://Advance To Utility (13 and 29), pay 10x dice roll
                    AdvanceToUtility(playerID);
                    break;
                case 20: //Advance to nearest railroad, pay double
                    AdvanceToRailroad(playerID);
                    break;
                case 21: //Advance To St Charles Place (12)
                    Game.AdvancePlayerToPosition(playerID, 12);
                    break;
                case 22: //collect 50
                    ChangeMoneyBank(playerID, 50);
                    break;
                case 23://Get out of Jail Free
                    Players[playerID].JailFreeCards++;
                    break;
                case 24://Go back three spaces
                    Game.AdvancePlayer(playerID, -3);
                    break;
                case 25: //GoToJail
                    Game.SendToJail(playerID);
                    break;
                case 26: //General repairs, see method
                    Repairs(playerID, 25, 100);
                    break;
                case 27: //Pay 15
                    ChangeMoneyBank(playerID, 15);
                    break;
                case 28: //go to reading railroad
                    Game.AdvancePlayerToPosition(playerID, 6);
                    break;
                case 29://Go to boardwalk
                    Game.AdvancePlayerToPosition(playerID, 40);
                    break;
                case 30: //pay each player 50
                    ChangeMoneyPlayers(playerID, -50);
                    break;
                case 31://collect 150
                    ChangeMoneyBank(playerID, 150);
                    break;
                case 32: //collect 100
                    ChangeMoneyBank(playerID, 100);
                    break;
            }//switch
        }//HandleCard()

        private void ChangeMoneyBank(int playerID, int amount)
        {
            Players[playerID].Money += amount;
        }//ChangeMoneyBank

        private void ChangeMoneyPlayers(int playerID, int amount)
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
                    if ((prop.Owner == Players[playerID].ID) && ((int)prop.ImprovementLevel > 0)) 
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
            ChangeMoneyBank(playerID, costToPlayer);
        }//StreetRepairs

        public void AdvanceToUtility(int playerID)
        {
            int currentPos = Players[playerID].Position;
            if ((currentPos < 13) || (currentPos >= 29))
            {
                Game.AdvancePlayerToPosition(playerID, 13);
            } else
            {
                Game.AdvancePlayerToPosition(playerID, 29);
            }//ifelse
        }//AdvanceToUtility()

        public void AdvanceToRailroad(int playerID)
        {
            //TODO
        }

    }//CardLogic
}
