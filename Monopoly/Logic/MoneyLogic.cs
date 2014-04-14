using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class MoneyLogic
    {
        private GameState mGame;
        public MoneyLogic(ref GameState game)
        {
            this.Game = game;
        }//GameLogic

        public GameState Game { get { return mGame; } private set { mGame = value; } }


        public void PayPlayer(int payerID, int recieverID, int amount)
        {
            ChangeMoney(payerID, -1 * amount);
            ChangeMoney(recieverID, amount);
        }//PayPlayer

        public void ChangeMoney(int playerID, int amount)
        {
            Game.Players[playerID].Money += amount;
            CheckForBankrupt(playerID);
        }//ChangeMoney()

        public void CheckForBankrupt(int playerID)
        {
            //check to see if player has < 0 money. If so, mortgage properties
        }//CheckForBankrupt() //TODO

        public void CollectFromBank(int playerID, int amount)
        {
            Game.Players[playerID].Money += amount;
        }//CollectFromBank

        public void CollectFromOtherPlayers(int playerID, int amount)
        //used for a few cards that have the player 
        //collecting money from all other players
        {
            foreach (Player p in Game.Players)
            {
                if (p.ID != Game.Players[playerID].ID)
                {
                    p.Money -= amount;
                    Game.Players[playerID].Money += amount;
                }//if

            }//foreach
        }//CollectFromPlayers
    }
}
